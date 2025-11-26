using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class IncomeReportPreviewForm : Form
    {
        private DataTable reportData;
        private DateTime startDate;
        private DateTime endDate;
        private decimal totalIncome;
        private decimal totalDiscount;
        private decimal totalTax;
        private decimal grossIncome;

        public IncomeReportPreviewForm(DataTable data, DateTime start, DateTime end,
            decimal income, decimal discount, decimal tax, decimal gross)
        {
            reportData = data;
            startDate = start;
            endDate = end;
            totalIncome = income;
            totalDiscount = discount;
            totalTax = tax;
            grossIncome = gross;

            InitializeComponent();
            LoadPreviewData();
        }

        private void LoadPreviewData()
        {
            lblDateRange.Text = $"From {startDate:MMMM dd, yyyy} to {endDate:MMMM dd, yyyy}";

            DataTable displayData = new DataTable();
            displayData.Columns.Add("Bill ID", typeof(string));
            displayData.Columns.Add("Discount", typeof(decimal));
            displayData.Columns.Add("Tax", typeof(decimal));
            displayData.Columns.Add("Total", typeof(decimal));

            foreach (DataRow row in reportData.Rows)
            {
                displayData.Rows.Add(
                    row["Bill ID"].ToString(),
                    Convert.ToDecimal(row["Discount"]),
                    Convert.ToDecimal(row["Tax"]),
                    Convert.ToDecimal(row["Total"])
                );
            }

            DataRow totalRow = displayData.NewRow();
            totalRow["Bill ID"] = "TOTAL";
            totalRow["Discount"] = totalDiscount;
            totalRow["Tax"] = totalTax;
            totalRow["Total"] = totalIncome;
            displayData.Rows.Add(totalRow);

            dgvPreview.DataSource = displayData;

            if (dgvPreview.Columns["Bill ID"] != null)
            {
                dgvPreview.Columns["Bill ID"].Width = 150;
                dgvPreview.Columns["Bill ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPreview.Columns["Discount"] != null)
            {
                dgvPreview.Columns["Discount"].Width = 270;
                dgvPreview.Columns["Discount"].DefaultCellStyle.Format = "₱#,##0.00";
                dgvPreview.Columns["Discount"].HeaderText = "Discount";
            }

            if (dgvPreview.Columns["Tax"] != null)
            {
                dgvPreview.Columns["Tax"].Width = 270;
                dgvPreview.Columns["Tax"].DefaultCellStyle.Format = "₱#,##0.00";
                dgvPreview.Columns["Tax"].HeaderText = "Tax";
            }

            if (dgvPreview.Columns["Total"] != null)
            {
                dgvPreview.Columns["Total"].Width = 270;
                dgvPreview.Columns["Total"].DefaultCellStyle.Format = "₱#,##0.00";
                dgvPreview.Columns["Total"].HeaderText = "Total";
            }

            if (dgvPreview.Rows.Count > 0)
            {
                int lastRowIndex = dgvPreview.Rows.Count - 1;
                dgvPreview.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                dgvPreview.Rows[lastRowIndex].DefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
                dgvPreview.Rows[lastRowIndex].DefaultCellStyle.ForeColor = Color.Black;
                dgvPreview.Rows[lastRowIndex].Height = 40;
            }

            Label lblTotalIncome = new Label
            {
                Text = $"Total Income:  ₱{totalIncome:N2}",
                Font = new Font("Arial", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204),
                Location = new Point(680, 580),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleRight
            };
            this.Controls.Add(lblTotalIncome);
            lblTotalIncome.BringToFront();
        }

        private void BtnSavePDF_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}