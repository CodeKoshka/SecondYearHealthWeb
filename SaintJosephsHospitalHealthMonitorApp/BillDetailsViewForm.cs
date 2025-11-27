using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class BillDetailsViewForm : Form
    {
        private int billId;
        private DataTable billData;
        private DataTable servicesData;

        public BillDetailsViewForm(int billId)
        {
            this.billId = billId;
            InitializeComponent();
            LoadBillData();
        }

        private void LoadBillData()
        {
            try
            {
                string query = @"
            SELECT 
                b.bill_id,
                b.bill_date,
                u.name AS patient_name,
                u.age,
                u.gender,
                p.patient_id,
                p.blood_type,
                p.phone_number,
                d.name AS attending_physician,
                b.subtotal,
                b.discount_percent,
                b.discount_amount,
                b.tax_percent,
                b.tax_amount,
                b.amount,
                b.payment_method,
                b.status,
                b.notes,
                pq.queue_date,
                pq.reason_for_visit,
                pq.discharged_time,
                creator.name AS created_by_name
            FROM Billing b
            INNER JOIN Patients p ON b.patient_id = p.patient_id
            INNER JOIN Users u ON p.user_id = u.user_id
            LEFT JOIN patientqueue pq ON b.queue_id = pq.queue_id
            LEFT JOIN Doctors doc ON pq.doctor_id = doc.doctor_id
            LEFT JOIN Users d ON doc.user_id = d.user_id
            LEFT JOIN Users creator ON b.created_by = creator.user_id
            WHERE b.bill_id = @billId";

                billData = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@billId", billId));

                string servicesQuery = @"
            SELECT 
                COALESCE(s.service_name, 'Service') AS service_name,
                COALESCE(sc.category_name, 'General') AS category_name,
                bs.quantity,
                bs.unit_price,
                (bs.quantity * bs.unit_price) AS total
            FROM BillServices bs
            LEFT JOIN Services s ON bs.service_id = s.service_id
            LEFT JOIN ServiceCategories sc ON bs.category_id = sc.category_id
            WHERE bs.bill_id = @billId
            ORDER BY sc.category_name, s.service_name";

                servicesData = DatabaseHelper.ExecuteQuery(servicesQuery,
                    new MySqlParameter("@billId", billId));

                DisplayBillDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bill details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayBillDetails()
        {
            if (billData.Rows.Count == 0) return;

            DataRow bill = billData.Rows[0];

            lblAccountNumber.Text = $"ACCOUNT NO. {bill["bill_id"]}";
            lblPatientName.Text = bill["patient_name"].ToString();
            lblAge.Text = bill["age"].ToString();
            lblSex.Text = bill["gender"].ToString();
            lblAttendingPhysician.Text = bill["attending_physician"] != DBNull.Value
                ? bill["attending_physician"].ToString()
                : "N/A";

            lblDateAdmitted.Text = bill["queue_date"] != DBNull.Value
                ? Convert.ToDateTime(bill["queue_date"]).ToString("MMMM dd, yyyy")
                : "N/A";
            lblTimeAdmitted.Text = bill["bill_date"] != DBNull.Value
                ? Convert.ToDateTime(bill["bill_date"]).ToString("hh:mm tt")
                : "";
            lblDateToday.Text = DateTime.Now.ToString("MMMM dd, yyyy");

            dgvHospitalCharges.Rows.Clear();
            decimal hospitalChargesTotal = 0;

            foreach (DataRow service in servicesData.Rows)
            {
                string serviceName = service["service_name"].ToString();
                string categoryName = service["category_name"].ToString();
                int quantity = Convert.ToInt32(service["quantity"]);
                decimal unitPrice = Convert.ToDecimal(service["unit_price"]);
                decimal total = Convert.ToDecimal(service["total"]);

                dgvHospitalCharges.Rows.Add(
                    serviceName,
                    categoryName,
                    quantity.ToString(),
                    $"₱{unitPrice:N2}",
                    $"₱{total:N2}"
                );

                hospitalChargesTotal += total;
            }

            decimal subtotal = Convert.ToDecimal(bill["subtotal"]);
            decimal discountAmount = Convert.ToDecimal(bill["discount_amount"]);
            decimal taxAmount = Convert.ToDecimal(bill["tax_amount"]);
            decimal grandTotal = Convert.ToDecimal(bill["amount"]);

            DataGridViewRow subtotalRow = new DataGridViewRow();
            subtotalRow.CreateCells(dgvHospitalCharges);
            subtotalRow.Cells[0].Value = "SUBTOTAL:";
            subtotalRow.Cells[0].Style.Font = new System.Drawing.Font("Arial", 11F, FontStyle.Bold);
            subtotalRow.Cells[4].Value = $"₱{subtotal:N2}";
            subtotalRow.Cells[4].Style.Font = new System.Drawing.Font("Arial", 11F, FontStyle.Bold);
            subtotalRow.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            subtotalRow.Height = 40;
            dgvHospitalCharges.Rows.Add(subtotalRow);

            if (discountAmount > 0)
            {
                decimal discountPercent = Convert.ToDecimal(bill["discount_percent"]);
                DataGridViewRow discountRow = new DataGridViewRow();
                discountRow.CreateCells(dgvHospitalCharges);
                discountRow.Cells[0].Value = $"DISCOUNT ({discountPercent}%):";
                discountRow.Cells[0].Style.Font = new System.Drawing.Font(dgvHospitalCharges.Font, FontStyle.Bold);
                discountRow.Cells[4].Value = $"-₱{discountAmount:N2}";
                discountRow.Cells[4].Style.Font = new System.Drawing.Font(dgvHospitalCharges.Font, FontStyle.Bold);
                discountRow.Cells[4].Style.ForeColor = Color.FromArgb(231, 76, 60);
                discountRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 235);
                dgvHospitalCharges.Rows.Add(discountRow);
            }

            if (taxAmount > 0)
            {
                decimal taxPercent = Convert.ToDecimal(bill["tax_percent"]);
                DataGridViewRow taxRow = new DataGridViewRow();
                taxRow.CreateCells(dgvHospitalCharges);
                taxRow.Cells[0].Value = $"TAX ({taxPercent}%):";
                taxRow.Cells[0].Style.Font = new System.Drawing.Font(dgvHospitalCharges.Font, FontStyle.Bold);
                taxRow.Cells[4].Value = $"₱{taxAmount:N2}";
                taxRow.Cells[4].Style.Font = new System.Drawing.Font(dgvHospitalCharges.Font, FontStyle.Bold);
                taxRow.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                dgvHospitalCharges.Rows.Add(taxRow);
            }

            DataGridViewRow totalRow = new DataGridViewRow();
            totalRow.CreateCells(dgvHospitalCharges);
            totalRow.Cells[0].Value = "TOTAL:";
            totalRow.Cells[0].Style.Font = new System.Drawing.Font(dgvHospitalCharges.Font, FontStyle.Bold);
            totalRow.Cells[4].Value = $"₱{grandTotal:N2}";
            totalRow.Cells[4].Style.Font = new System.Drawing.Font(dgvHospitalCharges.Font, FontStyle.Bold);
            totalRow.DefaultCellStyle.BackColor = Color.FromArgb(66, 153, 225);
            totalRow.DefaultCellStyle.ForeColor = Color.White;
            dgvHospitalCharges.Rows.Add(totalRow);

            lblGrandTotal.Text = $"GRAND TOTAL:   ₱{grandTotal:N2}";

            lblPreparedBy.Text = bill["created_by_name"] != DBNull.Value
                ? bill["created_by_name"].ToString()
                : "System";

            lblStatus.Text = bill["status"].ToString();
            switch (bill["status"].ToString().ToUpper())
            {
                case "PAID":
                    lblStatus.ForeColor = Color.FromArgb(46, 204, 113);
                    break;
                case "PENDING":
                    lblStatus.ForeColor = Color.FromArgb(243, 156, 18);
                    break;
                case "PARTIALLY PAID":
                    lblStatus.ForeColor = Color.FromArgb(52, 152, 219);
                    break;
                case "CANCELLED":
                    lblStatus.ForeColor = Color.FromArgb(231, 76, 60);
                    break;
            }
        }

        private void PreviewAndSavePDF()
        {
            try
            {
                if (billData.Rows.Count == 0) return;

                string tempPdfPath = Path.Combine(Path.GetTempPath(), $"Bill_{billId}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                Document document = new Document(PageSize.A4, 50, 50, 50, 50);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(tempPdfPath, FileMode.Create));

                document.Open();

                iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font headerFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = FontFactory.GetFont("Arial", 11);
                iTextSharp.text.Font smallFont = FontFactory.GetFont("Arial", 10);
                iTextSharp.text.Font tableHeaderFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);

                DataRow bill = billData.Rows[0];

                Paragraph hospitalName = new Paragraph("ST. JOSEPH'S HOSPITAL", headerFont);
                hospitalName.Alignment = Element.ALIGN_CENTER;
                hospitalName.SpacingAfter = 5;
                document.Add(hospitalName);

                Paragraph statementTitle = new Paragraph("STATEMENT OF ACCOUNT", titleFont);
                statementTitle.Alignment = Element.ALIGN_CENTER;
                statementTitle.SpacingAfter = 25;
                document.Add(statementTitle);

                PdfPTable patientTable = new PdfPTable(2);
                patientTable.WidthPercentage = 100;
                patientTable.SetWidths(new float[] { 1, 1 });
                patientTable.SpacingAfter = 20;

                PdfPCell cellPatient = new PdfPCell(new Phrase($"Patient: {bill["patient_name"]}", normalFont));
                cellPatient.Border = 0;
                cellPatient.PaddingBottom = 8;
                patientTable.AddCell(cellPatient);

                PdfPCell cellAccount = new PdfPCell(new Phrase($"ACCOUNT NO. {bill["bill_id"]}", normalFont));
                cellAccount.Border = 0;
                cellAccount.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellAccount.PaddingBottom = 8;
                patientTable.AddCell(cellAccount);

                PdfPCell cellAge = new PdfPCell(new Phrase($"Age: {bill["age"]}   Sex: {bill["gender"]}", normalFont));
                cellAge.Border = 0;
                cellAge.PaddingBottom = 8;
                patientTable.AddCell(cellAge);

                PdfPCell cellDateAdmitted = new PdfPCell(new Phrase($"Date Admitted: {(bill["queue_date"] != DBNull.Value ? Convert.ToDateTime(bill["queue_date"]).ToString("MMMM dd, yyyy") : "N/A")}", normalFont));
                cellDateAdmitted.Border = 0;
                cellDateAdmitted.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellDateAdmitted.PaddingBottom = 8;
                patientTable.AddCell(cellDateAdmitted);

                PdfPCell cellPhysician = new PdfPCell(new Phrase($"Attending Physician: {(bill["attending_physician"] != DBNull.Value ? bill["attending_physician"].ToString() : "N/A")}", normalFont));
                cellPhysician.Border = 0;
                cellPhysician.PaddingBottom = 8;
                patientTable.AddCell(cellPhysician);

                PdfPCell cellTimeAdmitted = new PdfPCell(new Phrase($"Time Admitted: {(bill["bill_date"] != DBNull.Value ? Convert.ToDateTime(bill["bill_date"]).ToString("hh:mm tt") : "")}", normalFont));
                cellTimeAdmitted.Border = 0;
                cellTimeAdmitted.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellTimeAdmitted.PaddingBottom = 8;
                patientTable.AddCell(cellTimeAdmitted);

                PdfPCell cellStatus = new PdfPCell(new Phrase($"Status: {bill["status"]}", normalFont));
                cellStatus.Border = 0;
                cellStatus.PaddingBottom = 8;
                patientTable.AddCell(cellStatus);

                PdfPCell cellDateToday = new PdfPCell(new Phrase($"Date Today: {DateTime.Now:MMMM dd, yyyy}", normalFont));
                cellDateToday.Border = 0;
                cellDateToday.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellDateToday.PaddingBottom = 8;
                patientTable.AddCell(cellDateToday);

                document.Add(patientTable);

                Paragraph chargesTitle = new Paragraph("HOSPITAL CHARGES", headerFont);
                chargesTitle.SpacingAfter = 10;
                document.Add(chargesTitle);

                PdfPTable chargesTable = new PdfPTable(5);
                chargesTable.WidthPercentage = 100;
                chargesTable.SetWidths(new float[] { 3, 1.5f, 1, 1.2f, 1.3f });
                chargesTable.SpacingAfter = 15;

                PdfPCell headerService = new PdfPCell(new Phrase("SERVICE/ITEM", tableHeaderFont));
                headerService.BackgroundColor = new BaseColor(240, 240, 240);
                headerService.Padding = 8;
                headerService.HorizontalAlignment = Element.ALIGN_LEFT;
                chargesTable.AddCell(headerService);

                PdfPCell headerCategory = new PdfPCell(new Phrase("CATEGORY", tableHeaderFont));
                headerCategory.BackgroundColor = new BaseColor(240, 240, 240);
                headerCategory.Padding = 8;
                headerCategory.HorizontalAlignment = Element.ALIGN_LEFT;
                chargesTable.AddCell(headerCategory);

                PdfPCell headerQty = new PdfPCell(new Phrase("QTY", tableHeaderFont));
                headerQty.BackgroundColor = new BaseColor(240, 240, 240);
                headerQty.Padding = 8;
                headerQty.HorizontalAlignment = Element.ALIGN_CENTER;
                chargesTable.AddCell(headerQty);

                PdfPCell headerUnitPrice = new PdfPCell(new Phrase("UNIT PRICE", tableHeaderFont));
                headerUnitPrice.BackgroundColor = new BaseColor(240, 240, 240);
                headerUnitPrice.Padding = 8;
                headerUnitPrice.HorizontalAlignment = Element.ALIGN_RIGHT;
                chargesTable.AddCell(headerUnitPrice);

                PdfPCell headerAmount = new PdfPCell(new Phrase("AMOUNT", tableHeaderFont));
                headerAmount.BackgroundColor = new BaseColor(240, 240, 240);
                headerAmount.Padding = 8;
                headerAmount.HorizontalAlignment = Element.ALIGN_RIGHT;
                chargesTable.AddCell(headerAmount);

                decimal hospitalChargesTotal = 0;
                foreach (DataRow service in servicesData.Rows)
                {
                    string serviceName = service["service_name"].ToString();
                    string categoryName = service["category_name"].ToString();
                    int quantity = Convert.ToInt32(service["quantity"]);
                    decimal unitPrice = Convert.ToDecimal(service["unit_price"]);
                    decimal total = Convert.ToDecimal(service["total"]);
                    hospitalChargesTotal += total;

                    PdfPCell cellService = new PdfPCell(new Phrase(serviceName, smallFont));
                    cellService.Padding = 6;
                    cellService.HorizontalAlignment = Element.ALIGN_LEFT;
                    chargesTable.AddCell(cellService);

                    PdfPCell cellCategory = new PdfPCell(new Phrase(categoryName, smallFont));
                    cellCategory.Padding = 6;
                    cellCategory.HorizontalAlignment = Element.ALIGN_LEFT;
                    chargesTable.AddCell(cellCategory);

                    PdfPCell cellQty = new PdfPCell(new Phrase(quantity.ToString(), smallFont));
                    cellQty.Padding = 6;
                    cellQty.HorizontalAlignment = Element.ALIGN_CENTER;
                    chargesTable.AddCell(cellQty);

                    PdfPCell cellUnit = new PdfPCell(new Phrase($"₱{unitPrice:N2}", smallFont));
                    cellUnit.Padding = 6;
                    cellUnit.HorizontalAlignment = Element.ALIGN_RIGHT;
                    chargesTable.AddCell(cellUnit);

                    PdfPCell cellTotal = new PdfPCell(new Phrase($"₱{total:N2}", smallFont));
                    cellTotal.Padding = 6;
                    cellTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
                    chargesTable.AddCell(cellTotal);
                }

                decimal subtotal = Convert.ToDecimal(bill["subtotal"]);
                decimal discountAmount = Convert.ToDecimal(bill["discount_amount"]);
                decimal discountPercent = Convert.ToDecimal(bill["discount_percent"]);
                decimal taxAmount = Convert.ToDecimal(bill["tax_amount"]);
                decimal taxPercent = Convert.ToDecimal(bill["tax_percent"]);
                decimal grandTotal = Convert.ToDecimal(bill["amount"]);

                PdfPCell subtotalLabel = new PdfPCell(new Phrase("SUBTOTAL:", headerFont));
                subtotalLabel.Colspan = 4;
                subtotalLabel.BackgroundColor = new BaseColor(240, 240, 240);
                subtotalLabel.Padding = 10;
                subtotalLabel.HorizontalAlignment = Element.ALIGN_LEFT;
                chargesTable.AddCell(subtotalLabel);

                PdfPCell subtotalValue = new PdfPCell(new Phrase($"₱{subtotal:N2}", headerFont));
                subtotalValue.BackgroundColor = new BaseColor(240, 240, 240);
                subtotalValue.Padding = 10;
                subtotalValue.HorizontalAlignment = Element.ALIGN_RIGHT;
                chargesTable.AddCell(subtotalValue);

                if (discountAmount > 0)
                {
                    PdfPCell discountLabel = new PdfPCell(new Phrase($"DISCOUNT ({discountPercent}%):", headerFont));
                    discountLabel.Colspan = 4;
                    discountLabel.BackgroundColor = new BaseColor(255, 250, 235);
                    discountLabel.Padding = 10;
                    discountLabel.HorizontalAlignment = Element.ALIGN_LEFT;
                    chargesTable.AddCell(discountLabel);

                    PdfPCell discountValue = new PdfPCell(new Phrase($"-₱{discountAmount:N2}", headerFont));
                    discountValue.BackgroundColor = new BaseColor(255, 250, 235);
                    discountValue.Padding = 10;
                    discountValue.HorizontalAlignment = Element.ALIGN_RIGHT;
                    chargesTable.AddCell(discountValue);
                }

                if (taxAmount > 0)
                {
                    PdfPCell taxLabel = new PdfPCell(new Phrase($"TAX ({taxPercent}%):", headerFont));
                    taxLabel.Colspan = 4;
                    taxLabel.BackgroundColor = new BaseColor(240, 240, 240);
                    taxLabel.Padding = 10;
                    taxLabel.HorizontalAlignment = Element.ALIGN_LEFT;
                    chargesTable.AddCell(taxLabel);

                    PdfPCell taxValue = new PdfPCell(new Phrase($"₱{taxAmount:N2}", headerFont));
                    taxValue.BackgroundColor = new BaseColor(240, 240, 240);
                    taxValue.Padding = 10;
                    taxValue.HorizontalAlignment = Element.ALIGN_RIGHT;
                    chargesTable.AddCell(taxValue);
                }

                PdfPCell totalLabel = new PdfPCell(new Phrase("TOTAL:", headerFont));
                totalLabel.Colspan = 4;
                totalLabel.BackgroundColor = new BaseColor(66, 153, 225);
                totalLabel.Padding = 10;
                totalLabel.HorizontalAlignment = Element.ALIGN_LEFT;
                chargesTable.AddCell(totalLabel);

                PdfPCell totalValue = new PdfPCell(new Phrase($"₱{grandTotal:N2}", headerFont));
                totalValue.BackgroundColor = new BaseColor(66, 153, 225);
                totalValue.Padding = 10;
                totalValue.HorizontalAlignment = Element.ALIGN_RIGHT;
                chargesTable.AddCell(totalValue);

                document.Add(chargesTable);

                Paragraph totalPara = new Paragraph($"GRAND TOTAL:   ₱{grandTotal:N2}", titleFont);
                totalPara.Alignment = Element.ALIGN_RIGHT;
                totalPara.SpacingAfter = 40;
                document.Add(totalPara);

                Paragraph acknowledgement = new Paragraph("ACKNOWLEDGEMENT OF MEMBER/REPRESENTATIVE", smallFont);
                acknowledgement.SpacingAfter = 20;
                document.Add(acknowledgement);

                Paragraph signatureLine = new Paragraph("_________________________________", normalFont);
                signatureLine.SpacingAfter = 5;
                document.Add(signatureLine);

                Paragraph signatureText = new Paragraph("Signature Over Printed Name", smallFont);
                signatureText.SpacingAfter = 20;
                document.Add(signatureText);

                Paragraph preparedBy = new Paragraph($"Prepared by: {(bill["created_by_name"] != DBNull.Value ? bill["created_by_name"].ToString() : "System")}", smallFont);
                document.Add(preparedBy);

                document.Close();
                writer.Close();

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true
                });

                DialogResult result = MessageBox.Show(
                    "PDF preview has been opened. Would you like to save a permanent copy?",
                    "Save PDF",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveDialog.FileName = $"Bill_{billId}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(tempPdfPath, saveDialog.FileName, true);
                        MessageBox.Show($"PDF saved successfully!\n{saveDialog.FileName}", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPreviewPDF_Click(object sender, EventArgs e)
        {
            PreviewAndSavePDF();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}