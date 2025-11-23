using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using MySqlConnector;

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
                reportGenerator.GenerateIncomeReport(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
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
        private int currentPage = 1;
        private int currentRow = 0;
        private Font headerFont = new Font("Arial", 16, FontStyle.Bold);
        private Font subHeaderFont = new Font("Arial", 10, FontStyle.Bold);
        private Font normalFont = new Font("Arial", 9);
        private Font totalFont = new Font("Arial", 12, FontStyle.Bold);

        public void GenerateIncomeReport(DateTime fromDate, DateTime toDate)
        {
            startDate = fromDate;
            endDate = toDate;

            string query = @"
                SELECT 
                    b.bill_id AS 'Bill ID',
                    u.name AS 'Patient Name',
                    DATE_FORMAT(b.bill_date, '%Y-%m-%d') AS 'Bill Date',
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
                new MySqlParameter("@startDate", fromDate.Date),
                new MySqlParameter("@endDate", toDate.Date));

            if (reportData.Rows.Count == 0)
            {
                MessageBox.Show(
                    $"No paid bills found between {fromDate:MMMM dd, yyyy} and {toDate:MMMM dd, yyyy}.",
                    "No Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            totalIncome = 0;
            totalDiscount = 0;
            totalTax = 0;

            foreach (DataRow row in reportData.Rows)
            {
                totalIncome += Convert.ToDecimal(row["Total"]);
                totalDiscount += Convert.ToDecimal(row["Discount"]);
                totalTax += Convert.ToDecimal(row["Tax"]);
            }

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintPage;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                currentPage = 1;
                currentRow = 0;
                printDoc.Print();
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float yPos = 50;
            float leftMargin = 50;
            float rightMargin = e.PageBounds.Width - 50;

            string title = "ST. JOSEPH'S HOSPITAL";
            SizeF titleSize = g.MeasureString(title, headerFont);
            g.DrawString(title, headerFont, Brushes.Black,
                (e.PageBounds.Width - titleSize.Width) / 2, yPos);
            yPos += titleSize.Height + 5;

            string subtitle = "Income Report";
            SizeF subtitleSize = g.MeasureString(subtitle, subHeaderFont);
            g.DrawString(subtitle, subHeaderFont, Brushes.Black,
                (e.PageBounds.Width - subtitleSize.Width) / 2, yPos);
            yPos += subtitleSize.Height + 20;

            string dateRange = $"Period: {startDate:MMMM dd, yyyy} - {endDate:MMMM dd, yyyy}";
            g.DrawString(dateRange, normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;

            string reportDate = $"Generated: {DateTime.Now:MMMM dd, yyyy hh:mm tt}";
            g.DrawString(reportDate, normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 30;

            float col1 = leftMargin;          
            float col2 = col1 + 60;           
            float col3 = col2 + 200;          
            float col4 = col3 + 100;          
            float col5 = col4 + 90;           
            float col6 = col5 + 90;           

            g.FillRectangle(new SolidBrush(Color.FromArgb(66, 153, 225)),
                leftMargin, yPos, rightMargin - leftMargin, 25);

            g.DrawString("Bill ID", subHeaderFont, Brushes.White, col1 + 5, yPos + 5);
            g.DrawString("Patient Name", subHeaderFont, Brushes.White, col2 + 5, yPos + 5);
            g.DrawString("Date", subHeaderFont, Brushes.White, col3 + 5, yPos + 5);
            g.DrawString("Discount", subHeaderFont, Brushes.White, col4 + 5, yPos + 5);
            g.DrawString("Tax", subHeaderFont, Brushes.White, col5 + 5, yPos + 5);
            g.DrawString("Total", subHeaderFont, Brushes.White, col6 + 5, yPos + 5);
            yPos += 30;

            int rowsPerPage = 25;
            int rowsPrinted = 0;

            while (currentRow < reportData.Rows.Count && rowsPrinted < rowsPerPage)
            {
                DataRow row = reportData.Rows[currentRow];

                if (rowsPrinted % 2 == 0)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(247, 250, 252)),
                        leftMargin, yPos, rightMargin - leftMargin, 20);
                }

                g.DrawString(row["Bill ID"].ToString(), normalFont, Brushes.Black, col1 + 5, yPos);

                string patientName = row["Patient Name"].ToString();
                if (patientName.Length > 25)
                    patientName = patientName.Substring(0, 22) + "...";
                g.DrawString(patientName, normalFont, Brushes.Black, col2 + 5, yPos);

                g.DrawString(row["Bill Date"].ToString(), normalFont, Brushes.Black, col3 + 5, yPos);
                g.DrawString($"₱{Convert.ToDecimal(row["Discount"]):N2}", normalFont, Brushes.Black, col4 + 5, yPos);
                g.DrawString($"₱{Convert.ToDecimal(row["Tax"]):N2}", normalFont, Brushes.Black, col5 + 5, yPos);
                g.DrawString($"₱{Convert.ToDecimal(row["Total"]):N2}", normalFont, Brushes.Black, col6 + 5, yPos);

                yPos += 22;
                currentRow++;
                rowsPrinted++;
            }

            if (currentRow >= reportData.Rows.Count)
            {
                yPos += 20;

                g.DrawLine(new Pen(Color.Black, 2), leftMargin, yPos, rightMargin, yPos);
                yPos += 10;

                float summaryHeight = 100;
                g.FillRectangle(new SolidBrush(Color.FromArgb(247, 250, 252)),
                    leftMargin, yPos, rightMargin - leftMargin, summaryHeight);

                g.DrawString($"Total Records: {reportData.Rows.Count}", totalFont, Brushes.Black,
                    leftMargin + 10, yPos + 10);

                g.DrawString($"Total Discounts: ₱{totalDiscount:N2}", normalFont,
                    Brushes.DarkRed, leftMargin + 10, yPos + 40);

                g.DrawString($"Total Tax: ₱{totalTax:N2}", normalFont,
                    Brushes.DarkGreen, leftMargin + 10, yPos + 60);

                g.DrawString("TOTAL INCOME:", totalFont, Brushes.Black, rightMargin - 300, yPos + 65);
                g.DrawString($"₱{totalIncome:N2}", totalFont,
                    new SolidBrush(Color.FromArgb(46, 204, 113)), rightMargin - 150, yPos + 65);
            }

            string pageInfo = $"Page {currentPage}";
            SizeF pageInfoSize = g.MeasureString(pageInfo, normalFont);
            g.DrawString(pageInfo, normalFont, Brushes.Gray,
                (e.PageBounds.Width - pageInfoSize.Width) / 2, e.PageBounds.Height - 50);

            if (currentRow < reportData.Rows.Count)
            {
                currentPage++;
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
    }
}