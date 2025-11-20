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
    public partial class ShowDetailedMedicalHistoryForm : Form
    {
        private int patientId;
        private string patientName;
        private int recordCount;
        private int visitCount;
        private int currentUserId;
        private string currentUserRole;

        public ShowDetailedMedicalHistoryForm(int patientId, string patientName, int recordCount, int visitCount, int currentUserId, string currentUserRole)
        {
            this.patientId = patientId;
            this.patientName = patientName;
            this.recordCount = recordCount;
            this.visitCount = visitCount;
            this.currentUserId = currentUserId;
            this.currentUserRole = currentUserRole;

            InitializeComponent();
            InitializeForm();
            LoadMedicalHistory();
        }

        private void InitializeForm()
        {
            this.Text = $"Medical History - {patientName}";

            lblTitle.Text = $"📋 Complete Medical History - {patientName}";
            lblStats.Text = $"Medical Records: {recordCount} | Total Visits: {visitCount}";

            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dgvHistory.AutoGenerateColumns = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.ReadOnly = true;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.MultiSelect = false;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.AllowUserToResizeRows = false;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(156, 39, 176);
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvHistory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHistory.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 8, 12, 8);
            dgvHistory.ColumnHeadersHeight = 50;

            dgvHistory.DefaultCellStyle.BackColor = Color.White;
            dgvHistory.DefaultCellStyle.ForeColor = Color.FromArgb(26, 32, 44);
            dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 190, 231);
            dgvHistory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44);
            dgvHistory.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvHistory.DefaultCellStyle.Padding = new Padding(12, 5, 12, 5);
            dgvHistory.RowTemplate.Height = 45;

            dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvHistory.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 190, 231);

            dgvHistory.GridColor = Color.FromArgb(226, 232, 240);
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvHistory, new object[] { true });
        }

        private void LoadMedicalHistory()
        {
            try
            {
                string query = @"
                    SELECT 
                    mr.record_id,
                    DATE_FORMAT(mr.record_date, '%Y-%m-%d %H:%i') AS 'Date & Time',
                    mr.visit_type AS 'Visit Type',
                    u.name AS 'Attending Doctor',
                    CASE 
                        WHEN LENGTH(mr.diagnosis) > 100 
                        THEN CONCAT(SUBSTRING(mr.diagnosis, 1, 100), '...')
                        ELSE mr.diagnosis
                    END AS 'Clinical Summary',
                    CASE 
                        WHEN mr.prescription IS NOT NULL AND mr.prescription != '' 
                        THEN 'Yes' 
                        ELSE 'No' 
                    END AS 'Rx',
                    CASE 
                        WHEN mr.lab_tests IS NOT NULL AND mr.lab_tests != '' 
                        THEN 'Yes' 
                        ELSE 'No' 
                    END AS 'Labs'
                    FROM MedicalRecords mr
                    INNER JOIN Doctors d ON mr.doctor_id = d.doctor_id
                    INNER JOIN Users u ON d.user_id = u.user_id
                    WHERE mr.patient_id = @patientId
                    ORDER BY mr.record_date DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@patientId", patientId));

                dgvHistory.DataSource = dt;

                // Configure column visibility and widths after binding
                dgvHistory.DataBindingComplete += DgvHistory_DataBindingComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading medical history: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvHistory.Columns["record_id"] != null)
            {
                dgvHistory.Columns["record_id"].Visible = false;
            }
            if (dgvHistory.Columns["Date & Time"] != null)
            {
                dgvHistory.Columns["Date & Time"].Width = 150;
            }
            if (dgvHistory.Columns["Visit Type"] != null)
            {
                dgvHistory.Columns["Visit Type"].Width = 120;
            }
            if (dgvHistory.Columns["Attending Doctor"] != null)
            {
                dgvHistory.Columns["Attending Doctor"].Width = 150;
            }
            if (dgvHistory.Columns["Rx"] != null)
            {
                dgvHistory.Columns["Rx"].Width = 50;
            }
            if (dgvHistory.Columns["Labs"] != null)
            {
                dgvHistory.Columns["Labs"].Width = 50;
            }

            // Disable sorting
            foreach (DataGridViewColumn column in dgvHistory.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void DgvHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int recordId = Convert.ToInt32(dgvHistory.Rows[e.RowIndex].Cells["record_id"].Value);
                ShowMedicalRecord(recordId);
            }
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count > 0)
            {
                int recordId = Convert.ToInt32(dgvHistory.SelectedRows[0].Cells["record_id"].Value);
                ShowMedicalRecord(recordId);
            }
            else
            {
                MessageBox.Show("Please select a record to view.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowMedicalRecord(int recordId)
        {
            MedicalRecordForm viewer = MedicalRecordForm.CreateViewMode(
                recordId,
                currentUserId,
                currentUserRole
            );
            viewer.ShowDialog();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Print functionality will be implemented in future update.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}