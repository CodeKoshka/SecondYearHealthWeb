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
                displayDt.Columns.Add("Clinical Summary", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    string diagnosis = row["diagnosis"].ToString();
                    string summary = diagnosis.Length > 100
                        ? diagnosis.Substring(0, 100) + "..."
                        : diagnosis;

                    DateTime recordDate = Convert.ToDateTime(row["record_date"]);

                    displayDt.Rows.Add(
                        row["record_id"],
                        recordDate.ToString("yyyy-MM-dd HH:mm"),
                        row["visit_type"],
                        row["doctor_name"],
                        summary
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
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveDialog.FileName = $"MedicalHistory_{patientName.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                    saveDialog.Title = "Save Medical History as PDF";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        GeneratePDF(saveDialog.FileName);

                        MessageBox.Show(
                            $"✅ Medical History PDF saved successfully!\n\n" +
                            $"Location: {saveDialog.FileName}",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
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

        private void GeneratePDF(string filePath)
        {
            Document document = new Document(PageSize.A4, 40, 40, 50, 50);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
            Font hospitalFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
            Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.BLACK);
            Font labelFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.BLACK);
            Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);
            Font smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK);
            Font smallBoldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, BaseColor.BLACK);

            var patientInfo = GetPatientInfo();

            Paragraph hospitalName = new Paragraph("ST. JOSEPH'S CARDIAC HOSPITAL", titleFont);
            hospitalName.Alignment = Element.ALIGN_CENTER;
            document.Add(hospitalName);

            Paragraph department = new Paragraph("Department of Cardiology", hospitalFont);
            department.Alignment = Element.ALIGN_CENTER;
            department.SpacingAfter = 5;
            document.Add(department);

            Paragraph contact = new Paragraph("123 Medical Plaza, Healthcare District | Phone: (555) 123-4567", smallFont);
            contact.Alignment = Element.ALIGN_CENTER;
            contact.SpacingAfter = 10;
            document.Add(contact);

            LineSeparator line = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -2);
            document.Add(new Chunk(line));
            document.Add(new Paragraph(" ", normalFont) { SpacingAfter = 5 });

            Paragraph docTitle = new Paragraph("COMPLETE MEDICAL HISTORY SUMMARY", headerFont);
            docTitle.Alignment = Element.ALIGN_CENTER;
            docTitle.SpacingAfter = 5;
            document.Add(docTitle);

            Paragraph generated = new Paragraph($"Generated: {DateTime.Now:MMMM dd, yyyy 'at' hh:mm tt}", smallFont);
            generated.Alignment = Element.ALIGN_CENTER;
            generated.SpacingAfter = 15;
            document.Add(generated);

            PdfPTable patientTable = new PdfPTable(1);
            patientTable.WidthPercentage = 100;
            patientTable.SpacingAfter = 15;

            PdfPCell headerCell = new PdfPCell(new Phrase("PATIENT INFORMATION", labelFont));
            headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            headerCell.Padding = 8;
            headerCell.Border = Rectangle.BOX;
            patientTable.AddCell(headerCell);

            PdfPCell infoCell = new PdfPCell();
            infoCell.Border = Rectangle.BOX;
            infoCell.Padding = 10;

            StringBuilder patientInfoText = new StringBuilder();
            patientInfoText.AppendLine($"Name: {patientInfo["name"]}");

            if (patientInfo["date_of_birth"] != DBNull.Value && patientInfo["date_of_birth"] != null)
            {
                DateTime dob = Convert.ToDateTime(patientInfo["date_of_birth"]);
                patientInfoText.AppendLine($"Date of Birth: {dob:MM/dd/yyyy} (Age: {patientInfo["age"]})");
            }
            else
            {
                patientInfoText.AppendLine($"Age: {patientInfo["age"]} years");
            }

            patientInfoText.AppendLine($"Gender: {patientInfo["gender"]}");
            patientInfoText.AppendLine($"Blood Type: {patientInfo["blood_type"] ?? "Unknown"}");
            patientInfoText.AppendLine($"Phone: {patientInfo["phone_number"] ?? "Not provided"}");
            patientInfoText.AppendLine($"Emergency Contact: {patientInfo["emergency_contact"] ?? "Not provided"}");

            string allergies = patientInfo["allergies"]?.ToString();
            if (!string.IsNullOrWhiteSpace(allergies))
            {
                patientInfoText.AppendLine($"*** ALLERGIES: {allergies} ***");
            }

            infoCell.AddElement(new Paragraph(patientInfoText.ToString(), normalFont));
            patientTable.AddCell(infoCell);

            document.Add(patientTable);

            PdfPTable statsTable = new PdfPTable(2);
            statsTable.WidthPercentage = 100;
            statsTable.SpacingAfter = 15;

            PdfPCell recordsCell = new PdfPCell(new Phrase($"Total Medical Records: {recordCount}", labelFont));
            recordsCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            recordsCell.Padding = 8;
            recordsCell.HorizontalAlignment = Element.ALIGN_LEFT;
            statsTable.AddCell(recordsCell);

            PdfPCell visitsCell = new PdfPCell(new Phrase($"Total Hospital Visits: {visitCount}", labelFont));
            visitsCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            visitsCell.Padding = 8;
            visitsCell.HorizontalAlignment = Element.ALIGN_LEFT;
            statsTable.AddCell(visitsCell);

            document.Add(statsTable);

            Paragraph recordsHeader = new Paragraph("CHRONOLOGICAL MEDICAL RECORDS", headerFont);
            recordsHeader.SpacingAfter = 10;
            document.Add(recordsHeader);

            var records = GetMedicalRecords();

            foreach (DataRow record in records.Rows)
            {
                PdfPTable recordTable = new PdfPTable(1);
                recordTable.WidthPercentage = 100;
                recordTable.SpacingAfter = 10;

                DateTime recordDate = Convert.ToDateTime(record["record_date"]);

                PdfPCell recordHeaderCell = new PdfPCell(
                    new Phrase($"MEDICAL RECORD - {recordDate:MMMM dd, yyyy 'at' hh:mm tt}", smallBoldFont));
                recordHeaderCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                recordHeaderCell.Padding = 6;
                recordTable.AddCell(recordHeaderCell);

                PdfPCell detailsCell = new PdfPCell();
                detailsCell.Border = Rectangle.BOX;
                detailsCell.Padding = 10;

                StringBuilder recordInfo = new StringBuilder();
                recordInfo.AppendLine($"Visit Type: {record["visit_type"]}");
                recordInfo.AppendLine($"Attending Physician: Dr. {record["doctor_name"]}");
                recordInfo.AppendLine($"Date: {recordDate:MM/dd/yyyy HH:mm}");
                recordInfo.AppendLine("");
                recordInfo.AppendLine("ASSESSMENT & DIAGNOSIS:");
                recordInfo.AppendLine(new string('-', 80));
                recordInfo.AppendLine(record["diagnosis"].ToString());

                if (!string.IsNullOrWhiteSpace(record["prescription"].ToString()) &&
                    record["prescription"].ToString() != "No medications prescribed.")
                {
                    recordInfo.AppendLine("");
                    recordInfo.AppendLine("MEDICATIONS PRESCRIBED:");
                    recordInfo.AppendLine(new string('-', 80));
                    recordInfo.AppendLine(record["prescription"].ToString());
                }

                detailsCell.AddElement(new Paragraph(recordInfo.ToString(), normalFont));
                recordTable.AddCell(detailsCell);

                document.Add(recordTable);

                if (writer.GetVerticalPosition(false) < 150)
                {
                    document.NewPage();
                }
            }

            document.Add(new Paragraph(" ", normalFont) { SpacingBefore = 20 });

            LineSeparator footerLine = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -2);
            document.Add(new Chunk(footerLine));

            Paragraph confidential = new Paragraph("CONFIDENTIAL MEDICAL RECORD - Protected Health Information", smallBoldFont);
            confidential.Alignment = Element.ALIGN_CENTER;
            confidential.SpacingAfter = 3;
            document.Add(confidential);

            Paragraph disclaimer = new Paragraph(
                "This document contains privileged medical information. Unauthorized disclosure is prohibited by law.",
                smallFont);
            disclaimer.Alignment = Element.ALIGN_CENTER;
            disclaimer.SpacingAfter = 5;
            document.Add(disclaimer);

            Paragraph docId = new Paragraph($"Document ID: MH-{patientId:D6}-{DateTime.Now:yyyyMMdd}", smallFont);
            docId.Alignment = Element.ALIGN_CENTER;
            document.Add(docId);

            document.Close();
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

        private DataTable GetMedicalRecords()
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

            return DatabaseHelper.ExecuteQuery(query,
                new MySqlParameter("@patientId", patientId));
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}