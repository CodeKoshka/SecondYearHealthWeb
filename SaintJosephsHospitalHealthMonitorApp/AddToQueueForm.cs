using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class AddToQueueForm : Form
    {
        private int registeredBy;

        public AddToQueueForm(int userId)
        {
            registeredBy = userId;
            InitializeComponent();
        }

        private void AddToQueueForm_Load(object sender, EventArgs e)
        {
            LoadAvailablePatients();
        }

        private void LoadAvailablePatients()
        {
            try
            {
                string query = @"
                SELECT 
                p.patient_id, 
                u.name, 
                u.age, 
                u.gender, 
                COALESCE(p.blood_type, 'Unknown') AS blood_type,
                CASE 
                WHEN NOT EXISTS (
                    SELECT 1 FROM PatientQueue 
                    WHERE patient_id = p.patient_id 
                    AND queue_date = CURDATE()
                    AND status NOT IN ('Discharged', 'Completed')
                ) THEN 'Available for Queue'
                WHEN EXISTS (
                    SELECT 1 FROM PatientQueue 
                    WHERE patient_id = p.patient_id 
                    AND queue_date = CURDATE()
                    AND status = 'Discharged'
                ) THEN 'Recently Discharged - Can Re-queue'
                ELSE 'Already in Queue'
                END AS queue_status,
                CASE 
                WHEN NOT EXISTS (SELECT 1 FROM CompletedVisits WHERE patient_id = p.patient_id) 
                THEN 'First Visit'
                ELSE CONCAT('Previous Visits: ', 
                    CAST((SELECT COUNT(*) FROM CompletedVisits WHERE patient_id = p.patient_id) AS CHAR))
                END AS visit_info
                FROM Patients p
                INNER JOIN Users u ON p.user_id = u.user_id
                WHERE u.is_active = 1
                AND NOT EXISTS (
                    SELECT 1 FROM patientqueue 
                    WHERE patient_id = p.patient_id 
                    AND queue_date = CURDATE()
                    AND status NOT IN ('Discharged', 'Completed')
                )
                ORDER BY u.name";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvPatients.DataSource = dt;

                if (dgvPatients.Columns["patient_id"] != null)
                {
                    dgvPatients.Columns["patient_id"].Visible = false;
                }

                if (dgvPatients.Columns["name"] != null)
                    dgvPatients.Columns["name"].HeaderText = "Patient Name";
                if (dgvPatients.Columns["age"] != null)
                    dgvPatients.Columns["age"].HeaderText = "Age";
                if (dgvPatients.Columns["gender"] != null)
                    dgvPatients.Columns["gender"].HeaderText = "Gender";
                if (dgvPatients.Columns["blood_type"] != null)
                    dgvPatients.Columns["blood_type"].HeaderText = "Blood Type";
                if (dgvPatients.Columns["queue_status"] != null)
                    dgvPatients.Columns["queue_status"].HeaderText = "Queue Status";
                if (dgvPatients.Columns["visit_info"] != null)
                    dgvPatients.Columns["visit_info"].HeaderText = "Visit History";

                lblPatientCount.Text = $"Available Patients: {dt.Rows.Count}";

                if (dgvPatients.Rows.Count > 0)
                {
                    dgvPatients.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patients: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient first.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);

            string checkQuery = @"
                SELECT COUNT(*) 
                FROM patientqueue 
                WHERE patient_id = @patientId 
                AND queue_date = CURDATE()
                AND status NOT IN ('Discharged', 'Completed')";

            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery,
                new MySqlParameter("@patientId", patientId)));

            if (count > 0)
            {
                MessageBox.Show(
                    "This patient is already in today's queue.\n\n" +
                    "A patient can only be added to the queue once per day.",
                    "Already in Queue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, registeredBy))
            {
                if (intakeForm.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    LoadAvailablePatients();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadAvailablePatients();
                return;
            }

            try
            {
                string query = @"
                SELECT 
                p.patient_id, 
                u.name, 
                u.age, 
                u.gender, 
                COALESCE(p.blood_type, 'Unknown') AS blood_type,
                CASE 
                WHEN NOT EXISTS (
                    SELECT 1 FROM PatientQueue 
                    WHERE patient_id = p.patient_id 
                    AND queue_date = CURDATE()
                    AND status NOT IN ('Discharged', 'Completed')
                ) THEN 'Available for Queue'
                WHEN EXISTS (
                    SELECT 1 FROM PatientQueue 
                    WHERE patient_id = p.patient_id 
                    AND queue_date = CURDATE()
                    AND status = 'Discharged'
                ) THEN 'Recently Discharged - Can Re-queue'
                ELSE 'Already in Queue'
                END AS queue_status,
                CASE 
                WHEN NOT EXISTS (SELECT 1 FROM CompletedVisits WHERE patient_id = p.patient_id) 
                THEN 'First Visit'
                ELSE CONCAT('Previous Visits: ', 
                    CAST((SELECT COUNT(*) FROM CompletedVisits WHERE patient_id = p.patient_id) AS CHAR))
                END AS visit_info
                FROM Patients p
                INNER JOIN Users u ON p.user_id = u.user_id
                WHERE u.is_active = 1
                AND NOT EXISTS (
                    SELECT 1 FROM patientqueue 
                    WHERE patient_id = p.patient_id 
                    AND queue_date = CURDATE()
                    AND status NOT IN ('Discharged', 'Completed')
                )
                AND (
                    LOWER(u.name) LIKE @search 
                    OR LOWER(p.blood_type) LIKE @search
                    OR LOWER(u.gender) LIKE @search
                )
                ORDER BY u.name";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@search", $"%{searchText}%"));

                dgvPatients.DataSource = dt;

                if (dgvPatients.Columns["patient_id"] != null)
                    dgvPatients.Columns["patient_id"].Visible = false;

                lblPatientCount.Text = $"Found: {dt.Rows.Count} patient(s)";

                if (dgvPatients.Rows.Count > 0)
                {
                    dgvPatients.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching patients: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnSelect_Click(sender, e);
            }
        }
    }
}