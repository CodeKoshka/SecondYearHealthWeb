using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySqlConnector;
using Timer = System.Windows.Forms.Timer;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class SetNewPasswordForm : Form
    {
        private int userId;

        public SetNewPasswordForm(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            SetupModernStyle();
        }

        private void SetupModernStyle()
        {
            SetRoundedCorners(panelNewPasswordContainer, 8);
            SetRoundedCorners(panelConfirmPasswordContainer, 8);
            SetRoundedCorners(btnSetPassword, 8);
            SetRoundedCorners(btnCancel, 8);

            txtNewPassword.Enter += (s, e) => AnimateInputFocus(panelNewPasswordBorder, true);
            txtNewPassword.Leave += (s, e) => AnimateInputFocus(panelNewPasswordBorder, false);

            txtConfirmPassword.Enter += (s, e) => AnimateInputFocus(panelConfirmPasswordBorder, true);
            txtConfirmPassword.Leave += (s, e) => AnimateInputFocus(panelConfirmPasswordBorder, false);

            btnSetPassword.MouseEnter += (s, e) => AnimateButton(btnSetPassword, Color.FromArgb(56, 161, 105), true);
            btnSetPassword.MouseLeave += (s, e) => AnimateButton(btnSetPassword, Color.FromArgb(72, 187, 120), false);

            btnCancel.MouseEnter += (s, e) => AnimateButton(btnCancel, Color.FromArgb(73, 80, 87), true);
            btnCancel.MouseLeave += (s, e) => AnimateButton(btnCancel, Color.FromArgb(108, 117, 125), false);

            txtConfirmPassword.KeyDown += TxtConfirmPassword_KeyDown;
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

        private void ChkShowPasswords_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPasswords.Checked)
            {
                txtNewPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtNewPassword.PasswordChar = '●';
                txtConfirmPassword.PasswordChar = '●';
            }
        }

        private void TxtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSetPassword_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnSetPassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                ShowStatus("Please enter a new password", true);
                txtNewPassword.Focus();
                return;
            }

            if (!IsPasswordValid(newPassword))
            {
                ShowStatus("Password does not meet requirements", true);
                txtNewPassword.Focus();
                return;
            }

            if (newPassword != confirmPassword)
            {
                ShowStatus("Passwords do not match", true);
                txtConfirmPassword.Focus();
                return;
            }

            try
            {
                string updateQuery = @"UPDATE Users 
                                      SET password = @password,
                                          failed_login_attempts = 0,
                                          last_failed_attempt = NULL,
                                          locked_until = NULL
                                      WHERE user_id = @userId";

                DatabaseHelper.ExecuteNonQuery(updateQuery,
                    new MySqlParameter("@password", newPassword),
                    new MySqlParameter("@userId", userId));

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowStatus($"Error: {ex.Message}", true);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool IsPasswordValid(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                return false;
            }

            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                return false;
            }

            if (!Regex.IsMatch(password, @"[!@#$%^&*]"))
            {
                return false;
            }
            return true;
        }

        private void ShowStatus(string message, bool isError)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = isError ? Color.FromArgb(229, 62, 62) : Color.FromArgb(72, 187, 120);
            lblStatus.Visible = true;

            Timer hideTimer = new Timer { Interval = 3000 };
            hideTimer.Tick += (s, e) =>
            {
                lblStatus.Visible = false;
                hideTimer.Stop();
                hideTimer.Dispose();
            };
            hideTimer.Start();
        }
    }
}