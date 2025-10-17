using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class PharmacyReportsForm : Form
    {
        private int userId;
        private string userName;

        public PharmacyReportsForm(int userId, string userName)
        {
            InitializeComponent();
            this.userId = userId;
            this.userName = userName;
        }

        private void PharmacyReportsForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Pharmacy Reports - {userName}";
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            cmbReportType.SelectedIndex = 0;
        }

        private void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbReportType.SelectedIndex >= 0)
            {
                string reportType = cmbReportType.SelectedItem.ToString();
                bool enableDates = reportType.Contains("Sales") || reportType.Contains("Dispensing") || reportType.Contains("Orders");
                dtpStartDate.Enabled = enableDates;
                dtpEndDate.Enabled = enableDates;
            }
        }

        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbReportType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a report type!", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string reportType = cmbReportType.SelectedItem.ToString();
                DataTable reportData = null;

                switch (reportType)
                {
                    case "Sales Summary":
                        reportData = GenerateSalesSummary();
                        break;
                    case "Inventory Status":
                        reportData = GenerateInventoryStatus();
                        break;
                    case "Low Stock Items":
                        reportData = GenerateLowStockReport();
                        break;
                    case "Expired Medicines":
                        reportData = GenerateExpiredMedicines();
                        break;
                    case "Dispensing History":
                        reportData = GenerateDispensingHistory();
                        break;
                    case "Medication Orders":
                        reportData = GenerateMedicationOrders();
                        break;
                    case "Controlled Substances Log":
                        reportData = GenerateControlledSubstancesLog();
                        break;
                    case "Returns Summary":
                        reportData = GenerateReturnsSummary();
                        break;
                }

                if (reportData != null && reportData.Rows.Count > 0)
                {
                    dgvReport.DataSource = reportData;
                    lblRecordCount.Text = $"Total Records: {reportData.Rows.Count}";
                    MessageBox.Show("Report generated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvReport.DataSource = null;
                    lblRecordCount.Text = "Total Records: 0";
                    MessageBox.Show("No data found for the selected criteria.", "No Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GenerateSalesSummary()
        {
            string query = @"
                SELECT 
                    DATE(dr.dispensed_date) AS 'Date',
                    COUNT(DISTINCT dr.dispense_id) AS 'Transactions',
                    SUM(dr.quantity_dispensed) AS 'Items Sold',
                    SUM(dr.total_amount) AS 'Total Sales'
                FROM DispensingRecords dr
                WHERE dr.dispensed_date BETWEEN @startDate AND @endDate
                GROUP BY DATE(dr.dispensed_date)
                ORDER BY DATE(dr.dispensed_date) DESC";

            MySqlParameter[] parameters = {
                new MySqlParameter("@startDate", dtpStartDate.Value.Date),
                new MySqlParameter("@endDate", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1))
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        private DataTable GenerateInventoryStatus()
        {
            string query = @"
                SELECT 
                    medicine_name AS 'Medicine Name',
                    category AS 'Category',
                    quantity AS 'Current Stock',
                    unit AS 'Unit',
                    reorder_level AS 'Reorder Level',
                    selling_price AS 'Price',
                    expiry_date AS 'Expiry Date',
                    CASE 
                        WHEN quantity = 0 THEN 'Out of Stock'
                        WHEN quantity <= reorder_level THEN 'Low Stock'
                        ELSE 'In Stock'
                    END AS 'Status'
                FROM MedicineInventory
                ORDER BY 
                    CASE 
                        WHEN quantity = 0 THEN 1
                        WHEN quantity <= reorder_level THEN 2
                        ELSE 3
                    END,
                    medicine_name";

            return DatabaseHelper.ExecuteQuery(query);
        }

        private DataTable GenerateLowStockReport()
        {
            string query = @"
                SELECT 
                    medicine_name AS 'Medicine Name',
                    generic_name AS 'Generic Name',
                    category AS 'Category',
                    quantity AS 'Current Stock',
                    reorder_level AS 'Reorder Level',
                    unit AS 'Unit',
                    (reorder_level - quantity) AS 'Shortage',
                    supplier AS 'Supplier'
                FROM MedicineInventory
                WHERE quantity <= reorder_level
                ORDER BY quantity ASC";

            return DatabaseHelper.ExecuteQuery(query);
        }

        private DataTable GenerateExpiredMedicines()
        {
            string query = @"
                SELECT 
                    medicine_name AS 'Medicine Name',
                    batch_number AS 'Batch Number',
                    quantity AS 'Quantity',
                    unit AS 'Unit',
                    expiry_date AS 'Expiry Date',
                    DATEDIFF(CURDATE(), expiry_date) AS 'Days Expired',
                    (quantity * cost_price) AS 'Estimated Loss'
                FROM MedicineInventory
                WHERE expiry_date < CURDATE()
                ORDER BY expiry_date DESC";

            return DatabaseHelper.ExecuteQuery(query);
        }

        private DataTable GenerateDispensingHistory()
        {
            string query = @"
                SELECT 
                    dr.dispense_id AS 'Dispense ID',
                    DATE(dr.dispensed_date) AS 'Date',
                    u.name AS 'Patient',
                    mi.medicine_name AS 'Medicine',
                    dr.quantity_dispensed AS 'Quantity',
                    dr.unit_price AS 'Unit Price',
                    dr.total_amount AS 'Total',
                    us.name AS 'Dispensed By'
                FROM DispensingRecords dr
                INNER JOIN Patients p ON dr.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                INNER JOIN MedicineInventory mi ON dr.medicine_id = mi.medicine_id
                INNER JOIN Users us ON dr.dispensed_by = us.user_id
                WHERE dr.dispensed_date BETWEEN @startDate AND @endDate
                ORDER BY dr.dispensed_date DESC";

            MySqlParameter[] parameters = {
                new MySqlParameter("@startDate", dtpStartDate.Value.Date),
                new MySqlParameter("@endDate", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1))
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        private DataTable GenerateMedicationOrders()
        {
            string query = @"
                SELECT 
                    mo.order_id AS 'Order ID',
                    DATE(mo.order_date) AS 'Order Date',
                    u.name AS 'Patient',
                    d.name AS 'Doctor',
                    mo.medicine_name AS 'Medicine',
                    mo.quantity AS 'Quantity',
                    mo.priority AS 'Priority',
                    mo.status AS 'Status',
                    IFNULL(us.name, 'N/A') AS 'Dispensed By'
                FROM MedicationOrders mo
                INNER JOIN Patients p ON mo.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                INNER JOIN Doctors doc ON mo.doctor_id = doc.doctor_id
                INNER JOIN Users d ON doc.user_id = d.user_id
                LEFT JOIN Users us ON mo.dispensed_by = us.user_id
                WHERE mo.order_date BETWEEN @startDate AND @endDate
                ORDER BY mo.order_date DESC";

            MySqlParameter[] parameters = {
                new MySqlParameter("@startDate", dtpStartDate.Value.Date),
                new MySqlParameter("@endDate", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1))
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        private DataTable GenerateControlledSubstancesLog()
        {
            string query = @"
                SELECT 
                    csl.log_id AS 'Log ID',
                    DATE(csl.log_date) AS 'Date',
                    mi.medicine_name AS 'Medicine',
                    u.name AS 'Patient',
                    csl.quantity AS 'Quantity',
                    csl.action_type AS 'Action',
                    us.name AS 'Dispensed By',
                    IFNULL(ua.name, 'N/A') AS 'Approved By'
                FROM ControlledSubstanceLog csl
                INNER JOIN MedicineInventory mi ON csl.medicine_id = mi.medicine_id
                INNER JOIN Patients p ON csl.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                INNER JOIN Users us ON csl.dispensed_by = us.user_id
                LEFT JOIN Users ua ON csl.approved_by = ua.user_id
                ORDER BY csl.log_date DESC";

            return DatabaseHelper.ExecuteQuery(query);
        }

        private DataTable GenerateReturnsSummary()
        {
            string query = @"
                SELECT 
                    mr.return_id AS 'Return ID',
                    DATE(mr.return_date) AS 'Return Date',
                    u.name AS 'Patient',
                    mi.medicine_name AS 'Medicine',
                    mr.quantity_returned AS 'Quantity',
                    mr.return_reason AS 'Reason',
                    mr.refund_amount AS 'Refund Amount',
                    mr.status AS 'Status',
                    us.name AS 'Processed By'
                FROM MedicationReturns mr
                INNER JOIN Patients p ON mr.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                INNER JOIN MedicineInventory mi ON mr.medicine_id = mi.medicine_id
                INNER JOIN Users us ON mr.processed_by = us.user_id
                WHERE mr.return_date BETWEEN @startDate AND @endDate
                ORDER BY mr.return_date DESC";

            MySqlParameter[] parameters = {
                new MySqlParameter("@startDate", dtpStartDate.Value.Date),
                new MySqlParameter("@endDate", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1))
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReport.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export! Please generate a report first.", "No Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV File|*.csv";
                saveDialog.Title = "Export Report";
                saveDialog.FileName = $"PharmacyReport_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    
                    for (int i = 0; i < dgvReport.Columns.Count; i++)
                    {
                        sb.Append(dgvReport.Columns[i].HeaderText);
                        if (i < dgvReport.Columns.Count - 1)
                            sb.Append(",");
                    }
                    sb.AppendLine();

                    
                    foreach (DataGridViewRow row in dgvReport.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dgvReport.Columns.Count; i++)
                            {
                                sb.Append(row.Cells[i].Value?.ToString() ?? "");
                                if (i < dgvReport.Columns.Count - 1)
                                    sb.Append(",");
                            }
                            sb.AppendLine();
                        }
                    }

                    System.IO.File.WriteAllText(saveDialog.FileName, sb.ToString());
                    MessageBox.Show("Report exported successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReport.Rows.Count == 0)
                {
                    MessageBox.Show("No data to print! Please generate a report first.", "No Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Print functionality will be implemented in future updates.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}