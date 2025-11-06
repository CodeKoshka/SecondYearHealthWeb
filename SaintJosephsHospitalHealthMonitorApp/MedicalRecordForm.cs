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
    public partial class MedicalRecordForm : Form
    {
        private int patientId;
        private int doctorId;
        private string patientName;

        public MedicalRecordForm(int pId, int dId, string pName)
        {
            patientId = pId;
            doctorId = dId;
            patientName = pName;
            InitializeComponent();
            lblPatientName.Text = $"Patient: {patientName}";
            LoadPatientInfo();
            LoadVisitTypes();
        }

        private void LoadPatientInfo()
        {
            try
            {
                string query = @"
                    SELECT u.name, u.age, u.gender, u.email,
                           p.blood_type, p.allergies, p.medical_history, 
                           p.phone_number, p.emergency_contact
                    FROM Patients p
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE p.patient_id = @patientId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@patientId", patientId));

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblPatientAge.Text = $"Age: {row["age"]}";
                    lblPatientGender.Text = $"Gender: {row["gender"]}";
                    lblBloodType.Text = $"Blood Type: {row["blood_type"]}";
                    lblAllergies.Text = $"Known Allergies: {row["allergies"]}";
                    txtMedicalHistory.Text = row["medical_history"]?.ToString() ?? "No previous medical history on record.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient info: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadVisitTypes()
        {
            cmbVisitType.Items.Clear();
            cmbVisitType.Items.AddRange(new string[] {
                "Consultation",
                "Follow-up",
                "Emergency",
                "Routine Check-up",
                "Surgical Procedure",
                "Laboratory Follow-up",
                "Vaccination",
                "Other"
            });
            cmbVisitType.SelectedIndex = 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtChiefComplaint.Text))
            {
                MessageBox.Show("Please enter the chief complaint.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                MessageBox.Show("Please enter a diagnosis.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string clinicalNotes = BuildClinicalNotes();

                string query = @"INSERT INTO MedicalRecords 
                               (patient_id, doctor_id, diagnosis, prescription, lab_tests, visit_type)
                               VALUES (@patientId, @doctorId, @diagnosis, @prescription, @labTests, @visitType)";

                DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@patientId", patientId),
                    new MySqlParameter("@doctorId", doctorId),
                    new MySqlParameter("@diagnosis", clinicalNotes),
                    new MySqlParameter("@prescription", txtPrescription.Text),
                    new MySqlParameter("@labTests", txtLabTests.Text),
                    new MySqlParameter("@visitType", cmbVisitType.SelectedItem.ToString()));

                MessageBox.Show("Medical record saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string BuildClinicalNotes()
        {
            StringBuilder notes = new StringBuilder();

            notes.AppendLine("=== MEDICAL RECORD ===");
            notes.AppendLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm}");
            notes.AppendLine($"Visit Type: {cmbVisitType.SelectedItem}");
            notes.AppendLine();

            notes.AppendLine("CHIEF COMPLAINT:");
            notes.AppendLine(txtChiefComplaint.Text);
            notes.AppendLine();

            if (!string.IsNullOrWhiteSpace(txtVitalSigns.Text))
            {
                notes.AppendLine("VITAL SIGNS:");
                notes.AppendLine(txtVitalSigns.Text);
                notes.AppendLine();
            }

            if (!string.IsNullOrWhiteSpace(txtPhysicalExam.Text))
            {
                notes.AppendLine("PHYSICAL EXAMINATION:");
                notes.AppendLine(txtPhysicalExam.Text);
                notes.AppendLine();
            }

            notes.AppendLine("DIAGNOSIS:");
            notes.AppendLine(txtDiagnosis.Text);
            notes.AppendLine();

            if (!string.IsNullOrWhiteSpace(txtTreatmentPlan.Text))
            {
                notes.AppendLine("TREATMENT PLAN:");
                notes.AppendLine(txtTreatmentPlan.Text);
                notes.AppendLine();
            }

            if (!string.IsNullOrWhiteSpace(txtFollowUp.Text))
            {
                notes.AppendLine("FOLLOW-UP INSTRUCTIONS:");
                notes.AppendLine(txtFollowUp.Text);
            }

            return notes.ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnTemplateRoutine_Click(object sender, EventArgs e)
        {
            txtVitalSigns.Text = @"BP: ___/___  HR: ___  RR: ___  Temp: ___°C  SpO2: ___%  Weight: ___ kg  Height: ___ cm";
            txtPhysicalExam.Text = @"General: Alert and oriented, no acute distress
HEENT: Normal
Cardiovascular: Regular rhythm, no murmurs
Respiratory: Clear bilateral breath sounds
Abdomen: Soft, non-tender
Extremities: No edema";
        }

        private void BtnTemplateEmergency_Click(object sender, EventArgs e)
        {
            txtVitalSigns.Text = @"BP: ___/___  HR: ___  RR: ___  Temp: ___°C  SpO2: ___%  GCS: ___";
            txtPhysicalExam.Text = @"EMERGENCY ASSESSMENT:
Primary Survey (ABCDE):
- Airway: 
- Breathing: 
- Circulation: 
- Disability: 
- Exposure: 

Secondary Survey: ";
        }
    }
}