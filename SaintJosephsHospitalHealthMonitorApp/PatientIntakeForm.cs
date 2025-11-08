using MySqlConnector;
using SaintJosephsHospitalHealthMonitorApp;
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
    public partial class PatientIntakeForm : Form
    {
        private int patientId;
        private int receptionistId;
        private bool isNewPatient;
        private bool isViewMode;
        private bool isEditMode;

        public PatientIntakeForm(int pId, int recId)
        {
            patientId = pId;
            receptionistId = recId;
            isViewMode = false;
            isEditMode = false;
            InitializeComponent();
            LoadPatientBasicInfo();
            CheckIfNewPatient();
            ConfigureForIntakeMode();

            cmbPriority.SelectedIndex = 0;
        }

        public PatientIntakeForm(int pId, int recId, bool viewOnly)
        {
            patientId = pId;
            receptionistId = recId;
            isViewMode = viewOnly;
            isEditMode = !viewOnly;
            InitializeComponent();
            LoadPatientBasicInfo();
            CheckIfNewPatient();

            if (isViewMode)
            {
                ConfigureForViewMode();
                LoadExistingIntakeData();
            }
            else
            {
                ConfigureForEditMode();
            }
        }

        private void ConfigureForViewMode()
        {
            lblTitle.Text = "📋 PATIENT DETAILS - VIEW ONLY";

            txtChiefComplaint.ReadOnly = true;
            txtSymptoms.ReadOnly = true;
            txtCurrentMedications.ReadOnly = true;
            txtAllergies.ReadOnly = true;
            txtMedicalHistory.ReadOnly = true;
            txtPhone.ReadOnly = true;
            cmbPhoneType.Enabled = false;
            txtEmergencyContact.ReadOnly = true;
            cmbEmergencyContactPhoneType.Enabled = false;

            txtBP1.ReadOnly = true;
            txtBP2.ReadOnly = true;
            txtHR.ReadOnly = true;
            txtRR.ReadOnly = true;
            txtTemp.ReadOnly = true;
            txtSpO2.ReadOnly = true;
            txtWeight.ReadOnly = true;

            cmbPriority.Enabled = false;

            lblChiefComplaint.Text = "Reason for Visit / Chief Complaint:";
            lblVitalSigns.Text = "Vital Signs:";

            btnSaveAndQueue.Visible = false;
            btnCancel.Text = "✓ CLOSE";
            btnCancel.BackColor = Color.FromArgb(66, 153, 225);
            btnCancel.Location = new Point(20, 929);
            btnCancel.Size = new Size(960, 50);

            this.ClientSize = new Size(1004, 995);
        }

        private void ConfigureForEditMode()
        {
            lblTitle.Text = "✏️ EDIT PATIENT INFORMATION";

            txtAllergies.ReadOnly = false;
            txtMedicalHistory.ReadOnly = false;
            txtPhone.ReadOnly = false;
            cmbPhoneType.Enabled = true;
            txtEmergencyContact.ReadOnly = false;
            cmbEmergencyContactPhoneType.Enabled = true;

            txtChiefComplaint.ReadOnly = true;
            txtSymptoms.ReadOnly = true;
            txtCurrentMedications.ReadOnly = true;
            txtBP1.ReadOnly = true;
            txtBP2.ReadOnly = true;
            txtHR.ReadOnly = true;
            txtRR.ReadOnly = true;
            txtTemp.ReadOnly = true;
            txtSpO2.ReadOnly = true;
            txtWeight.ReadOnly = true;

            cmbPriority.Enabled = true;

            grpIntakeInfo.Text = "Visit Information (Read Only - From Last Visit)";
            grpPatientInfo.Text = "Patient Information (Editable)";
            panelPriorityInfo.Visible = true;

            lblChiefComplaint.Text = "Reason for Visit / Chief Complaint:";
            lblVitalSigns.Text = "Vital Signs:";

            btnSaveAndQueue.Text = "💾 SAVE CHANGES";
            btnSaveAndQueue.BackColor = Color.FromArgb(72, 187, 120);
            btnCancel.Text = "❌ CANCEL";

            txtPhone.KeyPress += TxtPhone_KeyPress;
            txtEmergencyContact.KeyPress += TxtPhone_KeyPress;

            LoadExistingIntakeData();
        }

        private void ConfigureForIntakeMode()
        {
            lblTitle.Text = "📋 PATIENT INTAKE FORM";
            btnSaveAndQueue.Visible = true;
            btnSaveAndQueue.Text = "✓ SAVE & ADD TO QUEUE";
            btnCancel.Text = "❌ CANCEL";

            txtPhone.KeyPress += TxtPhone_KeyPress;
            txtEmergencyContact.KeyPress += TxtPhone_KeyPress;

            cmbPhoneType.SelectedIndexChanged += CmbPhoneType_SelectedIndexChanged;
            cmbEmergencyContactPhoneType.SelectedIndexChanged += CmbEmergencyContactPhoneType_SelectedIndexChanged;
        }

        private void CmbPhoneType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPhoneType.SelectedItem != null)
            {
                string phoneType = cmbPhoneType.SelectedItem.ToString();

                if (phoneType == "Mobile")
                {
                    txtPhone.MaxLength = 11;
                    lblPhone.Text = "Phone Number (09XXXXXXXXX):";
                }
                else
                {
                    txtPhone.MaxLength = 10;
                    lblPhone.Text = "Phone Number (0X-XXX-XXXX):";
                }

                txtPhone.Clear();
            }
        }

        private void CmbEmergencyContactPhoneType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmergencyContactPhoneType.SelectedItem != null)
            {
                string phoneType = cmbEmergencyContactPhoneType.SelectedItem.ToString();

                if (phoneType == "Mobile")
                {
                    txtEmergencyContact.MaxLength = 11;
                    lblEmergencyContact.Text = "Emergency Contact (09XXXXXXXXX):";
                }
                else
                {
                    txtEmergencyContact.MaxLength = 10;
                    lblEmergencyContact.Text = "Emergency Contact (0X-XXX-XXXX):";
                }

                txtEmergencyContact.Clear();
            }
        }

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '(' &&
                e.KeyChar != ')' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void LoadExistingIntakeData()
        {
            try
            {
                string query = @"
                    SELECT reason_for_visit, priority, registered_time
                    FROM PatientQueue 
                    WHERE patient_id = @patientId 
                    ORDER BY registered_time DESC 
                    LIMIT 1";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@patientId", patientId));

                if (dt.Rows.Count > 0)
                {
                    string reasonText = dt.Rows[0]["reason_for_visit"]?.ToString() ?? "";
                    string priority = dt.Rows[0]["priority"]?.ToString() ?? "Normal";

                   ParseIntakeNotes(reasonText);

                    if (cmbPriority.Items.Contains(priority))
                    {
                        cmbPriority.SelectedItem = priority;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading intake data: " + ex.Message);
            }
        }

        private void ParseIntakeNotes(string notes)
        {
            try
            {
                var lines = notes.Split('\n');
                bool inChiefComplaint = false;
                bool inVitalSigns = false;
                bool inSymptoms = false;
                bool inMedications = false;

                StringBuilder chiefComplaint = new StringBuilder();
                StringBuilder symptoms = new StringBuilder();
                StringBuilder medications = new StringBuilder();

                foreach (var line in lines)
                {
                    string trimmedLine = line.Trim();

                    if (trimmedLine.StartsWith("CHIEF COMPLAINT") || trimmedLine.StartsWith("REASON FOR VISIT"))
                    {
                        inChiefComplaint = true;
                        inVitalSigns = false;
                        inSymptoms = false;
                        inMedications = false;
                        continue;
                    }
                    else if (trimmedLine.StartsWith("VITAL SIGNS"))
                    {
                        inVitalSigns = true;
                        inChiefComplaint = false;
                        inSymptoms = false;
                        inMedications = false;
                        continue;
                    }
                    else if (trimmedLine.StartsWith("CURRENT SYMPTOMS"))
                    {
                        inSymptoms = true;
                        inChiefComplaint = false;
                        inVitalSigns = false;
                        inMedications = false;
                        continue;
                    }
                    else if (trimmedLine.StartsWith("CURRENT MEDICATIONS"))
                    {
                        inMedications = true;
                        inChiefComplaint = false;
                        inVitalSigns = false;
                        inSymptoms = false;
                        continue;
                    }
                    else if (trimmedLine.StartsWith("Priority Level:") ||
                             trimmedLine.StartsWith("===") ||
                             trimmedLine.StartsWith("Date:") ||
                             trimmedLine.StartsWith("Registered by:") ||
                             trimmedLine.StartsWith("Status:") ||
                             trimmedLine.Contains("KNOWN ALLERGIES"))
                    {
                        inChiefComplaint = false;
                        inVitalSigns = false;
                        inSymptoms = false;
                        inMedications = false;
                        continue;
                    }

                    if (inVitalSigns && !string.IsNullOrWhiteSpace(trimmedLine))
                    {
                        if (trimmedLine.StartsWith("BP:"))
                        {
                            var bpMatch = System.Text.RegularExpressions.Regex.Match(trimmedLine, @"BP:\s*(\d+)/(\d+)");
                            if (bpMatch.Success)
                            {
                                txtBP1.Text = bpMatch.Groups[1].Value;
                                txtBP2.Text = bpMatch.Groups[2].Value;
                            }
                        }
                        else if (trimmedLine.StartsWith("HR:"))
                        {
                            var hrMatch = System.Text.RegularExpressions.Regex.Match(trimmedLine, @"HR:\s*(\d+)");
                            if (hrMatch.Success) txtHR.Text = hrMatch.Groups[1].Value;
                        }
                        else if (trimmedLine.StartsWith("RR:"))
                        {
                            var rrMatch = System.Text.RegularExpressions.Regex.Match(trimmedLine, @"RR:\s*(\d+)");
                            if (rrMatch.Success) txtRR.Text = rrMatch.Groups[1].Value;
                        }
                        else if (trimmedLine.StartsWith("Temp:"))
                        {
                            var tempMatch = System.Text.RegularExpressions.Regex.Match(trimmedLine, @"Temp:\s*([\d.]+)");
                            if (tempMatch.Success) txtTemp.Text = tempMatch.Groups[1].Value;
                        }
                        else if (trimmedLine.StartsWith("SpO2:"))
                        {
                            var spo2Match = System.Text.RegularExpressions.Regex.Match(trimmedLine, @"SpO2:\s*(\d+)");
                            if (spo2Match.Success) txtSpO2.Text = spo2Match.Groups[1].Value;
                        }
                        else if (trimmedLine.StartsWith("Weight:"))
                        {
                            var weightMatch = System.Text.RegularExpressions.Regex.Match(trimmedLine, @"Weight:\s*([\d.]+)");
                            if (weightMatch.Success) txtWeight.Text = weightMatch.Groups[1].Value;
                        }
                    }
                    else if (inChiefComplaint && !string.IsNullOrWhiteSpace(trimmedLine))
                    {
                        chiefComplaint.AppendLine(trimmedLine);
                    }
                    else if (inSymptoms && !string.IsNullOrWhiteSpace(trimmedLine))
                    {
                        symptoms.AppendLine(trimmedLine);
                    }
                    else if (inMedications && !string.IsNullOrWhiteSpace(trimmedLine))
                    {
                        medications.AppendLine(trimmedLine);
                    }
                }

                txtChiefComplaint.Text = chiefComplaint.ToString().Trim();
                txtSymptoms.Text = symptoms.ToString().Trim();
                txtCurrentMedications.Text = medications.ToString().Trim();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error parsing intake notes: " + ex.Message);
            }
        }

        private void LoadPatientBasicInfo()
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
                    lblPatientName.Text = $"Patient: {row["name"]}";
                    lblAge.Text = $"Age: {row["age"]} | Gender: {row["gender"]}";
                    lblBloodType.Text = $"Blood Type: {row["blood_type"]}";

                    string phoneNumber = row["phone_number"]?.ToString() ?? "";
                    string phoneType = "";
                    if (!string.IsNullOrEmpty(phoneNumber))
                    {
                        if (phoneNumber.StartsWith("09") || phoneNumber.StartsWith("+639"))
                        {
                            phoneType = "Mobile";
                        }
                        else if (phoneNumber.StartsWith("0"))
                        {
                            phoneType = "Landline";
                        }
                    }

                    lblContact.Text = string.IsNullOrEmpty(phoneType)
                        ? $"Phone: {phoneNumber} | Email: {row["email"]}"
                        : $"Phone: {phoneNumber} ({phoneType}) | Email: {row["email"]}";

                    string emergencyContact = row["emergency_contact"]?.ToString() ?? "";
                    string emergencyPhoneType = "";
                    if (!string.IsNullOrEmpty(emergencyContact))
                    {
                        if (emergencyContact.StartsWith("09") || emergencyContact.StartsWith("+639"))
                        {
                            emergencyPhoneType = "Mobile";
                        }
                        else if (emergencyContact.StartsWith("0"))
                        {
                            emergencyPhoneType = "Landline";
                        }
                    }

                    lblEmergency.Text = string.IsNullOrEmpty(emergencyPhoneType)
                        ? $"Emergency Contact: {emergencyContact}"
                        : $"Emergency Contact: {emergencyContact} ({emergencyPhoneType})";

                    txtAllergies.Text = row["allergies"]?.ToString() ?? "";
                    txtMedicalHistory.Text = row["medical_history"]?.ToString() ?? "";

                    if (!string.IsNullOrEmpty(phoneNumber))
                    {
                        if (phoneNumber.StartsWith("09") || phoneNumber.StartsWith("+639"))
                        {
                            cmbPhoneType.SelectedItem = "Mobile";
                            txtPhone.Text = phoneNumber.Replace("+63", "0");
                        }
                        else
                        {
                            cmbPhoneType.SelectedItem = "Landline";
                            txtPhone.Text = phoneNumber;
                        }
                    }

                    if (!string.IsNullOrEmpty(emergencyContact))
                    {
                        if (emergencyContact.StartsWith("09") || emergencyContact.StartsWith("+639"))
                        {
                            cmbEmergencyContactPhoneType.SelectedItem = "Mobile";
                            txtEmergencyContact.Text = emergencyContact.Replace("+63", "0");
                        }
                        else
                        {
                            cmbEmergencyContactPhoneType.SelectedItem = "Landline";
                            txtEmergencyContact.Text = emergencyContact;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient info: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckIfNewPatient()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM CompletedVisits WHERE patient_id = @patientId";
                int recordCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@patientId", patientId)));

                string queryRecords = "SELECT COUNT(*) FROM MedicalRecords WHERE patient_id = @patientId";
                int medicalRecordCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryRecords,
                    new MySqlParameter("@patientId", patientId)));

                isNewPatient = (recordCount == 0 && medicalRecordCount == 0);

                if (isNewPatient)
                {
                    lblPatientStatus.Text = "⚕️ NEW PATIENT - First time visit";
                    lblPatientStatus.ForeColor = Color.FromArgb(229, 62, 62);
                }
                else
                {
                    lblPatientStatus.Text = "✓ RETURNING PATIENT - Has previous visits";
                    lblPatientStatus.ForeColor = Color.FromArgb(72, 187, 120);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking patient status: " + ex.Message);
            }
        }

        private bool ValidateVitalSigns()
        {
            if (string.IsNullOrWhiteSpace(txtBP1.Text) || string.IsNullOrWhiteSpace(txtBP2.Text))
            {
                MessageBox.Show("Please enter blood pressure (both systolic and diastolic).",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBP1.Focus();
                return false;
            }

            if (!int.TryParse(txtBP1.Text, out int systolic) || systolic < 50 || systolic > 250)
            {
                MessageBox.Show("Systolic blood pressure must be between 50 and 250 mmHg.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBP1.Focus();
                return false;
            }

            if (!int.TryParse(txtBP2.Text, out int diastolic) || diastolic < 30 || diastolic > 150)
            {
                MessageBox.Show("Diastolic blood pressure must be between 30 and 150 mmHg.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBP2.Focus();
                return false;
            }

            if (diastolic >= systolic)
            {
                MessageBox.Show("Diastolic pressure must be lower than systolic pressure.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBP2.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHR.Text))
            {
                MessageBox.Show("Please enter heart rate.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHR.Focus();
                return false;
            }

            if (!int.TryParse(txtHR.Text, out int heartRate) || heartRate < 30 || heartRate > 220)
            {
                MessageBox.Show("Heart rate must be between 30 and 220 bpm.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHR.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRR.Text))
            {
                MessageBox.Show("Please enter respiratory rate.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRR.Focus();
                return false;
            }

            if (!int.TryParse(txtRR.Text, out int respRate) || respRate < 5 || respRate > 60)
            {
                MessageBox.Show("Respiratory rate must be between 5 and 60 breaths/min.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRR.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTemp.Text))
            {
                MessageBox.Show("Please enter body temperature.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTemp.Focus();
                return false;
            }

            if (!decimal.TryParse(txtTemp.Text, out decimal temp) || temp < 32 || temp > 45)
            {
                MessageBox.Show("Body temperature must be between 32°C and 45°C.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTemp.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtSpO2.Text))
            {
                if (!int.TryParse(txtSpO2.Text, out int spo2) || spo2 < 50 || spo2 > 100)
                {
                    MessageBox.Show("Oxygen saturation (SpO2) must be between 50% and 100%.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSpO2.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtWeight.Text))
            {
                if (!decimal.TryParse(txtWeight.Text, out decimal weight) || weight < 1 || weight > 500)
                {
                    MessageBox.Show("Weight must be between 1 kg and 500 kg.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWeight.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool ValidatePhoneNumber(string phoneNumber, string phoneType)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return true;
            }

            phoneNumber = phoneNumber.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            if (phoneType == "Mobile")
            {
                if (phoneNumber.StartsWith("09") && phoneNumber.Length == 11 && phoneNumber.All(char.IsDigit))
                {
                    return true;
                }

                if (phoneNumber.StartsWith("+639") && phoneNumber.Length == 13 && phoneNumber.Substring(1).All(char.IsDigit))
                {
                    return true;
                }

                MessageBox.Show("Invalid mobile number format. Must be 11 digits starting with 09 (e.g., 09171234567).",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if (phoneNumber.StartsWith("0") && phoneNumber.Length >= 8 && phoneNumber.Length <= 10 && phoneNumber.All(char.IsDigit))
                {
                    return true;
                }

                MessageBox.Show("Invalid landline number format. Must be 8-10 digits starting with 0 (e.g., 028-1234567 for Metro Manila).",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private string FormatPhoneNumberForStorage(string phoneNumber, string phoneType)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return "";

            phoneNumber = phoneNumber.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            if (phoneType == "Mobile")
            {
                if (phoneNumber.StartsWith("09"))
                {
                    return "+63" + phoneNumber.Substring(1);
                }
            }

            return phoneNumber;
        }

        private void BtnSaveAndQueue_Click(object sender, EventArgs e)
        {
            if (isViewMode)
            {
                this.Close();
                return;
            }

            if (isEditMode)
            {
                SavePatientInfoOnly();
                return;
            }
        }

        private void SavePatientInfoOnly()
        {
            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                string phoneType = cmbPhoneType.SelectedItem?.ToString() ?? "Mobile";
                if (!ValidatePhoneNumber(txtPhone.Text, phoneType))
                {
                    txtPhone.Focus();
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtEmergencyContact.Text))
            {
                string emergencyPhoneType = cmbEmergencyContactPhoneType.SelectedItem?.ToString() ?? "Mobile";
                if (!ValidatePhoneNumber(txtEmergencyContact.Text, emergencyPhoneType))
                {
                    txtEmergencyContact.Focus();
                    return;
                }
            }

            if (cmbPriority.SelectedItem == null || cmbPriority.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a priority level.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPriority.Focus();
                return;
            }

            try
            {
                string phoneType = cmbPhoneType.SelectedItem?.ToString() ?? "Mobile";
                string formattedPhone = FormatPhoneNumberForStorage(txtPhone.Text, phoneType);

                string emergencyPhoneType = cmbEmergencyContactPhoneType.SelectedItem?.ToString() ?? "Mobile";
                string formattedEmergencyContact = FormatPhoneNumberForStorage(txtEmergencyContact.Text, emergencyPhoneType);

                string updatePatient = @"
                    UPDATE Patients 
                    SET allergies = @allergies, 
                        medical_history = @history,
                        phone_number = @phone,
                        emergency_contact = @emergency
                    WHERE patient_id = @patientId";

                DatabaseHelper.ExecuteNonQuery(updatePatient,
                    new MySqlParameter("@allergies", txtAllergies.Text ?? ""),
                    new MySqlParameter("@history", txtMedicalHistory.Text ?? ""),
                    new MySqlParameter("@phone", formattedPhone),
                    new MySqlParameter("@emergency", formattedEmergencyContact),
                    new MySqlParameter("@patientId", patientId));

                string updatePriority = @"
                    UPDATE PatientQueue 
                    SET priority = @priority
                    WHERE patient_id = @patientId 
                    AND queue_date = CURDATE()
                    ORDER BY registered_time DESC
                    LIMIT 1";

                DatabaseHelper.ExecuteNonQuery(updatePriority,
                    new MySqlParameter("@priority", cmbPriority.SelectedItem.ToString()),
                    new MySqlParameter("@patientId", patientId));

                MessageBox.Show(
                    "✓ Patient information and priority updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating patient information: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildIntakeNotes(bool isUrgentOrEmergency = false)
        {
            string notes = "=== PATIENT INTAKE FORM ===\n";
            notes += $"Date: {DateTime.Now:yyyy-MM-dd HH:mm}\n";
            notes += $"Registered by: Receptionist\n";
            notes += isNewPatient ? "Status: NEW PATIENT\n\n" : "Status: RETURNING PATIENT\n\n";

            notes += "CHIEF COMPLAINT / REASON FOR VISIT:\n";
            notes += txtChiefComplaint.Text + "\n\n";

            notes += "VITAL SIGNS:\n";

            if (isUrgentOrEmergency)
            {
                notes += "⚠️ PENDING - To be recorded by medical staff due to urgent/emergency priority\n\n";
            }
            else
            {
                notes += $"BP: {txtBP1.Text}/{txtBP2.Text} mmHg\n";
                notes += $"HR: {txtHR.Text} bpm\n";
                notes += $"RR: {txtRR.Text} /min\n";
                notes += $"Temp: {txtTemp.Text}°C\n";
                if (!string.IsNullOrWhiteSpace(txtSpO2.Text))
                    notes += $"SpO2: {txtSpO2.Text}%\n";
                if (!string.IsNullOrWhiteSpace(txtWeight.Text))
                    notes += $"Weight: {txtWeight.Text} kg\n";
                notes += "\n";
            }

            if (!string.IsNullOrWhiteSpace(txtSymptoms.Text))
            {
                notes += "CURRENT SYMPTOMS:\n";
                notes += txtSymptoms.Text + "\n\n";
            }

            if (!string.IsNullOrWhiteSpace(txtAllergies.Text))
            {
                notes += "⚠️ KNOWN ALLERGIES:\n";
                notes += txtAllergies.Text + "\n\n";
            }

            if (!string.IsNullOrWhiteSpace(txtCurrentMedications.Text))
            {
                notes += "CURRENT MEDICATIONS:\n";
                notes += txtCurrentMedications.Text + "\n\n";
            }

            notes += $"Priority Level: {cmbPriority.SelectedItem}\n";

            return notes;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            string priority = cmbPriority.SelectedItem?.ToString();

            switch (priority)
            {
                case "Emergency":
                    panelPriorityInfo.BackColor = Color.FromArgb(229, 62, 62);
                    lblPriorityInfo.Text = "🚨 EMERGENCY - Immediate attention, vital signs optional";

                    lblChiefComplaint.Text = "* Reason for Visit / Chief Complaint:";
                    lblVitalSigns.Text = "Vital Signs (Can be skipped for emergency):";
                    break;

                case "Urgent":
                    panelPriorityInfo.BackColor = Color.FromArgb(255, 193, 7);
                    lblPriorityInfo.Text = "⚠️ URGENT - Priority attention, vital signs optional";

                    lblChiefComplaint.Text = "* Reason for Visit / Chief Complaint:";
                    lblVitalSigns.Text = "Vital Signs (Can be skipped for urgent):";
                    break;

                default:
                    panelPriorityInfo.BackColor = Color.FromArgb(72, 187, 120);
                    lblPriorityInfo.Text = "✓ NORMAL - Standard queue processing";

                    lblChiefComplaint.Text = "* Reason for Visit / Chief Complaint:";
                    lblVitalSigns.Text = "* Vital Signs:";
                    break;
            }
        }
    }
}