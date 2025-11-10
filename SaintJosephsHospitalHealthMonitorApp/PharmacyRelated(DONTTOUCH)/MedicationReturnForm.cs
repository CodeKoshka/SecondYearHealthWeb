using MySqlConnector;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class MedicationReturnForm : Form
    {
        private int userId;
        private string userName;
        private int staffId;

        public MedicationReturnForm(int uId, string uName, int sId)
        {
            userId = uId;
            userName = uName;
            staffId = sId;
            InitializeComponent();
            LoadDispensingRecords();
            LoadReturnTypes();
        }

        private void LoadDispensingRecords()
        {
            try
            {
                
                string query = @"
                    SELECT 
                        dr.dispense_id AS 'Dispense ID',
                        u.name AS 'Patient',
                        mi.medicine_name AS 'Medicine',
                        dr.quantity_dispensed AS 'Quantity',
                        dr.dispensed_date AS 'Date',
                        DATEDIFF(CURDATE(), DATE(dr.dispensed_date)) AS 'Days Ago'
                    FROM DispensingRecords dr
                    INNER JOIN Patients p ON dr.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    INNER JOIN MedicineInventory mi ON dr.medicine_id = mi.medicine_id
                    WHERE dr.dispensed_date >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
                    ORDER BY dr.dispensed_date DESC";

                dgvDispensingRecords.DataSource = DatabaseHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading records: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReturnTypes()
        {
            cmbReturnType.Items.Clear();
            cmbReturnType.Items.AddRange(new string[] {
                "Full - Unused",
                "Partial - Unused Portion",
                "Wrong Medication",
                "Patient Deceased",
                "Adverse Reaction",
                "Doctor Changed Prescription",
                "Other"
            });
            cmbReturnType.SelectedIndex = 0;
        }

        private void DgvDispensingRecords_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDispensingRecords.SelectedRows.Count > 0)
            {
                try
                {
                    int dispenseId = Convert.ToInt32(dgvDispensingRecords.SelectedRows[0].Cells["Dispense ID"].Value);
                    LoadDispenseDetails(dispenseId);
                }
                catch { }
            }
        }

        private void LoadDispenseDetails(int dispenseId)
        {
            try
            {
                string query = @"
                    SELECT 
                        dr.*,
                        u.name AS patient_name,
                        mi.medicine_name,
                        mi.unit
                    FROM DispensingRecords dr
                    INNER JOIN Patients p ON dr.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    INNER JOIN MedicineInventory mi ON dr.medicine_id = mi.medicine_id
                    WHERE dr.dispense_id = @dispenseId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@dispenseId", dispenseId));

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblSelectedDispense.Text = $"Selected: {row["medicine_name"]} - {row["patient_name"]}";
                    lblQuantityDispensed.Text = $"Quantity Dispensed: {row["quantity_dispensed"]} {row["unit"]}";
                    lblUnitPrice.Text = $"Unit Price: ₱{row["unit_price"]}";
                    txtQuantityReturn.Maximum = Convert.ToInt32(row["quantity_dispensed"]);
                    txtQuantityReturn.Value = Convert.ToInt32(row["quantity_dispensed"]);
                    CalculateRefund();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtQuantityReturn_ValueChanged(object sender, EventArgs e)
        {
            CalculateRefund();
        }

        private void ChkReturnToStock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReturnToStock.Checked)
            {
                lblReturnWarning.Text = "Medicine will be returned to inventory";
                lblReturnWarning.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblReturnWarning.Text = "Medicine will NOT be returned to inventory (disposed)";
                lblReturnWarning.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void CalculateRefund()
        {
            try
            {
                if (dgvDispensingRecords.SelectedRows.Count == 0) return;

                int dispenseId = Convert.ToInt32(dgvDispensingRecords.SelectedRows[0].Cells["Dispense ID"].Value);

                string query = "SELECT unit_price FROM DispensingRecords WHERE dispense_id = @dispenseId";
                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@dispenseId", dispenseId));

                if (result != null)
                {
                    decimal unitPrice = Convert.ToDecimal(result);
                    int quantityReturn = (int)txtQuantityReturn.Value;
                    decimal refundAmount = unitPrice * quantityReturn;
                    lblRefundAmount.Text = $"Refund Amount: ₱{refundAmount:N2}";
                }
            }
            catch { }
        }

        private void BtnProcessReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDispensingRecords.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a dispensing record!", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtReturnReason.Text))
                {
                    MessageBox.Show("Please enter a reason for return!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int dispenseId = Convert.ToInt32(dgvDispensingRecords.SelectedRows[0].Cells["Dispense ID"].Value);

                
                string getDetails = @"
                    SELECT dr.*, mi.unit_price 
                    FROM DispensingRecords dr
                    INNER JOIN MedicineInventory mi ON dr.medicine_id = mi.medicine_id
                    WHERE dr.dispense_id = @dispenseId";

                DataTable dt = DatabaseHelper.ExecuteQuery(getDetails,
                    new MySqlParameter("@dispenseId", dispenseId));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Dispense record not found!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow dispenseRow = dt.Rows[0];
                int quantityReturn = (int)txtQuantityReturn.Value;
                decimal unitPrice = Convert.ToDecimal(dispenseRow["unit_price"]);
                decimal refundAmount = unitPrice * quantityReturn;

                DialogResult confirm = MessageBox.Show(
                    $"Process return of {quantityReturn} units?\n\n" +
                    $"Refund Amount: ₱{refundAmount:N2}\n" +
                    $"Return to Stock: {(chkReturnToStock.Checked ? "Yes" : "No")}",
                    "Confirm Return",
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
                            
                            string insertReturn = @"
                                INSERT INTO MedicationReturns 
                                (dispense_id, order_id, medicine_id, patient_id, quantity_returned,
                                 return_reason, return_type, refund_amount, returned_to_stock,
                                 processed_by, status, notes)
                                VALUES 
                                (@dispenseId, @orderId, @medicineId, @patientId, @quantityReturned,
                                 @returnReason, @returnType, @refundAmount, @returnedToStock,
                                 @processedBy, 'Pending', @notes)";

                            using (MySqlCommand cmd = new MySqlCommand(insertReturn, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@dispenseId", dispenseId);
                                cmd.Parameters.AddWithValue("@orderId", dispenseRow["order_id"]);
                                cmd.Parameters.AddWithValue("@medicineId", dispenseRow["medicine_id"]);
                                cmd.Parameters.AddWithValue("@patientId", dispenseRow["patient_id"]);
                                cmd.Parameters.AddWithValue("@quantityReturned", quantityReturn);
                                cmd.Parameters.AddWithValue("@returnReason", txtReturnReason.Text.Trim());
                                cmd.Parameters.AddWithValue("@returnType", cmbReturnType.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@refundAmount", refundAmount);
                                cmd.Parameters.AddWithValue("@returnedToStock", chkReturnToStock.Checked ? 1 : 0);
                                cmd.Parameters.AddWithValue("@processedBy", userId);
                                cmd.Parameters.AddWithValue("@notes", txtNotes.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }

                            
                            if (chkReturnToStock.Checked)
                            {
                                string updateInventory = @"
                                    UPDATE MedicineInventory 
                                    SET quantity = quantity + @quantity 
                                    WHERE medicine_id = @medicineId";

                                using (MySqlCommand cmd = new MySqlCommand(updateInventory, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@quantity", quantityReturn);
                                    cmd.Parameters.AddWithValue("@medicineId", dispenseRow["medicine_id"]);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            MessageBox.Show(
                                $"Return processed successfully!\n\n" +
                                $"Quantity Returned: {quantityReturn}\n" +
                                $"Refund Amount: ₱{refundAmount:N2}\n" +
                                $"Status: Pending Approval",
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
                MessageBox.Show($"Error processing return: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    LoadDispensingRecords();
                    return;
                }

                string query = @"
                    SELECT 
                        dr.dispense_id AS 'Dispense ID',
                        u.name AS 'Patient',
                        mi.medicine_name AS 'Medicine',
                        dr.quantity_dispensed AS 'Quantity',
                        dr.dispensed_date AS 'Date',
                        DATEDIFF(CURDATE(), DATE(dr.dispensed_date)) AS 'Days Ago'
                    FROM DispensingRecords dr
                    INNER JOIN Patients p ON dr.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    INNER JOIN MedicineInventory mi ON dr.medicine_id = mi.medicine_id
                    WHERE dr.dispensed_date >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
                      AND (u.name LIKE @search OR mi.medicine_name LIKE @search)
                    ORDER BY dr.dispensed_date DESC";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@search", "%" + searchTerm + "%")
                };

                dgvDispensingRecords.DataSource = DatabaseHelper.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}