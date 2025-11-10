using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class MedicalRecordForm : Form
    {
        private int patientId;
        private int doctorId;
        private string patientName;
        private int? queueId;
        private string intakeInformation;
        private int? recordId;
        private bool isViewMode;
        private int currentUserId;
        private string currentUserRole;

        public MedicalRecordForm(int pId, int dId, string pName, int qId)
        {
            patientId = pId;
            doctorId = dId;
            patientName = pName;
            queueId = qId;
            isViewMode = false;
            InitializeComponent();
            OptimizeFormSize();
            lblDate.Text = $"Date: {DateTime.Now:MM/dd/yy}";
            LoadPatientInfo();
            LoadPreviousRecordsCount();
            LoadIntakeData(qId);
        }

        public MedicalRecordForm(int pId, int dId, string pName)
        {
            patientId = pId;
            doctorId = dId;
            patientName = pName;
            queueId = null;
            isViewMode = false;
            InitializeComponent();
            OptimizeFormSize();
            lblDate.Text = $"Date: {DateTime.Now:MM/dd/yy}";
            LoadPatientInfo();
            LoadPreviousRecordsCount();
        }

        public static MedicalRecordForm CreateViewMode(int rId, int userId, string userRole)
        {
            return new MedicalRecordForm(rId, userId, userRole, true);
        }

        private MedicalRecordForm(int rId, int userId, string userRole, bool viewMode)
        {
            recordId = rId;
            currentUserId = userId;
            currentUserRole = userRole;
            isViewMode = true;
            InitializeComponent();

            ConfigureForViewMode();
            LoadExistingMedicalRecord();
        }

        private void OptimizeFormSize()
        {
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(1100, 1550);
            this.ClientSize = new Size(1120, 700);
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;

            int yPos = 100;
            int spacing = 10;

            if (panelCardiacSymptoms != null)
            {
                panelCardiacSymptoms.Top = yPos;
                panelCardiacSymptoms.Height = 120;
                yPos += panelCardiacSymptoms.Height + spacing;
            }

            if (panelCauseProblem != null)
            {
                panelCauseProblem.Top = yPos;
                panelCauseProblem.Height = 120;
                yPos += panelCauseProblem.Height + spacing;
            }

            if (panelPastHistory != null)
            {
                panelPastHistory.Top = yPos;
                panelPastHistory.Height = 240;
                yPos += panelPastHistory.Height + spacing;
            }

            if (panelSurgeries != null)
            {
                panelSurgeries.Top = yPos;
                panelSurgeries.Height = 130; 
                yPos += panelSurgeries.Height + spacing;
            }

            if (panelMedications != null)
            {
                panelMedications.Top = yPos;
                panelMedications.Height = 160;
                yPos += panelMedications.Height + spacing;
            }

            if (panelAllergies != null)
            {
                panelAllergies.Top = yPos;
                panelAllergies.Height = 110;
                yPos += panelAllergies.Height + spacing;
            }

            if (panelAdditional != null)
            {
                panelAdditional.Top = yPos;
                panelAdditional.Height = 130;
                yPos += panelAdditional.Height + spacing;
            }

            if (panelSignature != null)
            {
                panelSignature.Top = yPos;
                yPos += panelSignature.Height + spacing;
            }

            if (btnSave != null)
            {
                btnSave.Top = yPos;
                btnSave.Height = 50;
            }

            if (btnCancel != null)
            {
                btnCancel.Top = yPos;
                btnCancel.Height = 50;
            }
            AdjustTextBoxSizes();
        }

        private void AdjustTextBoxSizes()
        {
            if (txtSurgeryDetails != null)
                txtSurgeryDetails.Height = 50;

            if (txtMedications != null)
                txtMedications.Height = 80;

            if (txtAdditionalComments != null)
                txtAdditionalComments.Height = 75;
        }


        private void ConfigureForViewMode()
        {
            this.Text = "Medical Record - St. Joseph's Cardiac Hospital";
            this.ClientSize = new Size(1120, 700);
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.MaximizeBox = true;

            panelHeader.BackColor = Color.FromArgb(44, 62, 80);
            panelHeader.Height = 150;
            lblTitle.Text = "📋 MEDICAL RECORD - ST. JOSEPH'S CARDIAC HOSPITAL";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.AutoSize = true;

            int headerDiff = 150 - 80;

            if (panelCardiacSymptoms != null)
                panelCardiacSymptoms.Top += headerDiff;
            if (panelCauseProblem != null)
                panelCauseProblem.Top += headerDiff;
            if (panelPastHistory != null)
                panelPastHistory.Top += headerDiff;
            if (panelSurgeries != null)
                panelSurgeries.Top += headerDiff;
            if (panelMedications != null)
                panelMedications.Top += headerDiff;
            if (panelAllergies != null)
                panelAllergies.Top += headerDiff;
            if (panelAdditional != null)
                panelAdditional.Top += headerDiff;
            if (panelSignature != null)
                panelSignature.Top += headerDiff;

            chkChestPain.Enabled = false;
            chkShortBreath.Enabled = false;
            chkPalpitations.Enabled = false;
            chkDizziness.Enabled = false;
            chkFatigue.Enabled = false;
            chkSwelling.Enabled = false;
            chkIrregularHeartbeat.Enabled = false;
            chkFainting.Enabled = false;
            chkCarAccident.Enabled = false;
            chkWorkInjury.Enabled = false;
            chkGradualOnset.Enabled = false;
            chkOther.Enabled = false;
            txtOtherCause.ReadOnly = true;
            txtProblemStarted.ReadOnly = true;
            chkBreathingProblems.Enabled = false;
            chkPregnant.Enabled = false;
            chkHeartProblems.Enabled = false;
            chkCurrentWound.Enabled = false;
            chkPacemaker.Enabled = false;
            chkDiabetes.Enabled = false;
            chkTumorCancer.Enabled = false;
            chkStroke.Enabled = false;
            chkBoneJoint.Enabled = false;
            chkKidneyProblems.Enabled = false;
            chkGallbladderLiver.Enabled = false;
            chkElectricalImplants.Enabled = false;
            chkAnxietyAttacks.Enabled = false;
            chkSleepApnea.Enabled = false;
            chkDepression.Enabled = false;
            chkBowelBladder.Enabled = false;
            chkAlcoholUse.Enabled = false;
            chkDrugUse.Enabled = false;
            chkSmoking.Enabled = false;
            chkHeadaches.Enabled = false;
            chkHighBloodPressure.Enabled = false;
            chkHighCholesterol.Enabled = false;
            chkNoSurgeries.Enabled = false;
            chkYesSurgery.Enabled = false;
            txtSurgeryDetails.ReadOnly = true;
            chkNoMedication.Enabled = false;
            txtMedications.ReadOnly = true;
            chkNoKnownAllergies.Enabled = false;
            chkLatexAllergy.Enabled = false;
            chkIodineAllergy.Enabled = false;
            chkBromineAllergy.Enabled = false;
            txtOtherAllergies.ReadOnly = true;
            txtAdditionalComments.ReadOnly = true;
            txtDoctorSignature.ReadOnly = true;

            btnSave.Visible = false;

            btnCancel.Text = "✓ CLOSE";
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.Top += headerDiff;
            btnCancel.Location = new Point(btnSave.Location.X + (btnSave.Width - btnCancel.Width) / 2, btnCancel.Top);

            Button btnPrint = new Button
            {
                Text = "🖨️ PRINT RECORD",
                Location = new Point(btnSave.Location.X, btnCancel.Top - 70),
                Size = new Size(200, 50),
                BackColor = Color.FromArgb(66, 153, 225),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Name = "btnPrint"
            };
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.Click += (s, e) => MessageBox.Show("Print functionality - connect to your printer", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Controls.Add(btnPrint);
        }

        private void LoadExistingMedicalRecord()
        {
            try
            {
                string query = @"
                    SELECT 
                        m.diagnosis,
                        m.prescription,
                        m.record_date,
                        u1.name AS patient_name,
                        u1.age,
                        u1.gender,
                        u1.email,
                        p.blood_type,
                        p.phone_number,
                        p.emergency_contact,
                        u2.name AS doctor_name
                    FROM MedicalRecords m
                    INNER JOIN Patients p ON m.patient_id = p.patient_id
                    INNER JOIN Users u1 ON p.user_id = u1.user_id
                    INNER JOIN Doctors d ON m.doctor_id = d.doctor_id
                    INNER JOIN Users u2 ON d.user_id = u2.user_id
                    WHERE m.record_id = @recordId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@recordId", recordId));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Medical record not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                DataRow row = dt.Rows[0];
                string fullRecord = row["diagnosis"].ToString();
                patientName = row["patient_name"].ToString();
                DateTime recordDate = Convert.ToDateTime(row["record_date"]);

                this.Text = $"Medical Record - {patientName} - {recordDate:MM/dd/yyyy}";

                string age = row["age"].ToString();
                string gender = row["gender"].ToString();
                string bloodType = row["blood_type"]?.ToString() ?? "Not recorded";
                string phone = row["phone_number"]?.ToString() ?? "--";
                string email = row["email"]?.ToString() ?? "--";
                string emergencyContact = row["emergency_contact"]?.ToString() ?? "--";
                string doctorName = row["doctor_name"].ToString();

                Label lblPatientInfo = new Label
                {
                    Text = $"Patient: {patientName}",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(20, 50),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };

                Label lblAge = new Label
                {
                    Text = $"Age: {age}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(200, 220, 240),
                    Location = new Point(20, 80),
                    Size = new Size(180, 20),
                    BackColor = Color.Transparent
                };
                panelHeader.Controls.Add(lblAge);

                Label lblGender = new Label
                {
                    Text = $"| Gender: {gender}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(200, 220, 240),
                    Location = new Point(210, 80),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                panelHeader.Controls.Add(lblGender);

                Label lblPhone = new Label
                {
                    Text = $"Phone: {phone}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(200, 220, 240),
                    Location = new Point(20, 100),
                    Size = new Size(180, 20),
                    BackColor = Color.Transparent
                };
                panelHeader.Controls.Add(lblPhone);

                Label lblEmail = new Label
                {
                    Text = $"| Email: {email}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(200, 220, 240),
                    Location = new Point(210, 100),
                    Size = new Size(260, 20),
                    BackColor = Color.Transparent
                };
                panelHeader.Controls.Add(lblEmail);

                Label lblBloodType = new Label
                {
                    Text = $"Blood Type: {bloodType}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(200, 220, 240),
                    Location = new Point(480, 80),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                panelHeader.Controls.Add(lblBloodType);

                Label lblEmergency = new Label
                {
                    Text = $"Emergency Contact: {emergencyContact}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(200, 220, 240),
                    Location = new Point(480, 100),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                panelHeader.Controls.Add(lblEmergency);

                Label lblRecordDate = new Label
                {
                    Text = $"Record Date: {recordDate:MM/dd/yyyy HH:mm}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(200, 220, 240),
                    Location = new Point(800, 80),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                panelHeader.Controls.Add(lblRecordDate);

                Label lblDoctor = new Label
                {
                    Text = $"Attended Physician: Dr. {doctorName}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(200, 220, 240),
                    Location = new Point(800, 100),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                panelHeader.Controls.Add(lblDoctor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading record: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadPreviousRecordsCount()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM MedicalRecords WHERE patient_id = @patientId";
                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@patientId", patientId)));

                Label lblRecordCount = new Label
                {
                    Text = count == 0 ? "⚕️ NEW PATIENT - First Medical Record" : $"✓ {count} Previous Medical Record(s) on File",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = count == 0 ? Color.FromArgb(220, 53, 69) : Color.FromArgb(72, 187, 120),
                    Location = new Point(650, 60),
                    AutoSize = true
                };

                this.Controls.Add(lblRecordCount);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading record count: " + ex.Message);
            }
        }

        private void LoadIntakeData(int qId)
        {
            try
            {
                string query = @"
                    SELECT reason_for_visit, priority, registered_time
                    FROM PatientQueue 
                    WHERE queue_id = @queueId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@queueId", qId));

                if (dt.Rows.Count > 0)
                {
                    intakeInformation = dt.Rows[0]["reason_for_visit"]?.ToString() ?? "";

                    string reasonText = intakeInformation;
                    if (reasonText.Contains("CHIEF COMPLAINT"))
                    {
                        var lines = reasonText.Split('\n');
                        bool capture = false;
                        StringBuilder complaint = new StringBuilder();

                        foreach (var line in lines)
                        {
                            if (line.Contains("CHIEF COMPLAINT") || line.Contains("REASON FOR VISIT"))
                            {
                                capture = true;
                                continue;
                            }
                            if (capture && (line.Contains("SYMPTOMS") || line.Contains("MEDICATIONS") || line.Contains("Priority")))
                                break;
                            if (capture && !string.IsNullOrWhiteSpace(line))
                                complaint.AppendLine(line.Trim());
                        }

                        txtProblemStarted.Text = complaint.ToString().Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading intake data: " + ex.Message);
            }
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

                    Label lblPatientInfo = new Label
                    {
                        Text = $"Name: {row["name"]}    Date: {DateTime.Now:M/d/yy}",
                        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                        Location = new Point(20, 80),
                        AutoSize = true
                    };

                    Label lblDemographics = new Label
                    {
                        Text = $"Age: {row["age"]} | Gender: {row["gender"]} | Blood Type: {row["blood_type"]}",
                        Font = new Font("Segoe UI", 10F),
                        Location = new Point(20, 105),
                        ForeColor = Color.FromArgb(74, 85, 104),
                        AutoSize = true
                    };

                    this.Controls.AddRange(new Control[] { lblPatientInfo, lblDemographics });

                    string allergies = row["allergies"]?.ToString() ?? "None";
                    if (!string.IsNullOrEmpty(allergies) && allergies.ToLower() != "none")
                    {
                        txtOtherAllergies.Text = allergies;
                        chkNoKnownAllergies.Checked = false;
                    }
                    else
                    {
                        chkNoKnownAllergies.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient info: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (isViewMode)
            {
                this.Close();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDoctorSignature.Text))
            {
                MessageBox.Show("Doctor signature is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDoctorSignature.Focus();
                return;
            }

            try
            {
                string completeMedicalRecord = BuildCompleteMedicalRecord();

                string query = @"INSERT INTO MedicalRecords 
                               (patient_id, doctor_id, diagnosis, prescription, lab_tests, visit_type)
                               VALUES (@patientId, @doctorId, @diagnosis, @prescription, @labTests, @visitType)";

                DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@patientId", patientId),
                    new MySqlParameter("@doctorId", doctorId),
                    new MySqlParameter("@diagnosis", completeMedicalRecord),
                    new MySqlParameter("@prescription", BuildPrescriptionList()),
                    new MySqlParameter("@labTests", ""),
                    new MySqlParameter("@visitType", DetermineVisitType()));

                if (queueId.HasValue)
                {
                    string clearIntake = @"UPDATE PatientQueue 
                                         SET reason_for_visit = 'Medical record completed and archived' 
                                         WHERE queue_id = @queueId";
                    DatabaseHelper.ExecuteNonQuery(clearIntake,
                        new MySqlParameter("@queueId", queueId.Value));
                }

                MessageBox.Show(
                    "✓ Complete medical record saved successfully!\n\n" +
                    "The record includes:\n" +
                    "• Patient intake information (from receptionist)\n" +
                    "• Complete cardiac assessment (from doctor)\n\n" +
                    "This comprehensive record is now permanently saved.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving medical record: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildCompleteMedicalRecord()
        {
            StringBuilder record = new StringBuilder();

            record.AppendLine("SECTION 2: PHYSICIAN'S MEDICAL ASSESSMENT");
            record.AppendLine();

            record.AppendLine("CARDIAC SYMPTOMS ASSESSMENT:");
            var cardiacSymptoms = new List<string>();
            if (chkChestPain.Checked) cardiacSymptoms.Add("Chest Pain/Discomfort");
            if (chkShortBreath.Checked) cardiacSymptoms.Add("Shortness of Breath");
            if (chkPalpitations.Checked) cardiacSymptoms.Add("Heart Palpitations");
            if (chkDizziness.Checked) cardiacSymptoms.Add("Dizziness/Lightheaded");
            if (chkFatigue.Checked) cardiacSymptoms.Add("Unusual Fatigue");
            if (chkSwelling.Checked) cardiacSymptoms.Add("Swelling (Legs/Ankles)");
            if (chkIrregularHeartbeat.Checked) cardiacSymptoms.Add("Irregular Heartbeat");
            if (chkFainting.Checked) cardiacSymptoms.Add("Fainting Episodes");

            if (cardiacSymptoms.Count > 0)
            {
                foreach (var symptom in cardiacSymptoms)
                {
                    record.AppendLine($"  ☑ {symptom}");
                }
            }
            else
            {
                record.AppendLine("  None reported");
            }
            record.AppendLine();

            record.AppendLine("CAUSE OF CURRENT PROBLEM:");
            if (chkCarAccident.Checked) record.AppendLine("☑ Car Accident");
            if (chkWorkInjury.Checked) record.AppendLine("☑ Work Injury");
            if (chkGradualOnset.Checked) record.AppendLine("☑ Gradual Onset");
            if (chkOther.Checked) record.AppendLine($"☑ Other: {txtOtherCause?.Text}");
            record.AppendLine();

            record.AppendLine($"When did your problem start: {txtProblemStarted.Text}");
            record.AppendLine();

            record.AppendLine("PAST MEDICAL HISTORY:");
            var checkedConditions = new List<string>();
            if (chkBreathingProblems.Checked) checkedConditions.Add("Breathing Problems");
            if (chkPregnant.Checked) checkedConditions.Add("Pregnant");
            if (chkHeartProblems.Checked) checkedConditions.Add("Heart Problems");
            if (chkCurrentWound.Checked) checkedConditions.Add("Current Wound/Skin Problems");
            if (chkPacemaker.Checked) checkedConditions.Add("Pacemaker");
            if (chkDiabetes.Checked) checkedConditions.Add("Diabetes");
            if (chkTumorCancer.Checked) checkedConditions.Add("Tumor/Cancer");
            if (chkStroke.Checked) checkedConditions.Add("Stroke");
            if (chkBoneJoint.Checked) checkedConditions.Add("Bone/Joint Problems");
            if (chkKidneyProblems.Checked) checkedConditions.Add("Kidney Problems");
            if (chkGallbladderLiver.Checked) checkedConditions.Add("Gallbladder/Liver");
            if (chkElectricalImplants.Checked) checkedConditions.Add("Electrical Implants");
            if (chkAnxietyAttacks.Checked) checkedConditions.Add("Anxiety Attacks");
            if (chkSleepApnea.Checked) checkedConditions.Add("Sleep Apnea");
            if (chkDepression.Checked) checkedConditions.Add("Depression");
            if (chkBowelBladder.Checked) checkedConditions.Add("Bowel/Bladder");
            if (chkAlcoholUse.Checked) checkedConditions.Add("History of Heavy Alcohol Use");
            if (chkDrugUse.Checked) checkedConditions.Add("Drug Use");
            if (chkSmoking.Checked) checkedConditions.Add("Smoking");
            if (chkHeadaches.Checked) checkedConditions.Add("Headaches");
            if (chkHighBloodPressure.Checked) checkedConditions.Add("High Blood Pressure");
            if (chkHighCholesterol.Checked) checkedConditions.Add("High Cholesterol");

            if (checkedConditions.Count > 0)
            {
                foreach (var condition in checkedConditions)
                {
                    record.AppendLine($"  ☑ {condition}");
                }
            }
            else
            {
                record.AppendLine("  None reported");
            }
            record.AppendLine();

            record.AppendLine("SURGERIES/HOSPITALIZATIONS:");
            if (chkNoSurgeries.Checked)
            {
                record.AppendLine("  ☑ No Surgeries");
            }
            else if (chkYesSurgery.Checked)
            {
                record.AppendLine("  ☑ Yes (Details below)");
                record.AppendLine($"  {txtSurgeryDetails.Text}");
            }
            record.AppendLine();

            record.AppendLine("CURRENT MEDICATIONS:");
            if (chkNoMedication.Checked)
            {
                record.AppendLine("  ☑ No Medication");
            }
            else if (!string.IsNullOrWhiteSpace(txtMedications.Text))
            {
                var medicationLines = txtMedications.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in medicationLines)
                {
                    record.AppendLine($"  • {line.Trim()}");
                }
            }
            record.AppendLine();

            record.AppendLine("ALLERGIES:");
            if (chkNoKnownAllergies.Checked)
            {
                record.AppendLine("  ☑ No known allergies");
            }
            else
            {
                if (chkLatexAllergy.Checked) record.AppendLine("  ☑ Latex");
                if (chkIodineAllergy.Checked) record.AppendLine("  ☑ Iodine");
                if (chkBromineAllergy.Checked) record.AppendLine("  ☑ Bromine");
                if (!string.IsNullOrWhiteSpace(txtOtherAllergies.Text))
                {
                    record.AppendLine($"  Other: {txtOtherAllergies.Text}");
                }
            }
            record.AppendLine();

            if (!string.IsNullOrWhiteSpace(txtAdditionalComments.Text))
            {
                record.AppendLine("DOCTOR'S NOTES / ADDITIONAL COMMENTS:");
                record.AppendLine($"  {txtAdditionalComments.Text}");
                record.AppendLine();
            }

            record.AppendLine($"Physician Signature: {txtDoctorSignature.Text}");
            record.AppendLine($"Assessment Date: {DateTime.Now:MM/dd/yyyy HH:mm}");

            return record.ToString();
        }

        private string BuildPrescriptionList()
        {
            StringBuilder rx = new StringBuilder();

            if (chkNoMedication.Checked || string.IsNullOrWhiteSpace(txtMedications.Text))
            {
                return "No medications prescribed.";
            }

            var medicationLines = txtMedications.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int count = 1;
            foreach (var line in medicationLines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    rx.AppendLine($"{count}. {line.Trim()}");
                    rx.AppendLine();
                    count++;
                }
            }

            return rx.ToString();
        }

        private string DetermineVisitType()
        {
            if (chkCarAccident.Checked || chkWorkInjury.Checked)
                return "Emergency";
            if (chkHeartProblems.Checked || chkBreathingProblems.Checked ||
                chkChestPain.Checked || chkShortBreath.Checked || chkPalpitations.Checked)
                return "Cardiac Consultation";
            return "Routine Check-up";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (isViewMode)
            {
                this.Close();
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel?\n\nAny unsaved changes will be lost.",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}