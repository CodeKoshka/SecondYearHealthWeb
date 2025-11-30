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
            ApplyStyles();
            LoadAvailablePatients();
        }

        private void ApplyStyles()
        {
            dgvPatients.AutoGenerateColumns = true;
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AllowUserToDeleteRows = false;
            dgvPatients.ReadOnly = true;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.MultiSelect = false;
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.EnableHeadersVisualStyles = false;
            dgvPatients.AllowUserToResizeRows = false;
            dgvPatients.AllowUserToOrderColumns = false;
            dgvPatients.AllowUserToResizeColumns = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPatients.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(142, 68, 173);
            dgvPatients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPatients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvPatients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvPatients.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(142, 68, 173);
            dgvPatients.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvPatients.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 8, 12, 8);
            dgvPatients.ColumnHeadersHeight = 50;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvPatients.DefaultCellStyle.BackColor = Color.White;
            dgvPatients.DefaultCellStyle.ForeColor = Color.FromArgb(26, 32, 44);
            dgvPatients.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 255);
            dgvPatients.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44);
            dgvPatients.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvPatients.DefaultCellStyle.Padding = new Padding(12, 5, 12, 5);
            dgvPatients.RowTemplate.Height = 45;

            dgvPatients.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvPatients.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 255);
            dgvPatients.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44);

            dgvPatients.GridColor = Color.FromArgb(226, 232, 240);
            dgvPatients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPatients.BackgroundColor = Color.White;
            dgvPatients.BorderStyle = BorderStyle.None;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgvPatients, new object[] { true });

            dgvPatients.RowPostPaint -= DgvPatients_RowPostPaint;
            dgvPatients.RowPostPaint += DgvPatients_RowPostPaint;
        }

        private void DgvPatients_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvPatients.Rows.Count) return;

                DataGridViewRow row = dgvPatients.Rows[e.RowIndex];

                if (row.Selected)
                {
                    int slabWidth = 10;

                    using (SolidBrush slabBrush = new SolidBrush(Color.FromArgb(142, 68, 173)))
                    {
                        Rectangle slabRect = new Rectangle(
                            e.RowBounds.Left,
                            e.RowBounds.Top,
                            slabWidth,
                            e.RowBounds.Height
                        );

                        e.Graphics.FillRectangle(slabBrush, slabRect);
                    }
                }
            }
            catch { }
        }

        private void ConfigureDataGridViewColumns()
        {
            try
            {
                if (dgvPatients.Columns.Contains("patient_id"))
                    dgvPatients.Columns["patient_id"].Visible = false;

                if (dgvPatients.Columns.Contains("name"))
                {
                    dgvPatients.Columns["name"].HeaderText = "Patient Name";
                    dgvPatients.Columns["name"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvPatients.Columns["name"].Resizable = DataGridViewTriState.False;
                }

                if (dgvPatients.Columns.Contains("age"))
                {
                    dgvPatients.Columns["age"].HeaderText = "Age";
                    dgvPatients.Columns["age"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvPatients.Columns["age"].Resizable = DataGridViewTriState.False;
                }

                if (dgvPatients.Columns.Contains("gender"))
                {
                    dgvPatients.Columns["gender"].HeaderText = "Gender";
                    dgvPatients.Columns["gender"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvPatients.Columns["gender"].Resizable = DataGridViewTriState.False;
                }

                if (dgvPatients.Columns.Contains("blood_type"))
                {
                    dgvPatients.Columns["blood_type"].HeaderText = "Blood Type";
                    dgvPatients.Columns["blood_type"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvPatients.Columns["blood_type"].Resizable = DataGridViewTriState.False;
                }

                if (dgvPatients.Columns.Contains("queue_status"))
                {
                    dgvPatients.Columns["queue_status"].HeaderText = "Queue Status";
                    dgvPatients.Columns["queue_status"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvPatients.Columns["queue_status"].Resizable = DataGridViewTriState.False;
                }

                if (dgvPatients.Columns.Contains("visit_info"))
                {
                    dgvPatients.Columns["visit_info"].HeaderText = "Visit History";
                    dgvPatients.Columns["visit_info"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvPatients.Columns["visit_info"].Resizable = DataGridViewTriState.False;
                }

                foreach (DataGridViewColumn column in dgvPatients.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.Resizable = DataGridViewTriState.False;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Column configuration error: {ex.Message}", "Debug Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

                dgvPatients.DataSource = null;
                dgvPatients.DataSource = dt;

                dgvPatients.Refresh(); 

                ConfigureDataGridViewColumns(); 

                lblPatientCount.Text = $"Available Patients: {dt.Rows.Count}";

                dgvPatients.Cursor = Cursors.Hand;

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

        private void DgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvPatients.ClearSelection();
                dgvPatients.Rows[e.RowIndex].Selected = true;
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
            string patientName = dgvPatients.SelectedRows[0].Cells["name"].Value.ToString();

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

            bool needsIntake = PatientNeedsNewIntakeForm(patientId);

            if (needsIntake)
            {
                DialogResult confirm = MessageBox.Show(
                    $"📋 NEW INTAKE REQUIRED\n\n" +
                    $"Patient: {patientName}\n\n" +
                    "This patient needs a new intake form because they either:\n" +
                    "• Were discharged today, OR\n" +
                    "• Were removed from the queue\n\n" +
                    "Open intake form now?",
                    "Intake Form Required",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    using (PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, registeredBy))
                    {
                        if (intakeForm.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Intake form was cancelled.\n\n" +
                                "Patient was not added to the queue.",
                                "Cancelled",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            LoadAvailablePatients(); 
                        }
                    }
                }
            }
            else
            {
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

                dgvPatients.DataSource = null;
                dgvPatients.DataSource = dt;

                dgvPatients.Refresh();

                ConfigureDataGridViewColumns();

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

        private bool PatientNeedsNewIntakeForm(int patientId)
        {
            try
            {
                string checkAnyQueue = @"
            SELECT COUNT(*) 
            FROM PatientQueue 
            WHERE patient_id = @patientId";

                int totalQueueHistory = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkAnyQueue,
                    new MySqlParameter("@patientId", patientId)));

                if (totalQueueHistory == 0)
                {
                    return false; 
                }

                string checkDischargedToday = @"
            SELECT COUNT(*) 
            FROM CompletedVisits 
            WHERE patient_id = @patientId 
            AND DATE(archived_date) = CURDATE()";

                int dischargedToday = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkDischargedToday,
                    new MySqlParameter("@patientId", patientId)));

                if (dischargedToday > 0)
                {
                    return true;
                }

                string checkRemovedFromQueue = @"
            SELECT COUNT(*) 
            FROM CompletedVisits 
            WHERE patient_id = @patientId";

                int wasInSystemBefore = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkRemovedFromQueue,
                    new MySqlParameter("@patientId", patientId)));

                if (wasInSystemBefore > 0)
                {
                    return true;
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error checking intake need: {ex.Message}");
                return true;
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