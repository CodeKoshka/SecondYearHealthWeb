using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class ServiceChecklistForm : Form
    {
        private int queueId;
        private int patientId;
        private int doctorId;
        private string patientName;
        private bool isViewMode;

        public ServiceChecklistForm(int queueId, int patientId, int doctorId, string patientName)
        {
            this.queueId = queueId;
            this.patientId = patientId;
            this.doctorId = doctorId;
            this.patientName = patientName;
            this.isViewMode = false;

            InitializeComponent();
            LoadServiceCategories();
            SetupServicesList();

            lblPatientInfo.Text = $"Patient: {patientName} (ID: {patientId})";
            lblTotal.Visible = false;
        }

        public static ServiceChecklistForm CreateViewMode(int queueId, int patientId, string patientName, string checklistData)
        {
            return new ServiceChecklistForm(queueId, patientId, 0, patientName, checklistData, true);
        }

        private ServiceChecklistForm(int queueId, int patientId, int doctorId, string patientName, string checklistData, bool viewMode)
        {
            this.queueId = queueId;
            this.patientId = patientId;
            this.doctorId = doctorId;
            this.patientName = patientName;
            this.isViewMode = viewMode;

            InitializeComponent();
            SetupServicesList();
            ConfigureForViewMode(checklistData);
        }

        private void ConfigureForViewMode(string checklistData)
        {
            this.Text = "Equipment & Services Report - View Only";
            lblTitle.Text = "📋 Equipment & Services Report - Doctor's Record";

            grpAddService.Visible = false;
            btnSaveAndComplete.Visible = false;
            btnCancel.Text = "✓ Close";
            btnCancel.Location = new Point((this.Width - btnCancel.Width) / 2, btnCancel.Top);

            ParseChecklistData(checklistData);

            lstServices.CheckBoxes = false;
            lblServiceCount.Text = $"Total Services/Equipment Used: {lstServices.Items.Count}";
            lblTotal.Visible = false;
        }

        private void ParseChecklistData(string data)
        {
            if (string.IsNullOrEmpty(data)) return;

            var lines = data.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                if (line.StartsWith("•"))
                {
                    var serviceLine = line.Substring(1).Trim();
                    var parts = serviceLine.Split(new[] { " (" }, StringSplitOptions.None);
                    if (parts.Length >= 2)
                    {
                        string serviceName = parts[0].Trim();
                        string category = parts[1].Replace(")", "").Trim();

                        ListViewItem item = new ListViewItem(serviceName);
                        item.SubItems.Add(category);
                        item.SubItems.Add("");
                        lstServices.Items.Add(item);
                    }
                }
            }
        }

        private void LoadServiceCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("-- Select Category --");
            cmbCategory.Items.Add("Consultation");
            cmbCategory.Items.Add("Laboratory");
            cmbCategory.Items.Add("Radiology");
            cmbCategory.Items.Add("Procedures");
            cmbCategory.Items.Add("Medications");
            cmbCategory.Items.Add("Room Charges");
            cmbCategory.Items.Add("Emergency Services");
            cmbCategory.Items.Add("Surgery");
            cmbCategory.Items.Add("Other Services");
            cmbCategory.SelectedIndex = 0;
        }

        private void SetupServicesList()
        {
            lstServices.View = View.Details;
            lstServices.FullRowSelect = true;
            lstServices.GridLines = true;
            lstServices.CheckBoxes = !isViewMode;

            lstServices.Columns.Clear();
            lstServices.Columns.Add("Service/Equipment", 450);
            lstServices.Columns.Add("Category", 250);
            lstServices.Columns.Add("Quantity", 150);
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbService.Items.Clear();
            cmbService.Items.Add("-- Select Service --");

            string category = cmbCategory.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(category) || category == "-- Select Category --")
                return;

            switch (category)
            {
                case "Consultation":
                    cmbService.Items.Add("General Consultation");
                    cmbService.Items.Add("Specialist Consultation");
                    cmbService.Items.Add("Follow-up Consultation");
                    cmbService.Items.Add("Emergency Consultation");
                    break;

                case "Laboratory":
                    cmbService.Items.Add("Complete Blood Count (CBC)");
                    cmbService.Items.Add("Blood Chemistry");
                    cmbService.Items.Add("Urinalysis");
                    cmbService.Items.Add("Lipid Profile");
                    cmbService.Items.Add("Blood Typing");
                    cmbService.Items.Add("Liver Function Test");
                    cmbService.Items.Add("Kidney Function Test");
                    cmbService.Items.Add("HbA1c Test");
                    break;

                case "Radiology":
                    cmbService.Items.Add("X-Ray (Single View)");
                    cmbService.Items.Add("X-Ray (Two Views)");
                    cmbService.Items.Add("CT Scan");
                    cmbService.Items.Add("MRI");
                    cmbService.Items.Add("Ultrasound");
                    cmbService.Items.Add("Mammogram");
                    break;

                case "Procedures":
                    cmbService.Items.Add("ECG");
                    cmbService.Items.Add("Echocardiogram");
                    cmbService.Items.Add("Endoscopy");
                    cmbService.Items.Add("Colonoscopy");
                    cmbService.Items.Add("Minor Suturing");
                    cmbService.Items.Add("Wound Dressing");
                    cmbService.Items.Add("IV Insertion");
                    cmbService.Items.Add("Catheterization");
                    cmbService.Items.Add("Nebulization");
                    break;

                case "Medications":
                    cmbService.Items.Add("Antibiotics (Generic)");
                    cmbService.Items.Add("Pain Relief Medication");
                    cmbService.Items.Add("IV Fluids");
                    cmbService.Items.Add("Vaccine/Immunization");
                    cmbService.Items.Add("IV Antibiotics");
                    cmbService.Items.Add("Emergency Medication");
                    cmbService.Items.Add("Custom Medication (Enter Details)");
                    break;

                case "Room Charges":
                    cmbService.Items.Add("Private Room (per day)");
                    cmbService.Items.Add("Semi-Private Room (per day)");
                    cmbService.Items.Add("Ward Bed (per day)");
                    cmbService.Items.Add("ICU (per day)");
                    cmbService.Items.Add("Emergency Room");
                    cmbService.Items.Add("Observation Bed (per day)");
                    break;

                case "Emergency Services":
                    cmbService.Items.Add("Emergency Room Fee");
                    cmbService.Items.Add("Ambulance Service");
                    cmbService.Items.Add("Emergency Surgery");
                    cmbService.Items.Add("Trauma Care");
                    break;

                case "Surgery":
                    cmbService.Items.Add("Minor Surgery");
                    cmbService.Items.Add("Major Surgery");
                    cmbService.Items.Add("Operating Room Fee");
                    cmbService.Items.Add("Anesthesia");
                    cmbService.Items.Add("Surgical Supplies");
                    break;

                case "Other Services":
                    cmbService.Items.Add("Physical Therapy Session");
                    cmbService.Items.Add("Dietary Consultation");
                    cmbService.Items.Add("Medical Certificate");
                    cmbService.Items.Add("Medical Records Copy");
                    cmbService.Items.Add("Oxygen Therapy (per hour)");
                    cmbService.Items.Add("Cardiac Monitor (per day)");
                    cmbService.Items.Add("Infusion Pump (per day)");
                    cmbService.Items.Add("Medical Supplies (Sterile Gloves, Syringes, etc.)");
                    cmbService.Items.Add("Custom Service (Enter Details)");
                    break;
            }
            cmbService.SelectedIndex = 0;
        }

        private void BtnAddService_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex <= 0 || cmbService.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a category and service.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string serviceItem = cmbService.SelectedItem.ToString();
            string category = cmbCategory.SelectedItem.ToString();
            string serviceName = serviceItem;

            if (serviceItem.Contains("Custom") || serviceItem.Contains("Enter Details"))
            {
                using (var inputForm = new InputDialog("Enter Service Details", "Service Name:", serviceName))
                {
                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        serviceName = inputForm.InputValue;
                    }
                    else return;
                }
            }

            int quantity = (int)numQuantity.Value;

            ListViewItem item = new ListViewItem(serviceName);
            item.Checked = true;
            item.SubItems.Add(category);
            item.SubItems.Add(quantity.ToString());

            lstServices.Items.Add(item);
            UpdateServiceCount();

            cmbService.SelectedIndex = 0;
            numQuantity.Value = 1;
        }

        private void BtnRemoveService_Click(object sender, EventArgs e)
        {
            if (lstServices.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a service to remove.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (ListViewItem item in lstServices.SelectedItems)
            {
                lstServices.Items.Remove(item);
            }
            UpdateServiceCount();
        }

        private void LstServices_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateServiceCount();
        }

        private void UpdateServiceCount()
        {
            int checkedCount = 0;
            foreach (ListViewItem item in lstServices.Items)
            {
                if (item.Checked) checkedCount++;
            }

            lblServiceCount.Text = $"Services Selected: {checkedCount} of {lstServices.Items.Count}";
        }

        private void BtnSaveAndComplete_Click(object sender, EventArgs e)
        {
            if (lstServices.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one service/equipment before completing.",
                    "No Services Added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int checkedCount = 0;
            foreach (ListViewItem item in lstServices.Items)
            {
                if (item.Checked) checkedCount++;
            }

            if (checkedCount == 0)
            {
                MessageBox.Show("Please check at least one service/equipment to include in the report.",
                    "No Services Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string checkMedicalRecordQuery = @"
                SELECT COUNT(*) FROM medicalrecords 
                WHERE patient_id = @patientId 
                AND doctor_id = @doctorId 
                AND DATE(record_date) = CURDATE()";

            int recordCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkMedicalRecordQuery,
                new MySqlParameter("@patientId", patientId),
                new MySqlParameter("@doctorId", doctorId)));

            if (recordCount == 0)
            {
                MessageBox.Show(
                    "⚠️ Medical Record Required\n\n" +
                    "A medical record must be created before completing the equipment report.\n\n" +
                    "Please create a medical record first, then return to complete the equipment report.",
                    "Medical Record Missing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Complete equipment & services report?\n\n" +
                $"Patient: {patientName}\n" +
                $"Services/Equipment: {checkedCount} item(s)\n\n" +
                "This will:\n" +
                "• Save the equipment/services report\n" +
                "• Mark patient as completed\n\n" +
                "⚠️ Both medical record and equipment report are required!\n\n" +
                "Continue?",
                "Confirm Completion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string checklistReport = BuildEquipmentReport();

                string updateQueueQuery = @"
                    UPDATE patientqueue 
                    SET status = 'Completed', 
                        completed_time = NOW(),
                        equipment_checklist = @checklist
                    WHERE queue_id = @queueId";

                DatabaseHelper.ExecuteNonQuery(updateQueueQuery,
                    new MySqlParameter("@queueId", queueId),
                    new MySqlParameter("@checklist", checklistReport));

                MessageBox.Show(
                    $"✅ Equipment Report Completed Successfully!\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Services/Equipment: {checkedCount} item(s)\n\n" +
                    "✓ Medical record saved\n" +
                    "✓ Equipment report completed\n\n" +
                    "Status: Ready for billing\n" +
                    "The receptionist can now create the bill and process payment.",
                    "Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Error completing report:\n\n{ex.Message}\n\n" +
                    "No changes were saved to the database.\n" +
                    "Please try again or contact support.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string BuildEquipmentReport()
        {
            System.Text.StringBuilder report = new System.Text.StringBuilder();
            report.AppendLine($"EQUIPMENT & SERVICES REPORT");
            report.AppendLine($"Patient: {patientName}");
            report.AppendLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm}");
            report.AppendLine();
            report.AppendLine("Services/Equipment Used:");
            report.AppendLine();

            foreach (ListViewItem item in lstServices.Items)
            {
                if (item.Checked)
                {
                    report.AppendLine($"• {item.SubItems[0].Text} ({item.SubItems[1].Text})");
                    report.AppendLine($"  Quantity: {item.SubItems[2].Text}");
                }
            }

            return report.ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (isViewMode)
            {
                this.Close();
                return;
            }

            if (lstServices.Items.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "⚠️ You have unsaved services in the checklist.\n\n" +
                    "If you cancel now:\n" +
                    "• The equipment report will NOT be saved\n" +
                    "• The patient will remain 'In Progress'\n\n" +
                    "Are you sure you want to cancel?",
                    "Confirm Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}