using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class ReceptionistDashboard : Form
    {
        private User currentUser;

        public ReceptionistDashboard(User user)
        {
            currentUser = user;
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {currentUser.Name} (receptionist)";
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string queryQueue = @"
            SELECT 
                q.queue_id, 
                q.queue_number, 
                q.patient_id,
                u.name AS Patient, 
                IFNULL(d.name, 'Not Assigned') AS Doctor, 
                q.priority, 
                q.status,
                q.registered_time
            FROM patientqueue q
            INNER JOIN Patients p ON q.patient_id = p.patient_id
            INNER JOIN Users u ON p.user_id = u.user_id
            LEFT JOIN Doctors doc ON q.doctor_id = doc.doctor_id
            LEFT JOIN Users d ON doc.user_id = d.user_id
            WHERE q.queue_date = CURDATE()
            ORDER BY 
                CASE q.priority 
                    WHEN 'Emergency' THEN 1 
                    WHEN 'Urgent' THEN 2 
                    ELSE 3 
                END, 
                q.queue_number";

                DataTable dtQueue = DatabaseHelper.ExecuteQuery(queryQueue);
                dgvQueue.DataSource = dtQueue;
                if (dgvQueue.Columns["patient_id"] != null)
                {
                    dgvQueue.Columns["patient_id"].Visible = false;
                }

                int queueCount = dtQueue.Rows.Count;
                lblQueueCount.Text = $"Total in Queue Today: {queueCount}";

                string queryPatients = @"
            SELECT 
                p.patient_id, 
                u.name, 
                u.age, 
                u.gender, 
                IFNULL(p.blood_type, 'Unknown') AS blood_type, 
                IFNULL(p.phone_number, 'N/A') AS phone_number, 
                u.email
            FROM Patients p
            INNER JOIN Users u ON p.user_id = u.user_id
            WHERE u.is_active = 1
            ORDER BY u.name";

                dgvPatients.DataSource = DatabaseHelper.ExecuteQuery(queryPatients);

                LoadBillingData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBillingData()
        {
            try
            {
                string queryBilling = @"
                SELECT 
                    b.bill_id,
                    b.patient_id,
                    u.name AS 'Patient Name',
                    DATE_FORMAT(b.bill_date, '%Y-%m-%d %H:%i') AS 'Bill Date',
                    b.amount AS 'Total Amount',
                    b.status AS 'Status',
                    b.payment_method AS 'Payment Method',
                    CASE 
                        WHEN q.status = 'Completed' THEN 'Ready for Discharge'
                        ELSE 'Processing'
                    END AS 'Discharge Status'
                FROM Billing b
                INNER JOIN Patients p ON b.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                LEFT JOIN patientqueue q ON q.patient_id = b.patient_id 
                    AND q.queue_date = CURDATE()
                WHERE b.status IN ('Pending', 'Partially Paid')
                AND DATE(b.bill_date) = CURDATE()
                ORDER BY b.bill_date DESC";

                DataTable dtBills = DatabaseHelper.ExecuteQuery(queryBilling);
                dgvBilling.DataSource = dtBills;

                if (dgvBilling.Columns["bill_id"] != null)
                    dgvBilling.Columns["bill_id"].Visible = false;
                if (dgvBilling.Columns["patient_id"] != null)
                    dgvBilling.Columns["patient_id"].Visible = false;
                if (dgvBilling.Columns["Total Amount"] != null)
                {
                    dgvBilling.Columns["Total Amount"].DefaultCellStyle.Format = "₱#,##0.00";
                }

                int unpaidCount = dtBills.Rows.Count;
                decimal totalUnpaid = 0;
                foreach (DataRow row in dtBills.Rows)
                {
                    totalUnpaid += Convert.ToDecimal(row["Total Amount"]);
                }

                lblBillingStats.Text = $"Unpaid Bills: {unpaidCount} | Total: ₱{totalUnpaid:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading billing data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnViewBill_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bill to view.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int billId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["bill_id"].Value);
            ViewBillDetails(billId);
        }

        private void ViewBillDetails(int billId)
        {
            try
            {
                string query = @"
                SELECT 
                    b.*,
                    u.name AS patient_name,
                    p.blood_type,
                    p.phone_number
                FROM Billing b
                INNER JOIN Patients p ON b.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                WHERE b.bill_id = @billId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@billId", billId));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bill not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow bill = dt.Rows[0];

                Form viewForm = new Form
                {
                    Text = $"Bill Details - Invoice #{billId}",
                    Size = new Size(700, 650),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    BackColor = Color.White
                };

                RichTextBox rtbDetails = new RichTextBox
                {
                    Location = new Point(20, 20),
                    Size = new Size(640, 520),
                    ReadOnly = true,
                    Font = new Font("Consolas", 10F),
                    BorderStyle = BorderStyle.FixedSingle
                };

                string details = $@"═══════════════════════════════════════════════
                                                SAINT JOSEPH'S HOSPITAL
                                                    BILLING STATEMENT
                                    ═══════════════════════════════════════════════
                                    Invoice #: {billId}
                                    Date: {Convert.ToDateTime(bill["bill_date"]):yyyy-MM-dd HH:mm}

                                                    PATIENT INFORMATION
                                    ───────────────────────────────────────────────
                                    Name: {bill["patient_name"]}
                                    Patient ID: {bill["patient_id"]}
                                    Blood Type: {bill["blood_type"]}
                                    Contact: {bill["phone_number"]}

                                    BILLING DETAILS
                                    ───────────────────────────────────────────────
                                    {bill["description"]}

                                    PAYMENT SUMMARY
                                    ───────────────────────────────────────────────
                                    Subtotal:        ₱{Convert.ToDecimal(bill["subtotal"]):N2}
                                    Discount ({Convert.ToDecimal(bill["discount_percent"])}%): -₱{Convert.ToDecimal(bill["discount_amount"]):N2}
                                    Tax ({Convert.ToDecimal(bill["tax_percent"])}%):      ₱{Convert.ToDecimal(bill["tax_amount"]):N2}
                                    ═══════════════════════════════════════════════
                                    TOTAL AMOUNT:    ₱{Convert.ToDecimal(bill["amount"]):N2}
                                    ═══════════════════════════════════════════════

                                    Payment Method: {bill["payment_method"]}
                                    Status: {bill["status"]}

                                    Notes: {bill["notes"]}

                                    ═══════════════════════════════════════════════";

                                    rtbDetails.Text = details;

                Button btnClose = new Button
                {
                    Text = "Close",
                    Size = new Size(100, 35),
                    Location = new Point(560, 560),
                    BackColor = Color.FromArgb(149, 165, 166),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, ev) => viewForm.Close();

                viewForm.Controls.AddRange(new Control[] { rtbDetails, btnClose });
                viewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error viewing bill: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateBill_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bill to update.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int billId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["bill_id"].Value);
            int patientId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["patient_id"].Value);

            string checkDescQuery = "SELECT description FROM Billing WHERE bill_id = @billId";
            DataTable dtDesc = DatabaseHelper.ExecuteQuery(checkDescQuery,
                new MySqlParameter("@billId", billId));

            bool isAutoGenerated = false;
            if (dtDesc.Rows.Count > 0)
            {
                string description = dtDesc.Rows[0]["description"]?.ToString() ?? "";
                isAutoGenerated = description.Contains("Auto-generated from doctor's service checklist");
            }

            if (isAutoGenerated)
            {
                DialogResult result = MessageBox.Show(
                    "⚠️ AUTO-GENERATED BILL\n\n" +
                    "This bill was automatically created from the doctor's equipment checklist.\n\n" +
                    "The services and prices match exactly what the doctor used.\n\n" +
                    "Do you want to:\n" +
                    "• YES - View the equipment report (recommended)\n" +
                    "• NO - Edit the bill directly\n" +
                    "• CANCEL - Go back\n\n" +
                    "Note: Editing may cause discrepancies with the medical record.",
                    "Auto-Generated Bill",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    string patientName = dgvBilling.SelectedRows[0].Cells["Patient Name"].Value.ToString();
                    ShowEquipmentReportFromQueue(patientId, patientName);
                    return;
                }
            }

            BillingForm billingForm = new BillingForm(billId, currentUser.UserId);
            if (billingForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void CreateBillFromCompletedVisit(int patientId, string patientName)
        {
            try
            {
                string checkBillQuery = @"
            SELECT COUNT(*) 
            FROM Billing 
            WHERE patient_id = @patientId 
            AND DATE(bill_date) = CURDATE()";

                int billCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkBillQuery,
                    new MySqlParameter("@patientId", patientId)));

                if (billCount > 0)
                {
                    MessageBox.Show(
                        "✓ Bill Already Created\n\n" +
                        $"A bill for {patientName} already exists for today.\n\n" +
                        "The doctor has completed the equipment checklist and\n" +
                        "the bill was automatically generated.\n\n" +
                        "You can view or edit it in the Billing tab.",
                        "Bill Exists",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                string checkQueueQuery = @"
            SELECT q.queue_id, d.doctor_id, q.equipment_checklist
            FROM patientqueue q
            LEFT JOIN Doctors d ON q.doctor_id = d.doctor_id
            WHERE q.patient_id = @patientId 
            AND q.queue_date = CURDATE()
            AND q.status = 'Completed'
            ORDER BY q.completed_time DESC
            LIMIT 1";

                DataTable dtQueue = DatabaseHelper.ExecuteQuery(checkQueueQuery,
                    new MySqlParameter("@patientId", patientId));

                if (dtQueue.Rows.Count > 0)
                {
                    string equipmentReport = dtQueue.Rows[0]["equipment_checklist"]?.ToString();

                    if (!string.IsNullOrEmpty(equipmentReport))
                    {
                        MessageBox.Show(
                            "⚠️ BILL NOT YET GENERATED\n\n" +
                            $"The doctor completed the equipment report for {patientName},\n" +
                            "but the bill was not automatically created.\n\n" +
                            "This should not happen. Please contact support.\n\n" +
                            "For now, you can create a manual bill.",
                            "Missing Auto-Bill",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        BillingForm billingForm = new BillingForm(currentUser.UserId, patientId);
                        if (billingForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                        return;
                    }
                }

                MessageBox.Show(
                    "⚠️ NO EQUIPMENT REPORT FOUND\n\n" +
                    $"The doctor has not completed an equipment report for {patientName}.\n\n" +
                    "You will need to create a manual bill.\n\n" +
                    "Please verify services with the doctor.",
                    "Manual Bill Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                BillingForm manualBillForm = new BillingForm(currentUser.UserId, patientId);
                if (manualBillForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemoveFromQueue_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient from the queue.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int queueId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_id"].Value);
            int patientId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["patient_id"].Value);
            string status = dgvQueue.SelectedRows[0].Cells["status"].Value.ToString();
            string patientName = dgvQueue.SelectedRows[0].Cells["Patient"].Value.ToString();

            if (status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    string checkBillingQuery = @"
                SELECT bill_id, description, status
                FROM Billing 
                WHERE patient_id = @patientId 
                AND DATE(bill_date) = CURDATE()";

                    DataTable dtBilling = DatabaseHelper.ExecuteQuery(checkBillingQuery,
                        new MySqlParameter("@patientId", patientId));

                    if (dtBilling.Rows.Count == 0)
                    {
                        DialogResult billingWarning = MessageBox.Show(
                            $"⚠️ NO BILL FOUND\n\n" +
                            $"Patient: {patientName}\n" +
                            $"Status: Completed\n\n" +
                            "This patient has been marked as completed but has NO BILL!\n\n" +
                            "This should not happen if the doctor completed the equipment checklist.\n\n" +
                            "Do you want to create a bill now?",
                            "Missing Bill",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Warning);

                        if (billingWarning == DialogResult.Yes)
                        {
                            CreateBillFromCompletedVisit(patientId, patientName);
                            return;
                        }
                        else if (billingWarning == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else
                    {
                        string billStatus = dtBilling.Rows[0]["status"].ToString();
                        string description = dtBilling.Rows[0]["description"]?.ToString() ?? "";
                        bool isAutoGenerated = description.Contains("Auto-generated from doctor's service checklist");

                        if (billStatus != "Paid")
                        {
                            MessageBox.Show(
                                $"⚠️ BILL NOT PAID\n\n" +
                                $"Patient: {patientName}\n" +
                                $"Bill Status: {billStatus}\n" +
                                $"Bill Type: {(isAutoGenerated ? "Auto-generated" : "Manual")}\n\n" +
                                "The bill must be marked as PAID before removing from queue.\n\n" +
                                "Go to the Billing tab to process payment.",
                                "Payment Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        MessageBox.Show(
                            $"✓ READY FOR DISCHARGE\n\n" +
                            $"Patient: {patientName}\n" +
                            $"Bill Status: Paid\n" +
                            $"Bill Type: {(isAutoGenerated ? "Auto-generated from checklist" : "Manual")}\n\n" +
                            "Patient is ready for discharge.\n" +
                            "Go to Billing tab to complete discharge process.",
                            "Discharge Ready",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error checking billing status: {ex.Message}\n\n" +
                        "Please check the billing manually before removing this patient.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            DialogResult confirm = MessageBox.Show(
                $"Remove {patientName} from queue?\n\n" +
                $"Status: {status}\n\n" +
                "This will permanently remove them from today's queue.",
                "Confirm Remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string deleteQuery = "DELETE FROM PatientQueue WHERE queue_id = @queueId";
                DatabaseHelper.ExecuteNonQuery(deleteQuery,
                    new MySqlParameter("@queueId", queueId));

                MessageBox.Show("✓ Patient removed from queue.", "Removed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing patient: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowEquipmentReportFromQueue(int patientId, string patientName)
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

                if (dt.Rows.Count == 0 || dt.Rows[0]["equipment_checklist"] == DBNull.Value)
                {
                    MessageBox.Show(
                        "No equipment report found for this patient.\n\n" +
                        "The doctor has not completed the equipment & services report yet.",
                        "No Report Available",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                string equipmentReport = dt.Rows[0]["equipment_checklist"].ToString();

                Form reportView = new Form
                {
                    Text = $"Equipment & Services Report - {patientName}",
                    Size = new Size(900, 700),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    BackColor = Color.White
                };

                Panel headerPanel = new Panel
                {
                    BackColor = Color.FromArgb(52, 152, 219),
                    Dock = DockStyle.Top,
                    Height = 100
                };

                Label lblTitle = new Label
                {
                    Text = $"📋 Equipment & Services Report",
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(20, 15),
                    AutoSize = true
                };

                Label lblPatient = new Label
                {
                    Text = $"Patient: {patientName}",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.White,
                    Location = new Point(20, 50),
                    AutoSize = true
                };

                Label lblNote = new Label
                {
                    Text = "Use this report to create the patient bill",
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    ForeColor = Color.FromArgb(220, 220, 220),
                    Location = new Point(20, 75),
                    AutoSize = true
                };

                headerPanel.Controls.AddRange(new Control[] { lblTitle, lblPatient, lblNote });

                RichTextBox rtbReport = new RichTextBox
                {
                    Location = new Point(20, 120),
                    Size = new Size(840, 450),
                    ReadOnly = true,
                    Font = new Font("Consolas", 10F),
                    BorderStyle = BorderStyle.FixedSingle,
                    Text = equipmentReport,
                    BackColor = Color.FromArgb(250, 250, 250)
                };

                Button btnCreateBill = new Button
                {
                    Text = "💳 Create Bill from Report",
                    Size = new Size(220, 45),
                    Location = new Point(540, 590),
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                btnCreateBill.FlatAppearance.BorderSize = 0;
                btnCreateBill.Click += (s, ev) =>
                {
                    reportView.Close();
                    BillingForm billingForm = new BillingForm(currentUser.UserId, patientId);
                    if (billingForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                };

                Button btnClose = new Button
                {
                    Text = "Close",
                    Size = new Size(120, 45),
                    Location = new Point(770, 590),
                    BackColor = Color.FromArgb(149, 165, 166),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, ev) => reportView.Close();

                reportView.Controls.AddRange(new Control[] {
            headerPanel, rtbReport, btnCreateBill, btnClose
        });
                reportView.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading equipment report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateBillFromCompletedVisit(int patientId, string patientName)
        {
            try
            {
                string checkQueueQuery = @"
            SELECT q.queue_id, d.doctor_id, q.equipment_checklist
            FROM patientqueue q
            LEFT JOIN Doctors d ON q.doctor_id = d.doctor_id
            WHERE q.patient_id = @patientId 
            AND q.queue_date = CURDATE()
            AND q.status = 'Completed'
            ORDER BY q.completed_time DESC
            LIMIT 1";

                DataTable dtQueue = DatabaseHelper.ExecuteQuery(checkQueueQuery,
                    new MySqlParameter("@patientId", patientId));

                if (dtQueue.Rows.Count > 0)
                {
                    int queueId = Convert.ToInt32(dtQueue.Rows[0]["queue_id"]);
                    int doctorId = dtQueue.Rows[0]["doctor_id"] != DBNull.Value
                        ? Convert.ToInt32(dtQueue.Rows[0]["doctor_id"])
                        : 0;
                    string equipmentReport = dtQueue.Rows[0]["equipment_checklist"]?.ToString();

                    if (!string.IsNullOrEmpty(equipmentReport))
                    {
                        DialogResult result = MessageBox.Show(
                            "✅ EQUIPMENT REPORT FOUND\n\n" +
                            $"The doctor has completed an equipment & services report for {patientName}.\n\n" +
                            "Would you like to:\n" +
                            "• YES - View the equipment report and create bill\n" +
                            "• NO - Create a manual bill instead",
                            "Equipment Report Available",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            ShowEquipmentReportFromQueue(patientId, patientName);
                            return;
                        }
                    }
                    else if (doctorId > 0)
                    {
                        DialogResult askReport = MessageBox.Show(
                            "⚠️ NO EQUIPMENT REPORT FOUND\n\n" +
                            $"The doctor has not created an equipment report for {patientName}.\n\n" +
                            "Would you like to create a manual bill?",
                            "Missing Equipment Report",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (askReport != DialogResult.Yes)
                            return;
                    }
                }

                BillingForm billingForm = new BillingForm(currentUser.UserId, patientId);
                if (billingForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnProcessPayment_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bill to process payment.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int billId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["bill_id"].Value);
            int patientId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvBilling.SelectedRows[0].Cells["Patient Name"].Value.ToString();
            decimal amount = Convert.ToDecimal(dgvBilling.SelectedRows[0].Cells["Total Amount"].Value);

            DialogResult result = MessageBox.Show(
                $"Process payment for {patientName}?\n\n" +
                $"Invoice #{billId}\n" +
                $"Amount: ₱{amount:N2}\n\n" +
                "Mark this bill as PAID?",
                "Confirm Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string updateQuery = @"
                UPDATE Billing 
                SET status = 'Paid', 
                    payment_method = @paymentMethod
                WHERE bill_id = @billId";

                string paymentMethod = "Cash";
                using (var methodForm = new Form())
                {
                    methodForm.Text = "Payment Method";
                    methodForm.Size = new Size(300, 200);
                    methodForm.StartPosition = FormStartPosition.CenterParent;
                    methodForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    methodForm.MaximizeBox = false;

                    Label lbl = new Label
                    {
                        Text = "Select Payment Method:",
                        Location = new Point(20, 20),
                        AutoSize = true
                    };

                    ComboBox cmb = new ComboBox
                    {
                        Location = new Point(20, 50),
                        Size = new Size(240, 25),
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    cmb.Items.AddRange(new object[] { "Cash", "Credit Card", "Debit Card", "Check", "Bank Transfer" });
                    cmb.SelectedIndex = 0;

                    Button btnOk = new Button
                    {
                        Text = "OK",
                        Location = new Point(100, 110),
                        Size = new Size(75, 30),
                        DialogResult = DialogResult.OK
                    };

                    Button btnCancel = new Button
                    {
                        Text = "Cancel",
                        Location = new Point(185, 110),
                        Size = new Size(75, 30),
                        DialogResult = DialogResult.Cancel
                    };

                    methodForm.Controls.AddRange(new Control[] { lbl, cmb, btnOk, btnCancel });
                    methodForm.AcceptButton = btnOk;
                    methodForm.CancelButton = btnCancel;

                    if (methodForm.ShowDialog() == DialogResult.OK)
                    {
                        paymentMethod = cmb.SelectedItem.ToString();
                    }
                    else
                    {
                        return;
                    }
                }

                DatabaseHelper.ExecuteNonQuery(updateQuery,
                    new MySqlParameter("@paymentMethod", paymentMethod),
                    new MySqlParameter("@billId", billId));

                MessageBox.Show(
                    $"✓ Payment processed successfully!\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Amount Paid: ₱{amount:N2}\n" +
                    $"Payment Method: {paymentMethod}\n\n" +
                    "Patient is now ready for discharge.",
                    "Payment Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDischargePatient_Click(object sender, EventArgs e)
        {
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to discharge.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string status = dgvBilling.SelectedRows[0].Cells["Status"].Value.ToString();
            if (status != "Paid")
            {
                MessageBox.Show(
                    "Cannot discharge patient!\n\n" +
                    "The bill must be marked as PAID before discharge.\n\n" +
                    "Please process the payment first.",
                    "Payment Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int billId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["bill_id"].Value);
            int patientId = Convert.ToInt32(dgvBilling.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvBilling.SelectedRows[0].Cells["Patient Name"].Value.ToString();

            DialogResult confirm = MessageBox.Show(
                $"Discharge patient: {patientName}?\n\n" +
                "This will:\n" +
                "• Remove patient from today's queue\n" +
                "• Archive the completed visit\n" +
                "• Close the billing record\n\n" +
                "Continue with discharge?",
                "Confirm Discharge",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string deleteQueueQuery = @"
                DELETE FROM patientqueue 
                WHERE patient_id = @patientId 
                AND queue_date = CURDATE()
                AND status = 'Completed'";

                DatabaseHelper.ExecuteNonQuery(deleteQueueQuery,
                    new MySqlParameter("@patientId", patientId));

                MessageBox.Show(
                    $"✓ Patient discharged successfully!\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Date: {DateTime.Now:yyyy-MM-dd HH:mm}\n\n" +
                    "Visit completed and archived.",
                    "Discharge Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error discharging patient: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddToQueue_Click(object sender, EventArgs e)
        {
            using (var selectForm = new Form())
            {
                selectForm.Text = "Select Patient";
                selectForm.Size = new Size(500, 400);
                selectForm.StartPosition = FormStartPosition.CenterParent;

                var lblInstruction = new Label
                {
                    Text = "Select a patient to add to queue:",
                    Location = new Point(20, 20),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };

                var dgv = new DataGridView
                {
                    Location = new Point(20, 50),
                    Size = new Size(440, 250),
                    ReadOnly = true,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    MultiSelect = false,
                    AllowUserToAddRows = false,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };

                string query = @"
                    SELECT p.patient_id, u.name, u.age, u.gender, p.blood_type
                    FROM Patients p
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE u.is_active = 1
                    ORDER BY u.name";
                dgv.DataSource = DatabaseHelper.ExecuteQuery(query);

                var btnSelect = new Button
                {
                    Text = "Select & Continue to Intake",
                    Location = new Point(150, 310),
                    Size = new Size(200, 35),
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };
                btnSelect.FlatAppearance.BorderSize = 0;

                btnSelect.Click += (s, ev) =>
                {
                    if (dgv.SelectedRows.Count > 0)
                    {
                        int patientId = Convert.ToInt32(dgv.SelectedRows[0].Cells["patient_id"].Value);
                        selectForm.DialogResult = DialogResult.OK;
                        selectForm.Tag = patientId;
                        selectForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select a patient.", "Selection Required",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };

                selectForm.Controls.AddRange(new Control[] { lblInstruction, dgv, btnSelect });

                if (selectForm.ShowDialog() == DialogResult.OK && selectForm.Tag != null)
                {
                    int patientId = (int)selectForm.Tag;

                    PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, currentUser.UserId);
                    intakeForm.FormClosed += (s, args) => LoadData();
                    intakeForm.ShowDialog();
                }
            }
        }

        private void BtnAssignDoctor_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient from the queue.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int queueId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_id"].Value);
            string patientName = dgvQueue.SelectedRows[0].Cells["Patient"].Value.ToString();

            AssignDoctorForm assignForm = new AssignDoctorForm(queueId, patientName);
            assignForm.FormClosed += (s, args) => LoadData();
            assignForm.ShowDialog();
        }

        private void BtnCallNext_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to call.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string status = dgvQueue.SelectedRows[0].Cells["status"].Value.ToString();
            if (status != "Waiting")
            {
                MessageBox.Show("This patient is already being attended or completed.", "Invalid Status",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int queueId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_id"].Value);
                string patientName = dgvQueue.SelectedRows[0].Cells["Patient"].Value.ToString();
                int queueNumber = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_number"].Value);

                string query = @"UPDATE PatientQueue 
                               SET status = 'Called', called_time = NOW()
                               WHERE queue_id = @queueId";
                DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@queueId", queueId));

                MessageBox.Show($"Now calling: Queue #{queueNumber} - {patientName}", "Patient Called",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemoveFromQueue_Click(object sender, EventArgs e)
        {
            if (dgvQueue.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient from the queue.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int queueId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["queue_id"].Value);
            int patientId = Convert.ToInt32(dgvQueue.SelectedRows[0].Cells["patient_id"].Value);
            string status = dgvQueue.SelectedRows[0].Cells["status"].Value.ToString();
            string patientName = dgvQueue.SelectedRows[0].Cells["Patient"].Value.ToString();

            if (status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    string checkBillingQuery = @"
                        SELECT COUNT(*) 
                        FROM Billing 
                        WHERE patient_id = @patientId 
                        AND DATE(bill_date) = CURDATE()";

                    int billingCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                        checkBillingQuery,
                        new MySqlParameter("@patientId", patientId)));

                    if (billingCount == 0)
                    {
                        DialogResult billingWarning = MessageBox.Show(
                            $"⚠️ BILLING WARNING\n\n" +
                            $"Patient: {patientName}\n" +
                            $"Status: {status}\n\n" +
                            "This patient has NOT been billed yet!\n\n" +
                            "Before removing a completed patient from the queue, you should:\n" +
                            "1. Create an invoice for their visit\n" +
                            "2. Process the payment\n\n" +
                            "Do you want to create a bill for this patient now?",
                            "Patient Not Billed",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Warning);

                        if (billingWarning == DialogResult.Yes)
                        {

                            CreateBillFromCompletedVisit(patientId, patientName);

                            string checkBillQuery = @"
                            SELECT COUNT(*) 
                            FROM Billing 
                            WHERE patient_id = @patientId 
                            AND DATE(bill_date) = CURDATE()";

                            int billCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                                checkBillQuery,
                                new MySqlParameter("@patientId", patientId)));

                            if (billCount == 0)
                            {
                                return;
                            }

                            MessageBox.Show(
                                "✓ Invoice created successfully!\n\n" +
                                "You can now safely remove the patient from the queue.",
                                "Billing Complete",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else if (billingWarning == DialogResult.Cancel)
                        {
                            return;
                        }
                        else
                        {
                            DialogResult forceRemove = MessageBox.Show(
                                $"Are you SURE you want to remove {patientName} without billing?\n\n" +
                                "⚠️ This patient visit will not be invoiced!\n\n" +
                                "This action cannot be undone.",
                                "Confirm Remove Without Billing",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Exclamation);

                            if (forceRemove != DialogResult.Yes)
                            {
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error checking billing status: {ex.Message}\n\n" +
                        "Please check the billing manually before removing this patient.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            DialogResult confirm = MessageBox.Show(
                $"Remove {patientName} from queue?\n\n" +
                "This will permanently remove them from today's queue.",
                "Confirm Remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string deleteQuery = "DELETE FROM PatientQueue WHERE queue_id = @queueId";
                DatabaseHelper.ExecuteNonQuery(deleteQuery,
                    new MySqlParameter("@queueId", queueId));

                MessageBox.Show("✓ Patient removed from queue.", "Removed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing patient: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnViewPatient_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to view.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);

            PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, currentUser.UserId, viewOnly: true);
            intakeForm.ShowDialog();
        }

        private void BtnEditPatient_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);

            PatientIntakeForm intakeForm = new PatientIntakeForm(patientId, currentUser.UserId, viewOnly: false);
            intakeForm.FormClosed += (s, args) => LoadData();
            intakeForm.ShowDialog();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void BtnAddPatient_Click(object sender, EventArgs e)
        {
            RegisterForm createPatientForm = new RegisterForm(currentUser.UserId, currentUser.Role);

            if (createPatientForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    "✓ Patient record has been created successfully!\n\n" +
                    "The patient is now registered in the system.\n\n" +
                    "To add them to the queue:\n" +
                    "1. Click 'Add to Queue' button\n" +
                    "2. Select the patient\n" +
                    "3. Complete the intake form",
                    "Patient Created",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
            else
            {
                LoadData();
            }
        }

        private void BtnCheckMedicalHistory_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to check their medical history.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int patientId = Convert.ToInt32(dgvPatients.SelectedRows[0].Cells["patient_id"].Value);
            string patientName = dgvPatients.SelectedRows[0].Cells["name"].Value.ToString();

            try
            {
                string checkQuery = @"SELECT COUNT(*) FROM MedicalRecords WHERE patient_id = @patientId";
                int recordCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery,
                    new MySqlParameter("@patientId", patientId)));

                string checkVisitsQuery = @"SELECT COUNT(*) FROM CompletedVisits WHERE patient_id = @patientId";
                int visitCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkVisitsQuery,
                    new MySqlParameter("@patientId", patientId)));

                if (recordCount == 0 && visitCount == 0)
                {
                    MessageBox.Show(
                        $"Patient: {patientName}\n\n" +
                        "✓ NEW PATIENT\n\n" +
                        "This patient has no previous medical records or visits.\n" +
                        "They are visiting the hospital for the first time.",
                        "Medical History - New Patient",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    ShowDetailedMedicalHistory(patientId, patientName, recordCount, visitCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking medical history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowDetailedMedicalHistory(int patientId, string patientName, int recordCount, int visitCount)
        {
            Form historyForm = new Form
            {
                Text = $"Medical History - {patientName}",
                Size = new Size(1200, 750),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.FromArgb(240, 245, 250)
            };

            Panel headerPanel = new Panel
            {
                BackColor = Color.FromArgb(156, 39, 176),
                Dock = DockStyle.Top,
                Height = 100
            };

            Label lblTitle = new Label
            {
                Text = $"📋 Complete Medical History - {patientName}",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label lblStats = new Label
            {
                Text = $"Medical Records: {recordCount} | Total Visits: {visitCount}",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                Location = new Point(20, 50),
                AutoSize = true
            };

            Label lblInstruction = new Label
            {
                Text = "Double-click any record to view full medical documentation",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.FromArgb(220, 220, 220),
                Location = new Point(20, 75),
                AutoSize = true
            };

            headerPanel.Controls.AddRange(new Control[] { lblTitle, lblStats, lblInstruction });

            DataGridView dgvHistory = new DataGridView
            {
                Location = new Point(20, 120),
                Size = new Size(1150, 520),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowTemplate = { Height = 40 }
            };

            string query = @"
        SELECT 
            mr.record_id,
            DATE_FORMAT(mr.record_date, '%Y-%m-%d %H:%i') AS 'Date & Time',
            mr.visit_type AS 'Visit Type',
            u.name AS 'Attending Doctor',
            CASE 
                WHEN LENGTH(mr.diagnosis) > 100 
                THEN CONCAT(SUBSTRING(mr.diagnosis, 1, 100), '...')
                ELSE mr.diagnosis
            END AS 'Clinical Summary',
            CASE 
                WHEN mr.prescription IS NOT NULL AND mr.prescription != '' 
                THEN 'Yes' 
                ELSE 'No' 
            END AS 'Rx',
            CASE 
                WHEN mr.lab_tests IS NOT NULL AND mr.lab_tests != '' 
                THEN 'Yes' 
                ELSE 'No' 
            END AS 'Labs'
        FROM MedicalRecords mr
        INNER JOIN Doctors d ON mr.doctor_id = d.doctor_id
        INNER JOIN Users u ON d.user_id = u.user_id
        WHERE mr.patient_id = @patientId
        ORDER BY mr.record_date DESC";

            DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@patientId", patientId));
            dgvHistory.DataSource = dt;

            dgvHistory.DataBindingComplete += (s, ev) =>
            {
                if (dgvHistory.Columns["record_id"] != null)
                {
                    dgvHistory.Columns["record_id"].Visible = false;
                }
                if (dgvHistory.Columns["Date & Time"] != null)
                {
                    dgvHistory.Columns["Date & Time"].Width = 150;
                }
                if (dgvHistory.Columns["Visit Type"] != null)
                {
                    dgvHistory.Columns["Visit Type"].Width = 120;
                }
                if (dgvHistory.Columns["Attending Doctor"] != null)
                {
                    dgvHistory.Columns["Attending Doctor"].Width = 150;
                }
                if (dgvHistory.Columns["Rx"] != null)
                {
                    dgvHistory.Columns["Rx"].Width = 50;
                }
                if (dgvHistory.Columns["Labs"] != null)
                {
                    dgvHistory.Columns["Labs"].Width = 50;
                }
            };

            dgvHistory.CellDoubleClick += (s, ev) =>
            {
                if (ev.RowIndex >= 0)
                {
                    int recordId = Convert.ToInt32(dgvHistory.Rows[ev.RowIndex].Cells["record_id"].Value);
                    ShowEnhancedMedicalRecord(recordId);
                }
            };

            Button btnViewDetails = new Button
            {
                Text = "👁️ View Full Record",
                Size = new Size(180, 45),
                Location = new Point(20, 660),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.Click += (s, ev) =>
            {
                if (dgvHistory.SelectedRows.Count > 0)
                {
                    int recordId = Convert.ToInt32(dgvHistory.SelectedRows[0].Cells["record_id"].Value);
                    ShowEnhancedMedicalRecord(recordId);
                }
                else
                {
                    MessageBox.Show("Please select a record to view.", "Selection Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            Button btnPrint = new Button
            {
                Text = "🖨️ Print History",
                Size = new Size(150, 45),
                Location = new Point(210, 660),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.Click += (s, ev) =>
            {
                MessageBox.Show("Print functionality will be implemented in future update.",
                    "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            Button btnClose = new Button
            {
                Text = "✓ Close",
                Size = new Size(150, 45),
                Location = new Point(1020, 660),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, ev) => historyForm.Close();

            historyForm.Controls.AddRange(new Control[] {
        headerPanel, dgvHistory, btnViewDetails, btnPrint, btnClose
    });
            historyForm.ShowDialog();
        }

        private void ShowEnhancedMedicalRecord(int recordId)
        {
            MedicalRecordForm viewer = MedicalRecordForm.CreateViewMode(
                recordId,
                currentUser.UserId,
                currentUser.Role
            );
            viewer.ShowDialog();
        }
    }
}

        