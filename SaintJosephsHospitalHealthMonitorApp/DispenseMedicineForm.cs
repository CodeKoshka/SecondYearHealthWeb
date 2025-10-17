using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class DispenseMedicineForm : Form
    {
        private int userId;
        private string userName;
        private int staffId;
        private int orderId;
        private DataRow orderData;

        public DispenseMedicineForm(int uId, string uName, int sId, int oId = 0)
        {
            orderId = oId;
            userId = uId;
            userName = uName;
            staffId = sId;
            InitializeComponent();
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            try
            {
                string query = @"
                    SELECT 
                        mo.*,
                        p_user.name AS patient_name,
                        p.patient_id,
                        d_user.name AS doctor_name
                    FROM MedicationOrders mo
                    INNER JOIN Patients p ON mo.patient_id = p.patient_id
                    INNER JOIN Users p_user ON p.user_id = p_user.user_id
                    INNER JOIN Doctors doc ON mo.doctor_id = doc.doctor_id
                    INNER JOIN Users d_user ON doc.user_id = d_user.user_id
                    WHERE mo.order_id = @orderId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@orderId", orderId));

                if (dt.Rows.Count > 0)
                {
                    orderData = dt.Rows[0];
                    DisplayOrderInfo();
                    SearchMedicineInInventory();
                }
                else
                {
                    MessageBox.Show("Order not found!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void DisplayOrderInfo()
        {
            lblOrderId.Text = $"Order ID: {orderData["order_id"]}";
            lblPatient.Text = $"Patient: {orderData["patient_name"]}";
            lblDoctor.Text = $"Doctor: {orderData["doctor_name"]}";
            lblMedicineName.Text = $"Medicine: {orderData["medicine_name"]}";
            lblDosage.Text = $"Dosage: {orderData["dosage"]}";
            lblQuantityOrdered.Text = $"Quantity Ordered: {orderData["quantity"]}";
            txtQuantityDispense.Text = orderData["quantity"].ToString();
        }

        private void SearchMedicineInInventory()
        {
            try
            {
                string medicineName = orderData["medicine_name"].ToString();

                string query = @"
                    SELECT 
                        medicine_id,
                        medicine_name,
                        generic_name,
                        brand_name,
                        quantity,
                        unit,
                        selling_price,
                        batch_number,
                        expiry_date,
                        is_controlled,
                        requires_approval
                    FROM MedicineInventory
                    WHERE medicine_name LIKE @search
                       OR generic_name LIKE @search
                       OR brand_name LIKE @search
                    ORDER BY 
                        CASE 
                            WHEN medicine_name = @exact THEN 1
                            WHEN generic_name = @exact THEN 2
                            ELSE 3
                        END,
                        expiry_date";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@search", "%" + medicineName + "%"),
                    new MySqlParameter("@exact", medicineName)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    cmbMedicineSelect.DisplayMember = "medicine_name";
                    cmbMedicineSelect.ValueMember = "medicine_id";
                    cmbMedicineSelect.DataSource = dt;
                    cmbMedicineSelect.SelectedIndex = 0;
                    UpdateSelectedMedicineInfo();
                }
                else
                {
                    lblStockStatus.Text = "Medicine not found in inventory!";
                    lblStockStatus.ForeColor = System.Drawing.Color.Red;
                    btnDispense.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching inventory: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbMedicineSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedMedicineInfo();
        }

        private void UpdateSelectedMedicineInfo()
        {
            if (cmbMedicineSelect.SelectedIndex == -1) return;

            try
            {
                DataRowView drv = (DataRowView)cmbMedicineSelect.SelectedItem;
                DataRow row = drv.Row;

                int availableStock = Convert.ToInt32(row["quantity"]);
                decimal price = Convert.ToDecimal(row["selling_price"]);
                bool isControlled = Convert.ToBoolean(row["is_controlled"]);
                bool requiresApproval = Convert.ToBoolean(row["requires_approval"]);

                lblAvailableStock.Text = $"Available: {availableStock} {row["unit"]}";
                lblPrice.Text = $"Price: ₱{price:N2} per {row["unit"]}";
                lblBatchNumber.Text = $"Batch: {row["batch_number"]}";
                lblExpiryDate.Text = $"Expiry: {Convert.ToDateTime(row["expiry_date"]):MM/dd/yyyy}";

                if (isControlled)
                {
                    lblControlled.Text = "⚠️ CONTROLLED SUBSTANCE";
                    lblControlled.ForeColor = System.Drawing.Color.Red;
                    lblControlled.Visible = true;
                }
                else
                {
                    lblControlled.Visible = false;
                }

                int quantityToDispense = int.Parse(txtQuantityDispense.Text);
                if (availableStock >= quantityToDispense)
                {
                    lblStockStatus.Text = "✓ Stock available";
                    lblStockStatus.ForeColor = System.Drawing.Color.Green;
                    btnDispense.Enabled = true;
                }
                else
                {
                    lblStockStatus.Text = $"✗ Insufficient stock (Need: {quantityToDispense}, Available: {availableStock})";
                    lblStockStatus.ForeColor = System.Drawing.Color.Red;
                    btnDispense.Enabled = false;
                }

                UpdateTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating medicine info: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtQuantityDispense_TextChanged(object sender, EventArgs e)
        {
            UpdateSelectedMedicineInfo();
        }

        private void UpdateTotalAmount()
        {
            try
            {
                if (cmbMedicineSelect.SelectedIndex == -1) return;

                DataRowView drv = (DataRowView)cmbMedicineSelect.SelectedItem;
                DataRow row = drv.Row;

                decimal price = Convert.ToDecimal(row["selling_price"]);
                int quantity = int.Parse(txtQuantityDispense.Text);
                decimal total = price * quantity;

                lblTotalAmount.Text = $"Total: ₱{total:N2}";
            }
            catch
            {
                lblTotalAmount.Text = "Total: ₱0.00";
            }
        }

        private void BtnDispense_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMedicineSelect.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a medicine from inventory!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtQuantityDispense.Text, out int quantityToDispense) || quantityToDispense <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRowView drv = (DataRowView)cmbMedicineSelect.SelectedItem;
                DataRow medicineRow = drv.Row;

                int medicineId = Convert.ToInt32(medicineRow["medicine_id"]);
                int availableStock = Convert.ToInt32(medicineRow["quantity"]);
                decimal unitPrice = Convert.ToDecimal(medicineRow["selling_price"]);
                decimal totalAmount = unitPrice * quantityToDispense;
                bool isControlled = Convert.ToBoolean(medicineRow["is_controlled"]);

                if (availableStock < quantityToDispense)
                {
                    MessageBox.Show("Insufficient stock!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    $"Dispense {quantityToDispense} units of {medicineRow["medicine_name"]}?\n\n" +
                    $"Total Amount: ₱{totalAmount:N2}\n" +
                    $"Patient: {orderData["patient_name"]}",
                    "Confirm Dispensing",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.No) return;

                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Update inventory
                            string updateInventory = @"
                                UPDATE MedicineInventory 
                                SET quantity = quantity - @quantity 
                                WHERE medicine_id = @medicineId";

                            using (MySqlCommand cmd = new MySqlCommand(updateInventory, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@quantity", quantityToDispense);
                                cmd.Parameters.AddWithValue("@medicineId", medicineId);
                                cmd.ExecuteNonQuery();
                            }

                            // Insert dispensing record
                            string insertDispensing = @"
                                INSERT INTO DispensingRecords 
                                (order_id, medicine_id, patient_id, quantity_dispensed, unit_price, 
                                 total_amount, batch_number, dispensed_by, patient_type, notes)
                                VALUES 
                                (@orderId, @medicineId, @patientId, @quantity, @unitPrice, 
                                 @totalAmount, @batchNumber, @dispensedBy, 'Outpatient', @notes)";

                            using (MySqlCommand cmd = new MySqlCommand(insertDispensing, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@orderId", orderId);
                                cmd.Parameters.AddWithValue("@medicineId", medicineId);
                                cmd.Parameters.AddWithValue("@patientId", orderData["patient_id"]);
                                cmd.Parameters.AddWithValue("@quantity", quantityToDispense);
                                cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
                                cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                                cmd.Parameters.AddWithValue("@batchNumber", medicineRow["batch_number"]);
                                cmd.Parameters.AddWithValue("@dispensedBy", userId);
                                cmd.Parameters.AddWithValue("@notes", txtNotes.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }

                            // Update medication order status
                            string updateOrder = @"
                                UPDATE MedicationOrders 
                                SET status = 'Dispensed', 
                                    dispensed_by = @dispensedBy, 
                                    dispensed_date = NOW(),
                                    completed_date = NOW()
                                WHERE order_id = @orderId";

                            using (MySqlCommand cmd = new MySqlCommand(updateOrder, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@dispensedBy", userId);
                                cmd.Parameters.AddWithValue("@orderId", orderId);
                                cmd.ExecuteNonQuery();
                            }

                            // Add to billing
                            string insertBilling = @"
                                INSERT INTO Billing 
                                (patient_id, amount, description, status, created_by)
                                VALUES 
                                (@patientId, @amount, @description, 'Pending', @createdBy)";

                            using (MySqlCommand cmd = new MySqlCommand(insertBilling, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@patientId", orderData["patient_id"]);
                                cmd.Parameters.AddWithValue("@amount", totalAmount);
                                cmd.Parameters.AddWithValue("@description",
                                    $"Medication: {medicineRow["medicine_name"]} ({quantityToDispense} units)");
                                cmd.Parameters.AddWithValue("@createdBy", userId);
                                cmd.ExecuteNonQuery();
                            }

                            // If controlled substance, log it
                            if (isControlled)
                            {
                                string insertLog = @"
                                    INSERT INTO ControlledSubstanceLog 
                                    (medicine_id, patient_id, quantity, action_type, 
                                     dispensed_by, reason, notes)
                                    VALUES 
                                    (@medicineId, @patientId, @quantity, 'Dispensed', 
                                     @dispensedBy, @reason, @notes)";

                                using (MySqlCommand cmd = new MySqlCommand(insertLog, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@medicineId", medicineId);
                                    cmd.Parameters.AddWithValue("@patientId", orderData["patient_id"]);
                                    cmd.Parameters.AddWithValue("@quantity", quantityToDispense);
                                    cmd.Parameters.AddWithValue("@dispensedBy", userId);
                                    cmd.Parameters.AddWithValue("@reason",
                                        $"Order #{orderId} - {orderData["medicine_name"]}");
                                    cmd.Parameters.AddWithValue("@notes", txtNotes.Text.Trim());
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            MessageBox.Show(
                                $"Medicine dispensed successfully!\n\n" +
                                $"Patient: {orderData["patient_name"]}\n" +
                                $"Medicine: {medicineRow["medicine_name"]}\n" +
                                $"Quantity: {quantityToDispense}\n" +
                                $"Amount: ₱{totalAmount:N2}\n\n" +
                                $"Billing record created.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            try { transaction.Rollback(); } catch { }
                            throw new Exception("Transaction failed: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error dispensing medicine: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}