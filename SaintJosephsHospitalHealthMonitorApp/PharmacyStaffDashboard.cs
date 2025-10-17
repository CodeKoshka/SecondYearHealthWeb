using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class PharmacyStaffDashboard : Form
    {
        private int userId;
        private string userName;
        private int staffId;

        public PharmacyStaffDashboard(User user)
        {
            InitializeComponent();
            this.userId = user.UserId;
            this.userName = user.Name;
            LoadStaffId();
        }

        private void LoadStaffId()
        {
            try
            {
                string query = "SELECT staff_id FROM Staff WHERE user_id = @userId";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@userId", userId)
                };
                object result = DatabaseHelper.ExecuteScalar(query, parameters);
                if (result != null)
                {
                    staffId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading staff ID: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PharmacyStaffForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {userName}";
            LoadDashboardStats();
            LoadPendingOrders();
            LoadLowStockMedicines();
        }

        private void LoadDashboardStats()
        {
            try
            {
                
                string queryTotal = "SELECT COUNT(*) FROM MedicineInventory";
                object totalResult = DatabaseHelper.ExecuteScalar(queryTotal);
                lblTotalMedicines.Text = totalResult != null ? totalResult.ToString() : "0";

                
                string queryPending = "SELECT COUNT(*) FROM MedicationOrders WHERE status = 'Pending'";
                object pendingResult = DatabaseHelper.ExecuteScalar(queryPending);
                lblPendingOrders.Text = pendingResult != null ? pendingResult.ToString() : "0";

                
                string queryLowStock = "SELECT COUNT(*) FROM MedicineInventory WHERE quantity <= reorder_level";
                object lowStockResult = DatabaseHelper.ExecuteScalar(queryLowStock);
                lblLowStock.Text = lowStockResult != null ? lowStockResult.ToString() : "0";

                
                string queryExpired = "SELECT COUNT(*) FROM MedicineInventory WHERE expiry_date < CURDATE()";
                object expiredResult = DatabaseHelper.ExecuteScalar(queryExpired);
                lblExpiredMeds.Text = expiredResult != null ? expiredResult.ToString() : "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard stats: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPendingOrders()
        {
            try
            {
                string query = @"
                    SELECT 
                        mo.order_id AS 'Order ID',
                        CONCAT(u.name) AS 'Patient Name',
                        mo.medicine_name AS 'Medicine',
                        mo.dosage AS 'Dosage',
                        mo.quantity AS 'Quantity',
                        mo.frequency AS 'Frequency',
                        mo.priority AS 'Priority',
                        mo.status AS 'Status',
                        mo.order_date AS 'Order Date'
                    FROM MedicationOrders mo
                    INNER JOIN Patients p ON mo.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE mo.status IN ('Pending', 'Validated')
                    ORDER BY 
                        CASE mo.priority
                            WHEN 'Emergency' THEN 1
                            WHEN 'Urgent' THEN 2
                            WHEN 'Normal' THEN 3
                        END,
                        mo.order_date";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvPendingOrders.DataSource = dt;

                if (dgvPendingOrders.Columns.Count > 0)
                {
                    dgvPendingOrders.Columns["Order ID"].Width = 80;
                    dgvPendingOrders.Columns["Patient Name"].Width = 150;
                    dgvPendingOrders.Columns["Medicine"].Width = 150;
                    dgvPendingOrders.Columns["Priority"].Width = 80;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pending orders: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLowStockMedicines()
        {
            try
            {
                string query = @"
                    SELECT 
                        medicine_name AS 'Medicine Name',
                        quantity AS 'Current Stock',
                        reorder_level AS 'Reorder Level',
                        unit AS 'Unit',
                        expiry_date AS 'Expiry Date'
                    FROM MedicineInventory
                    WHERE quantity <= reorder_level
                    ORDER BY quantity ASC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvLowStock.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading low stock medicines: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnManageInventory_Click(object sender, EventArgs e)
        {
            ManageInventoryForm form = new ManageInventoryForm(userId, userName);
            form.ShowDialog();
            LoadDashboardStats();
            LoadLowStockMedicines();
        }

        private void BtnProcessOrders_Click(object sender, EventArgs e)
        {
            ProcessOrdersForm form = new ProcessOrdersForm(userId, userName, staffId);
            form.ShowDialog();
            LoadDashboardStats();
            LoadPendingOrders();
        }

        private void BtnDispenseMedicine_Click(object sender, EventArgs e)
        {
            if (dgvPendingOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to dispense from the pending orders list.",
                    "No Order Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgvPendingOrders.SelectedRows[0].Cells["Order ID"].Value);
            DispenseMedicineForm form = new DispenseMedicineForm(userId, userName, staffId, orderId);
            form.ShowDialog();
            LoadDashboardStats();
        }

        private void BtnManagePricing_Click(object sender, EventArgs e)
        {
            ManagePricingForm form = new ManagePricingForm(userId, userName);
            form.ShowDialog();
        }

        private void BtnReturnMedication_Click(object sender, EventArgs e)
        {
            MedicationReturnForm form = new MedicationReturnForm(userId, userName, staffId);
            form.ShowDialog();
            LoadDashboardStats();
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            PharmacyReportsForm form = new PharmacyReportsForm(userId, userName);
            form.ShowDialog();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardStats();
            LoadPendingOrders();
            LoadLowStockMedicines();
            MessageBox.Show("Dashboard refreshed successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void DgvPendingOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int orderId = Convert.ToInt32(dgvPendingOrders.Rows[e.RowIndex].Cells["Order ID"].Value);
                ProcessOrdersForm form = new ProcessOrdersForm(userId, userName, staffId, orderId);
                form.ShowDialog();
                LoadPendingOrders();
                LoadDashboardStats();
            }
        }
    }
}