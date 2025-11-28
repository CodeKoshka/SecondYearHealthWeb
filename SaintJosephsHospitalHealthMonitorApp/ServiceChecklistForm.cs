using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class ServiceChecklistForm : Form
    {
        private int queueId;
        private int patientId;
        private int doctorId;
        private string patientName;
        private bool isViewMode;
        private bool isEditMode;

        public ServiceChecklistForm(int queueId, int patientId, int doctorId, string patientName)
        {
            this.queueId = queueId;
            this.patientId = patientId;
            this.doctorId = doctorId;
            this.patientName = patientName;
            this.isViewMode = false;
            this.isEditMode = false;

            InitializeComponent();
            LoadServiceCategories();
            SetupServicesList();

            lblPatientInfo.Text = $"Patient: {patientName} (ID: {patientId})";
            lblTotal.Visible = false;
        }

        public static ServiceChecklistForm CreateViewMode(int queueId, int patientId, string patientName, string checklistData)
        {
            return new ServiceChecklistForm(queueId, patientId, 0, patientName, checklistData, true, false);
        }

        public static ServiceChecklistForm CreateEditMode(int queueId, int patientId, int doctorId, string patientName, string checklistData)
        {
            return new ServiceChecklistForm(queueId, patientId, doctorId, patientName, checklistData, false, true);
        }

        private ServiceChecklistForm(int queueId, int patientId, int doctorId, string patientName, string checklistData, bool viewMode, bool editMode)
        {
            this.queueId = queueId;
            this.patientId = patientId;
            this.doctorId = doctorId;
            this.patientName = patientName;
            this.isViewMode = viewMode;
            this.isEditMode = editMode;

            InitializeComponent();
            LoadServiceCategories();
            SetupServicesList();

            lblPatientInfo.Text = $"Patient: {patientName} (ID: {patientId})";
            lblTotal.Visible = false;

            if (viewMode)
            {
                ConfigureForViewMode(checklistData);
            }
            else if (editMode)
            {
                ConfigureForEditMode(checklistData);
            }
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

        private void ConfigureForEditMode(string checklistData)
        {
            this.Text = "Equipment & Services Report - Edit Mode";
            lblTitle.Text = "📝 Edit Equipment & Services Report";

            ParseChecklistData(checklistData);

            btnSaveAndComplete.Text = "✅ Save Changes";
            lblServiceCount.Text = $"Services Selected: {lstServices.CheckedItems.Count} of {lstServices.Items.Count}";
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
                    int qtyMarkerIndex = serviceLine.LastIndexOf("[Qty:");
                    string quantity = "1";

                    if (qtyMarkerIndex > 0)
                    {
                        int qtyEndIndex = serviceLine.LastIndexOf(']');
                        if (qtyEndIndex > qtyMarkerIndex)
                        {
                            quantity = serviceLine.Substring(qtyMarkerIndex + 5, qtyEndIndex - qtyMarkerIndex - 5).Trim();
                            serviceLine = serviceLine.Substring(0, qtyMarkerIndex).Trim();
                        }
                    }

                    var parts = serviceLine.Split(new[] { " (" }, StringSplitOptions.None);
                    if (parts.Length >= 2)
                    {
                        string serviceName = parts[0].Trim();
                        string categoryPart = parts[1];

                        int closeParen = categoryPart.IndexOf(')');
                        string category = closeParen > 0 ? categoryPart.Substring(0, closeParen).Trim() : categoryPart;

                        ListViewItem item = new ListViewItem(serviceName);
                        item.Checked = true;
                        item.SubItems.Add(category);
                        item.SubItems.Add(quantity);
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
            cmbService.SelectedIndex = 0;

            string category = cmbCategory.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(category) || category == "-- Select Category --")
            {
                numQuantity.Enabled = false;
                numQuantity.Value = 1;
                return;
            }

            numQuantity.Enabled = false;
            numQuantity.Value = 1;

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

        private void CmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = cmbCategory.SelectedItem?.ToString();
            string service = cmbService.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(service) ||
                category == "-- Select Category --" || service == "-- Select Service --")
            {
                numQuantity.Enabled = false;
                numQuantity.Value = 1;
                return;
            }

            numQuantity.Enabled = ServiceAllowsQuantity(service, category);
            numQuantity.Value = 1;
        }

        private bool ServiceAllowsQuantity(string serviceName, string category)
        {
            if (category == "Laboratory" || category == "Medications")
            {
                return true; 
            }

            var quantityAllowedServices = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Private Room (per day)",
                "Semi-Private Room (per day)",
                "Ward Bed (per day)",
                "ICU (per day)",
                "Observation Bed (per day)",
        
                "Wound Dressing",
                "Nebulization",

                "Physical Therapy Session",
                "Oxygen Therapy (per hour)",
                "Cardiac Monitor (per day)",
                "Infusion Pump (per day)",
                "Medical Supplies (Sterile Gloves, Syringes, etc.)",

                "Custom Medication (Enter Details)",
                "Custom Service (Enter Details)"
            };

            return quantityAllowedServices.Contains(serviceName);
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

            ListViewItem existingItem = null;
            foreach (ListViewItem item in lstServices.Items)
            {
                if (item.SubItems[0].Text.Equals(serviceName, StringComparison.OrdinalIgnoreCase) &&
                    item.SubItems[1].Text.Equals(category, StringComparison.OrdinalIgnoreCase))
                {
                    existingItem = item;
                    break;
                }
            }

            bool allowQuantityIncrement = ServiceAllowsQuantity(serviceName, category);

            if (allowQuantityIncrement)
            {
                if (existingItem != null)
                {
                    int currentQuantity = int.Parse(existingItem.SubItems[2].Text);
                    int newQuantity = currentQuantity + quantity;
                    existingItem.SubItems[2].Text = newQuantity.ToString();

                    MessageBox.Show(
                        $"⚠️ Service Quantity Updated\n\n" +
                        $"Service: {serviceName}\n" +
                        $"Category: {category}\n\n" +
                        $"Previous Quantity: {currentQuantity}\n" +
                        $"Added: {quantity}\n" +
                        $"New Total: {newQuantity}",
                        "Quantity Updated",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    ListViewItem item = new ListViewItem(serviceName);
                    item.Checked = true;
                    item.SubItems.Add(category);
                    item.SubItems.Add(quantity.ToString());
                    lstServices.Items.Add(item);
                }
            }
            else
            {
                if (existingItem != null)
                {
                    MessageBox.Show(
                        $"⚠️ Duplicate Service Not Allowed\n\n" +
                        $"Service: {serviceName}\n" +
                        $"Category: {category}\n\n" +
                        $"This service already exists in the list and can only be added once.\n\n" +
                        $"Services that allow quantities:\n" +
                        $"• All Laboratory tests\n" +
                        $"• All Medications\n" +
                        $"• Room charges (per day)\n" +
                        $"• Wound Dressing, Nebulization\n" +
                        $"• Physical Therapy, Oxygen Therapy\n" +
                        $"• Medical Supplies\n\n" +
                        $"Please select a different service or remove the existing entry first.",
                        "Duplicate Service",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                ListViewItem item = new ListViewItem(serviceName);
                item.Checked = true;
                item.SubItems.Add(category);
                item.SubItems.Add("1");
                lstServices.Items.Add(item);
            }

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

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to remove the selected service(s)?\n\n" +
                $"Selected: {lstServices.SelectedItems.Count} item(s)",
                "Confirm Removal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

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
                MessageBox.Show("Please add at least one service/equipment before saving.",
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

            string actionText = isEditMode ? "Update" : "Save";
            string confirmMessage = isEditMode
                ? $"Save changes to equipment & services report?\n\n" +
                  $"Patient: {patientName}\n" +
                  $"Services/Equipment: {checkedCount} item(s)\n\n" +
                  "This will update the existing equipment/services report.\n\n" +
                  "Continue?"
                : $"Save equipment & services report?\n\n" +
                  $"Patient: {patientName}\n" +
                  $"Services/Equipment: {checkedCount} item(s)\n\n" +
                  "This will save the equipment/services report.\n\n" +
                  "Note: Both the medical record and equipment report\n" +
                  "must be completed before the consultation can be marked as complete.\n\n" +
                  "Continue?";

            DialogResult confirm = MessageBox.Show(
                confirmMessage,
                $"Confirm {actionText}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string checklistReport = BuildEquipmentReport();

                string updateQuery = @"
                UPDATE patientqueue 
                SET equipment_checklist = @checklist
                WHERE queue_id = @queueId";

                DatabaseHelper.ExecuteNonQuery(updateQuery,
                    new MySqlParameter("@checklist", checklistReport),
                    new MySqlParameter("@queueId", queueId));

                this.Tag = new
                {
                    ChecklistReport = checklistReport,
                    QueueId = queueId,
                    PatientId = patientId
                };

                string successMessage = isEditMode
                    ? $"✅ Equipment Report Updated!\n\n" +
                      $"Patient: {patientName}\n" +
                      $"Services/Equipment: {checkedCount} item(s)\n\n" +
                      "The equipment report has been updated successfully."
                    : $"✅ Equipment Report Saved!\n\n" +
                      $"Patient: {patientName}\n" +
                      $"Services/Equipment: {checkedCount} item(s)\n\n" +
                      "The equipment report has been saved to the database.";

                MessageBox.Show(
                    successMessage,
                    isEditMode ? "Report Updated" : "Report Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Error saving report:\n\n{ex.Message}\n\n" +
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
            if (isEditMode)
            {
                report.AppendLine($"Status: Updated");
            }
            report.AppendLine();
            report.AppendLine("Services/Equipment Used:");
            report.AppendLine();

            foreach (ListViewItem item in lstServices.Items)
            {
                if (item.Checked)
                {
                    string serviceName = item.SubItems[0].Text;
                    string category = item.SubItems[1].Text;
                    string quantity = item.SubItems[2].Text;
                    report.AppendLine($"• {serviceName} ({category}) [Qty: {quantity}]");
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
                string cancelMessage = isEditMode
                    ? "⚠️ You have unsaved changes to the equipment report.\n\n" +
                      "If you cancel now, your changes will be lost.\n\n" +
                      "Are you sure you want to cancel?"
                    : "⚠️ You have unsaved services in the checklist.\n\n" +
                      "If you cancel now:\n" +
                      "• The equipment report will NOT be saved\n" +
                      "• The patient will remain 'In Progress'\n\n" +
                      "Are you sure you want to cancel?";

                DialogResult result = MessageBox.Show(
                    cancelMessage,
                    "Confirm Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}