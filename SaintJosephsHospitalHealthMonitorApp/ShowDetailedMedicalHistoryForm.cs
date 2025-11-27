using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;
using Rectangle = iTextSharp.text.Rectangle;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class ShowDetailedMedicalHistoryForm : Form
    {
        private int patientId;
        private string patientName;
        private int recordCount;
        private int visitCount;
        private int currentUserId;
        private string currentUserRole;

        public ShowDetailedMedicalHistoryForm(int patientId, string patientName, int recordCount, int visitCount, int currentUserId, string currentUserRole)
        {
            this.patientId = patientId;
            this.patientName = patientName;
            this.recordCount = recordCount;
            this.visitCount = visitCount;
            this.currentUserId = currentUserId;
            this.currentUserRole = currentUserRole;

            InitializeComponent();
            InitializeForm();
            LoadMedicalHistory();
        }

        private void InitializeForm()
        {
            this.Text = $"Medical History - {patientName}";

            lblTitle.Text = $"📋 Complete Medical History - {patientName}";
            lblStats.Text = $"Medical Records: {recordCount} | Total Visits: {visitCount}";

            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dgvHistory.AutoGenerateColumns = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.ReadOnly = true;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.MultiSelect = false;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.AllowUserToResizeRows = false;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(156, 39, 176);
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvHistory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHistory.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 8, 12, 8);
            dgvHistory.ColumnHeadersHeight = 50;

            dgvHistory.DefaultCellStyle.BackColor = Color.White;
            dgvHistory.DefaultCellStyle.ForeColor = Color.FromArgb(26, 32, 44);
            dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 190, 231);
            dgvHistory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 44);
            dgvHistory.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvHistory.DefaultCellStyle.Padding = new Padding(12, 5, 12, 5);
            dgvHistory.RowTemplate.Height = 45;

            dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvHistory.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 190, 231);

            dgvHistory.GridColor = Color.FromArgb(226, 232, 240);
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvHistory, new object[] { true });
        }

        private void LoadMedicalHistory()
        {
            try
            {
                string query = @"
                    SELECT 
                    mr.record_id,
                    mr.record_date,
                    mr.diagnosis,
                    mr.prescription,
                    mr.visit_type,
                    u.name AS doctor_name
                    FROM MedicalRecords mr
                    INNER JOIN Doctors d ON mr.doctor_id = d.doctor_id
                    INNER JOIN Users u ON d.user_id = u.user_id
                    WHERE mr.patient_id = @patientId
                    ORDER BY mr.record_date DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@patientId", patientId));

                DataTable displayDt = new DataTable();
                displayDt.Columns.Add("record_id", typeof(int));
                displayDt.Columns.Add("Date & Time", typeof(string));
                displayDt.Columns.Add("Visit Type", typeof(string));
                displayDt.Columns.Add("Attending Doctor", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    DateTime recordDate = Convert.ToDateTime(row["record_date"]);

                    displayDt.Rows.Add(
                        row["record_id"],
                        recordDate.ToString("yyyy-MM-dd HH:mm"),
                        row["visit_type"],
                        row["doctor_name"]
                    );
                }

                dgvHistory.DataSource = displayDt;
                dgvHistory.DataBindingComplete += DgvHistory_DataBindingComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading medical history: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvHistory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvHistory.Columns["record_id"] != null)
            {
                dgvHistory.Columns["record_id"].Visible = false;
            }
            if (dgvHistory.Columns["Date & Time"] != null)
            {
                dgvHistory.Columns["Date & Time"].FillWeight = 33;
            }
            if (dgvHistory.Columns["Visit Type"] != null)
            {
                dgvHistory.Columns["Visit Type"].FillWeight = 33;
            }
            if (dgvHistory.Columns["Attending Doctor"] != null)
            {
                dgvHistory.Columns["Attending Doctor"].FillWeight = 34;
            }

            foreach (DataGridViewColumn column in dgvHistory.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void DgvHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int recordId = Convert.ToInt32(dgvHistory.Rows[e.RowIndex].Cells["record_id"].Value);
                ShowMedicalRecord(recordId);
            }
        }

        private void BtnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count > 0)
            {
                int recordId = Convert.ToInt32(dgvHistory.SelectedRows[0].Cells["record_id"].Value);
                ShowMedicalRecord(recordId);
            }
            else
            {
                MessageBox.Show("Please select a record to view.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowMedicalRecord(int recordId)
        {
            MedicalRecordForm viewer = MedicalRecordForm.CreateViewMode(
                recordId,
                currentUserId,
                currentUserRole
            );
            viewer.ShowDialog();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHistory.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Please select a medical record to print.",
                        "Selection Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                int selectedRecordId = Convert.ToInt32(dgvHistory.SelectedRows[0].Cells["record_id"].Value);

                string tempPdfPath = Path.Combine(Path.GetTempPath(), $"MedicalRecord_{patientName.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
                GeneratePDF(tempPdfPath, selectedRecordId);

                MessageBox.Show(
                    $"✅ Medical Record PDF preview opened.",
                    "Preview",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error generating PDF:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private DataTable GetSingleMedicalRecord(int recordId)
        {
            string query = @"
            SELECT 
            mr.record_id,
            mr.record_date,
            mr.diagnosis,
            mr.prescription,
            mr.visit_type,
            u.name AS doctor_name
            FROM MedicalRecords mr
            INNER JOIN Doctors d ON mr.doctor_id = d.doctor_id
            INNER JOIN Users u ON d.user_id = u.user_id
            WHERE mr.record_id = @recordId";

            return DatabaseHelper.ExecuteQuery(query,
                new MySqlParameter("@recordId", recordId));
        }

        private void GeneratePDF(string filePath, int recordId)
        {
            try
            {
                Document document = new Document(PageSize.A4, 35, 35, 35, 35);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13, BaseColor.BLACK);
                Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);
                Font sectionFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);
                Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);
                Font smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 7, BaseColor.BLACK);

                var patientInfo = GetPatientInfo();

                Paragraph hospitalTitle = new Paragraph("MEDICAL RECORD - ST. JOSEPH'S CARDIAC HOSPITAL", titleFont);
                hospitalTitle.Alignment = Element.ALIGN_CENTER;
                hospitalTitle.SpacingAfter = 4;
                document.Add(hospitalTitle);

                Paragraph dept = new Paragraph("Department of Cardiology", normalFont);
                dept.Alignment = Element.ALIGN_CENTER;
                dept.SpacingAfter = 3;
                document.Add(dept);

                Paragraph contactInfo = new Paragraph("Tarlac City, Black Market District | Phone: 09111111111", smallFont);
                contactInfo.Alignment = Element.ALIGN_CENTER;
                contactInfo.SpacingAfter = 8;
                document.Add(contactInfo);

                Paragraph patientName = new Paragraph($"Patient: {patientInfo["name"]}", headerFont);
                patientName.SpacingAfter = 2;
                document.Add(patientName);

                if (patientInfo["date_of_birth"] != DBNull.Value && patientInfo["date_of_birth"] != null)
                {
                    DateTime dob = Convert.ToDateTime(patientInfo["date_of_birth"]);
                    Paragraph dobInfo = new Paragraph($"Date of Birth: {dob:MM/dd/yyyy}", normalFont);
                    dobInfo.SpacingAfter = 1;
                    document.Add(dobInfo);
                }

                Paragraph ageInfo = new Paragraph($"Age: {patientInfo["age"]}", normalFont);
                ageInfo.SpacingAfter = 1;
                document.Add(ageInfo);

                Paragraph genderInfo = new Paragraph($"Gender: {patientInfo["gender"]}", normalFont);
                genderInfo.SpacingAfter = 1;
                document.Add(genderInfo);

                Paragraph phoneInfo = new Paragraph($"Phone: {patientInfo["phone_number"] ?? "N/A"}", normalFont);
                phoneInfo.SpacingAfter = 1;
                document.Add(phoneInfo);

                Paragraph emergencyInfo = new Paragraph($"Emergency Contact: {patientInfo["emergency_contact"] ?? "N/A"}", normalFont);
                emergencyInfo.SpacingAfter = 1;
                document.Add(emergencyInfo);

                Paragraph bloodTypeInfo = new Paragraph($"Blood Type: {patientInfo["blood_type"] ?? "N/A"}", normalFont);
                bloodTypeInfo.SpacingAfter = 10;
                document.Add(bloodTypeInfo);

                var record = GetSingleMedicalRecord(recordId);

                if (record != null && record.Rows.Count > 0)
                {
                    DataRow recordRow = record.Rows[0];
                    DateTime recordDate = Convert.ToDateTime(recordRow["record_date"]);

                    Paragraph recordDatePara = new Paragraph($"Record Date: {recordDate:MM/dd/yyyy HH:mm}", sectionFont);
                    recordDatePara.SpacingAfter = 3;
                    document.Add(recordDatePara);

                    Paragraph visitType = new Paragraph($"Visit Type: {recordRow["visit_type"]}", normalFont);
                    visitType.SpacingAfter = 2;
                    document.Add(visitType);

                    Paragraph attendingDoc = new Paragraph($"Attending Physician: Dr. {recordRow["doctor_name"]}", normalFont);
                    attendingDoc.SpacingAfter = 5;
                    document.Add(attendingDoc);

                    Paragraph assessmentHeader = new Paragraph("ASSESSMENT & DIAGNOSIS:", sectionFont);
                    assessmentHeader.SpacingAfter = 2;
                    document.Add(assessmentHeader);

                    LineSeparator line = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -2);
                    document.Add(new Chunk(line));

                    string diagnosis = recordRow["diagnosis"].ToString();
                    string cleanedDiagnosis = GetDiagnosisWithBoldHeaders(
                        diagnosis, out string doctorNotes, out string doctorSignature,
                        sectionFont, normalFont, document);

                    document.Add(new Chunk(line));

                    Paragraph notesHeader = new Paragraph("DOCTOR'S NOTES / ADDITIONAL COMMENTS:", sectionFont);
                    notesHeader.SpacingBefore = 3;
                    notesHeader.SpacingAfter = 3;
                    document.Add(notesHeader);

                    if (!string.IsNullOrWhiteSpace(doctorNotes))
                    {
                        Paragraph notesContent = new Paragraph(doctorNotes, normalFont);
                        notesContent.SpacingAfter = 3;
                        document.Add(notesContent);
                    }
                    else
                    {
                        Paragraph blankContent = new Paragraph(" ", normalFont);
                        blankContent.SpacingAfter = 3;
                        document.Add(blankContent);
                    }

                    document.Add(new Chunk(line));
                    document.Add(new Paragraph(" ", normalFont) { SpacingAfter = 10 });

                    document.Add(new Paragraph(" ", normalFont) { SpacingAfter = 8 });

                    PdfPTable sigTable = new PdfPTable(2);
                    sigTable.WidthPercentage = 100;
                    sigTable.SpacingBefore = 8;
                    sigTable.SpacingAfter = 8;

                    string signatureName = !string.IsNullOrWhiteSpace(doctorSignature)
                        ? doctorSignature
                        : recordRow["doctor_name"].ToString();

                    PdfPCell sigLeft = new PdfPCell(new Phrase($"Physician Signature: {signatureName}", normalFont));
                    sigLeft.Border = Rectangle.NO_BORDER;
                    sigLeft.PaddingTop = 5;
                    sigTable.AddCell(sigLeft);

                    PdfPCell sigRight = new PdfPCell(new Phrase($"Printed Date: {DateTime.Now:MM/dd/yyyy HH:mm}", normalFont));
                    sigRight.Border = Rectangle.NO_BORDER;
                    sigRight.HorizontalAlignment = Element.ALIGN_RIGHT;
                    sigRight.PaddingTop = 5;
                    sigTable.AddCell(sigRight);

                    document.Add(sigTable);
                }

                document.Add(new Paragraph(" ", normalFont) { SpacingBefore = 12 });

                LineSeparator footerLine = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -2);
                document.Add(new Chunk(footerLine));

                Paragraph confidential = new Paragraph(
                    "CONFIDENTIAL MEDICAL RECORD - Protected Health Information",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7, BaseColor.BLACK));
                confidential.Alignment = Element.ALIGN_CENTER;
                confidential.SpacingBefore = 3;
                confidential.SpacingAfter = 2;
                document.Add(confidential);

                Paragraph disclaimer = new Paragraph(
                    "This document contains privileged medical information. Unauthorized disclosure is prohibited by law.",
                    smallFont);
                disclaimer.Alignment = Element.ALIGN_CENTER;
                document.Add(disclaimer);

                Paragraph docId = new Paragraph(
                    $"Document ID: MR-{recordId:D6}-{DateTime.Now:yyyyMMdd}", smallFont);
                docId.Alignment = Element.ALIGN_CENTER;
                document.Add(docId);

                document.Close();
                writer.Close();

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = filePath,
                    UseShellExecute = true
                });

                DialogResult saveResult = MessageBox.Show(
                    "PDF preview has been opened. Would you like to save a permanent copy?",
                    "Save PDF",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (saveResult == DialogResult.Yes)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveDialog.FileName = $"MedicalRecord_{recordId}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(filePath, saveDialog.FileName, true);
                        MessageBox.Show(
                            $"PDF saved successfully!\n{saveDialog.FileName}",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDiagnosisWithBoldHeaders(string diagnosis, out string doctorNotes, out string doctorSignature, Font sectionFont, Font normalFont, Document document)
        {
            doctorNotes = string.Empty;
            doctorSignature = string.Empty;

            if (string.IsNullOrEmpty(diagnosis)) return diagnosis;

            int doctorNotesIndex = diagnosis.IndexOf("DOCTOR'S NOTES / ADDITIONAL COMMENTS:");
            string mainDiagnosis;

            if (doctorNotesIndex >= 0)
            {
                mainDiagnosis = diagnosis.Substring(0, doctorNotesIndex);
                string notesSection = diagnosis.Substring(doctorNotesIndex);

                int signatureIndex = notesSection.IndexOf("Physician Signature:");

                if (signatureIndex >= 0)
                {
                    notesSection = notesSection.Substring(0, signatureIndex);
                }

                doctorNotes = notesSection.Replace("DOCTOR'S NOTES / ADDITIONAL COMMENTS:", "").Trim();

                var noteLines = doctorNotes.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder cleanNotes = new StringBuilder();

                foreach (var line in noteLines)
                {
                    string trimmedLine = line.Trim();
                    if (!trimmedLine.StartsWith("Assessment Date:"))
                    {
                        cleanNotes.AppendLine(trimmedLine);
                    }
                }

                doctorNotes = cleanNotes.ToString().Trim();
            }
            else
            {
                mainDiagnosis = diagnosis;
            }

            int sigIndex = diagnosis.IndexOf("Physician Signature:");
            if (sigIndex >= 0)
            {
                string sigLine = diagnosis.Substring(sigIndex);
                var sigLines = sigLine.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (sigLines.Length > 0)
                {
                    doctorSignature = sigLines[0].Replace("Physician Signature:", "").Trim();
                }
            }

            var lines = mainDiagnosis.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                string trimmed = line.Trim();

                if (trimmed.StartsWith("Physician Signature:") ||
                    trimmed.StartsWith("Assessment Date:") ||
                    trimmed.StartsWith("SECTION 2:") ||
                    trimmed == "SECTION 2: PHYSICIAN'S MEDICAL ASSESSMENT" ||
                    string.IsNullOrWhiteSpace(trimmed))
                {
                    continue;
                }

                if (trimmed.EndsWith(":") && trimmed == trimmed.ToUpper())
                {
                    Paragraph header = new Paragraph(trimmed, sectionFont);
                    header.SpacingBefore = 3;
                    header.SpacingAfter = 2;
                    document.Add(header);
                }
                else
                {
                    Paragraph content = new Paragraph(trimmed, normalFont);
                    content.SpacingAfter = 2;
                    document.Add(content);
                }
            }

            return string.Empty;
        }

        private Dictionary<string, object> GetPatientInfo()
        {
            Dictionary<string, object> info = new Dictionary<string, object>();

            try
            {
                string query = @"
                    SELECT 
                    u.name,
                    u.date_of_birth,
                    u.age,
                    u.gender,
                    p.blood_type,
                    p.phone_number,
                    p.emergency_contact,
                    p.allergies
                    FROM Patients p
                    INNER JOIN Users u ON p.user_id = u.user_id
                    WHERE p.patient_id = @patientId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@patientId", patientId));

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    foreach (DataColumn col in dt.Columns)
                    {
                        info[col.ColumnName] = row[col.ColumnName];
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading patient info: {ex.Message}");
            }

            return info;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}