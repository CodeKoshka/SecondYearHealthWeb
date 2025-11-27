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
    public partial class IncomeReportForm : Form
    {
        public IncomeReportForm()
        {
            InitializeComponent();
            InitializeDateRanges();
        }

        private void InitializeDateRanges()
        {
            rbThisMonth.CheckedChanged += RadioButton_CheckedChanged;
            rbLastMonth.CheckedChanged += RadioButton_CheckedChanged;
            rbCustomRange.CheckedChanged += RadioButton_CheckedChanged;

            rbThisMonth.Checked = true;
            UpdateDatesForThisMonth();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rbThisMonth.Checked)
            {
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
                UpdateDatesForThisMonth();
            }
            else if (rbLastMonth.Checked)
            {
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
                UpdateDatesForLastMonth();
            }
            else if (rbCustomRange.Checked)
            {
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;
            }
        }

        private void UpdateDatesForThisMonth()
        {
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now.Date;
        }

        private void UpdateDatesForLastMonth()
        {
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            dtpStartDate.Value = new DateTime(lastMonth.Year, lastMonth.Month, 1);
            dtpEndDate.Value = new DateTime(lastMonth.Year, lastMonth.Month,
                DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month));
        }

        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Start date cannot be later than end date.", "Invalid Date Range",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                IncomeReportPDF reportGenerator = new IncomeReportPDF();
                bool previewResult = reportGenerator.ShowPreview(dtpStartDate.Value.Date, dtpEndDate.Value.Date);

                if (previewResult)
                {
                    reportGenerator.GenerateIncomeReport(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class IncomeReportPDF
    {
        private DataTable reportData;
        private DateTime startDate;
        private DateTime endDate;
        private decimal totalIncome;
        private decimal totalDiscount;
        private decimal totalTax;
        private decimal grossIncome;

        public bool ShowPreview(DateTime fromDate, DateTime toDate)
        {
            startDate = fromDate;
            endDate = toDate;

            LoadReportData();

            if (reportData.Rows.Count == 0)
            {
                MessageBox.Show(
                    $"No paid bills found between {fromDate:MMMM dd, yyyy} and {toDate:MMMM dd, yyyy}.",
                    "No Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }

            using (IncomeReportPreviewForm previewForm = new IncomeReportPreviewForm(
                reportData, startDate, endDate, totalIncome, totalDiscount, totalTax, grossIncome))
            {
                return previewForm.ShowDialog() == DialogResult.OK;
            }
        }

        private void LoadReportData()
        {
            string query = @"
                SELECT 
                    b.bill_id AS 'Bill ID',
                    u.name AS 'Patient Name',
                    DATE_FORMAT(b.bill_date, '%Y-%m-%d') AS 'Bill Date',
                    b.subtotal AS 'Subtotal',
                    b.discount_amount AS 'Discount',
                    b.tax_amount AS 'Tax',
                    b.amount AS 'Total'
                FROM Billing b
                INNER JOIN Patients p ON b.patient_id = p.patient_id
                INNER JOIN Users u ON p.user_id = u.user_id
                WHERE DATE(b.bill_date) BETWEEN @startDate AND @endDate
                AND b.status = 'Paid'
                ORDER BY b.bill_date ASC";

            reportData = DatabaseHelper.ExecuteQuery(query,
                new MySqlParameter("@startDate", startDate.Date),
                new MySqlParameter("@endDate", endDate.Date));

            totalIncome = 0;
            totalDiscount = 0;
            totalTax = 0;
            grossIncome = 0;

            foreach (DataRow row in reportData.Rows)
            {
                grossIncome += Convert.ToDecimal(row["Subtotal"]);
                totalDiscount += Convert.ToDecimal(row["Discount"]);
                totalTax += Convert.ToDecimal(row["Tax"]);
                totalIncome += Convert.ToDecimal(row["Total"]);
            }
        }

        public void GenerateIncomeReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                startDate = fromDate;
                endDate = toDate;

                if (reportData == null || reportData.Rows.Count == 0)
                {
                    LoadReportData();
                }

                string tempPdfPath = Path.Combine(Path.GetTempPath(), $"IncomeReport_{startDate:yyyyMMdd}_to_{endDate:yyyyMMdd}_{DateTime.Now:HHmmss}.pdf");
                GeneratePDF(tempPdfPath);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true
                });

                DialogResult saveResult = MessageBox.Show(
                    "PDF preview has been opened. Would you like to save a permanent copy?",
                    "Save PDF",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (saveResult == DialogResult.Yes)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "PDF Files (*.pdf)|*.pdf",
                        FileName = $"IncomeReport_{startDate:yyyyMMdd}_to_{endDate:yyyyMMdd}.pdf",
                        Title = "Save Income Report"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(tempPdfPath, saveDialog.FileName, true);
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

        private void GeneratePDF(string filePath)
        {
            Document document = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

            iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font headerFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font normalFont = FontFactory.GetFont("Arial", 10);
            iTextSharp.text.Font smallFont = FontFactory.GetFont("Arial", 8);

            document.Open();

            Paragraph hospitalName = new Paragraph("ST. JOSEPH'S HOSPITAL", titleFont);
            hospitalName.Alignment = Element.ALIGN_CENTER;
            document.Add(hospitalName);

            Paragraph reportTitle = new Paragraph("INCOME REPORT", headerFont);
            reportTitle.Alignment = Element.ALIGN_CENTER;
            reportTitle.SpacingAfter = 10;
            document.Add(reportTitle);

            Paragraph dateRange = new Paragraph($"Period: {startDate:MMMM dd, yyyy} - {endDate:MMMM dd, yyyy}", normalFont);
            dateRange.Alignment = Element.ALIGN_CENTER;
            dateRange.SpacingAfter = 5;
            document.Add(dateRange);

            Paragraph generatedDate = new Paragraph($"Generated: {DateTime.Now:MMMM dd, yyyy hh:mm tt}", smallFont);
            generatedDate.Alignment = Element.ALIGN_CENTER;
            generatedDate.SpacingAfter = 20;
            document.Add(generatedDate);

            PdfPTable summaryTable = new PdfPTable(2);
            summaryTable.WidthPercentage = 100;
            summaryTable.SpacingAfter = 20;

            PdfPCell summaryHeader = new PdfPCell(new Phrase("FINANCIAL SUMMARY", headerFont));
            summaryHeader.Colspan = 2;
            summaryHeader.BackgroundColor = new BaseColor(240, 240, 240);
            summaryHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            summaryHeader.Padding = 10;
            summaryTable.AddCell(summaryHeader);

            PdfPTable transactionsTable = new PdfPTable(6);
            transactionsTable.WidthPercentage = 100;

            transactionsTable.SetWidths(new float[] { 1.3f, 2.8f, 2.0f, 1.3f, 1.3f, 1.3f });

            string[] headers = { "Bill ID", "Patient Name", "Bill Date", "Discount", "Tax", "Total" };
            foreach (string header in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(header, smallFont));
                cell.BackgroundColor = new BaseColor(52, 73, 94);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Padding = 5;
                transactionsTable.AddCell(cell);
            }

            float rowPadding = 4;

            foreach (DataRow row in reportData.Rows)
            {
                transactionsTable.AddCell(new PdfPCell(new Phrase(row["Bill ID"].ToString(), smallFont)) { Padding = rowPadding });
                transactionsTable.AddCell(new PdfPCell(new Phrase(row["Patient Name"].ToString(), smallFont)) { Padding = rowPadding });
                transactionsTable.AddCell(new PdfPCell(new Phrase(row["Bill Date"].ToString(), smallFont)) { Padding = rowPadding });
                transactionsTable.AddCell(new PdfPCell(new Phrase($"₱{Convert.ToDecimal(row["Discount"]):N2}", smallFont)) { Padding = rowPadding });
                transactionsTable.AddCell(new PdfPCell(new Phrase($"₱{Convert.ToDecimal(row["Tax"]):N2}", smallFont)) { Padding = rowPadding });
                transactionsTable.AddCell(new PdfPCell(new Phrase($"₱{Convert.ToDecimal(row["Total"]):N2}", smallFont)) { Padding = rowPadding });
            }

            PdfPCell transactionsCell = new PdfPCell(transactionsTable);
            transactionsCell.Colspan = 2;
            transactionsCell.Border = 0;
            transactionsCell.Padding = 10;
            summaryTable.AddCell(transactionsCell);

            summaryTable.AddCell(new PdfPCell(new Phrase($"Total Transactions:", normalFont)) { Border = 0, Padding = 5 });
            summaryTable.AddCell(new PdfPCell(new Phrase($"{reportData.Rows.Count}", normalFont)) { Border = 0, Padding = 5, HorizontalAlignment = Element.ALIGN_RIGHT });

            summaryTable.AddCell(new PdfPCell(new Phrase($"Gross Income:", normalFont)) { Border = 0, Padding = 5 });
            summaryTable.AddCell(new PdfPCell(new Phrase($"₱{grossIncome:N2}", normalFont)) { Border = 0, Padding = 5, HorizontalAlignment = Element.ALIGN_RIGHT });

            summaryTable.AddCell(new PdfPCell(new Phrase($"Total Discounts:", normalFont)) { Border = 0, Padding = 5 });
            summaryTable.AddCell(new PdfPCell(new Phrase($"-₱{totalDiscount:N2}", normalFont)) { Border = 0, Padding = 5, HorizontalAlignment = Element.ALIGN_RIGHT });

            summaryTable.AddCell(new PdfPCell(new Phrase($"Total Tax Collected:", normalFont)) { Border = 0, Padding = 5 });
            summaryTable.AddCell(new PdfPCell(new Phrase($"₱{totalTax:N2}", normalFont)) { Border = 0, Padding = 5, HorizontalAlignment = Element.ALIGN_RIGHT });

            PdfPCell netIncomeLabel = new PdfPCell(new Phrase($"NET INCOME:", headerFont));
            netIncomeLabel.Border = 0;
            netIncomeLabel.Padding = 10;
            netIncomeLabel.BackgroundColor = new BaseColor(240, 240, 240);
            summaryTable.AddCell(netIncomeLabel);

            PdfPCell netIncomeValue = new PdfPCell(new Phrase($"₱{totalIncome:N2}", headerFont));
            netIncomeValue.Border = 0;
            netIncomeValue.Padding = 10;
            netIncomeValue.HorizontalAlignment = Element.ALIGN_RIGHT;
            netIncomeValue.BackgroundColor = new BaseColor(240, 240, 240);
            summaryTable.AddCell(netIncomeValue);

            document.Add(summaryTable);

            Paragraph footer = new Paragraph("\n\nSt. Joseph's Hospital | Healthcare Excellence", smallFont);
            footer.Alignment = Element.ALIGN_CENTER;
            document.Add(footer);

            document.Close();
            writer.Close();
        }
    }
}