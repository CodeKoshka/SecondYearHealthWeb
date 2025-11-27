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
        private bool isEditMode;
        private int editRecordId;

        public MedicalRecordForm(int pId, int dId, string pName, int qId)
        {
            patientId = pId;
            doctorId = dId;
            patientName = pName;
            queueId = qId;
            isViewMode = false;
            isEditMode = false;
            InitializeComponent();
            OptimizeFormSize();
            lblDate.Text = $"Date: {DateTime.Now:MM/dd/yy}";
            LoadPatientInfo();
            LoadPreviousRecordsCount();
            LoadIntakeData(qId);
            SetupEventHandlers();
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
            SetupEventHandlers();
        }

        public static MedicalRecordForm CreateViewMode(int rId, int userId, string userRole)
        {
            return new MedicalRecordForm(rId, userId, userRole, true);
        }

        public static MedicalRecordForm CreateEditMode(int recordId, int patientId, int doctorId, string patientName, int queueId)
        {
            return new MedicalRecordForm(recordId, patientId, doctorId, patientName, queueId, true);
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

        private MedicalRecordForm(int recId, int pId, int dId, string pName, int qId, bool editMode)
        {
            editRecordId = recId;
            patientId = pId;
            doctorId = dId;
            patientName = pName;
            queueId = qId;
            isEditMode = true;
            isViewMode = false;

            InitializeComponent();
            OptimizeFormSize();

            this.Text = "Edit Medical Record - St. Joseph's Cardiac Hospital";
            lblTitle.Text = "✏️ EDIT CARDIAC ASSESSMENT - MEDICAL REPORT";
            lblDate.Text = $"Date: {DateTime.Now:MM/dd/yy}";

            LoadPatientInfo();
            LoadExistingRecordForEdit(recId);
            SetupEventHandlers();
        }

        private void LoadExistingRecordForEdit(int recordId)
        {
            try
            {
                string query = @"
            SELECT 
            m.diagnosis,
            m.prescription,
            m.record_date
            FROM MedicalRecords m
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

                ParseAndLoadSavedData(fullRecord);

                Label lblEditWarning = new Label
                {
                    Text = "⚠️ EDITING CURRENT SESSION RECORD - Changes will update this medical record",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(243, 156, 18),
                    Location = new Point(650, 60),
                    AutoSize = true
                };
                this.Controls.Add(lblEditWarning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading record for editing: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void SetupEventHandlers()
        {
            txtMedications.Enter += TxtMedications_Enter;
            txtMedications.Leave += TxtMedications_Leave;

            chkNoMedication.CheckedChanged += ChkNoMedication_CheckedChanged;

            chkNoKnownAllergies.CheckedChanged += ChkNoKnownAllergies_CheckedChanged;
            chkLatexAllergy.CheckedChanged += AllergyCheckBox_CheckedChanged;
            chkIodineAllergy.CheckedChanged += AllergyCheckBox_CheckedChanged;
            chkBromineAllergy.CheckedChanged += AllergyCheckBox_CheckedChanged;
            txtOtherAllergies.TextChanged += TxtOtherAllergies_TextChanged;
        }

        private void TxtMedications_Enter(object sender, EventArgs e)
        {
            if (txtMedications.Text == "Enter medications, one per line:\nExample: Aspirin 81mg - Blood thinner\nLisinopril 10mg - Blood pressure")
            {
                txtMedications.Text = "";
                txtMedications.ForeColor = Color.Black;
            }
        }

        private void TxtMedications_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMedications.Text))
            {
                txtMedications.Text = "Enter medications, one per line:\nExample: Aspirin 81mg - Blood thinner\nLisinopril 10mg - Blood pressure";
                txtMedications.ForeColor = Color.Gray;
            }
        }

        private void ChkNoMedication_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoMedication.Checked)
            {
                txtMedications.Enabled = false;
                txtMedications.Text = "";
                txtMedications.BackColor = Color.FromArgb(240, 240, 240);
            }
            else
            {
                txtMedications.Enabled = true;
                txtMedications.BackColor = Color.White;
                if (string.IsNullOrWhiteSpace(txtMedications.Text))
                {
                    txtMedications.Text = "Enter medications, one per line:\nExample: Aspirin 81mg - Blood thinner\nLisinopril 10mg - Blood pressure";
                    txtMedications.ForeColor = Color.Gray;
                }
            }
        }

        private void ChkNoKnownAllergies_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoKnownAllergies.Checked)
            {
                chkLatexAllergy.Checked = false;
                chkIodineAllergy.Checked = false;
                chkBromineAllergy.Checked = false;

                chkLatexAllergy.Enabled = false;
                chkIodineAllergy.Enabled = false;
                chkBromineAllergy.Enabled = false;
                txtOtherAllergies.Enabled = false;
                txtOtherAllergies.Text = "";
                txtOtherAllergies.BackColor = Color.FromArgb(240, 240, 240);
            }
            else
            {
                chkLatexAllergy.Enabled = true;
                chkIodineAllergy.Enabled = true;
                chkBromineAllergy.Enabled = true;
                txtOtherAllergies.Enabled = true;
                txtOtherAllergies.BackColor = Color.White;
            }
        }

        private void ChkNoSurgeries_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkNoSurgeries.Checked)
                chkYesSurgery.Checked = false;
        }

        private void ChkYesSurgery_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkYesSurgery.Checked)
                chkNoSurgeries.Checked = false;
        }

        private void AllergyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((chkLatexAllergy.Checked || chkIodineAllergy.Checked || chkBromineAllergy.Checked) &&
                chkNoKnownAllergies.Checked)
            {
                chkNoKnownAllergies.Checked = false;
            }
        }

        private void TxtOtherAllergies_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOtherAllergies.Text) && chkNoKnownAllergies.Checked)
            {
                chkNoKnownAllergies.Checked = false;
            }
        }

        private void OptimizeFormSize()
        {
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(1100, 1320);
            this.ClientSize = new Size(1120, 700);
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            int yPos = 86;
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
                btnSave.Top = yPos + 10;
                btnSave.Height = 50;
            }

            if (btnCancel != null)
            {
                btnCancel.Top = yPos + 10;
                btnCancel.Height = 50;
            }
            AdjustTextBoxSizes();
        }

        private void AdjustTextBoxSizes()
        {
            if (txtSurgeryDetails != null)
                txtSurgeryDetails.Height = 50;

            if (txtMedications != null)
            {
                txtMedications.Height = 80;
                txtMedications.Text = "Enter medications, one per line:\nExample: Aspirin 81mg - Blood thinner\nLisinopril 10mg - Blood pressure";
                txtMedications.ForeColor = Color.Gray;
            }

            if (txtAdditionalComments != null)
                txtAdditionalComments.Height = 75;
        }

        private void ConfigureForViewMode()
        {
            this.Text = "Medical Record - St. Joseph's Cardiac Hospital";
            this.ClientSize = new Size(1120, 700);
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.MaximizeBox = false;

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
            btnCancel.BackColor = Color.FromArgb(52, 152, 219);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.Cursor = Cursors.Hand;

            btnCancel.Top += headerDiff + 10;
            btnCancel.Left = 30;
            btnCancel.Width = 1040;
            btnCancel.Height = 50;

            Button btnPrint = new Button
            {
                Text = "🖨️ PRINT RECORD",
                Location = new Point(30, btnCancel.Top - 60),
                Size = new Size(1040, 45),
                BackColor = Color.FromArgb(149, 165, 166),
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
                u1.date_of_birth,
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
                panelHeader.Controls.Add(lblPatientInfo);

                Label lblAge;
                if (row["date_of_birth"] != DBNull.Value)
                {
                    DateTime dob = Convert.ToDateTime(row["date_of_birth"]);
                    lblAge = new Label
                    {
                        Text = $"DOB: {dob:MM/dd/yyyy} (Age: {age})",
                        Font = new Font("Segoe UI", 9F),
                        ForeColor = Color.FromArgb(200, 220, 240),
                        Location = new Point(20, 80),
                        Size = new Size(250, 20),
                        BackColor = Color.Transparent
                    };
                }
                else
                {
                    lblAge = new Label
                    {
                        Text = $"Age: {age}",
                        Font = new Font("Segoe UI", 9F),
                        ForeColor = Color.FromArgb(200, 220, 240),
                        Location = new Point(20, 80),
                        Size = new Size(180, 20),
                        BackColor = Color.Transparent
                    };
                }
                panelHeader.Controls.Add(lblAge);

                Label lblGender = new Label
                {
                    Text = $"| Gender: {gender}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(200, 220, 240),
                    Location = new Point(280, 80),
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
                    Text = $"Attending Physician: Dr. {doctorName}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(200, 220, 240),
                    Location = new Point(800, 100),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                panelHeader.Controls.Add(lblDoctor);

                ParseAndLoadSavedData(fullRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading record: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ParseAndLoadSavedData(string diagnosis)
        {
            if (string.IsNullOrEmpty(diagnosis)) return;

            var lines = diagnosis.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Chest Pain"))
                    chkChestPain.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Shortness of Breath"))
                    chkShortBreath.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Palpitations"))
                    chkPalpitations.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Dizziness"))
                    chkDizziness.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Fatigue"))
                    chkFatigue.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Swelling"))
                    chkSwelling.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Irregular Heartbeat"))
                    chkIrregularHeartbeat.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Fainting"))
                    chkFainting.Checked = true;

                if (trimmedLine.Contains("☑ Car Accident"))
                    chkCarAccident.Checked = true;
                if (trimmedLine.Contains("☑ Work Injury"))
                    chkWorkInjury.Checked = true;
                if (trimmedLine.Contains("☑ Gradual Onset"))
                    chkGradualOnset.Checked = true;
                if (trimmedLine.Contains("☑ Other:"))
                {
                    chkOther.Checked = true;
                    txtOtherCause.Text = trimmedLine.Replace("☑ Other:", "").Trim();
                }

                if (trimmedLine.StartsWith("When did your problem start:"))
                {
                    txtProblemStarted.Text = trimmedLine.Replace("When did your problem start:", "").Trim();
                }

                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Breathing Problems"))
                    chkBreathingProblems.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Pregnant"))
                    chkPregnant.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Heart Problems"))
                    chkHeartProblems.Checked = true;
                if (trimmedLine.Contains("☑") && (trimmedLine.Contains("Wound") || trimmedLine.Contains("Skin Problems")))
                    chkCurrentWound.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Pacemaker"))
                    chkPacemaker.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Diabetes"))
                    chkDiabetes.Checked = true;
                if (trimmedLine.Contains("☑") && (trimmedLine.Contains("Tumor") || trimmedLine.Contains("Cancer")))
                    chkTumorCancer.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Stroke"))
                    chkStroke.Checked = true;
                if (trimmedLine.Contains("☑") && (trimmedLine.Contains("Bone") || trimmedLine.Contains("Joint")))
                    chkBoneJoint.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Kidney"))
                    chkKidneyProblems.Checked = true;
                if (trimmedLine.Contains("☑") && (trimmedLine.Contains("Gallbladder") || trimmedLine.Contains("Liver")))
                    chkGallbladderLiver.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Electrical Implants"))
                    chkElectricalImplants.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Anxiety"))
                    chkAnxietyAttacks.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Sleep Apnea"))
                    chkSleepApnea.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Depression"))
                    chkDepression.Checked = true;
                if (trimmedLine.Contains("☑") && (trimmedLine.Contains("Bowel") || trimmedLine.Contains("Bladder")))
                    chkBowelBladder.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Alcohol"))
                    chkAlcoholUse.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Drug Use"))
                    chkDrugUse.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Smoking"))
                    chkSmoking.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("Headaches"))
                    chkHeadaches.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("High Blood Pressure"))
                    chkHighBloodPressure.Checked = true;
                if (trimmedLine.Contains("☑") && trimmedLine.Contains("High Cholesterol"))
                    chkHighCholesterol.Checked = true;

                if (trimmedLine.Contains("☑ No Surgeries"))
                    chkNoSurgeries.Checked = true;
                if (trimmedLine.Contains("☑ Yes (Details below)"))
                    chkYesSurgery.Checked = true;

                if (trimmedLine.Contains("☑ No known allergies"))
                    chkNoKnownAllergies.Checked = true;
                if (trimmedLine.Contains("☑ Latex"))
                    chkLatexAllergy.Checked = true;
                if (trimmedLine.Contains("☑ Iodine"))
                    chkIodineAllergy.Checked = true;
                if (trimmedLine.Contains("☑ Bromine"))
                    chkBromineAllergy.Checked = true;

                if (trimmedLine.Contains("☑ No Medication"))
                    chkNoMedication.Checked = true;
            }

            ParseSurgeryDetails(diagnosis);
            ParseMedications(diagnosis);
            ParseOtherAllergies(diagnosis);
            ParseDoctorNotes(diagnosis);
            ParseDoctorSignature(diagnosis);
        }

        private void ParseSurgeryDetails(string diagnosis)
        {
            int surgeryStart = diagnosis.IndexOf("SURGERIES/HOSPITALIZATIONS:");
            int surgeryEnd = diagnosis.IndexOf("CURRENT MEDICATIONS:");

            if (surgeryStart >= 0 && surgeryEnd > surgeryStart)
            {
                string surgerySection = diagnosis.Substring(surgeryStart, surgeryEnd - surgeryStart);
                var lines = surgerySection.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                StringBuilder surgeryText = new StringBuilder();
                bool captureDetails = false;

                foreach (var line in lines)
                {
                    if (line.Contains("☑ Yes (Details below)"))
                    {
                        captureDetails = true;
                        continue;
                    }

                    if (line.Contains("SURGERIES/HOSPITALIZATIONS:") || line.Contains("☑ No Surgeries"))
                    {
                        continue;
                    }

                    if (captureDetails && !string.IsNullOrWhiteSpace(line.Trim()))
                    {
                        string cleaned = line.Trim().TrimStart('•', ' ');
                        if (!string.IsNullOrWhiteSpace(cleaned))
                        {
                            surgeryText.AppendLine(cleaned);
                        }
                    }
                }

                if (surgeryText.Length > 0)
                {
                    txtSurgeryDetails.Text = surgeryText.ToString().Trim();
                }
            }
        }

        private void ParseMedications(string diagnosis)
        {
            int medsStart = diagnosis.IndexOf("CURRENT MEDICATIONS:");
            int medsEnd = diagnosis.IndexOf("ALLERGIES:");

            if (medsStart >= 0 && medsEnd > medsStart)
            {
                string medsSection = diagnosis.Substring(medsStart, medsEnd - medsStart);
                var lines = medsSection.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                StringBuilder medsText = new StringBuilder();

                foreach (var line in lines)
                {
                    string trimmed = line.Trim();

                    if (trimmed.Contains("CURRENT MEDICATIONS:") ||
                        trimmed.Contains("☑ No Medication"))
                    {
                        continue;
                    }

                    if (trimmed.StartsWith("•"))
                    {
                        string med = trimmed.Substring(1).Trim();
                        if (!string.IsNullOrWhiteSpace(med))
                        {
                            medsText.AppendLine(med);
                        }
                    }
                }

                if (medsText.Length > 0)
                {
                    txtMedications.Text = medsText.ToString().Trim();
                    txtMedications.ForeColor = Color.Black;
                }
            }
        }

        private void ParseOtherAllergies(string diagnosis)
        {
            int allergyStart = diagnosis.IndexOf("ALLERGIES:");
            int allergyEnd = diagnosis.IndexOf("DOCTOR'S NOTES");

            if (allergyStart >= 0)
            {
                string allergySection;
                if (allergyEnd > allergyStart)
                {
                    allergySection = diagnosis.Substring(allergyStart, allergyEnd - allergyStart);
                }
                else
                {
                    allergySection = diagnosis.Substring(allergyStart);
                }

                var lines = allergySection.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    string trimmed = line.Trim();
                    if (trimmed.StartsWith("Other:"))
                    {
                        string allergyText = trimmed.Replace("Other:", "").Trim();
                        allergyText = System.Text.RegularExpressions.Regex.Replace(allergyText, @"[\u00A0-\uFFFF]+", "");
                        txtOtherAllergies.Text = allergyText.Trim();
                        break;
                    }
                }
            }
        }

        private void ParseDoctorNotes(string diagnosis)
        {
            int notesStart = diagnosis.IndexOf("DOCTOR'S NOTES / ADDITIONAL COMMENTS:");
            int notesEnd = diagnosis.IndexOf("Physician Signature:");

            if (notesStart >= 0 && notesEnd > notesStart)
            {
                string notesSection = diagnosis.Substring(notesStart, notesEnd - notesStart);
                notesSection = notesSection.Replace("DOCTOR'S NOTES / ADDITIONAL COMMENTS:", "").Trim();

                var lines = notesSection.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder cleanNotes = new StringBuilder();
                foreach (var line in lines)
                {
                    string cleaned = line.TrimStart(' ', '•');
                    if (!string.IsNullOrWhiteSpace(cleaned))
                    {
                        cleanNotes.AppendLine(cleaned);
                    }
                }

                txtAdditionalComments.Text = cleanNotes.ToString().Trim();
            }
        }

        private void ParseDoctorSignature(string diagnosis)
        {
            var lines = diagnosis.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (line.StartsWith("Physician Signature:"))
                {
                    txtDoctorSignature.Text = line.Replace("Physician Signature:", "").Trim();
                    break;
                }
            }
        }

        private void LoadPreviousRecordsCount()
        {
            try
            {
                if (isViewMode)
                    return;

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
                    if (reasonText.Contains("CHIEF COMPLAINT") || reasonText.Contains("REASON FOR VISIT"))
                    {
                        var lines = reasonText.Split('\n');
                        bool capture = false;
                        StringBuilder complaint = new StringBuilder();

                        foreach (var line in lines)
                        {
                            string trimmedLine = line.Trim();

                            if (trimmedLine.Contains("CHIEF COMPLAINT") || trimmedLine.Contains("REASON FOR VISIT"))
                            {
                                capture = true;
                                continue;
                            }

                            if (trimmedLine.StartsWith("CURRENT SYMPTOMS") ||
                                trimmedLine.StartsWith("KNOWN ALLERGIES") ||
                                trimmedLine.StartsWith("⚠️ KNOWN ALLERGIES") ||
                                trimmedLine.StartsWith("CURRENT MEDICATIONS") ||
                                trimmedLine.Contains("Priority Level:") ||
                                trimmedLine.StartsWith("===") ||
                                trimmedLine.StartsWith("Date:") ||
                                trimmedLine.StartsWith("Status:"))
                            {
                                break;
                            }

                            if (capture && !string.IsNullOrWhiteSpace(trimmedLine))
                            {
                                complaint.AppendLine(trimmedLine);
                            }
                        }

                        string complaintText = complaint.ToString().Trim();
                        if (!string.IsNullOrWhiteSpace(complaintText))
                        {
                            txtProblemStarted.Text = complaintText;
                        }
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
                    string allergies = row["allergies"]?.ToString() ?? "";

                    if (!string.IsNullOrEmpty(allergies))
                    {
                        allergies = System.Text.RegularExpressions.Regex.Replace(allergies, @"[\u00A0-\uFFFF]+", "");
                        allergies = allergies.Trim();
                    }

                    if (!string.IsNullOrEmpty(allergies) && !allergies.Equals("None", StringComparison.OrdinalIgnoreCase))
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

            bool hasMedicationText = !string.IsNullOrWhiteSpace(txtMedications.Text) &&
                                    !txtMedications.Text.Contains("Enter medications, one per line:") &&
                                    !txtMedications.Text.Contains("Example:");

            if (!chkNoMedication.Checked && !hasMedicationText)
            {
                MessageBox.Show(
                    "Please either:\n" +
                    "• Enter current medications, OR\n" +
                    "• Check 'No Medication' if the patient is not taking any medications",
                    "Medication Information Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtMedications.Focus();
                return;
            }

            bool hasAllergyCheckbox = chkLatexAllergy.Checked || chkIodineAllergy.Checked || chkBromineAllergy.Checked;
            bool hasOtherAllergy = !string.IsNullOrWhiteSpace(txtOtherAllergies.Text);

            if (!chkNoKnownAllergies.Checked && !hasAllergyCheckbox && !hasOtherAllergy)
            {
                MessageBox.Show(
                    "Please either:\n" +
                    "• Check 'No Known Allergies', OR\n" +
                    "• Select specific allergies (Latex, Iodine, Bromine), OR\n" +
                    "• Enter other allergies in the text field",
                    "Allergy Information Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                chkNoKnownAllergies.Focus();
                return;
            }

            try
            {
                string completeMedicalRecord = BuildCompleteMedicalRecord();

                if (isEditMode)
                {
                    string updateQuery = @"
                UPDATE MedicalRecords 
                SET diagnosis = @diagnosis, 
                    prescription = @prescription,
                    visit_type = @visitType,
                    record_date = NOW()
                WHERE record_id = @recordId";

                    DatabaseHelper.ExecuteNonQuery(updateQuery,
                        new MySqlParameter("@recordId", editRecordId),
                        new MySqlParameter("@diagnosis", completeMedicalRecord),
                        new MySqlParameter("@prescription", BuildPrescriptionList()),
                        new MySqlParameter("@visitType", DetermineVisitType()));

                    MessageBox.Show(
                        "✓ Medical record updated successfully!\n\n" +
                        "The record has been updated with your changes.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    if (queueId.HasValue && queueId.Value > 0)
                    {
                        string checkDuplicate = @"
                    SELECT COUNT(*) 
                    FROM MedicalRecords 
                    WHERE patient_id = @patientId 
                    AND doctor_id = @doctorId 
                    AND queue_id = @queueId";

                        int existingCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkDuplicate,
                            new MySqlParameter("@patientId", patientId),
                            new MySqlParameter("@doctorId", doctorId),
                            new MySqlParameter("@queueId", queueId.Value)));

                        if (existingCount > 0)
                        {
                            MessageBox.Show(
                                "⚠ A medical record already exists for this visit.\n" +
                                "Cannot save duplicate records.",
                                "Duplicate Record",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query = @"INSERT INTO MedicalRecords 
                (patient_id, doctor_id, diagnosis, prescription, lab_tests, visit_type, queue_id)
                VALUES (@patientId, @doctorId, @diagnosis, @prescription, @labTests, @visitType, @queueId)";

                    DatabaseHelper.ExecuteNonQuery(query,
                        new MySqlParameter("@patientId", patientId),
                        new MySqlParameter("@doctorId", doctorId),
                        new MySqlParameter("@diagnosis", completeMedicalRecord),
                        new MySqlParameter("@prescription", BuildPrescriptionList()),
                        new MySqlParameter("@labTests", ""),
                        new MySqlParameter("@visitType", DetermineVisitType()),
                        new MySqlParameter("@queueId", queueId.HasValue ? (object)queueId.Value : DBNull.Value));

                    if (queueId.HasValue && queueId.Value > 0)
                    {
                        string updateReasonQuery = @"
                    UPDATE patientqueue
                    SET reason_for_visit = 
                    CASE
                    WHEN reason_for_visit IS NULL OR reason_for_visit = '' THEN @note
                    ELSE CONCAT(reason_for_visit, ' | ', @note)
                    END
                    WHERE queue_id = @queueId
                    AND status NOT IN ('Completed', 'Discharged')";

                        DatabaseHelper.ExecuteNonQuery(updateReasonQuery,
                            new MySqlParameter("@queueId", queueId.Value),
                            new MySqlParameter("@note", "Medical record created - visit ongoing"));
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
                }

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
            if (chkOther.Checked && !string.IsNullOrWhiteSpace(txtOtherCause.Text))
                record.AppendLine($"☑ Other: {txtOtherCause.Text}");
            record.AppendLine();

            if (!string.IsNullOrWhiteSpace(txtProblemStarted.Text))
            {
                record.AppendLine($"When did your problem start: {txtProblemStarted.Text}");
                record.AppendLine();
            }

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
                if (!string.IsNullOrWhiteSpace(txtSurgeryDetails.Text))
                {
                    var surgeryLines = txtSurgeryDetails.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var line in surgeryLines)
                    {
                        record.AppendLine($"  • {line.Trim()}");
                    }
                }
            }
            record.AppendLine();

            record.AppendLine("CURRENT MEDICATIONS:");
            if (chkNoMedication.Checked)
            {
                record.AppendLine("  ☑ No Medication");
            }
            else
            {
                string medicationsText = txtMedications.Text;

                bool isPlaceholder = string.IsNullOrWhiteSpace(medicationsText) ||
                                    medicationsText.Contains("Enter medications, one per line:") ||
                                    medicationsText.Contains("Example: Aspirin 81mg");

                if (!isPlaceholder)
                {
                    var medicationLines = medicationsText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    bool hasValidMedication = false;

                    foreach (var line in medicationLines)
                    {
                        string trimmedLine = line.Trim();
                        if (!string.IsNullOrWhiteSpace(trimmedLine) &&
                            !trimmedLine.Contains("Enter medications") &&
                            !trimmedLine.Contains("Example:"))
                        {
                            record.AppendLine($"  • {trimmedLine}");
                            hasValidMedication = true;
                        }
                    }

                    if (!hasValidMedication)
                    {
                        record.AppendLine("  ☑ No Medication");
                    }
                }
                else
                {
                    record.AppendLine("  ☑ No Medication");
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
                    string cleanAllergy = System.Text.RegularExpressions.Regex.Replace(txtOtherAllergies.Text, @"[\u00A0-\uFFFF]+", "");
                    record.AppendLine($"  Other: {cleanAllergy.Trim()}");
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

            string medicationsText = txtMedications.Text;

            bool isPlaceholder = string.IsNullOrWhiteSpace(medicationsText) ||
                                medicationsText.Contains("Enter medications, one per line:") ||
                                medicationsText.Contains("Example: Aspirin 81mg");

            if (chkNoMedication.Checked || isPlaceholder)
            {
                return "No medications prescribed.";
            }

            var medicationLines = medicationsText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int count = 1;
            foreach (var line in medicationLines)
            {
                string trimmedLine = line.Trim();

                if (!string.IsNullOrWhiteSpace(trimmedLine) &&
                    !trimmedLine.Contains("Enter medications") &&
                    !trimmedLine.Contains("Example:"))
                {
                    rx.AppendLine($"{count}. {trimmedLine}");
                    rx.AppendLine();
                    count++;
                }
            }

            if (count == 1)
            {
                return "No medications prescribed.";
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