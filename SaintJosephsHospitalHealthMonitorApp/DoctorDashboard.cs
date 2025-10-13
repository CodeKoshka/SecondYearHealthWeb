using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class DoctorDashboard : Form
    {
        private User currentUser;
        private int doctorId;

        public DoctorDashboard(User user)
        {
            currentUser = user;
            GetDoctorId();
            InitializeComponent();
            UpdateWelcomeMessage();
            LoadData();
        }
        //this just updates the welcome message at the top of the dashboard
        private void UpdateWelcomeMessage()
        {
            if (panelHeader.Controls.Count > 0)
            {
                Label lblWelcome = panelHeader.Controls[0] as Label;
                if (lblWelcome != null)
                {
                    lblWelcome.Text = $"Dr. {currentUser.Name} - Doctor Portal";
                }
            }
        }
        //this retrieves the doctor_id from the database using the user_id
        //this is important because Appointments and medicalrecords uses the doctor_id and not user_id
        private void GetDoctorId()
        {
            string query = "SELECT doctor_id FROM Doctors WHERE user_id = @userId";
            object result = DatabaseHelper.ExecuteScalar(query,
                new MySqlParameter("@userId", currentUser.UserId));
            doctorId = Convert.ToInt32(result);
        }

        private void LoadData()
        {
            try
            {
                //this loads Appointments
                string queryAppointments = @"
                    SELECT a.appointment_id, u.name AS Patient, u.age, u.gender,
                           a.appointment_date, a.status, a.notes
                    FROM Appointments a
                    INNER JOIN Patients p ON a.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE a.doctor_id = @doctorId
                    ORDER BY a.appointment_date DESC";
                dgvAppointments.DataSource = DatabaseHelper.ExecuteQuery(queryAppointments,
                    new MySqlParameter("@doctorId", doctorId));

                //this loads patients
                string queryPatients = @"
                    SELECT DISTINCT u.user_id, u.name, u.age, u.gender, 
                           p.blood_type, p.allergies, u.email
                    FROM Appointments a
                    INNER JOIN Patients p ON a.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE a.doctor_id = @doctorId";
                dgvPatients.DataSource = DatabaseHelper.ExecuteQuery(queryPatients,
                    new MySqlParameter("@doctorId", doctorId));

                //this loads medical records
                string queryRecords = @"
                    SELECT m.record_id, u.name AS Patient, m.diagnosis, 
                           m.prescription, m.lab_tests, m.record_date
                    FROM MedicalRecords m
                    INNER JOIN Patients p ON m.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE m.doctor_id = @doctorId
                    ORDER BY m.record_date DESC";
                dgvMedicalRecords.DataSource = DatabaseHelper.ExecuteQuery(queryRecords,
                    new MySqlParameter("@doctorId", doctorId));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnViewPatient_Click(object sender, EventArgs e)
        {
            //this ensures a row is selected
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //this retrieves patient details from the selected row
            string patientName = dgvAppointments.SelectedRows[0].Cells["Patient"].Value.ToString();
            string age = dgvAppointments.SelectedRows[0].Cells["age"].Value.ToString();
            string gender = dgvAppointments.SelectedRows[0].Cells["gender"].Value.ToString();
            string apptDate = dgvAppointments.SelectedRows[0].Cells["appointment_date"].Value.ToString();
            string notes = dgvAppointments.SelectedRows[0].Cells["notes"].Value?.ToString() ?? "None";

            string message = $"Patient: {patientName}\nAge: {age}\nGender: {gender}\n" +
                           $"Appointment: {apptDate}\nNotes: {notes}";

            MessageBox.Show(message, "Patient Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //this is for marking an appointment as completed
        private void BtnCompleteAppointment_Click(object sender, EventArgs e)
        {
            //this ensures a row is selected
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int apptId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["appointment_id"].Value);

            try
            {
                //this updates sql to update the appointment status to "Completed"
                string query = "UPDATE Appointments SET status = 'Completed' WHERE appointment_id = @id";
                DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@id", apptId));
                MessageBox.Show("Appointment marked as completed!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //this is for for viewing the medical history of a patient
        private void BtnViewHistory_Click(object sender, EventArgs e)
        {
            //this ensures a row is selected
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["user_id"].Value);

            //this is meant to get patient_id from user_id
            string getPatientId = "SELECT patient_id FROM Patients WHERE user_id = @userId";
            int patientId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(getPatientId,
                new MySqlParameter("@userId", userId)));

            //this show medical history
            string query = @"
                SELECT m.record_date, u.name AS Doctor, m.diagnosis, 
                       m.prescription, m.lab_tests
                FROM MedicalRecords m
                INNER JOIN Doctors d ON m.doctor_id = d.doctor_id
                INNER JOIN Users u ON d.user_id = u.user_id
                WHERE m.patient_id = @patientId
                ORDER BY m.record_date DESC";

            //this execute the query and store results in a table
            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new MySqlParameter("@patientId", patientId));

            Form historyForm = new Form();
            historyForm.Text = "Patient Medical History";
            historyForm.Size = new Size(900, 500);
            historyForm.StartPosition = FormStartPosition.CenterParent;

            DataGridView dgvHistory = new DataGridView();
            dgvHistory.Location = new Point(10, 10);
            dgvHistory.Size = new Size(860, 430);
            dgvHistory.ReadOnly = true;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.DataSource = dt;
            historyForm.Controls.Add(dgvHistory);
            historyForm.ShowDialog();
        }

        //this is for for adding a new medical record
        private void BtnAddMedicalRecord_Click(object sender, EventArgs e)
        {
            //this ensures a row is selected
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["user_id"].Value);
            string patientName = dgvPatients.SelectedRows[0].Cells["name"].Value.ToString();

            //this is to get the patient_id
            string getPatientId = "SELECT patient_id FROM Patients WHERE user_id = @userId";
            int patientId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(getPatientId,
                new MySqlParameter("@userId", userId)));

            MedicalRecordForm recordForm = new MedicalRecordForm(patientId, doctorId, patientName);
            recordForm.FormClosed += (s, args) => LoadData();
            recordForm.ShowDialog();
        }

        //this is for editing an existing medical record
        private void BtnEditRecord_Click(object sender, EventArgs e)
        {
            //this ensures a row is selected
            if (dgvMedicalRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //this gets the record_id of the selected medical record
            int recordId = Convert.ToInt32(dgvMedicalRecords.SelectedRows[0].Cells["record_id"].Value);
            string diagnosis = dgvMedicalRecords.SelectedRows[0].Cells["diagnosis"].Value?.ToString() ?? "";
            string prescription = dgvMedicalRecords.SelectedRows[0].Cells["prescription"].Value?.ToString() ?? "";
            string labTests = dgvMedicalRecords.SelectedRows[0].Cells["lab_tests"].Value?.ToString() ?? "";

            EditMedicalRecordForm editForm = new EditMedicalRecordForm(recordId, diagnosis, prescription, labTests);
            editForm.FormClosed += (s, args) => LoadData();
            editForm.ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}