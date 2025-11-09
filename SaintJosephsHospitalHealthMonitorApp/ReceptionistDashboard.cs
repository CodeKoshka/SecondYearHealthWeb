using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class ReceptionistDashboard : Form
    {
        private User currentUser;

        public ReceptionistDashboard(User user)
        {
            currentUser = user;
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {currentUser.Name} (receptionist)";
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string queryQueue = @"
            SELECT 
                q.queue_id, 
                q.queue_number, 
                u.name AS Patient, 
                IFNULL(d.name, 'Not Assigned') AS Doctor, 
                q.priority, 
                q.status,
                q.registered_time
            FROM patientqueue q
            INNER JOIN Patients p ON q.patient_id = p.patient_id
            INNER JOIN Users u ON p.user_id = u.user_id
            LEFT JOIN Doctors doc ON q.doctor_id = doc.doctor_id
            LEFT JOIN Users d ON doc.user_id = d.user_id
            WHERE q.queue_date = CURDATE()
            ORDER BY 
                CASE q.priority 
                    WHEN 'Emergency' THEN 1 
                    WHEN 'Urgent' THEN 2 
                    ELSE 3 
                END, 
                q.queue_number";

                DataTable dtQueue = DatabaseHelper.ExecuteQuery(queryQueue);
                dgvQueue.DataSource = dtQueue;

                string queryPatients = @"
            SELECT 
                p.patient_id, 
                u.name, 
                u.age, 
                u.gender, 
                IFNULL(p.blood_type, 'Unknown') AS blood_type, 
                IFNULL(p.phone_number, 'N/A') AS phone_number, 
                u.email
            FROM Patients p
            INNER JOIN Users u ON p.user_id = u.user_id
            WHERE u.is_active = 1
            ORDER BY u.name";

                dgvPatients.DataSource = DatabaseHelper.ExecuteQuery(queryPatients);

                int queueCount = dtQueue.Rows.Count;
                lblQueueCount.Text = $"Total in Queue Today: {queueCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddToQueue_Click(object sender, EventArgs e)
        {
            using (var selectForm = new Form())
            {
                selectForm.Text = "Select Patient";
                selectForm.Size = new Size(500, 400);
                selectForm.StartPosition = FormStartPosition.CenterParent;

                var lblInstruction = new Label
                {
                    Text = "Select a patient to add to queue:",
                    Location = new Point(20, 20),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };

                var dgv = new DataGridView
                {
                    Location = new Point(20, 50),
                    Size = new Size(440, 250),
                    ReadOnly = true,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    MultiSelect = false,
                    AllowUserToAddRows = false,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };

                string query = @"
                    SELECT p.patient_id, u.name, u.age, u.gender, p.blood_type
                    FROM Patients p
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE u.is_active = 1
                    ORDER BY u.name";
                dgv.DataSource = DatabaseHelper.ExecuteQuery(query);

                var btnSelect = new Button
                {
                    Text = "Select & Continue to Intake",
                    Location = new Point(150, 310),
                    Size = new Size(200, 35),
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };
                btnSelect.FlatAppearance.BorderSize = 0;

                btnSelect.Click += (s, ev) =>
                {
                    if (dgv.SelectedRows.Count > 0)
                    {
                        int patientId = Convert.ToInt32(dgv.SelectedRows[0].Cells["patient_id"].Value);
                        selectForm.DialogResult = DialogResult.OK;
                        selectForm.Tag = patientId;
                        selectForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select a patient.", "Selection Required",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };

                selectForm.Controls.AddRange(new Control[] { lblInstruction, dgv, btnSelect });

                if (selectForm.ShowDialog() == DialogResult.OK && selectForm.Tag != null)
                {
                    int patientId = (int)selectForm.Tag;

                    PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, currentUser.UserId);
                    intakeForm.FormClosed += (s, args) => LoadData();
                    intakeForm.ShowDialog();
                }
            }
        }

        private void BtnAssignDoctor_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient from the queue.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int queueId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_id"].Value);
            string patientName = dgvQueue.SelectedRows[0].Cells["Patient"].Value.ToString();

            AssignDoctorForm assignForm = new AssignDoctorForm(queueId, patientName);
            assignForm.FormClosed += (s, args) => LoadData();
            assignForm.ShowDialog();
        }

        private void BtnCallNext_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to call.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string status = dgvQueue.SelectedRows[0].Cells["status"].Value.ToString();
            if (status != "Waiting")
            {
                MessageBox.Show("This patient is already being attended or completed.", "Invalid Status",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int queueId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_id"].Value);
                string patientName = dgvQueue.SelectedRows[0].Cells["Patient"].Value.ToString();
                int queueNumber = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_number"].Value);

                string query = @"UPDATE PatientQueue 
                               SET status = 'Called', called_time = NOW()
                               WHERE queue_id = @queueId";
                DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@queueId", queueId));

                MessageBox.Show($"Now calling: Queue #{queueNumber} - {patientName}", "Patient Called",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemoveFromQueue_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient from the queue.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int queueId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_id"].Value);
            string status = dgvQueue.SelectedRows[0].Cells["status"].Value.ToString();
            string patientName = dgvQueue.SelectedRows[0].Cells["Patient"].Value.ToString();

            DialogResult confirm = MessageBox.Show(
                $"Remove {patientName} from queue?\n\n" +
                "This will permanently remove them from today's queue.",
                "Confirm Remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string deleteQuery = "DELETE FROM PatientQueue WHERE queue_id = @queueId";
                DatabaseHelper.ExecuteNonQuery(deleteQuery,
                    new MySqlParameter("@queueId", queueId));

                MessageBox.Show("✓ Patient removed from queue.", "Removed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing patient: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnViewPatient_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to view.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);

            PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, currentUser.UserId, viewOnly: true);
            intakeForm.ShowDialog();
        }

        private void BtnEditPatient_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);

            PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, currentUser.UserId, viewOnly: false);
            intakeForm.FormClosed += (s, args) => LoadData();
            intakeForm.ShowDialog();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }


        private void BtnAddPatient_Click(object sender, EventArgs e)
        {
            RegisterForm createPatientForm = new RegisterForm(currentUser.UserId, currentUser.Role);

            if (createPatientForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    "✓ Patient record has been created successfully!\n\n" +
                    "The patient is now registered in the system.\n\n" +
                    "To add them to the queue:\n" +
                    "1. Click 'Add to Queue' button\n" +
                    "2. Select the patient\n" +
                    "3. Complete the intake form",
                    "Patient Created",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
            else
            {
                LoadData();
            }
        }

        private void BtnCheckMedicalHistory_Click(object sender, EventArgs e)
            {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to check their medical history.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvPatients.SelectedRows[0].Cells["name"].Value.ToString();

            try
            {
                string checkQuery = @"SELECT COUNT(*) FROM MedicalRecords WHERE patient_id = @patientId";
                int recordCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery,
                    new MySqlParameter("@patientId", patientId)));

                string checkVisitsQuery = @"SELECT COUNT(*) FROM CompletedVisits WHERE patient_id = @patientId";
                int visitCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkVisitsQuery,
                    new MySqlParameter("@patientId", patientId)));

                if (recordCount == 0 && visitCount == 0)
                {
                    MessageBox.Show(
                        $"Patient: {patientName}\n\n" +
                        "✓ NEW PATIENT\n\n" +
                        "This patient has no previous medical records or visits.\n" +
                        "They are visiting the hospital for the first time.",
                        "Medical History - New Patient",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    ShowMedicalHistoryDetails(patientId, patientName, recordCount, visitCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking medical history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowMedicalHistoryDetails(int patientId, string patientName, int recordCount, int visitCount)
        {
            Form historyForm = new Form
            {
                Text = $"Medical History - {patientName}",
                Size = new Size(1000, 600),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.FromArgb(240, 245, 250)
            };

            Panel headerPanel = new Panel
            {
                BackColor = Color.FromArgb(156, 39, 176),
                Dock = DockStyle.Top,
                Height = 80
            };

            Label lblTitle = new Label
            {
                Text = $"📋 Medical History - {patientName}",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label lblStats = new Label
            {
                Text = $"Total Medical Records: {recordCount} | Total Visits: {visitCount}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                Location = new Point(20, 45),
                AutoSize = true
            };

            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblStats);

            DataGridView dgvHistory = new DataGridView
            {
                Location = new Point(20, 100),
                Size = new Size(940, 400),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowTemplate = { Height = 35 }
            };

            string query = @"
        SELECT 
            mr.record_id AS 'Record ID',
            mr.visit_date AS 'Visit Date',
            mr.visit_type AS 'Visit Type',
            u.name AS 'Doctor',
            SUBSTRING(mr.diagnosis, 1, 100) AS 'Diagnosis Summary'
        FROM MedicalRecords mr
        INNER JOIN Doctors d ON mr.doctor_id = d.doctor_id
        INNER JOIN Users u ON d.user_id = u.user_id
        WHERE mr.patient_id = @patientId
        ORDER BY mr.visit_date DESC";

            DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@patientId", patientId));
            dgvHistory.DataSource = dt;

            if (dgvHistory.Columns.Count > 0)
            {
                dgvHistory.Columns[0].Width = 80;
                dgvHistory.Columns[1].Width = 150; 
                dgvHistory.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
                dgvHistory.Columns[2].Width = 120;
                dgvHistory.Columns[3].Width = 150;
                dgvHistory.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            Button btnClose = new Button
            {
                Text = "✓ Close",
                Size = new Size(150, 40),
                Location = new Point(425, 510),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => historyForm.Close();

            historyForm.Controls.Add(headerPanel);
            historyForm.Controls.Add(dgvHistory);
            historyForm.Controls.Add(btnClose);

            historyForm.ShowDialog();
        }
    }
}