using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class ManageInventoryForm : Form
    {
        private int userId;
        private string userName;

        public ManageInventoryForm(int userId, string userName)
        {
            InitializeComponent();
            this.userId = userId;
            this.userName = userName;
        }

        private void ManageInventoryForm_Load(object sender, EventArgs e)
        {
            LoadMedicineInventory();
            LoadCategories();
            txtQuantity.Text = "0";
            txtReorderLevel.Text = "10";
            txtCostPrice.Text = "0.00";
            txtSellingPrice.Text = "0.00";
        }

        private void LoadMedicineInventory()
        {
            try
            {
                string query = @"
                    SELECT 
                        medicine_id AS 'ID',
                        medicine_name AS 'Medicine Name',
                        generic_name AS 'Generic Name',
                        brand_name AS 'Brand',
                        category AS 'Category',
                        CONCAT(strength, ' - ', dosage_form) AS 'Strength/Form',
                        quantity AS 'Stock',
                        unit AS 'Unit',
                        reorder_level AS 'Reorder Level',
                        selling_price AS 'Price',
                        expiry_date AS 'Expiry Date',
                        CASE WHEN is_controlled = 1 THEN 'Yes' ELSE 'No' END AS 'Controlled'
                    FROM MedicineInventory
                    ORDER BY medicine_name";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvInventory.DataSource = dt;

                if (dgvInventory.Columns.Count > 0)
                {
                    dgvInventory.Columns["ID"].Width = 50;
                    dgvInventory.Columns["Medicine Name"].Width = 150;
                    dgvInventory.Columns["Stock"].Width = 70;
                    dgvInventory.Columns["Unit"].Width = 60;
                    dgvInventory.Columns["Price"].Width = 80;
                }

                lblTotalItems.Text = $"Total Items: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(new string[] {
                "Analgesics", "Antibiotics", "Antivirals", "Antifungals",
                "Cardiovascular", "Diabetes", "Respiratory", "Gastrointestinal",
                "Vitamins & Supplements", "IV Solutions", "Topical",
                "Emergency", "Controlled Substance", "Other"
            });

            cmbDosageForm.Items.Clear();
            cmbDosageForm.Items.AddRange(new string[] {
                "Tablet", "Capsule", "Syrup", "Injection", "Cream",
                "Ointment", "Drops", "Spray", "Inhaler", "IV Solution", "Other"
            });

            cmbUnit.Items.Clear();
            cmbUnit.Items.AddRange(new string[] {
                "Tablet", "Capsule", "ml", "mg", "g", "Bottle", "Vial", "Piece", "Box"
            });
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMedicineName.Text))
                {
                    MessageBox.Show("Please enter medicine name!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbCategory.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a category!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = @"
                    INSERT INTO MedicineInventory 
                    (medicine_name, generic_name, brand_name, category, dosage_form, strength,
                     quantity, unit, reorder_level, cost_price, selling_price, supplier,
                     batch_number, expiry_date, is_controlled, requires_approval, storage_location, created_by)
                    VALUES 
                    (@medicineName, @genericName, @brandName, @category, @dosageForm, @strength,
                     @quantity, @unit, @reorderLevel, @costPrice, @sellingPrice, @supplier,
                     @batchNumber, @expiryDate, @isControlled, @requiresApproval, @storageLocation, @createdBy)";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@medicineName", txtMedicineName.Text.Trim()),
                    new MySqlParameter("@genericName", txtGenericName.Text.Trim()),
                    new MySqlParameter("@brandName", txtBrandName.Text.Trim()),
                    new MySqlParameter("@category", cmbCategory.SelectedItem.ToString()),
                    new MySqlParameter("@dosageForm", cmbDosageForm.SelectedItem?.ToString() ?? ""),
                    new MySqlParameter("@strength", txtStrength.Text.Trim()),
                    new MySqlParameter("@quantity", int.Parse(txtQuantity.Text)),
                    new MySqlParameter("@unit", cmbUnit.SelectedItem?.ToString() ?? "Piece"),
                    new MySqlParameter("@reorderLevel", int.Parse(txtReorderLevel.Text)),
                    new MySqlParameter("@costPrice", decimal.Parse(txtCostPrice.Text)),
                    new MySqlParameter("@sellingPrice", decimal.Parse(txtSellingPrice.Text)),
                    new MySqlParameter("@supplier", txtSupplier.Text.Trim()),
                    new MySqlParameter("@batchNumber", txtBatchNumber.Text.Trim()),
                    new MySqlParameter("@expiryDate", dtpExpiryDate.Value.Date),
                    new MySqlParameter("@isControlled", chkControlled.Checked ? 1 : 0),
                    new MySqlParameter("@requiresApproval", chkRequiresApproval.Checked ? 1 : 0),
                    new MySqlParameter("@storageLocation", txtStorageLocation.Text.Trim()),
                    new MySqlParameter("@createdBy", userId)
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Medicine added to inventory successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadMedicineInventory();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for quantity and prices!", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding medicine: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInventory.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a medicine to update!", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int medicineId = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["ID"].Value);

                string query = @"
                    UPDATE MedicineInventory SET
                        medicine_name = @medicineName,
                        generic_name = @genericName,
                        brand_name = @brandName,
                        category = @category,
                        dosage_form = @dosageForm,
                        strength = @strength,
                        quantity = @quantity,
                        unit = @unit,
                        reorder_level = @reorderLevel,
                        cost_price = @costPrice,
                        selling_price = @sellingPrice,
                        supplier = @supplier,
                        batch_number = @batchNumber,
                        expiry_date = @expiryDate,
                        is_controlled = @isControlled,
                        requires_approval = @requiresApproval,
                        storage_location = @storageLocation
                    WHERE medicine_id = @medicineId";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@medicineName", txtMedicineName.Text.Trim()),
                    new MySqlParameter("@genericName", txtGenericName.Text.Trim()),
                    new MySqlParameter("@brandName", txtBrandName.Text.Trim()),
                    new MySqlParameter("@category", cmbCategory.SelectedItem.ToString()),
                    new MySqlParameter("@dosageForm", cmbDosageForm.SelectedItem?.ToString() ?? ""),
                    new MySqlParameter("@strength", txtStrength.Text.Trim()),
                    new MySqlParameter("@quantity", int.Parse(txtQuantity.Text)),
                    new MySqlParameter("@unit", cmbUnit.SelectedItem?.ToString() ?? "Piece"),
                    new MySqlParameter("@reorderLevel", int.Parse(txtReorderLevel.Text)),
                    new MySqlParameter("@costPrice", decimal.Parse(txtCostPrice.Text)),
                    new MySqlParameter("@sellingPrice", decimal.Parse(txtSellingPrice.Text)),
                    new MySqlParameter("@supplier", txtSupplier.Text.Trim()),
                    new MySqlParameter("@batchNumber", txtBatchNumber.Text.Trim()),
                    new MySqlParameter("@expiryDate", dtpExpiryDate.Value.Date),
                    new MySqlParameter("@isControlled", chkControlled.Checked ? 1 : 0),
                    new MySqlParameter("@requiresApproval", chkRequiresApproval.Checked ? 1 : 0),
                    new MySqlParameter("@storageLocation", txtStorageLocation.Text.Trim()),
                    new MySqlParameter("@medicineId", medicineId)
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Medicine updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadMedicineInventory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating medicine: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInventory.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a medicine to delete!", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this medicine from inventory?\n\nWarning: This action cannot be undone!",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int medicineId = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["ID"].Value);

                    string query = "DELETE FROM MedicineInventory WHERE medicine_id = @medicineId";
                    MySqlParameter[] parameters = {
                        new MySqlParameter("@medicineId", medicineId)
                    };

                    int deleteResult = DatabaseHelper.ExecuteNonQuery(query, parameters);

                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Medicine deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadMedicineInventory();
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("foreign key constraint"))
                {
                    MessageBox.Show("Cannot delete this medicine as it has associated records (dispensing history, orders, etc.)!",
                        "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting medicine: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdjustStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInventory.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a medicine to adjust stock!", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int medicineId = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["ID"].Value);
                string medicineName = dgvInventory.SelectedRows[0].Cells["Medicine Name"].Value.ToString();
                int currentStock = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["Stock"].Value);

                StockAdjustmentForm adjustForm = new StockAdjustmentForm(medicineId, medicineName, currentStock, userId);
                if (adjustForm.ShowDialog() == DialogResult.OK)
                {
                    LoadMedicineInventory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    LoadMedicineInventory();
                    return;
                }

                string query = @"
                    SELECT 
                        medicine_id AS 'ID',
                        medicine_name AS 'Medicine Name',
                        generic_name AS 'Generic Name',
                        brand_name AS 'Brand',
                        category AS 'Category',
                        CONCAT(strength, ' - ', dosage_form) AS 'Strength/Form',
                        quantity AS 'Stock',
                        unit AS 'Unit',
                        reorder_level AS 'Reorder Level',
                        selling_price AS 'Price',
                        expiry_date AS 'Expiry Date',
                        CASE WHEN is_controlled = 1 THEN 'Yes' ELSE 'No' END AS 'Controlled'
                        FROM MedicineInventory
                        WHERE medicine_name LIKE @search
                       OR generic_name LIKE @search
                       OR brand_name LIKE @search
                       OR category LIKE @search
                    ORDER BY medicine_name";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@search", "%" + searchTerm + "%")
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvInventory.DataSource = dt;

                lblTotalItems.Text = $"Search Results: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                try
                {
                    int medicineId = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["ID"].Value);
                    LoadMedicineDetails(medicineId);
                }
                catch { }
            }
        }

        private void LoadMedicineDetails(int medicineId)
        {
            try
            {
                string query = "SELECT * FROM MedicineInventory WHERE medicine_id = @medicineId";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@medicineId", medicineId)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtMedicineName.Text = row["medicine_name"].ToString();
                    txtGenericName.Text = row["generic_name"].ToString();
                    txtBrandName.Text = row["brand_name"].ToString();
                    cmbCategory.SelectedItem = row["category"].ToString();
                    cmbDosageForm.SelectedItem = row["dosage_form"].ToString();
                    txtStrength.Text = row["strength"].ToString();
                    txtQuantity.Text = row["quantity"].ToString();
                    cmbUnit.SelectedItem = row["unit"].ToString();
                    txtReorderLevel.Text = row["reorder_level"].ToString();
                    txtCostPrice.Text = row["cost_price"].ToString();
                    txtSellingPrice.Text = row["selling_price"].ToString();
                    txtSupplier.Text = row["supplier"].ToString();
                    txtBatchNumber.Text = row["batch_number"].ToString();
                    dtpExpiryDate.Value = Convert.ToDateTime(row["expiry_date"]);
                    chkControlled.Checked = Convert.ToBoolean(row["is_controlled"]);
                    chkRequiresApproval.Checked = Convert.ToBoolean(row["requires_approval"]);
                    txtStorageLocation.Text = row["storage_location"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading medicine details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtMedicineName.Clear();
            txtGenericName.Clear();
            txtBrandName.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbDosageForm.SelectedIndex = -1;
            txtStrength.Clear();
            txtQuantity.Text = "0";
            cmbUnit.SelectedIndex = -1;
            txtReorderLevel.Text = "10";
            txtCostPrice.Text = "0.00";
            txtSellingPrice.Text = "0.00";
            txtSupplier.Clear();
            txtBatchNumber.Clear();
            dtpExpiryDate.Value = DateTime.Now.AddMonths(6);
            chkControlled.Checked = false;
            chkRequiresApproval.Checked = false;
            txtStorageLocation.Clear();
            txtSearch.Clear();
        }
    }
}