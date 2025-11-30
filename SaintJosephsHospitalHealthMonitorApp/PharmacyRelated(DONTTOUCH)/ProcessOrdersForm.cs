using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class ProcessOrdersForm : Form
    {
        private int userId;
        private string userName;
        private int staffId;
        private int? selectedOrderId;

        public ProcessOrdersForm(int uId, string uName, int sId, int orderId = 0)
        {
            userId = uId;
            userName = uName;
            staffId = sId;
            selectedOrderId = orderId > 0 ? orderId : null;
            InitializeComponent();
            LoadOrders();
            LoadOrderStatusFilter();
            if (selectedOrderId.HasValue)
            {
                SelectOrderInGrid(selectedOrderId.Value);
            }
        }

        private void SelectOrderInGrid(int orderId)
        {
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.Cells["Order ID"].Value != null)
                {
                    if (Convert.ToInt32(row.Cells["Order ID"].Value) == orderId)
                    {
                        dgvOrders.ClearSelection();
                        row.Selected = true;
                        dgvOrders.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }
        }

        private void LoadOrderStatusFilter()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.AddRange(new string[] {
                "All Orders",
                "Pending",
                "Validated",
                "Dispensed",
                "Completed",
                "Cancelled"
            });
            cmbStatusFilter.SelectedIndex = 0;
        }

        private void LoadOrders()
        {
            try
            {
                string statusFilter = cmbStatusFilter.SelectedItem?.ToString() ?? "All Orders";
                string whereClause = statusFilter == "All Orders" ? "" : "WHERE mo.status = @status";

                string query = $@"
                    SELECT 
                        mo.order_id AS 'Order ID',
                        u_patient.name AS 'Patient',
                        u_doctor.name AS 'Doctor',
                        mo.medicine_name AS 'Medicine',
                        mo.dosage AS 'Dosage',
                        mo.frequency AS 'Frequency',
                        mo.quantity AS 'Qty',
                        mo.priority AS 'Priority',
                        mo.status AS 'Status',
                        mo.order_date AS 'Order Date',
                        IFNULL(u_validated.name, '-') AS 'Validated By',
                        IFNULL(u_dispensed.name, '-') AS 'Dispensed By'
                    FROM MedicationOrders mo
                    INNER JOIN Patients p ON mo.patient_id = p.patient_id
                    INNER JOIN Users u_patient ON p.user_id = u_patient.user_id
                    INNER JOIN Doctors d ON mo.doctor_id = d.doctor_id
                    INNER JOIN Users u_doctor ON d.user_id = u_doctor.user_id
                    LEFT JOIN Users u_validated ON mo.validated_by = u_validated.user_id
                    LEFT JOIN Users u_dispensed ON mo.dispensed_by = u_dispensed.user_id
                    {whereClause}
                    ORDER BY 
                        CASE mo.priority 
                            WHEN 'Emergency' THEN 1 
                            WHEN 'Urgent' THEN 2 
                            ELSE 3 
                        END,
                        mo.order_date DESC";

                if (statusFilter != "All Orders")
                {
                    dgvOrders.DataSource = DatabaseHelper.ExecuteQuery(query,
                        new MySqlParameter("@status", statusFilter));
                }
                else
                {
                    dgvOrders.DataSource = DatabaseHelper.ExecuteQuery(query);
                }

                lblTotalOrders.Text = $"Total Orders: {dgvOrders.Rows.Count}";

                // Color code by priority
                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (row.Cells["Priority"].Value != null)
                    {
                        string priority = row.Cells["Priority"].Value.ToString();
                        if (priority == "Emergency")
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                        else if (priority == "Urgent")
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 200);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to view.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Order ID"].Value);
                ViewOrderDetailsForm detailsForm = new ViewOrderDetailsForm(orderId);
                detailsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnValidateOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to validate.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Order ID"].Value);
                string status = dgvOrders.SelectedRows[0].Cells["Status"].Value.ToString();

                if (status != "Pending")
                {
                    MessageBox.Show("Only pending orders can be validated.", "Invalid Action",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Validate this medication order?\n\nThis confirms the prescription is correct and can be dispensed.",
                    "Confirm Validation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    string query = @"
                        UPDATE MedicationOrders 
                        SET status = 'Validated', 
                            validated_by = @userId, 
                            validated_date = NOW() 
                        WHERE order_id = @orderId";

                    DatabaseHelper.ExecuteNonQuery(query,
                        new MySqlParameter("@userId", userId),
                        new MySqlParameter("@orderId", orderId));

                    MessageBox.Show("Order validated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error validating order: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDispenseOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to dispense.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Order ID"].Value);
                string status = dgvOrders.SelectedRows[0].Cells["Status"].Value.ToString();

                if (status != "Validated")
                {
                    MessageBox.Show("Only validated orders can be dispensed.", "Invalid Action",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DispenseOrderForm dispenseForm = new DispenseOrderForm(orderId, userId);
                if (dispenseForm.ShowDialog() == DialogResult.OK)
                {
                    LoadOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to cancel.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Order ID"].Value);
                string status = dgvOrders.SelectedRows[0].Cells["Status"].Value.ToString();

                if (status == "Dispensed" || status == "Completed")
                {
                    MessageBox.Show("Cannot cancel orders that have been dispensed or completed.", "Invalid Action",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Cancel this medication order?\n\nThis action cannot be undone.",
                    "Confirm Cancellation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    string query = "UPDATE MedicationOrders SET status = 'Cancelled' WHERE order_id = @orderId";
                    DatabaseHelper.ExecuteNonQuery(query,
                        new MySqlParameter("@orderId", orderId));

                    MessageBox.Show("Order cancelled successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling order: {ex.Message}", "Error",
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
                    LoadOrders();
                    return;
                }

                string query = @"
                    SELECT 
                        mo.order_id AS 'Order ID',
                        u_patient.name AS 'Patient',
                        u_doctor.name AS 'Doctor',
                        mo.medicine_name AS 'Medicine',
                        mo.dosage AS 'Dosage',
                        mo.frequency AS 'Frequency',
                        mo.quantity AS 'Qty',
                        mo.priority AS 'Priority',
                        mo.status AS 'Status',
                        mo.order_date AS 'Order Date',
                        IFNULL(u_validated.name, '-') AS 'Validated By',
                        IFNULL(u_dispensed.name, '-') AS 'Dispensed By'
                    FROM MedicationOrders mo
                    INNER JOIN Patients p ON mo.patient_id = p.patient_id
                    INNER JOIN Users u_patient ON p.user_id = u_patient.user_id
                    INNER JOIN Doctors d ON mo.doctor_id = d.doctor_id
                    INNER JOIN Users u_doctor ON d.user_id = u_doctor.user_id
                    LEFT JOIN Users u_validated ON mo.validated_by = u_validated.user_id
                    LEFT JOIN Users u_dispensed ON mo.dispensed_by = u_dispensed.user_id
                    WHERE u_patient.name LIKE @search
                       OR u_doctor.name LIKE @search
                       OR mo.medicine_name LIKE @search
                       OR mo.order_id = @orderId
                    ORDER BY mo.order_date DESC";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@search", "%" + searchTerm + "%"),
                    new MySqlParameter("@orderId", int.TryParse(searchTerm, out int id) ? id : 0)
                };

                dgvOrders.DataSource = DatabaseHelper.ExecuteQuery(query, parameters);
                lblTotalOrders.Text = $"Search Results: {dgvOrders.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}