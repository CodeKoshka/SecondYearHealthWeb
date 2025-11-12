using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class BillingForm : Form
    {
        private int? editingBillId = null;
        private int? currentUserId = null;
        private int? preselectedPatientId = null;
        private int actualPatientId = 0;
        private bool isPreselectedPatient = false;
        private bool isViewOnly = false;

        public BillingForm(int? userId, int patientId, int billId, bool viewOnly)
        {
            InitializeComponent();
            currentUserId = userId;
            editingBillId = billId;
            isPreselectedPatient = true;
            preselectedPatientId = patientId;
            actualPatientId = patientId;
            isViewOnly = viewOnly;

            LoadServiceCategories();
            SetupServiceItems();

            ConfigureForPreselectPatient(actualPatientId);
            LoadExistingBill(billId);
            LoadBillServices(billId);

            if (isViewOnly)
            {
                lblTitle.Text = "View Invoice";
                this.Text = "View Invoice";
                MakeFormReadOnly();
            }
            else
            {
                lblTitle.Text = "Edit Invoice";
                this.Text = "Edit Invoice";
            }
        }

        public BillingForm(int? userId = null, int? patientId = null)
        {
            InitializeComponent();
            currentUserId = userId;
            editingBillId = null;
            preselectedPatientId = patientId;
            isViewOnly = false;

            if (patientId.HasValue && patientId.Value > 0)
            {
                actualPatientId = patientId.Value;
                isPreselectedPatient = true;
            }

            LoadServiceCategories();
            SetupServiceItems();

            ConfigurePaymentControls();

            if (isPreselectedPatient)
            {
                if (!VerifyPatientCompleted(actualPatientId))
                {
                    MessageBox.Show(
                        "❌ CANNOT CREATE BILL\n\n" +
                        "This patient has not completed their visit yet.\n\n" +
                        "The patient must be in 'Completed' status before billing.",
                        "Patient Not Completed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    this.Load += (s, e) => this.Close();
                    return;
                }

                ConfigureForPreselectPatient(actualPatientId);
                LoadServicesFromEquipmentReport(actualPatientId);
            }
            else
            {
                LoadPatientsToComboBox();
            }
        }

        private void ConfigurePaymentControls()
        {
            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.Add("Pending Payment");
            cmbPaymentMethod.SelectedIndex = 0;
            cmbPaymentMethod.Visible = false;
            lblPaymentMethod.Visible = false;
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Partially Paid");
            cmbStatus.Items.Add("Cancelled");
            cmbStatus.SelectedIndex = 0;
        }

        public BillingForm(int? userId, int patientId, int billId)
        {
            InitializeComponent();
            currentUserId = userId;
            editingBillId = billId;
            isPreselectedPatient = true;
            preselectedPatientId = patientId;
            actualPatientId = patientId;
            isViewOnly = false;

            LoadServiceCategories();
            SetupServiceItems();

            ConfigureForPreselectPatient(actualPatientId);
            LoadExistingBill(billId);
            LoadBillServices(billId);

            lblTitle.Text = "Edit Invoice";
            this.Text = "Edit Invoice";
        }

        private void MakeFormReadOnly()
        {
            cmbServiceCategory.Enabled = false;
            cmbServiceItem.Enabled = false;
            numQuantity.Enabled = false;
            btnAddService.Enabled = false;
            btnRemoveService.Enabled = false;
            numDiscount.Enabled = false;
            numTax.Enabled = false;
            cmbPaymentMethod.Enabled = false;
            cmbStatus.Enabled = false;
            txtNotes.ReadOnly = true;
            lstServices.Enabled = true;
            lblPaymentMethod.Visible = true;
            cmbPaymentMethod.Visible = true;

            btnSave.Visible = false;
            btnCancel.Text = "Close";
            btnCancel.Location = new Point(
                (this.ClientSize.Width - btnCancel.Width) / 2,
                btnCancel.Location.Y
            );

            btnPrintPreview.BackColor = Color.FromArgb(52, 152, 219);
        }

        private bool VerifyPatientCompleted(int patientId)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM patientqueue 
                    WHERE patient_id = @patientId 
                    AND queue_date = CURDATE()
                    AND status = 'Completed'";

                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@patientId", patientId)));

                return count > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error verifying patient status: {ex.Message}");
                return false;
            }
        }

        private void ConfigureForPreselectPatient(int patientId)
        {
            try
            {
                string query = @"
                    SELECT u.name, p.blood_type, p.phone_number, u.age, u.gender
                    FROM Patients p
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE p.patient_id = @patientId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@patientId", patientId));

                if (dt.Rows.Count > 0)
                {
                    string patientName = dt.Rows[0]["name"].ToString();

                    string bloodType = "Unknown";
                    if (dt.Rows[0]["blood_type"] != DBNull.Value &&
                        !string.IsNullOrWhiteSpace(dt.Rows[0]["blood_type"]?.ToString()))
                    {
                        bloodType = dt.Rows[0]["blood_type"].ToString();
                    }

                    string phone = dt.Rows[0]["phone_number"]?.ToString() ?? "N/A";
                    string age = dt.Rows[0]["age"]?.ToString() ?? "N/A";
                    string gender = dt.Rows[0]["gender"]?.ToString() ?? "N/A";

                    cmbPatient.Visible = false;
                    cmbPatient.Enabled = false;

                    Panel patientInfoPanel = new Panel
                    {
                        Name = "patientInfoPanel",
                        BackColor = Color.FromArgb(237, 242, 247),
                        Location = new Point(cmbPatient.Location.X, cmbPatient.Location.Y - 5),
                        Size = new Size(520, 40),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    Label lblPatientInfo = new Label
                    {
                        Name = "lblPatientInfo",
                        Text = $"👤 {patientName}",
                        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                        ForeColor = Color.FromArgb(26, 32, 44),
                        Location = new Point(10, 3),
                        AutoSize = true
                    };

                    Label lblPatientDetails = new Label
                    {
                        Name = "lblPatientDetails",
                        Text = $"ID: {patientId} | Age: {age} | Gender: {gender} | Blood Type: {bloodType} | Contact: {phone}",
                        Font = new Font("Segoe UI", 8.5F),
                        ForeColor = Color.FromArgb(74, 85, 104),
                        Location = new Point(10, 22),
                        AutoSize = true
                    };

                    patientInfoPanel.Controls.Add(lblPatientInfo);
                    patientInfoPanel.Controls.Add(lblPatientDetails);

                    this.Controls.Add(patientInfoPanel);
                    patientInfoPanel.BringToFront();

                    if (isViewOnly)
                    {
                        lblPatient.Text = "Patient Information:";
                        lblPatient.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        lblPatient.ForeColor = Color.FromArgb(52, 152, 219);
                    }
                    else if (editingBillId.HasValue)
                    {
                        lblPatient.Text = "Patient (Cannot be changed):";
                        lblPatient.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        lblPatient.ForeColor = Color.FromArgb(243, 156, 18);
                    }
                    else
                    {
                        lblPatient.Text = "Patient (Pre-selected - Cannot be changed):";
                        lblPatient.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        lblPatient.ForeColor = Color.FromArgb(231, 76, 60);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patient info: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPatientsToComboBox()
        {
            string query = @"SELECT p.patient_id, CONCAT(u.name, ' (ID: ', p.patient_id, ')') as display_name
                           FROM Patients p
                           INNER JOIN Users u ON p.user_id = u.user_id
                           WHERE u.is_active = 1
                           ORDER BY u.name";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cmbPatient.DisplayMember = "display_name";
            cmbPatient.ValueMember = "patient_id";
            cmbPatient.DataSource = dt;
        }

        private void NumDiscount_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void NumTax_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void LoadServiceCategories()
        {
            cmbServiceCategory.Items.Clear();
            cmbServiceCategory.Items.Add("-- Select Category --");
            cmbServiceCategory.Items.Add("Consultation");
            cmbServiceCategory.Items.Add("Laboratory");
            cmbServiceCategory.Items.Add("Radiology");
            cmbServiceCategory.Items.Add("Procedures");
            cmbServiceCategory.Items.Add("Medications");
            cmbServiceCategory.Items.Add("Room Charges");
            cmbServiceCategory.Items.Add("Emergency Services");
            cmbServiceCategory.Items.Add("Surgery");
            cmbServiceCategory.Items.Add("Other Services");
            cmbServiceCategory.SelectedIndex = 0;
        }

        private void SetupServiceItems()
        {
            lstServices.View = View.Details;
            lstServices.FullRowSelect = true;
            lstServices.GridLines = true;
            lstServices.Columns.Clear();
            lstServices.Columns.Add("Service/Item", 285);
            lstServices.Columns.Add("Category", 143);
            lstServices.Columns.Add("Quantity", 93);
            lstServices.Columns.Add("Unit Price", 153);
            lstServices.Columns.Add("Amount", 153);
            lstServices.AllowColumnReorder = false;
            lstServices.Scrollable = true;
        }

        private void LoadServicesFromEquipmentReport(int patientId)
        {
            try
            {
                string query = @"
                    SELECT equipment_checklist
                    FROM patientqueue
                    WHERE patient_id = @patientId 
                    AND queue_date = CURDATE()
                    AND status = 'Completed'
                    ORDER BY completed_time DESC
                    LIMIT 1";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@patientId", patientId));

                if (dt.Rows.Count > 0 && dt.Rows[0]["equipment_checklist"] != DBNull.Value)
                {
                    string equipmentReport = dt.Rows[0]["equipment_checklist"].ToString();
                    ParseAndAddServices(equipmentReport);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Could not load equipment report: {ex.Message}");
            }
        }

        private void ParseAndAddServices(string report)
        {
            var lines = report.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                if (line.Trim().StartsWith("•"))
                {
                    try
                    {
                        string serviceLine = line.Substring(1).Trim();
                        int categoryStart = serviceLine.LastIndexOf('(');
                        int categoryEnd = serviceLine.LastIndexOf(')');

                        if (categoryStart > 0 && categoryEnd > categoryStart)
                        {
                            string serviceName = serviceLine.Substring(0, categoryStart).Trim();
                            string category = serviceLine.Substring(categoryStart + 1, categoryEnd - categoryStart - 1).Trim();
                            decimal unitPrice = GetServicePrice(serviceName, category);
                            int quantity = 1;

                            AddOrUpdateService(serviceName, category, quantity, unitPrice);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            UpdateTotals();
        }

        private void AddOrUpdateService(string serviceName, string category, int quantity, decimal unitPrice)
        {
            foreach (ListViewItem existingItem in lstServices.Items)
            {
                if (existingItem.SubItems[0].Text == serviceName &&
                    existingItem.SubItems[1].Text == category)
                {
                    int existingQty = Convert.ToInt32(existingItem.SubItems[2].Text);
                    int newQty = existingQty + quantity;
                    decimal amount = unitPrice * newQty;

                    existingItem.SubItems[2].Text = newQty.ToString();
                    existingItem.SubItems[4].Text = "₱" + amount.ToString("N2");

                    return;
                }
            }

            decimal totalAmount = unitPrice * quantity;
            ListViewItem item = new ListViewItem(serviceName);
            item.SubItems.Add(category);
            item.SubItems.Add(quantity.ToString());
            item.SubItems.Add("₱" + unitPrice.ToString("N2"));
            item.SubItems.Add("₱" + totalAmount.ToString("N2"));
            lstServices.Items.Add(item);
        }
        private int? GetCurrentQueueId(int patientId)
        {
            try
            {
                string query = @"
            SELECT queue_id 
            FROM patientqueue 
            WHERE patient_id = @patientId 
            AND queue_date = CURDATE()
            AND status = 'Completed'
            ORDER BY completed_time DESC
            LIMIT 1";

                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@patientId", patientId));

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting queue_id: {ex.Message}");
                return null;
            }
        }

        private decimal GetServicePrice(string serviceName, string category)
        {
            var servicePrices = new System.Collections.Generic.Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
            {
                {"General Consultation", 2500},
                {"Specialist Consultation", 5000},
                {"Follow-up Consultation", 1500},
                {"Emergency Consultation", 7500},
                {"Complete Blood Count (CBC)", 1250},
                {"Blood Chemistry", 2000},
                {"Urinalysis", 750},
                {"Lipid Profile", 1750},
                {"Blood Typing", 1000},
                {"Liver Function Test", 2250},
                {"Kidney Function Test", 2250},
                {"HbA1c Test", 1800},
                {"X-Ray (Single View)", 3000},
                {"X-Ray (Two Views)", 4500},
                {"CT Scan", 15000},
                {"MRI", 25000},
                {"Ultrasound", 4000},
                {"Mammogram", 6000},
                {"ECG", 2000},
                {"Echocardiogram", 10000},
                {"Endoscopy", 20000},
                {"Colonoscopy", 22500},
                {"Minor Suturing", 3750},
                {"Wound Dressing", 1500},
                {"IV Insertion", 1000},
                {"Catheterization", 2500},
                {"Nebulization", 800},
                {"Antibiotics (Generic)", 750},
                {"Pain Relief Medication", 500},
                {"IV Fluids", 1250},
                {"Vaccine/Immunization", 1750},
                {"IV Antibiotics", 2000},
                {"Emergency Medication", 3000},
                {"Private Room (per day)", 10000},
                {"Semi-Private Room (per day)", 6000},
                {"Ward Bed (per day)", 4000},
                {"ICU (per day)", 25000},
                {"Emergency Room", 7500},
                {"Observation Bed (per day)", 3000},
                {"Emergency Room Fee", 7500},
                {"Ambulance Service", 10000},
                {"Emergency Surgery", 100000},
                {"Trauma Care", 15000},
                {"Minor Surgery", 50000},
                {"Major Surgery", 150000},
                {"Operating Room Fee", 25000},
                {"Anesthesia", 20000},
                {"Surgical Supplies", 10000},
                {"Physical Therapy Session", 3000},
                {"Dietary Consultation", 2000},
                {"Medical Certificate", 1000},
                {"Medical Records Copy", 500},
                {"Oxygen Therapy (per hour)", 500},
                {"Cardiac Monitor (per day)", 2000},
                {"Infusion Pump (per day)", 1500},
                {"Medical Supplies (Sterile Gloves, Syringes, etc.)", 500}
            };

            if (servicePrices.ContainsKey(serviceName))
                return servicePrices[serviceName];

            return 0;
        }

        private void CmbServiceCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbServiceItem.Items.Clear();
            cmbServiceItem.Items.Add("-- Select Service --");

            string category = cmbServiceCategory.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(category) || category == "-- Select Category --")
            {
                cmbServiceItem.SelectedIndex = 0;
                return;
            }

            switch (category)
            {
                case "Consultation":
                    cmbServiceItem.Items.Add("General Consultation - ₱2,500");
                    cmbServiceItem.Items.Add("Specialist Consultation - ₱5,000");
                    cmbServiceItem.Items.Add("Follow-up Consultation - ₱1,500");
                    cmbServiceItem.Items.Add("Emergency Consultation - ₱7,500");
                    break;

                case "Laboratory":
                    cmbServiceItem.Items.Add("Complete Blood Count (CBC) - ₱1,250");
                    cmbServiceItem.Items.Add("Blood Chemistry - ₱2,000");
                    cmbServiceItem.Items.Add("Urinalysis - ₱750");
                    cmbServiceItem.Items.Add("Lipid Profile - ₱1,750");
                    cmbServiceItem.Items.Add("Blood Typing - ₱1,000");
                    cmbServiceItem.Items.Add("Liver Function Test - ₱2,250");
                    cmbServiceItem.Items.Add("Kidney Function Test - ₱2,250");
                    break;

                case "Radiology":
                    cmbServiceItem.Items.Add("X-Ray (Single View) - ₱3,000");
                    cmbServiceItem.Items.Add("X-Ray (Two Views) - ₱4,500");
                    cmbServiceItem.Items.Add("CT Scan - ₱15,000");
                    cmbServiceItem.Items.Add("MRI - ₱25,000");
                    cmbServiceItem.Items.Add("Ultrasound - ₱4,000");
                    cmbServiceItem.Items.Add("Mammogram - ₱6,000");
                    break;

                case "Procedures":
                    cmbServiceItem.Items.Add("ECG - ₱2,000");
                    cmbServiceItem.Items.Add("Echocardiogram - ₱10,000");
                    cmbServiceItem.Items.Add("Endoscopy - ₱20,000");
                    cmbServiceItem.Items.Add("Colonoscopy - ₱22,500");
                    cmbServiceItem.Items.Add("Minor Suturing - ₱3,750");
                    cmbServiceItem.Items.Add("Wound Dressing - ₱1,500");
                    break;

                case "Medications":
                    cmbServiceItem.Items.Add("Antibiotics (Generic) - ₱750");
                    cmbServiceItem.Items.Add("Pain Relief Medication - ₱500");
                    cmbServiceItem.Items.Add("IV Fluids - ₱1,250");
                    cmbServiceItem.Items.Add("Vaccine/Immunization - ₱1,750");
                    break;

                case "Room Charges":
                    cmbServiceItem.Items.Add("Private Room (per day) - ₱10,000");
                    cmbServiceItem.Items.Add("Semi-Private Room (per day) - ₱6,000");
                    cmbServiceItem.Items.Add("Ward Bed (per day) - ₱4,000");
                    cmbServiceItem.Items.Add("ICU (per day) - ₱25,000");
                    cmbServiceItem.Items.Add("Emergency Room - ₱7,500");
                    break;

                case "Emergency Services":
                    cmbServiceItem.Items.Add("Emergency Room Fee - ₱7,500");
                    cmbServiceItem.Items.Add("Ambulance Service - ₱10,000");
                    cmbServiceItem.Items.Add("Emergency Surgery - ₱100,000");
                    cmbServiceItem.Items.Add("Trauma Care - ₱15,000");
                    break;

                case "Surgery":
                    cmbServiceItem.Items.Add("Minor Surgery - ₱50,000");
                    cmbServiceItem.Items.Add("Major Surgery - ₱150,000");
                    cmbServiceItem.Items.Add("Operating Room Fee - ₱25,000");
                    cmbServiceItem.Items.Add("Anesthesia - ₱20,000");
                    cmbServiceItem.Items.Add("Surgical Supplies - ₱10,000");
                    break;

                case "Other Services":
                    cmbServiceItem.Items.Add("Physical Therapy Session - ₱3,000");
                    cmbServiceItem.Items.Add("Dietary Consultation - ₱2,000");
                    cmbServiceItem.Items.Add("Medical Certificate - ₱1,000");
                    cmbServiceItem.Items.Add("Medical Records Copy - ₱500");
                    break;
            }
            cmbServiceItem.SelectedIndex = 0;
        }

        private void BtnAddService_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbServiceItem.SelectedIndex <= 0 || cmbServiceCategory.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select both category and service.", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int quantity = (int)numQuantity.Value;
                string serviceText = cmbServiceItem.Text;
                string categoryName = cmbServiceCategory.Text;

                string[] parts = serviceText.Split(new[] { " - ₱" }, StringSplitOptions.None);
                if (parts.Length != 2)
                {
                    MessageBox.Show("Invalid service format.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string serviceName = parts[0].Trim();
                string priceStr = parts[1].Replace(",", "").Trim();

                if (!decimal.TryParse(priceStr, out decimal unitPrice))
                {
                    MessageBox.Show("Invalid price format.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddOrUpdateService(serviceName, categoryName, quantity, unitPrice);
                UpdateTotals();

                bool serviceExists = false;
                foreach (ListViewItem item in lstServices.Items)
                {
                    if (item.SubItems[0].Text == serviceName && item.SubItems[1].Text == categoryName)
                    {
                        int currentQty = Convert.ToInt32(item.SubItems[2].Text);
                        if (currentQty > quantity)
                        {
                            serviceExists = true;
                            MessageBox.Show(
                                $"Service already exists!\n\n" +
                                $"Updated quantity from {currentQty - quantity} to {currentQty}.",
                                "Service Updated",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            break;
                        }
                    }
                }

                cmbServiceCategory.SelectedIndex = 0;
                numQuantity.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding service: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBillServices(int billId)
        {
            try
            {
                lstServices.Items.Clear();

                string query = @"
                    SELECT bs.quantity, bs.unit_price, s.service_name, sc.category_name
                    FROM BillServices bs
                    LEFT JOIN Services s ON bs.service_id = s.service_id
                    LEFT JOIN ServiceCategories sc ON bs.category_id = sc.category_id
                    WHERE bs.bill_id = @billId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@billId", billId));

                foreach (DataRow row in dt.Rows)
                {
                    string serviceName = row["service_name"]?.ToString() ?? "Unknown Service";
                    string categoryName = row["category_name"]?.ToString() ?? "N/A";
                    int quantity = Convert.ToInt32(row["quantity"]);
                    decimal unitPrice = Convert.ToDecimal(row["unit_price"]);
                    decimal total = quantity * unitPrice;

                    ListViewItem item = new ListViewItem(serviceName);
                    item.SubItems.Add(categoryName);
                    item.SubItems.Add(quantity.ToString());
                    item.SubItems.Add("₱" + unitPrice.ToString("N2"));
                    item.SubItems.Add("₱" + total.ToString("N2"));

                    lstServices.Items.Add(item);
                }

                UpdateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bill services: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            UpdateTotals();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstServices.Items.Count == 0)
                {
                    MessageBox.Show("Please add at least one service to the bill.", "No Services",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal subtotal = CalculateSubtotal();
                decimal discountPercent = numDiscount.Value;
                decimal taxPercent = numTax.Value;
                decimal discountAmount = subtotal * (discountPercent / 100);
                decimal taxAmount = (subtotal - discountAmount) * (taxPercent / 100);
                decimal total = subtotal - discountAmount + taxAmount;
                string paymentMethod = "Pending Payment";
                string status = string.IsNullOrWhiteSpace(cmbStatus.Text) ? "Pending" : cmbStatus.Text;
                string notes = txtNotes.Text.Trim();

                int createdBy = currentUserId ?? 1;
                int patientId = isPreselectedPatient ? actualPatientId : Convert.ToInt32(cmbPatient.SelectedValue);

                int? queueId = GetCurrentQueueId(patientId);

                if (editingBillId.HasValue)
                {
                    string updateQuery = @"
                UPDATE Billing 
                SET subtotal = @subtotal, 
                    discount_percent = @discountPercent, 
                    discount_amount = @discountAmount,
                    tax_percent = @taxPercent, 
                    tax_amount = @taxAmount, 
                    amount = @amount, 
                    status = @status, 
                    notes = @notes,
                    queue_id = @queueId
                WHERE bill_id = @billId";

                    DatabaseHelper.ExecuteNonQuery(updateQuery,
                        new MySqlParameter("@subtotal", subtotal),
                        new MySqlParameter("@discountPercent", discountPercent),
                        new MySqlParameter("@discountAmount", discountAmount),
                        new MySqlParameter("@taxPercent", taxPercent),
                        new MySqlParameter("@taxAmount", taxAmount),
                        new MySqlParameter("@amount", total),
                        new MySqlParameter("@status", status),
                        new MySqlParameter("@notes", notes),
                        new MySqlParameter("@queueId", (object)queueId ?? DBNull.Value),
                        new MySqlParameter("@billId", editingBillId.Value));

                    SaveBillServices(editingBillId.Value);
                }
                else
                {
                    if (queueId.HasValue)
                    {
                        string checkQuery = @"
                    SELECT bill_id 
                    FROM Billing 
                    WHERE queue_id = @queueId";

                        object existingBill = DatabaseHelper.ExecuteScalar(checkQuery,
                            new MySqlParameter("@queueId", queueId.Value));

                        if (existingBill != null && existingBill != DBNull.Value)
                        {
                            DialogResult confirmResult = MessageBox.Show(
                                "A bill already exists for this visit.\n\n" +
                                "Do you want to UPDATE the existing bill instead?",
                                "Bill Already Exists",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (confirmResult == DialogResult.Yes)
                            {
                                editingBillId = Convert.ToInt32(existingBill);
                                BtnSave_Click(sender, e);
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }

                    string insertQuery = @"
                INSERT INTO Billing (patient_id, queue_id, subtotal, discount_percent, discount_amount, 
                                     tax_percent, tax_amount, amount, payment_method, status, notes, 
                                     created_by, bill_date)
                VALUES (@patientId, @queueId, @subtotal, @discountPercent, @discountAmount, 
                        @taxPercent, @taxAmount, @amount, @paymentMethod, @status, @notes, 
                        @createdBy, NOW());
                SELECT LAST_INSERT_ID();";

                    object insertResult = DatabaseHelper.ExecuteScalar(insertQuery,
                        new MySqlParameter("@patientId", patientId),
                        new MySqlParameter("@queueId", (object)queueId ?? DBNull.Value),
                        new MySqlParameter("@subtotal", subtotal),
                        new MySqlParameter("@discountPercent", discountPercent),
                        new MySqlParameter("@discountAmount", discountAmount),
                        new MySqlParameter("@taxPercent", taxPercent),
                        new MySqlParameter("@taxAmount", taxAmount),
                        new MySqlParameter("@amount", total),
                        new MySqlParameter("@paymentMethod", paymentMethod),
                        new MySqlParameter("@status", status),
                        new MySqlParameter("@notes", notes),
                        new MySqlParameter("@createdBy", createdBy));

                    int newBillId = Convert.ToInt32(insertResult);
                    SaveBillServices(newBillId);
                }

                MessageBox.Show(
                    "✅ Bill saved successfully!\n\n" +
                    $"Status: {status}\n" +
                    $"Total Amount: ₱{total:N2}\n\n" +
                    "💡 TIP: Use 'Process Payment' button in the Receptionist Dashboard\n" +
                    "to record payment and mark this bill as 'Paid'.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving bill: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveBillServices(int billId)
        {
            try
            {
                string deleteQuery = "DELETE FROM BillServices WHERE bill_id = @billId";
                DatabaseHelper.ExecuteNonQuery(deleteQuery, new MySqlParameter("@billId", billId));

                foreach (ListViewItem item in lstServices.Items)
                {
                    string serviceName = item.SubItems[0].Text;
                    string categoryName = item.SubItems[1].Text;
                    int quantity = Convert.ToInt32(item.SubItems[2].Text);

                    string priceText = item.SubItems[3].Text.Replace("₱", "").Replace(",", "").Trim();
                    decimal unitPrice = Convert.ToDecimal(priceText);

                    int? categoryId = GetOrCreateCategoryId(categoryName);
                    int serviceId = GetOrCreateServiceId(serviceName, categoryId, unitPrice);

                    string insertQuery = @"
                        INSERT INTO BillServices (bill_id, service_id, category_id, quantity, unit_price)
                        VALUES (@billId, @serviceId, @categoryId, @quantity, @unitPrice)";

                    DatabaseHelper.ExecuteNonQuery(insertQuery,
                        new MySqlParameter("@billId", billId),
                        new MySqlParameter("@serviceId", serviceId),
                        new MySqlParameter("@categoryId", (object)categoryId ?? DBNull.Value),
                        new MySqlParameter("@quantity", quantity),
                        new MySqlParameter("@unitPrice", unitPrice));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving bill services: {ex.Message}", ex);
            }
        }

        private int? GetOrCreateCategoryId(string categoryName)
        {
            try
            {
                if (string.IsNullOrEmpty(categoryName) || categoryName == "N/A")
                    return null;

                string checkQuery = "SELECT category_id FROM ServiceCategories WHERE category_name = @categoryName";
                object result = DatabaseHelper.ExecuteScalar(checkQuery,
                    new MySqlParameter("@categoryName", categoryName));

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                string insertQuery = @"
                    INSERT INTO ServiceCategories (category_name) VALUES (@categoryName);
                    SELECT LAST_INSERT_ID();";

                result = DatabaseHelper.ExecuteScalar(insertQuery,
                    new MySqlParameter("@categoryName", categoryName));

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error with category: {ex.Message}");
                return null;
            }
        }

        private int GetOrCreateServiceId(string serviceName, int? categoryId, decimal unitPrice)
        {
            try
            {
                string checkQuery = "SELECT service_id FROM Services WHERE service_name = @serviceName";
                object result = DatabaseHelper.ExecuteScalar(checkQuery,
                    new MySqlParameter("@serviceName", serviceName));

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                string insertQuery = @"
                    INSERT INTO Services (service_name, category_id, unit_price) 
                    VALUES (@serviceName, @categoryId, @unitPrice);
                    SELECT LAST_INSERT_ID();";

                result = DatabaseHelper.ExecuteScalar(insertQuery,
                    new MySqlParameter("@serviceName", serviceName),
                    new MySqlParameter("@categoryId", (object)categoryId ?? DBNull.Value),
                    new MySqlParameter("@unitPrice", unitPrice));

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error with service '{serviceName}': {ex.Message}", ex);
            }
        }

        private decimal CalculateSubtotal()
        {
            decimal subtotal = 0;
            foreach (ListViewItem item in lstServices.Items)
            {
                string amountText = item.SubItems[4].Text.Replace("₱", "").Replace(",", "").Trim();
                if (decimal.TryParse(amountText, out decimal amount))
                {
                    subtotal += amount;
                }
            }
            return subtotal;
        }

        private void UpdateTotals()
        {
            decimal subtotal = CalculateSubtotal();
            decimal discountPercent = numDiscount.Value;
            decimal discountAmount = subtotal * (discountPercent / 100m);
            decimal taxableBase = subtotal - discountAmount;
            decimal taxPercent = numTax.Value;
            decimal taxAmount = taxableBase * (taxPercent / 100m);
            decimal grandTotal = taxableBase + taxAmount;

            lblSubtotal.Text = $"Subtotal: ₱{subtotal:N2}";
            lblDiscountAmount.Text = $"Discount ({discountPercent}%): -₱{discountAmount:N2}";
            lblTaxAmount.Text = $"Tax ({taxPercent}%): ₱{taxAmount:N2}";
            lblGrandTotal.Text = $"Grand Total: ₱{grandTotal:N2}";
        }

        private void LoadExistingBill(int billId)
        {
            try
            {
                string query = @"SELECT * FROM Billing WHERE bill_id = @billId";
                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@billId", billId));

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    actualPatientId = Convert.ToInt32(row["patient_id"]);
                    txtNotes.Text = row["notes"]?.ToString() ?? "";

                    if (row["discount_percent"] != DBNull.Value)
                        numDiscount.Value = Convert.ToDecimal(row["discount_percent"]);

                    if (row["tax_percent"] != DBNull.Value)
                        numTax.Value = Convert.ToDecimal(row["tax_percent"]);
                    string currentStatus = row["status"]?.ToString() ?? "Pending";
                    if (row["payment_method"] != DBNull.Value && currentStatus == "Paid")
                    {
                        lblPaymentMethod.Visible = true;
                        cmbPaymentMethod.Visible = true;
                        cmbPaymentMethod.Items.Clear();
                        cmbPaymentMethod.Items.Add(row["payment_method"].ToString());
                        cmbPaymentMethod.SelectedIndex = 0;
                    }
                    else
                    {
                        lblPaymentMethod.Visible = false;
                        cmbPaymentMethod.Visible = false;
                    }

                    if (row["status"] != DBNull.Value)
                    {
                        string status = row["status"].ToString();
                        if (cmbStatus.Items.Contains(status))
                        {
                            cmbStatus.Text = status;
                        }
                        else if (status == "Paid")
                        {
                            if (!cmbStatus.Items.Contains("Paid"))
                            {
                                cmbStatus.Items.Add("Paid");
                            }
                            cmbStatus.Text = "Paid";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bill: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPrintPreview_Click(object sender, EventArgs e)
        {
            if (lstServices.Items.Count == 0)
            {
                MessageBox.Show("Please add services before generating preview.", "No Services",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string preview = GenerateInvoicePreview();
            MessageBox.Show(preview, "Invoice Preview", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GenerateInvoicePreview()
        {
            string patientName = "Unknown Patient";

            if (isPreselectedPatient)
            {
                Panel patientInfoPanel = this.Controls.Find("patientInfoPanel", true).FirstOrDefault() as Panel;
                if (patientInfoPanel != null)
                {
                    Label lblPatientInfo = patientInfoPanel.Controls.Find("lblPatientInfo", true).FirstOrDefault() as Label;
                    if (lblPatientInfo != null)
                    {
                        patientName = lblPatientInfo.Text.Replace("👤 ", "");
                    }
                }
            }
            else
            {
                if (cmbPatient.SelectedItem != null)
                {
                    DataRowView drv = cmbPatient.SelectedItem as DataRowView;
                    if (drv != null)
                    {
                        patientName = drv["display_name"].ToString().Split('(')[0].Trim();
                    }
                }
            }

            string preview = "SAINT JOSEPH'S HOSPITAL\n";
            preview += "INVOICE PREVIEW\n";
            preview += new string('=', 50) + "\n\n";
            preview += $"Patient: {patientName}\n";
            preview += $"Date: {DateTime.Now:yyyy-MM-dd HH:mm}\n";
            preview += $"Payment Method: {cmbPaymentMethod.Text}\n";
            preview += $"Status: {cmbStatus.Text}\n\n";
            preview += new string('=', 50) + "\n";
            preview += "SERVICES:\n";
            preview += new string('=', 50) + "\n\n";

            foreach (ListViewItem item in lstServices.Items)
            {
                preview += $"{item.SubItems[0].Text}\n";
                preview += $"  Category: {item.SubItems[1].Text}\n";
                preview += $"  Qty: {item.SubItems[2].Text} x {item.SubItems[3].Text} = {item.SubItems[4].Text}\n\n";
            }

            preview += new string('=', 50) + "\n";
            preview += lblSubtotal.Text + "\n";
            preview += lblDiscountAmount.Text + "\n";
            preview += lblTaxAmount.Text + "\n";
            preview += new string('=', 50) + "\n";
            preview += lblGrandTotal.Text + "\n";

            if (!string.IsNullOrWhiteSpace(txtNotes.Text))
            {
                preview += $"\nNotes: {txtNotes.Text}\n";
            }

            return preview;
        }
    }
}