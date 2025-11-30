using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class SecurityQuestionsNotificationForm : Form
    {
        private DataTable usersData;
        private string currentUserRole;

        public SecurityQuestionsNotificationForm(DataTable data, string userRole)
        {
            InitializeComponent();
            usersData = data;
            currentUserRole = userRole;
            LoadUsersWithoutSecurity();
            SetupModernStyle();
        }

        private void SetupModernStyle()
        {
            this.BackColor = Color.FromArgb(247, 250, 252);

            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.GridColor = Color.FromArgb(226, 232, 240);

            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 153, 225);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvUsers.ColumnHeadersHeight = 45;

            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(187, 222, 251);
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44);
            dgvUsers.RowTemplate.Height = 40;

            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
        }

        private void LoadUsersWithoutSecurity()
        {
            dgvUsers.DataSource = usersData;

            if (dgvUsers.Columns.Contains("user_id"))
            {
                dgvUsers.Columns["user_id"].Visible = false;
            }

            lblCount.Text = $"⚠️ {usersData.Rows.Count} user(s) need security configuration";

            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                if (row.Cells["Security Status"].Value?.ToString() == "Temporary Default")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205);
                }
                else if (row.Cells["Security Status"].Value?.ToString() == "Not Set")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                }
            }
        }

        private void BtnSetSecurity_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to configure security settings.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["user_id"].Value);
            string userName = dgvUsers.SelectedRows[0].Cells["Name"].Value.ToString();
            string userEmail = dgvUsers.SelectedRows[0].Cells["Email"].Value.ToString();

            SetSecurityQuestionForm securityForm = new SetSecurityQuestionForm(userId, userName, userEmail);

            if (securityForm.ShowDialog() == DialogResult.OK)
            {
                string query = @"
                    SELECT 
                        user_id,
                        unique_id AS 'User ID',
                        name AS 'Name',
                        role AS 'Role',
                        email AS 'Email',
                        CASE 
                            WHEN security_answer = 'HAPPYHEALTH' THEN 'Temporary Default'
                            WHEN security_question IS NULL OR security_answer IS NULL THEN 'Not Set'
                            ELSE 'Set'
                        END AS 'Security Status'
                    FROM Users 
                    WHERE role != 'Patient' 
                    AND is_active = 1 
                    AND (security_question IS NULL 
                         OR security_answer IS NULL 
                         OR security_answer = 'HAPPYHEALTH')
                    ORDER BY role, name";

                usersData = DatabaseHelper.ExecuteQuery(query);

                if (usersData.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "✓ All users now have security questions configured!",
                        "Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                LoadUsersWithoutSecurity();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}