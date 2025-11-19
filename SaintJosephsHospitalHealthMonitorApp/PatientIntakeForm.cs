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
            cmbBloodType.SelectedItem = "Unknown";
            cmbPhoneType.SelectedIndex = 0;
            cmbEmergencyContactPhoneType.SelectedIndex = 0;
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
            cmbBloodType.Enabled = false;
            txtPhone.ReadOnly = true;
            cmbPhoneType.Enabled = false;
            txtEmergencyContact.ReadOnly = true;
            cmbEmergencyContactPhoneType.Enabled = false;

            cmbPriority.Enabled = false;

            lblChiefComplaint.Text = "Reason for Visit / Chief Complaint:";

            panelPriorityInfo.Location = new Point(20, 789);

            btnSaveAndQueue.Visible = false;
            btnCancel.Text = "✓ CLOSE";
            btnCancel.BackColor = Color.FromArgb(66, 153, 225);
            btnCancel.Location = new Point(20, 869);
            btnCancel.Size = new Size(960, 50);

            this.ClientSize = new Size(1004, 950);
        }

        private void ConfigureForEditMode()
        {
            lblTitle.Text = "✏️ EDIT PATIENT INFORMATION";

            txtAllergies.ReadOnly = false;
            txtMedicalHistory.ReadOnly = false;
            cmbBloodType.Enabled = true;
            txtPhone.ReadOnly = false;
            cmbPhoneType.Enabled = true;
            txtEmergencyContact.ReadOnly = false;
            cmbEmergencyContactPhoneType.Enabled = true;

            txtChiefComplaint.ReadOnly = true;
            txtSymptoms.ReadOnly = true;
            txtCurrentMedications.ReadOnly = true;

            cmbPriority.Enabled = true;

            grpIntakeInfo.Text = "Visit Information (Read Only - From Last Visit)";
            grpPatientInfo.Text = "Patient Information (Editable)";
            panelPriorityInfo.Visible = true;

            lblChiefComplaint.Text = "Reason for Visit / Chief Complaint:";

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
                        inSymptoms = false;
                        inMedications = false;
                        continue;
                    }
                    else if (trimmedLine.StartsWith("CURRENT SYMPTOMS"))
                    {
                        inSymptoms = true;
                        inChiefComplaint = false;
                        inMedications = false;
                        continue;
                    }
                    else if (trimmedLine.StartsWith("CURRENT MEDICATIONS"))
                    {
                        inMedications = true;
                        inChiefComplaint = false;
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
                        inSymptoms = false;
                        inMedications = false;
                        continue;
                    }

                    if (inChiefComplaint && !string.IsNullOrWhiteSpace(trimmedLine))
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
                SELECT u.name, u.date_of_birth, u.age, u.gender, u.email,
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
                    if (row["date_of_birth"] != DBNull.Value)
                    {
                        DateTime dob = Convert.ToDateTime(row["date_of_birth"]);
                        int age = row["age"] != DBNull.Value ? Convert.ToInt32(row["age"]) : CalculateAge(dob);
                        lblAge.Text = $"DOB: {dob:MM/dd/yyyy} (Age: {age}) | Gender: {row["gender"]}";
                    }
                    else
                    {
                        lblAge.Text = $"Age: {row["age"]} | Gender: {row["gender"]}";
                    }

                    string bloodType = row["blood_type"]?.ToString() ?? "";
                    lblBloodType.Text = string.IsNullOrEmpty(bloodType) ? "Blood Type: Not recorded" : $"Blood Type: {bloodType}";

                    if (!string.IsNullOrEmpty(bloodType) && cmbBloodType.Items.Contains(bloodType))
                    {
                        cmbBloodType.SelectedItem = bloodType;
                    }
                    else
                    {
                        cmbBloodType.SelectedItem = "Unknown";
                    }

                    string email = row["email"]?.ToString() ?? "";
                    string emailDisplay = string.IsNullOrEmpty(email) ? "Not provided" : email;

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

                    string phoneDisplay = string.IsNullOrEmpty(phoneNumber) ? "Not provided" : phoneNumber;
                    if (!string.IsNullOrEmpty(phoneType))
                    {
                        phoneDisplay = $"{phoneNumber} ({phoneType})";
                    }

                    lblContact.Text = $"Phone: {phoneDisplay} | Email: {emailDisplay}";

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

                    string emergencyDisplay = string.IsNullOrEmpty(emergencyContact) ? "Not provided" : emergencyContact;
                    if (!string.IsNullOrEmpty(emergencyPhoneType))
                    {
                        emergencyDisplay = $"{emergencyContact} ({emergencyPhoneType})";
                    }

                    lblEmergency.Text = $"Emergency Contact: {emergencyDisplay}";

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

        private int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
                age--;
            return age;
        }

        private void CheckIfNewPatient()
        {
            try
            {
                string queryVisits = "SELECT COUNT(*) FROM CompletedVisits WHERE patient_id = @patientId";
                int visitCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryVisits,
                    new MySqlParameter("@patientId", patientId)));

                string queryRecords = "SELECT COUNT(*) FROM MedicalRecords WHERE patient_id = @patientId";
                int medicalRecordCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryRecords,
                    new MySqlParameter("@patientId", patientId)));

                isNewPatient = (visitCount == 0 && medicalRecordCount == 0);


                if (isNewPatient)
                {
                    lblPatientStatus.Text = "⚕️ NEW PATIENT\nFirst time visit";
                    lblPatientStatus.ForeColor = Color.FromArgb(229, 62, 62);
                }
                else
                {
                    string queryTodayDischarge = @"
                SELECT COUNT(*) 
                FROM CompletedVisits 
                WHERE patient_id = @patientId 
                AND DATE(archived_date) = CURDATE()
                AND notes LIKE '%Discharged:%'";

                    int todayDischargeCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryTodayDischarge,
                        new MySqlParameter("@patientId", patientId)));

                    if (todayDischargeCount > 0)
                    {
                        lblPatientStatus.Text = $"🔄 RETURNING PATIENT\n" +
                                                $"   Discharged today | Visits: {visitCount}";
                        lblPatientStatus.ForeColor = Color.FromArgb(243, 156, 18);
                    }
                    else
                    {
                        lblPatientStatus.Text = $"✓ RETURNING PATIENT\n" +
                                                $"  Previous Visits: {visitCount}";
                        lblPatientStatus.ForeColor = Color.FromArgb(72, 187, 120);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking patient status: " + ex.Message);
                lblPatientStatus.Text = "⚠️ Unable to verify patient status";
                lblPatientStatus.ForeColor = Color.FromArgb(243, 156, 18);
            }
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
                bool isValidFormat = false;
                string mobileNumber = phoneNumber;

                if (phoneNumber.StartsWith("09") && phoneNumber.Length == 11 && phoneNumber.All(char.IsDigit))
                {
                    isValidFormat = true;
                }
                else if (phoneNumber.StartsWith("+639") && phoneNumber.Length == 13 && phoneNumber.Substring(1).All(char.IsDigit))
                {
                    isValidFormat = true;
                    mobileNumber = "0" + phoneNumber.Substring(3);
                }

                if (!isValidFormat)
                {
                    MessageBox.Show("Invalid mobile number format. Must be 11 digits starting with 09 (e.g., 09171234567).",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string prefix = mobileNumber.Substring(0, 4);
                int prefixNum = int.Parse(prefix);

                bool isValidPrefix = (prefixNum >= 813 && prefixNum <= 817) ||
                                     (prefixNum >= 900 && prefixNum <= 907) ||
                                     (prefixNum >= 908 && prefixNum <= 999);  
                if (!isValidPrefix)
                {
                    MessageBox.Show("Invalid mobile number prefix. Please enter a valid Philippine mobile number (e.g., 0917, 0918, 0919, 0920, etc.).",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string lastSevenDigits = mobileNumber.Substring(4);
                if (IsObviouslyFakeNumber(lastSevenDigits))
                {
                    MessageBox.Show("The phone number appears to be invalid. Please enter a valid Philippine mobile number.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
            else
            {
                if (!phoneNumber.StartsWith("0") || phoneNumber.Length < 8 || phoneNumber.Length > 10 || !phoneNumber.All(char.IsDigit))
                {
                    MessageBox.Show("Invalid landline number format. Must be 8-10 digits starting with 0 (e.g., 028-1234567 for Metro Manila).",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string areaCode = phoneNumber.Substring(0, Math.Min(3, phoneNumber.Length));

                string numberPart = phoneNumber.Substring(areaCode.Length);
                if (IsObviouslyFakeNumber(numberPart))
                {
                    MessageBox.Show("The phone number appears to be invalid. Please enter a valid Philippine landline number.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
        }

        private bool IsObviouslyFakeNumber(string number)
        {
            if (string.IsNullOrEmpty(number) || number.Length < 4)
                return false;

            if (number.All(c => c == number[0]))
                return true;

            bool isAscending = true;
            bool isDescending = true;
            for (int i = 1; i < number.Length; i++)
            {
                if (number[i] != number[i - 1] + 1)
                    isAscending = false;
                if (number[i] != number[i - 1] - 1)
                    isDescending = false;
            }

            if (isAscending || isDescending)
                return true;

            if (number.Length >= 6)
            {
                string pattern2 = number.Substring(0, 2);
                string pattern3 = number.Substring(0, 3);

                bool isRepeating2 = true;
                bool isRepeating3 = true;

                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] != pattern2[i % 2])
                        isRepeating2 = false;
                    if (number[i] != pattern3[i % 3])
                        isRepeating3 = false;
                }

                if (isRepeating2 || isRepeating3)
                    return true;
            }

            return false;
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

            if (string.IsNullOrWhiteSpace(txtChiefComplaint.Text))
            {
                MessageBox.Show("Please enter the reason for visit / chief complaint.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChiefComplaint.Focus();
                return;
            }

            if (cmbPriority.SelectedItem == null)
            {
                MessageBox.Show("Please select a priority level.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPriority.Focus();
                return;
            }

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

            try
            {
                string phoneType = cmbPhoneType.SelectedItem?.ToString() ?? "Mobile";
                string formattedPhone = FormatPhoneNumberForStorage(txtPhone.Text, phoneType);

                string emergencyPhoneType = cmbEmergencyContactPhoneType.SelectedItem?.ToString() ?? "Mobile";
                string formattedEmergencyContact = FormatPhoneNumberForStorage(txtEmergencyContact.Text, emergencyPhoneType);

                string bloodType = cmbBloodType.SelectedItem?.ToString();

                if (bloodType == "Unknown" || string.IsNullOrEmpty(bloodType))
                {
                    bloodType = null;
                }
                else if (bloodType == "A+" || bloodType == "A-" || bloodType == "B+" || bloodType == "B-" ||
                    bloodType == "AB+" || bloodType == "AB-" || bloodType == "O+" || bloodType == "O-")
                {
                }
                else
                {
                    bloodType = null;
                }

                string updatePatient = @"
                    UPDATE Patients 
                    SET allergies = @allergies, 
                    medical_history = @history,
                    phone_number = @phone,
                    emergency_contact = @emergency,
                    blood_type = @bloodType
                    WHERE patient_id = @patientId";

                DatabaseHelper.ExecuteNonQuery(updatePatient,
                    new MySqlParameter("@allergies", txtAllergies.Text ?? ""),
                    new MySqlParameter("@history", txtMedicalHistory.Text ?? ""),
                    new MySqlParameter("@phone", formattedPhone),
                    new MySqlParameter("@emergency", formattedEmergencyContact),
                    new MySqlParameter("@bloodType", string.IsNullOrEmpty(bloodType) ? (object)DBNull.Value : bloodType),
                    new MySqlParameter("@patientId", patientId));

                string getQueueNumber = @"
                    SELECT COALESCE(MAX(queue_number), 0) + 1 
                    FROM PatientQueue 
                    WHERE queue_date = CURDATE()";

                int queueNumber = Convert.ToInt32(DatabaseHelper.ExecuteScalar(getQueueNumber));

                string intakeNotes = BuildIntakeNotes();

                string insertQueue = @"
                    INSERT INTO PatientQueue 
                    (patient_id, queue_number, priority, status, reason_for_visit, 
                    registered_by, queue_date, registered_time)
                    VALUES 
                    (@patientId, @queueNumber, @priority, 'Waiting', @reasonForVisit, 
                    @registeredBy, CURDATE(), NOW())";

                DatabaseHelper.ExecuteNonQuery(insertQueue,
                    new MySqlParameter("@patientId", patientId),
                    new MySqlParameter("@queueNumber", queueNumber),
                    new MySqlParameter("@priority", cmbPriority.SelectedItem.ToString()),
                    new MySqlParameter("@reasonForVisit", intakeNotes),
                    new MySqlParameter("@registeredBy", receptionistId));

                string patientName = lblPatientName.Text.Replace("Patient: ", "");

                MessageBox.Show(
                    $"✓ Patient added to queue successfully!\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Queue Number: {queueNumber}\n" +
                    $"Priority: {cmbPriority.SelectedItem}\n" +
                    $"Blood Type: {(string.IsNullOrEmpty(bloodType) ? "Unknown" : bloodType)}\n\n" +
                    $"The patient can now wait to be called.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding patient to queue: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string bloodType = cmbBloodType.SelectedItem?.ToString();

                if (bloodType == "Unknown" || string.IsNullOrEmpty(bloodType))
                {
                    bloodType = null;
                }
                else if (bloodType == "A+" || bloodType == "A-" || bloodType == "B+" || bloodType == "B-" ||
                    bloodType == "AB+" || bloodType == "AB-" || bloodType == "O+" || bloodType == "O-")
                {
                }
                else
                {
                    bloodType = null;
                }

                string updatePatient = @"
                    UPDATE Patients 
                    SET allergies = @allergies, 
                    medical_history = @history,
                    phone_number = @phone,
                    emergency_contact = @emergency,
                    blood_type = @bloodType
                    WHERE patient_id = @patientId";

                DatabaseHelper.ExecuteNonQuery(updatePatient,
                    new MySqlParameter("@allergies", txtAllergies.Text ?? ""),
                    new MySqlParameter("@history", txtMedicalHistory.Text ?? ""),
                    new MySqlParameter("@phone", formattedPhone),
                    new MySqlParameter("@emergency", formattedEmergencyContact),
                    new MySqlParameter("@bloodType", string.IsNullOrEmpty(bloodType) ? (object)DBNull.Value : bloodType),
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

        private string BuildIntakeNotes()
        {
            string notes = "=== PATIENT INTAKE - ST. JOSEPH'S CARDIAC HOSPITAL ===\n";
            notes += $"Date: {DateTime.Now:yyyy-MM-dd HH:mm}\n";
            notes += $"Registered by: Receptionist\n";

            if (isNewPatient)
            {
                notes += "Status: NEW PATIENT - First Visit\n\n";
            }
            else
            {
                try
                {
                    string queryTodayDischarge = @"
                SELECT COUNT(*) 
                FROM CompletedVisits 
                WHERE patient_id = @patientId 
                AND DATE(archived_date) = CURDATE()
                AND notes LIKE '%Discharged:%'";

                    int todayDischargeCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryTodayDischarge,
                        new MySqlParameter("@patientId", patientId)));

                    if (todayDischargeCount > 0)
                    {
                        notes += "Status: RETURNING PATIENT - Re-queued after discharge today\n\n";
                    }
                    else
                    {
                        notes += "Status: RETURNING PATIENT - Has Previous Visits\n\n";
                    }
                }
                catch
                {
                    notes += "Status: RETURNING PATIENT\n\n";
                }
            }

            notes += "CHIEF COMPLAINT / REASON FOR VISIT:\n";
            notes += txtChiefComplaint.Text + "\n\n";

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
                    lblPriorityInfo.Text = "🚨 EMERGENCY - Immediate cardiac attention required";
                    lblChiefComplaint.Text = "* Reason for Visit / Chief Complaint:";
                    break;

                case "Urgent":
                    panelPriorityInfo.BackColor = Color.FromArgb(255, 193, 7);
                    lblPriorityInfo.Text = "⚠️ URGENT - Priority cardiac assessment needed";
                    lblChiefComplaint.Text = "* Reason for Visit / Chief Complaint:";
                    break;

                default:
                    panelPriorityInfo.BackColor = Color.FromArgb(72, 187, 120);
                    lblPriorityInfo.Text = "✓ NORMAL - Standard queue processing";
                    lblChiefComplaint.Text = "* Reason for Visit / Chief Complaint:";
                    break;
            }
        }
    }
}