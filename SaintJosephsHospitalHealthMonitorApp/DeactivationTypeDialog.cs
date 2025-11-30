using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class DeactivationTypeDialog : Form
    {
        public string DeactivationType { get; private set; }
        public string Reason { get; private set; }

        public DeactivationTypeDialog(string userName, string userRole)
        {
            InitializeComponent();
            SetupDynamicContent(userName, userRole);
            SetupModernStyle();
        }

        private void SetupDynamicContent(string userName, string userRole)
        {
            lblTitle.Text = $"Deactivate User: {userName}";
            lblSubtitle.Text = $"Role: {userRole}";
        }

        private void SetupModernStyle()
        {
            SetRoundedCorners(panelTemporary, 8);
            SetRoundedCorners(panelPermanent, 8);
            SetRoundedCorners(panelReasonContainer, 8);
            SetRoundedCorners(btnConfirm, 8);
            SetRoundedCorners(btnCancel, 8);

            btnConfirm.MouseEnter += (s, e) => AnimateButton(btnConfirm, Color.FromArgb(192, 57, 43), true);
            btnConfirm.MouseLeave += (s, e) => AnimateButton(btnConfirm, Color.FromArgb(231, 76, 60), false);

            btnCancel.MouseEnter += (s, e) => AnimateButton(btnCancel, Color.FromArgb(73, 80, 87), true);
            btnCancel.MouseLeave += (s, e) => AnimateButton(btnCancel, Color.FromArgb(108, 117, 125), false);

            txtReason.Enter += (s, e) => AnimateInputFocus(panelReasonBorder, true);
            txtReason.Leave += (s, e) => AnimateInputFocus(panelReasonBorder, false);

            panelTemporary.Click += (s, e) => rdoTemporary.Checked = true;
            lblTempDesc.Click += (s, e) => rdoTemporary.Checked = true;

            panelPermanent.Click += (s, e) => rdoPermanent.Checked = true;
            lblPermDesc.Click += (s, e) => rdoPermanent.Checked = true;
        }

        private void SetRoundedCorners(Control control, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(control.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(control.Width - radius, control.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, control.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }

        private void AnimateInputFocus(Panel borderPanel, bool isFocused)
        {
            Timer t = new Timer { Interval = 10 };
            int steps = 0;
            Color startColor = borderPanel.BackColor;
            Color targetColor = isFocused ? Color.FromArgb(66, 153, 225) : Color.FromArgb(226, 232, 240);

            t.Tick += (s, e) =>
            {
                steps++;
                float progress = steps / 15f;

                if (progress >= 1f)
                {
                    borderPanel.BackColor = targetColor;
                    t.Stop();
                    t.Dispose();
                }
                else
                {
                    int r = (int)(startColor.R + (targetColor.R - startColor.R) * progress);
                    int g = (int)(startColor.G + (targetColor.G - startColor.G) * progress);
                    int b = (int)(startColor.B + (targetColor.B - startColor.B) * progress);
                    borderPanel.BackColor = Color.FromArgb(r, g, b);
                }
            };
            t.Start();
        }

        private void AnimateButton(Button button, Color targetColor, bool isHover)
        {
            Timer t = new Timer { Interval = 10 };
            int steps = 0;
            Color startColor = button.BackColor;

            t.Tick += (s, e) =>
            {
                steps++;
                float progress = steps / 10f;

                if (progress >= 1f)
                {
                    button.BackColor = targetColor;
                    t.Stop();
                    t.Dispose();
                }
                else
                {
                    int r = (int)(startColor.R + (targetColor.R - startColor.R) * progress);
                    int g = (int)(startColor.G + (targetColor.G - startColor.G) * progress);
                    int b = (int)(startColor.B + (targetColor.B - startColor.B) * progress);
                    button.BackColor = Color.FromArgb(r, g, b);
                }
            };
            t.Start();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Please provide a reason for deactivation.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DeactivationType = rdoTemporary.Checked ? "temporary" : "permanent";
            Reason = txtReason.Text.Trim();

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