using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class StockAdjustmentForm : Form
    {
        private int medicineId;
        private string medicineName;
        private int currentStock;
        private int userId;

        public StockAdjustmentForm(int medId, string medName, int currentQty, int uId)
        {
            medicineId = medId;
            medicineName = medName;
            currentStock = currentQty;
            userId = uId;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            lblMedicineName.Text = $"Medicine: {medicineName}";
            lblCurrentStock.Text = $"Current Stock: {currentStock}";

            // Load adjustment types
            cmbAdjustmentType.Items.Clear();
            cmbAdjustmentType.Items.AddRange(new string[] {
                "Stock In - Purchase",
                "Stock In - Return",
                "Stock Out - Damaged",
                "Stock Out - Expired",
                "Stock Out - Lost",
                "Stock Out - Transfer",
                "Correction - Count Error",
                "Other"
            });
            cmbAdjustmentType.SelectedIndex = 0;

            txtQuantityChange.Text = "0";
            UpdateNewStock();
        }

        private void TxtQuantityChange_TextChanged(object sender, EventArgs e)
        {
            UpdateNewStock();
        }

        private void CmbAdjustmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNewStock();
        }

        private void UpdateNewStock()
        {
            try
            {
                if (int.TryParse(txtQuantityChange.Text, out int change))
                {
                    string adjustmentType = cmbAdjustmentType.SelectedItem?.ToString() ?? "";
                    int newStock = currentStock;

                    if (adjustmentType.StartsWith("Stock In"))
                    {
                        newStock = currentStock + Math.Abs(change);
                    }
                    else if (adjustmentType.StartsWith("Stock Out"))
                    {
                        newStock = currentStock - Math.Abs(change);
                    }
                    else if (adjustmentType.StartsWith("Correction"))
                    {
                        newStock = currentStock + change; // Can be positive or negative
                    }

                    lblNewStock.Text = $"New Stock: {newStock}";

                    if (newStock < 0)
                    {
                        lblNewStock.ForeColor = System.Drawing.Color.Red;
                        lblWarning.Text = "Warning: Stock cannot be negative!";
                        lblWarning.Visible = true;
                    }
                    else
                    {
                        lblNewStock.ForeColor = System.Drawing.Color.Green;
                        lblWarning.Visible = false;
                    }
                }
            }
            catch
            {
                lblNewStock.Text = "New Stock: Error";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtQuantityChange.Text))
                {
                    MessageBox.Show("Please enter quantity change!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtReason.Text))
                {
                    MessageBox.Show("Please enter reason for adjustment!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int quantityChange = int.Parse(txtQuantityChange.Text);
                string adjustmentType = cmbAdjustmentType.SelectedItem.ToString();

                // Calculate actual change based on type
                int actualChange = 0;
                if (adjustmentType.StartsWith("Stock In"))
                {
                    actualChange = Math.Abs(quantityChange);
                }
                else if (adjustmentType.StartsWith("Stock Out"))
                {
                    actualChange = -Math.Abs(quantityChange);
                }
                else if (adjustmentType.StartsWith("Correction"))
                {
                    actualChange = quantityChange;
                }

                int newQuantity = currentStock + actualChange;

                if (newQuantity < 0)
                {
                    MessageBox.Show("Adjustment would result in negative stock!", "Invalid Adjustment",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (MySqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Update medicine inventory
                            string updateQuery = @"
                                UPDATE MedicineInventory 
                                SET quantity = @newQuantity 
                                WHERE medicine_id = @medicineId";

                            using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                                cmd.Parameters.AddWithValue("@medicineId", medicineId);
                                cmd.ExecuteNonQuery();
                            }

                            // Insert adjustment record
                            string insertQuery = @"
                                INSERT INTO StockAdjustment 
                                (medicine_id, adjustment_type, quantity_change, previous_quantity, 
                                 new_quantity, reason, batch_number, adjusted_by, notes)
                                VALUES 
                                (@medicineId, @adjustmentType, @quantityChange, @previousQuantity, 
                                 @newQuantity, @reason, @batchNumber, @adjustedBy, @notes)";

                            using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@medicineId", medicineId);
                                cmd.Parameters.AddWithValue("@adjustmentType", adjustmentType);
                                cmd.Parameters.AddWithValue("@quantityChange", actualChange);
                                cmd.Parameters.AddWithValue("@previousQuantity", currentStock);
                                cmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                                cmd.Parameters.AddWithValue("@reason", txtReason.Text.Trim());
                                cmd.Parameters.AddWithValue("@batchNumber", txtBatchNumber.Text.Trim());
                                cmd.Parameters.AddWithValue("@adjustedBy", userId);
                                cmd.Parameters.AddWithValue("@notes", txtNotes.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            MessageBox.Show("Stock adjusted successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for quantity!", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adjusting stock: {ex.Message}", "Error",
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