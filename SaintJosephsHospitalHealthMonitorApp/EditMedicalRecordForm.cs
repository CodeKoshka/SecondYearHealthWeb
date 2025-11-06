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
    public partial class EditMedicalRecordForm : Form
    {
        private int recordId;
        private string originalDiagnosis;
        private string patientName;
        private DateTime recordDate;

        public EditMedicalRecordForm(int rId, string diagnosis, string prescription, string labTests)
        {
            recordId = rId;
            originalDiagnosis = diagnosis;
            InitializeComponent();
            LoadRecordDetails();
            ParseAndPopulateFields(diagnosis, prescription, labTests);
        }

        // Load complete record information including patient details
        private void LoadRecordDetails()
        {
            try
            {
                string query = @"
                    SELECT m.record_date, m.visit_type, u.name AS patient_name,
                           u.age, u.gender, p.blood_type, p.allergies
                    FROM MedicalRecords m
                    INNER JOIN Patients p ON m.patient_id = p.patient_id
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE m.record_id = @recordId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@recordId", recordId));

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    patientName = row["patient_name"].ToString();
                    recordDate = Convert.ToDateTime(row["record_date"]);

                    lblPatientName.Text = $"Patient: {patientName}";
                    lblRecordDate.Text = $"Record Date: {recordDate:MMMM dd, yyyy HH:mm}";
                    lblPatientAge.Text = $"Age: {row["age"]}";
                    lblPatientGender.Text = $"Gender: {row["gender"]}";
                    lblBloodType.Text = $"Blood Type: {row["blood_type"]}";
                    lblAllergies.Text = $"⚠️ Known Allergies: {row["allergies"]}";

                    // Set visit type if exists
                    if (row["visit_type"] != DBNull.Value)
                    {
                        string visitType = row["visit_type"].ToString();
                        if (cmbVisitType.Items.Contains(visitType))
                        {
                            cmbVisitType.SelectedItem = visitType;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading record details: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ParseAndPopulateFields(string diagnosis, string prescription, string labTests)
        {
            try
            {
                if (diagnosis.Contains("=== MEDICAL RECORD ==="))
                {
                    ParseStructuredNotes(diagnosis);
                }
                else
                {
                    txtDiagnosis.Text = diagnosis;
                }

                txtPrescription.Text = prescription;
                txtLabTests.Text = labTests;
            }
            catch (Exception ex)
            {
                txtDiagnosis.Text = diagnosis;
                txtPrescription.Text = prescription;
                txtLabTests.Text = labTests;
            }
        }

        private void ParseStructuredNotes(string notes)
        {
            var sections = new Dictionary<string, string>();
            string currentSection = "";
            StringBuilder currentContent = new StringBuilder();

            var lines = notes.Split(new[] { '\r', '\n' }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                if (line.StartsWith("CHIEF COMPLAINT:") ||
                    line.StartsWith("VITAL SIGNS:") ||
                    line.StartsWith("PHYSICAL EXAMINATION:") ||
                    line.StartsWith("DIAGNOSIS:") ||
                    line.StartsWith("TREATMENT PLAN:") ||
                    line.StartsWith("FOLLOW-UP INSTRUCTIONS:"))
                {
                    if (!string.IsNullOrEmpty(currentSection))
                    {
                        sections[currentSection] = currentContent.ToString().Trim();
                    }

                    currentSection = line.TrimEnd(':');
                    currentContent.Clear();
                }
                else if (!string.IsNullOrEmpty(currentSection) &&
                         !line.StartsWith("===") &&
                         !line.StartsWith("Date:") &&
                         !line.StartsWith("Visit Type:"))
                {
                    currentContent.AppendLine(line);
                }
            }

            if (!string.IsNullOrEmpty(currentSection))
            {
                sections[currentSection] = currentContent.ToString().Trim();
            }

            if (sections.ContainsKey("CHIEF COMPLAINT"))
                txtChiefComplaint.Text = sections["CHIEF COMPLAINT"];
            if (sections.ContainsKey("VITAL SIGNS"))
                txtVitalSigns.Text = sections["VITAL SIGNS"];
            if (sections.ContainsKey("PHYSICAL EXAMINATION"))
                txtPhysicalExam.Text = sections["PHYSICAL EXAMINATION"];
            if (sections.ContainsKey("DIAGNOSIS"))
                txtDiagnosis.Text = sections["DIAGNOSIS"];
            if (sections.ContainsKey("TREATMENT PLAN"))
                txtTreatmentPlan.Text = sections["TREATMENT PLAN"];
            if (sections.ContainsKey("FOLLOW-UP INSTRUCTIONS"))
                txtFollowUp.Text = sections["FOLLOW-UP INSTRUCTIONS"];
        }

        private string BuildClinicalNotes()
        {
            StringBuilder notes = new StringBuilder();

            notes.AppendLine("=== MEDICAL RECORD (AMENDED) ===");
            notes.AppendLine($"Original Date: {recordDate:yyyy-MM-dd HH:mm}");
            notes.AppendLine($"Amended Date: {DateTime.Now:yyyy-MM-dd HH:mm}");
            notes.AppendLine($"Visit Type: {cmbVisitType.SelectedItem}");
            notes.AppendLine();

            if (!string.IsNullOrWhiteSpace(txtChiefComplaint.Text))
            {
                notes.AppendLine("CHIEF COMPLAINT:");
                notes.AppendLine(txtChiefComplaint.Text);
                notes.AppendLine();
            }

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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                MessageBox.Show("Diagnosis is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Save changes to this medical record?\n\n" +
                "Note: This will create an amendment log entry.",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string clinicalNotes = BuildClinicalNotes();

                string query = @"UPDATE medicalrecords 
                               SET diagnosis = @diagnosis, 
                                   prescription = @prescription, 
                                   lab_tests = @labTests,
                                   visit_type = @visitType
                               WHERE record_id = @recordId";

                DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@diagnosis", clinicalNotes),
                    new MySqlParameter("@prescription", txtPrescription.Text),
                    new MySqlParameter("@labTests", txtLabTests.Text),
                    new MySqlParameter("@visitType", cmbVisitType.SelectedItem.ToString()),
                    new MySqlParameter("@recordId", recordId));

                MessageBox.Show("Medical record updated successfully!", "Success",
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