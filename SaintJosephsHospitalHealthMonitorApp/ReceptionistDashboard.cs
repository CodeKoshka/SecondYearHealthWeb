using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                SELECT q.queue_id, q.queue_number, u.name AS Patient, 
                IFNULL(d.name, 'Not Assigned') AS Doctor, q.priority, 
                q.status, q.reason_for_visit, q.registered_time
                FROM PatientQueue q
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
                dgvQueue.DataSource = DatabaseHelper.ExecuteQuery(queryQueue);

                string queryPatients = @"
                SELECT p.patient_id, u.name, u.age, u.gender, 
                p.blood_type, p.phone_number, u.email
                FROM Patients p
                INNER JOIN Users u ON p.user_id = u.user_id
                WHERE u.is_active = 1
                ORDER BY u.name";
                dgvPatients.DataSource = DatabaseHelper.ExecuteQuery(queryPatients);

                int queueCount = dgvQueue.Rows.Count;
                lblQueueCount.Text = $"Total in Queue Today: {queueCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //this is to add a patient to the queue
        private void BtnAddToQueue_Click(object sender, EventArgs e)
        {
            AddToQueueForm queueForm = new AddToQueueForm(currentUser.UserId);
            queueForm.FormClosed += (s, args) => LoadData();
            queueForm.ShowDialog();
        }

        //this is to assign a doctor to a queued patient
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

        //this marks the selected patient as called
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

                //this is to update queue status to Called with current time
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

        //this removes a patient from the queue
        private void BtnRemoveFromQueue_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient from the queue.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Remove this patient from queue?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int queueId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_id"].Value);
                    string query = "DELETE FROM PatientQueue WHERE queue_id = @queueId";
                    DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@queueId", queueId));
                    MessageBox.Show("Patient removed from queue.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //this to view detailed information about a selected patient
        private void BtnViewPatient_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to view.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);
            PatientDetailsForm detailsForm = new PatientDetailsForm(patientId);
            detailsForm.ShowDialog();
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
            createPatientForm.FormClosed += (s, args) => LoadData();
            createPatientForm.ShowDialog();
        }
    }
}