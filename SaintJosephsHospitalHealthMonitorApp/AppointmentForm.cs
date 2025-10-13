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
    public partial class AppointmentForm : Form
    {
        private int? preSelectedPatientId;

        public AppointmentForm(int? patientId = null)
        {
            preSelectedPatientId = patientId;
            InitializeComponent();
            LoadDoctors();
            if (patientId == null)
                LoadPatients();
        }
        //this gets all patients with their user profiles
        private void LoadPatients()
        {
            string query = @"SELECT p.patient_id, u.name FROM Patients p
                           INNER JOIN Users u ON p.user_id = u.user_id";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cmbPatient.DisplayMember = "name";
            cmbPatient.ValueMember = "patient_id";
            cmbPatient.DataSource = dt;
        }
        //this gets the doctors with specialization appended to their name
        private void LoadDoctors()
        {
            string query = @"SELECT d.doctor_id, u.name + ' (' + d.specialization + ')' AS doctor_info
                           FROM Doctors d
                           INNER JOIN Users u ON d.user_id = u.user_id";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cmbDoctor.DisplayMember = "doctor_info";
            cmbDoctor.ValueMember = "doctor_id";
            cmbDoctor.DataSource = dt;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //this to make sure user selected a doctor
            if (cmbDoctor.SelectedValue == null)
            {
                MessageBox.Show("Please select a doctor.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                //this is if patient_id was provided beforehand it will use it 
                //Otherwise it will use a selected patient from dropdown
                int patientId = preSelectedPatientId ?? Convert.ToInt32(cmbPatient.SelectedValue);
                int doctorId = Convert.ToInt32(cmbDoctor.SelectedValue);

                //this inserts appointment with the "Scheduled" status by default
                string query = @"INSERT INTO Appointments (patient_id, doctor_id, appointment_date, notes, status)
                               VALUES (@patientId, @doctorId, @date, @notes, 'Scheduled')";

                //this execute the insert command with parameters to prevent SQL injection
                //(without this database breaks)
                DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@patientId", patientId),
                    new MySqlParameter("@doctorId", doctorId),
                    new MySqlParameter("@date", dtpAppointment.Value),
                    new MySqlParameter("@notes", txtNotes.Text));

                MessageBox.Show("Appointment scheduled successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}