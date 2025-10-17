using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class ManagePricingForm : Form
    {
        private int userId;
        private string userName;

        public ManagePricingForm(int uId, string uName)
        {
            userId = uId;
            userName = uName;
            InitializeComponent();
            LoadMedicines();
        }

        private void LoadMedicines()
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
                cost_price AS 'Cost Price',
                selling_price AS 'Selling Price',
                (selling_price - cost_price) AS 'Profit',
                ROUND(((selling_price - cost_price) / cost_price * 100), 2) AS 'Markup %',
                quantity AS 'Stock'
            FROM MedicineInventory
            ORDER BY medicine_name";

                DataTable result = DatabaseHelper.ExecuteQuery(query);

                if (result == null || result.Rows.Count == 0)
                {
                    dgvPricing.DataSource = new DataTable(); 
                    lblTotalItems.Text = "Total Items: 0";

                    if (result == null)
                    {
                        MessageBox.Show("Failed to load medicine data. Please check database connection.",
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return;
                }

                dgvPricing.DataSource = result;

                if (dgvPricing.Columns.Count > 0 && dgvPricing.Columns.Contains("ID"))
                {
                    dgvPricing.Columns["ID"].Width = 50;
                    dgvPricing.Columns["Medicine Name"].Width = 150;
                    dgvPricing.Columns["Cost Price"].DefaultCellStyle.Format = "₱#,##0.00";
                    dgvPricing.Columns["Selling Price"].DefaultCellStyle.Format = "₱#,##0.00";
                    dgvPricing.Columns["Profit"].DefaultCellStyle.Format = "₱#,##0.00";
                }

                lblTotalItems.Text = $"Total Items: {dgvPricing.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading medicines: {ex.Message}\n\nStack: {ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvPricing.DataSource = new DataTable(); 
                lblTotalItems.Text = "Total Items: 0";
            }
        }

        private void DgvPricing_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPricing.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvPricing.SelectedRows[0];

                    if (dgvPricing.Columns.Contains("Medicine Name") &&
                        dgvPricing.Columns.Contains("Cost Price") &&
                        dgvPricing.Columns.Contains("Selling Price"))
                    {
                        lblSelectedMedicine.Text = $"Selected: {row.Cells["Medicine Name"].Value}";
                        txtCostPrice.Text = row.Cells["Cost Price"].Value?.ToString() ?? "0";
                        txtSellingPrice.Text = row.Cells["Selling Price"].Value?.ToString() ?? "0";

                        CalculateMarkup();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Selection error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtCostPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateMarkup();
        }

        private void TxtSellingPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateMarkup();
        }

        private void TxtMarkupPercent_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMarkupPercent.Text) &&
                !string.IsNullOrWhiteSpace(txtCostPrice.Text))
            {
                try
                {
                    decimal costPrice = decimal.Parse(txtCostPrice.Text);
                    decimal markupPercent = decimal.Parse(txtMarkupPercent.Text);
                    decimal sellingPrice = costPrice + (costPrice * (markupPercent / 100));

                    txtSellingPrice.TextChanged -= TxtSellingPrice_TextChanged;
                    txtSellingPrice.Text = sellingPrice.ToString("0.00");
                    txtSellingPrice.TextChanged += TxtSellingPrice_TextChanged;

                    lblProfit.Text = $"Profit: ₱{(sellingPrice - costPrice):N2}";
                }
                catch { }
            }
        }

        private void CalculateMarkup()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCostPrice.Text) &&
                    !string.IsNullOrWhiteSpace(txtSellingPrice.Text))
                {
                    decimal costPrice = decimal.Parse(txtCostPrice.Text);
                    decimal sellingPrice = decimal.Parse(txtSellingPrice.Text);

                    if (costPrice > 0)
                    {
                        decimal markup = ((sellingPrice - costPrice) / costPrice) * 100;
                        decimal profit = sellingPrice - costPrice;

                        txtMarkupPercent.TextChanged -= TxtMarkupPercent_TextChanged;
                        txtMarkupPercent.Text = markup.ToString("0.00");
                        txtMarkupPercent.TextChanged += TxtMarkupPercent_TextChanged;

                        lblProfit.Text = $"Profit: ₱{profit:N2}";

                        if (markup < 0)
                        {
                            lblProfit.ForeColor = System.Drawing.Color.Red;
                            lblWarning.Text = "⚠ Warning: Selling price is less than cost!";
                            lblWarning.Visible = true;
                        }
                        else if (markup < 10)
                        {
                            lblProfit.ForeColor = System.Drawing.Color.Orange;
                            lblWarning.Text = "⚠ Low profit margin";
                            lblWarning.Visible = true;
                        }
                        else
                        {
                            lblProfit.ForeColor = System.Drawing.Color.Green;
                            lblWarning.Visible = false;
                        }
                    }
                }
            }
            catch { }
        }

        private void BtnUpdatePrice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPricing.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a medicine to update pricing!", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCostPrice.Text) ||
                    string.IsNullOrWhiteSpace(txtSellingPrice.Text))
                {
                    MessageBox.Show("Please enter both cost and selling prices!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal costPrice = decimal.Parse(txtCostPrice.Text);
                decimal sellingPrice = decimal.Parse(txtSellingPrice.Text);

                if (sellingPrice < costPrice)
                {
                    DialogResult confirm = MessageBox.Show(
                        "Selling price is LESS than cost price!\n\nThis will result in a loss. Continue?",
                        "Pricing Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirm == DialogResult.No) return;
                }

                int medicineId = Convert.ToInt32(dgvPricing.SelectedRows[0].Cells["ID"].Value);
                string medicineName = dgvPricing.SelectedRows[0].Cells["Medicine Name"].Value.ToString();

                DialogResult finalConfirm = MessageBox.Show(
                    $"Update pricing for {medicineName}?\n\n" +
                    $"Cost Price: ₱{costPrice:N2}\n" +
                    $"Selling Price: ₱{sellingPrice:N2}\n" +
                    $"Markup: {txtMarkupPercent.Text}%",
                    "Confirm Price Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (finalConfirm == DialogResult.Yes)
                {
                    string query = @"
                        UPDATE MedicineInventory 
                        SET cost_price = @costPrice, 
                            selling_price = @sellingPrice,
                            updated_date = NOW()
                        WHERE medicine_id = @medicineId";

                    DatabaseHelper.ExecuteNonQuery(query,
                        new MySqlParameter("@costPrice", costPrice),
                        new MySqlParameter("@sellingPrice", sellingPrice),
                        new MySqlParameter("@medicineId", medicineId));

                    MessageBox.Show("Pricing updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadMedicines();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for prices!", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating pricing: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBulkUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBulkMarkup.Text))
                {
                    MessageBox.Show("Please enter a markup percentage!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal markupPercent = decimal.Parse(txtBulkMarkup.Text);

                DialogResult confirm = MessageBox.Show(
                    $"Apply {markupPercent}% markup to ALL medicines?\n\n" +
                    "This will recalculate selling prices based on current cost prices.\n\n" +
                    "This action affects all items!",
                    "Bulk Price Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    string query = @"
                        UPDATE MedicineInventory 
                        SET selling_price = cost_price + (cost_price * (@markup / 100)),
                            updated_date = NOW()
                        WHERE cost_price > 0";

                    int rowsAffected = DatabaseHelper.ExecuteNonQuery(query,
                        new MySqlParameter("@markup", markupPercent));

                    MessageBox.Show(
                        $"Bulk pricing updated successfully!\n\n" +
                        $"{rowsAffected} item(s) updated with {markupPercent}% markup.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadMedicines();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid numeric value for markup percentage!", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in bulk update: {ex.Message}", "Error",
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
                    LoadMedicines();
                    return;
                }

                string query = @"
                    SELECT 
                        medicine_id AS 'ID',
                        medicine_name AS 'Medicine Name',
                        generic_name AS 'Generic Name',
                        brand_name AS 'Brand',
                        category AS 'Category',
                        cost_price AS 'Cost Price',
                        selling_price AS 'Selling Price',
                        (selling_price - cost_price) AS 'Profit',
                        ROUND(((selling_price - cost_price) / cost_price * 100), 2) AS 'Markup %',
                        quantity AS 'Stock'
                    FROM MedicineInventory
                    WHERE medicine_name LIKE @search
                       OR generic_name LIKE @search
                       OR brand_name LIKE @search
                       OR category LIKE @search
                    ORDER BY medicine_name";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@search", "%" + searchTerm + "%")
                };

                dgvPricing.DataSource = DatabaseHelper.ExecuteQuery(query, parameters);
                lblTotalItems.Text = $"Search Results: {dgvPricing.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportPricing_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV files (*.csv)|*.csv";
                saveDialog.FileName = $"PricingReport_{DateTime.Now:yyyyMMdd}.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(saveDialog.FileName))
                    {
                        
                        writer.WriteLine("Medicine Name,Generic Name,Brand,Category,Cost Price,Selling Price,Profit,Markup %");

                        
                        foreach (DataGridViewRow row in dgvPricing.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                writer.WriteLine(string.Join(",",
                                    row.Cells["Medicine Name"].Value,
                                    row.Cells["Generic Name"].Value,
                                    row.Cells["Brand"].Value,
                                    row.Cells["Category"].Value,
                                    row.Cells["Cost Price"].Value,
                                    row.Cells["Selling Price"].Value,
                                    row.Cells["Profit"].Value,
                                    row.Cells["Markup %"].Value));
                            }
                        }
                    }

                    MessageBox.Show("Pricing report exported successfully!", "Export Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}