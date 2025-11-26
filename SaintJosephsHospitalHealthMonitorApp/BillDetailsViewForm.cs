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
                string particulars = service["service_name"].ToString();
                decimal total = Convert.ToDecimal(service["total"]);

                dgvHospitalCharges.Rows.Add(
                    particulars,
                    $"₱{total:N2}",
                    "0.00",
                    "0.00",
                    "0.00",
                    $"₱{total:N2}"
                );

                hospitalChargesTotal += total;
            }

            dgvHospitalCharges.Rows.Add(
                "TOTAL:",
                $"₱{hospitalChargesTotal:N2}",
                "0.00",
                "0.00",
                "0.00",
                $"₱{hospitalChargesTotal:N2}"
            );

            lblGrandTotal.Text = $"GRAND TOTAL:   ₱{hospitalChargesTotal:N2}";

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

                iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font headerFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = FontFactory.GetFont("Arial", 9);
                iTextSharp.text.Font smallFont = FontFactory.GetFont("Arial", 8);

                DataRow bill = billData.Rows[0];

                Paragraph hospitalName = new Paragraph("ST. JOSEPH'S HOSPITAL", headerFont);
                hospitalName.Alignment = Element.ALIGN_CENTER;
                document.Add(hospitalName);

                Paragraph statementTitle = new Paragraph("STATEMENT OF ACCOUNT", titleFont);
                statementTitle.Alignment = Element.ALIGN_CENTER;
                statementTitle.SpacingAfter = 20;
                document.Add(statementTitle);

                PdfPTable patientTable = new PdfPTable(2);
                patientTable.WidthPercentage = 100;
                patientTable.SetWidths(new float[] { 1, 1 });

                patientTable.AddCell(new PdfPCell(new Phrase($"Patient: {bill["patient_name"]}", normalFont)) { Border = 0 });
                patientTable.AddCell(new PdfPCell(new Phrase($"ACCOUNT NO. {bill["bill_id"]}", normalFont)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

                patientTable.AddCell(new PdfPCell(new Phrase($"Age: {bill["age"]}   Sex: {bill["gender"]}", normalFont)) { Border = 0 });
                patientTable.AddCell(new PdfPCell(new Phrase($"Date Admitted: {(bill["queue_date"] != DBNull.Value ? Convert.ToDateTime(bill["queue_date"]).ToString("MMMM dd, yyyy") : "N/A")}", normalFont)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

                patientTable.AddCell(new PdfPCell(new Phrase($"Attending Physician: {(bill["attending_physician"] != DBNull.Value ? bill["attending_physician"].ToString() : "N/A")}", normalFont)) { Border = 0 });
                patientTable.AddCell(new PdfPCell(new Phrase($"Time Admitted: {(bill["bill_date"] != DBNull.Value ? Convert.ToDateTime(bill["bill_date"]).ToString("hh:mm tt") : "")}", normalFont)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

                patientTable.AddCell(new PdfPCell(new Phrase($"Status: {bill["status"]}", normalFont)) { Border = 0 });
                patientTable.AddCell(new PdfPCell(new Phrase($"Date Today: {DateTime.Now:MMMM dd, yyyy}", normalFont)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

                patientTable.SpacingAfter = 20;
                document.Add(patientTable);

                document.Add(new Paragraph("HOSPITAL CHARGES", headerFont));

                PdfPTable chargesTable = new PdfPTable(6);
                chargesTable.WidthPercentage = 100;
                chargesTable.SetWidths(new float[] { 3, 1, 1, 1, 1, 1 });

                chargesTable.AddCell(new PdfPCell(new Phrase("PARTICULARS", smallFont)) { BackgroundColor = new BaseColor(240, 240, 240) });
                chargesTable.AddCell(new PdfPCell(new Phrase("TOTAL", smallFont)) { BackgroundColor = new BaseColor(240, 240, 240) });
                chargesTable.AddCell(new PdfPCell(new Phrase("PHIC", smallFont)) { BackgroundColor = new BaseColor(240, 240, 240) });
                chargesTable.AddCell(new PdfPCell(new Phrase("MSS", smallFont)) { BackgroundColor = new BaseColor(240, 240, 240) });
                chargesTable.AddCell(new PdfPCell(new Phrase("CASH", smallFont)) { BackgroundColor = new BaseColor(240, 240, 240) });
                chargesTable.AddCell(new PdfPCell(new Phrase("BALANCE", smallFont)) { BackgroundColor = new BaseColor(240, 240, 240) });

                decimal hospitalChargesTotal = 0;
                foreach (DataRow service in servicesData.Rows)
                {
                    string particulars = service["service_name"].ToString();
                    decimal total = Convert.ToDecimal(service["total"]);
                    hospitalChargesTotal += total;

                    chargesTable.AddCell(new Phrase(particulars, smallFont));
                    chargesTable.AddCell(new Phrase($"₱{total:N2}", smallFont));
                    chargesTable.AddCell(new Phrase("0.00", smallFont));
                    chargesTable.AddCell(new Phrase("0.00", smallFont));
                    chargesTable.AddCell(new Phrase("0.00", smallFont));
                    chargesTable.AddCell(new Phrase($"₱{total:N2}", smallFont));
                }

                chargesTable.AddCell(new PdfPCell(new Phrase("TOTAL:", headerFont)) { BackgroundColor = new BaseColor(240, 240, 240) });
                chargesTable.AddCell(new PdfPCell(new Phrase($"₱{hospitalChargesTotal:N2}", headerFont)) { BackgroundColor = new BaseColor(240, 240, 240) });
                chargesTable.AddCell(new PdfPCell(new Phrase("0.00", headerFont)) { BackgroundColor = new BaseColor(240, 240, 240) });
                chargesTable.AddCell(new PdfPCell(new Phrase("0.00", headerFont)) { BackgroundColor = new BaseColor(240, 240, 240) });
                chargesTable.AddCell(new PdfPCell(new Phrase("0.00", headerFont)) { BackgroundColor = new BaseColor(240, 240, 240) });
                chargesTable.AddCell(new PdfPCell(new Phrase($"₱{hospitalChargesTotal:N2}", headerFont)) { BackgroundColor = new BaseColor(240, 240, 240) });

                chargesTable.SpacingAfter = 20;
                document.Add(chargesTable);

                Paragraph totalPara = new Paragraph($"GRAND TOTAL:   ₱{hospitalChargesTotal:N2}", titleFont);
                totalPara.Alignment = Element.ALIGN_RIGHT;
                totalPara.SpacingAfter = 30;
                document.Add(totalPara);

                document.Add(new Paragraph("ACKNOWLEDGEMENT OF MEMBER/REPRESENTATIVE", smallFont));
                document.Add(new Paragraph("\n_________________________________", normalFont));
                document.Add(new Paragraph("Signature Over Printed Name", smallFont));
                document.Add(new Paragraph($"\nPrepared by: {(bill["created_by_name"] != DBNull.Value ? bill["created_by_name"].ToString() : "System")}", smallFont));

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