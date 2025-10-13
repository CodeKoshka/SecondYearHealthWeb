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
    public partial class PatientDashboard : Form
    {
        private User currentUser;
        private int patientId;

        public PatientDashboard(User user)
        {
            currentUser = user;
            GetPatientId();
            InitializeComponent();
            UpdateWelcomeMessage();
            LoadPatientProfile();
            LoadData();
        }

        //this is to display welcome message in the header panel
        private void UpdateWelcomeMessage()
        {
            lblWelcome.Text = $"Welcome, {currentUser.Name}";
        }

        //this retrieves the patient_id from the database using their user id
        private void GetPatientId()
        {
            string query = "SELECT patient_id FROM Patients WHERE user_id = @userId";
            object result = DatabaseHelper.ExecuteScalar(query,
                new MySqlParameter("@userId", currentUser.UserId));
            patientId = Convert.ToInt32(result);
        }

        //this is just to load the patients profile details into labels
        private void LoadPatientProfile()
        {
            try
            {
                string query = @"
                    SELECT u.name, u.age, u.gender, p.blood_type, p.allergies
                    FROM Users u
                    INNER JOIN Patients p ON u.user_id = p.user_id
                    WHERE u.user_id = @userId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@userId", currentUser.UserId));

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblName.Text = $"Name: {row["name"]}";
                    lblAge.Text = $"Age: {row["age"]}";
                    lblGender.Text = $"Gender: {row["gender"]}";
                    lblBloodType.Text = $"Blood Type: {row["blood_type"]}";
                    lblAllergies.Text = $"Allergies: {row["allergies"]}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                //this loads appointments
                string queryAppointments = @"
                    SELECT a.appointment_id, u.name AS Doctor, d.specialization,
                           a.appointment_date, a.status, a.notes
                    FROM Appointments a
                    INNER JOIN Doctors d ON a.doctor_id = d.doctor_id
                    INNER JOIN Users u ON d.user_id = u.user_id
                    WHERE a.patient_id = @patientId
                    ORDER BY a.appointment_date DESC";
                dgvAppointments.DataSource = DatabaseHelper.ExecuteQuery(queryAppointments,
                    new MySqlParameter("@patientId", patientId));

                //this loads medical records
                string queryRecords = @"
                    SELECT m.record_id, u.name AS Doctor, m.diagnosis, 
                           m.prescription, m.lab_tests, m.record_date
                    FROM MedicalRecords m
                    INNER JOIN Doctors d ON m.doctor_id = d.doctor_id
                    INNER JOIN Users u ON d.user_id = u.user_id
                    WHERE m.patient_id = @patientId
                    ORDER BY m.record_date DESC";
                dgvMedicalRecords.DataSource = DatabaseHelper.ExecuteQuery(queryRecords,
                    new MySqlParameter("@patientId", patientId));

                //this loads bills
                string queryBilling = @"
                    SELECT bill_id, amount, status, description, bill_date
                    FROM Billing
                    WHERE patient_id = @patientId
                    ORDER BY bill_date DESC";
                dgvBilling.DataSource = DatabaseHelper.ExecuteQuery(queryBilling,
                    new MySqlParameter("@patientId", patientId));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //this opens the AppointmentForm to request a new appointment
        private void BtnRequestAppointment_Click(object sender, EventArgs e)
        {
            AppointmentForm apptForm = new AppointmentForm(patientId);
            apptForm.FormClosed += (s, args) => LoadData();
            apptForm.ShowDialog();
        }

        //this is to cancel a selected appointment
        private void BtnCancelAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to cancel.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string status = dgvAppointments.SelectedRows[0].Cells["status"].Value.ToString();
            if (status == "Completed" || status == "Cancelled")
            {
                MessageBox.Show("This appointment cannot be cancelled.", "Invalid Operation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to cancel this appointment?",
                "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int apptId = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["appointment_id"].Value);
                    string query = "UPDATE Appointments SET status = 'Cancelled' WHERE appointment_id = @id";
                    DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@id", apptId));
                    MessageBox.Show("Appointment cancelled successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //this is to view details of a selected medical record
        private void BtnViewRecord_Click(object sender, EventArgs e)
        {
            if (dgvMedicalRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to view.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string doctor = dgvMedicalRecords.SelectedRows[0].Cells["Doctor"].Value.ToString();
            string diagnosis = dgvMedicalRecords.SelectedRows[0].Cells["diagnosis"].Value?.ToString() ?? "N/A";
            string prescription = dgvMedicalRecords.SelectedRows[0].Cells["prescription"].Value?.ToString() ?? "N/A";
            string labTests = dgvMedicalRecords.SelectedRows[0].Cells["lab_tests"].Value?.ToString() ?? "N/A";
            string date = dgvMedicalRecords.SelectedRows[0].Cells["record_date"].Value.ToString();

            string message = $"Doctor: {doctor}\nDate: {date}\n\n" +
                           $"Diagnosis:\n{diagnosis}\n\n" +
                           $"Prescription:\n{prescription}\n\n" +
                           $"Lab Tests:\n{labTests}";

            MessageBox.Show(message, "Medical Record Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //this is to view details of a selected bill
        private void BtnViewBill_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bill to view.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string amount = dgvBilling.SelectedRows[0].Cells["amount"].Value.ToString();
            string status = dgvBilling.SelectedRows[0].Cells["status"].Value.ToString();
            string description = dgvBilling.SelectedRows[0].Cells["description"].Value?.ToString() ?? "N/A";
            string date = dgvBilling.SelectedRows[0].Cells["bill_date"].Value.ToString();

            string message = $"Date: {date}\nAmount: ${amount}\nStatus: {status}\n\nDescription:\n{description}";

            MessageBox.Show(message, "Bill Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
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