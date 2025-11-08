using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class AppointmentForm : Form
    {
        private int? preSelectedPatientId;
        private int createdByUserId;

        public AppointmentForm(int? patientId = null, int createdBy = 0)
        {
            preSelectedPatientId = patientId;
            createdByUserId = createdBy;
            InitializeComponent();
            LoadDoctors();

            if (patientId == null)
            {
                LoadPatients();
            }
            else
            {
                cmbPatient.Visible = false;
                lblPatient.Text = "Patient: (Pre-selected)";
            }
        }

        private void LoadPatients()
        {
            string query = @"SELECT p.patient_id, u.name 
                        FROM Patients p
                        INNER JOIN Users u ON p.user_id = u.user_id
                        WHERE u.is_active = 1
                        ORDER BY u.name";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cmbPatient.DisplayMember = "name";
            cmbPatient.ValueMember = "patient_id";
            cmbPatient.DataSource = dt;
        }

        private void LoadDoctors()
        {
            string query = @"SELECT d.doctor_id, 
                        CONCAT(u.name, ' (', d.specialization, ')') AS doctor_info
                        FROM Doctors d
                        INNER JOIN Users u ON d.user_id = u.user_id
                        WHERE u.is_active = 1
                        ORDER BY u.name";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cmbDoctor.DisplayMember = "doctor_info";
            cmbDoctor.ValueMember = "doctor_id";
            cmbDoctor.DataSource = dt;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (preSelectedPatientId == null && cmbPatient.SelectedValue == null)
            {
                MessageBox.Show("Please select a patient.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbDoctor.SelectedValue == null)
            {
                MessageBox.Show("Please select a doctor.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpAppointment.Value < DateTime.Now)
            {
                MessageBox.Show("Appointment date cannot be in the past.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int patientId = preSelectedPatientId ?? Convert.ToInt32(cmbPatient.SelectedValue);
                int doctorId = Convert.ToInt32(cmbDoctor.SelectedValue);

                string query = @"INSERT INTO Appointments 
                           (patient_id, doctor_id, appointment_date, notes, status, created_by)
                           VALUES (@patientId, @doctorId, @date, @notes, 'Scheduled', @createdBy)";

                DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@patientId", patientId),
                    new MySqlParameter("@doctorId", doctorId),
                    new MySqlParameter("@date", dtpAppointment.Value),
                    new MySqlParameter("@notes", txtNotes.Text.Trim()),
                    new MySqlParameter("@createdBy", createdByUserId));

                MessageBox.Show("Appointment scheduled successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}