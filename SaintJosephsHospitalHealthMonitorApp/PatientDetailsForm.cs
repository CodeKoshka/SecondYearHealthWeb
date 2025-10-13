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
    public partial class PatientDetailsForm : Form
    {
        private int patientId;

        public PatientDetailsForm(int pId)
        {
            patientId = pId;
            InitializeComponent();
            LoadPatientDetails();
        }
        //nothing much here aswell just to check the patients details
        private void LoadPatientDetails()
        {
            try
            {
                //this loads patient basic info
                string query = @"
                    SELECT u.name, u.age, u.gender, u.email, 
                           p.blood_type, p.allergies, p.phone_number, 
                           p.emergency_contact, p.medical_history
                    FROM Patients p
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE p.patient_id = @patientId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@patientId", patientId));

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblName.Text = $"Name: {row["name"]}";
                    lblAge.Text = $"Age: {row["age"]}";
                    lblGender.Text = $"Gender: {row["gender"]}";
                    lblEmail.Text = $"Email: {row["email"]}";
                    lblBloodType.Text = $"Blood Type: {row["blood_type"]}";
                    lblPhone.Text = $"Phone: {row["phone_number"]}";
                    lblEmergency.Text = $"Emergency Contact: {row["emergency_contact"]}";
                    txtAllergies.Text = row["allergies"].ToString();
                    txtMedicalHistory.Text = row["medical_history"].ToString();
                }

                //this loads medical records
                string recordsQuery = @"
                    SELECT m.record_date, u.name AS Doctor, m.diagnosis
                    FROM MedicalRecords m
                    INNER JOIN Doctors d ON m.doctor_id = d.doctor_id
                    INNER JOIN Users u ON d.user_id = u.user_id
                    WHERE m.patient_id = @patientId
                    ORDER BY m.record_date DESC";

                dgvRecords.DataSource = DatabaseHelper.ExecuteQuery(recordsQuery,
                    new MySqlParameter("@patientId", patientId));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading details: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}