using System;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;
using System.Data;
using Timer = System.Windows.Forms.Timer;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class ForgotPasswordForm : Form
    {
        private string currentSecurityQuestion = "";
        private int currentUserId = -1;

        public ForgotPasswordForm()
        {
            InitializeComponent();
            SetupModernStyle();
            InitializeAnimations();
        }

        private void InitializeAnimations()
        {
            this.Opacity = 0;
            Timer fadeIn = new Timer { Interval = 20 };
            float opacity = 0f;
            fadeIn.Tick += (s, e) =>
            {
                opacity += 0.05f;
                this.Opacity = Math.Min(opacity, 1.0f);
                if (opacity >= 1.0f)
                {
                    fadeIn.Stop();
                    fadeIn.Dispose();
                }
            };
            fadeIn.Start();
        }

        private void SetupModernStyle()
        {
            SetRoundedCorners(panelEmailContainer, 8);
            SetRoundedCorners(panelSecurityAnswerContainer, 8);
            SetRoundedCorners(btnResetPassword, 8);

            txtEmail.Enter += (s, e) => AnimateInputFocus(panelEmailBorder, true);
            txtEmail.Leave += (s, e) => AnimateInputFocus(panelEmailBorder, false);

            txtSecurityAnswer.Enter += (s, e) => AnimateInputFocus(panelSecurityAnswerBorder, true);
            txtSecurityAnswer.Leave += (s, e) => AnimateInputFocus(panelSecurityAnswerBorder, false);

            btnResetPassword.MouseEnter += (s, e) => AnimateButton(btnResetPassword, Color.FromArgb(56, 131, 186), true);
            btnResetPassword.MouseLeave += (s, e) => AnimateButton(btnResetPassword, Color.FromArgb(66, 153, 225), false);

            btnBackToLogin.MouseEnter += (s, e) => btnBackToLogin.ForeColor = Color.FromArgb(56, 131, 186);
            btnBackToLogin.MouseLeave += (s, e) => btnBackToLogin.ForeColor = Color.FromArgb(66, 153, 225);

            txtSecurityAnswer.KeyDown += TxtSecurityAnswer_KeyDown;
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

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                lblSecurityQuestion.Text = "Enter your email first to see your security question";
                lblSecurityQuestion.ForeColor = Color.FromArgb(113, 128, 150);
                currentSecurityQuestion = "";
                currentUserId = -1;
                return;
            }

            try
            {
                string query = "SELECT user_id, security_question FROM Users WHERE BINARY email = @email";
                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@email", email));

                if (dt.Rows.Count > 0)
                {
                    currentUserId = Convert.ToInt32(dt.Rows[0]["user_id"]);
                    currentSecurityQuestion = dt.Rows[0]["security_question"]?.ToString() ?? "";

                    if (string.IsNullOrEmpty(currentSecurityQuestion))
                    {
                        lblSecurityQuestion.Text = "⚠️ No security question set for this account. Contact administrator.";
                        lblSecurityQuestion.ForeColor = Color.FromArgb(229, 62, 62);
                        currentUserId = -1;
                    }
                    else
                    {
                        lblSecurityQuestion.Text = $"🔒 {currentSecurityQuestion}";
                        lblSecurityQuestion.ForeColor = Color.FromArgb(66, 153, 225);
                    }
                }
                else
                {
                    lblSecurityQuestion.Text = "❌ Email not found in system";
                    lblSecurityQuestion.ForeColor = Color.FromArgb(229, 62, 62);
                    currentSecurityQuestion = "";
                    currentUserId = -1;
                }
            }
            catch (Exception ex)
            {
                ShowStatus($"Error: {ex.Message}", true);
            }
        }

        private void TxtSecurityAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnResetPassword_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string answer = txtSecurityAnswer.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                ShowStatus("Please enter your email address", true);
                txtEmail.Focus();
                return;
            }

            if (currentUserId == -1)
            {
                ShowStatus("Please enter a valid email address", true);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(answer))
            {
                ShowStatus("Please answer the security question", true);
                txtSecurityAnswer.Focus();
                return;
            }

            try
            {
                string query = "SELECT security_answer FROM Users WHERE user_id = @userId";
                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@userId", currentUserId));

                if (dt.Rows.Count == 0)
                {
                    ShowStatus("User not found", true);
                    return;
                }

                string correctAnswer = dt.Rows[0]["security_answer"]?.ToString() ?? "";

                if (answer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
                {
                    SetNewPasswordForm setPasswordForm = new SetNewPasswordForm(currentUserId);
                    this.Hide();

                    if (setPasswordForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show(
                            "✓ PASSWORD RESET SUCCESSFUL\n\n" +
                            "Your password has been reset successfully.\n" +
                            "You can now login with your new password.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.Show();
                    }
                }
                else
                {
                    ShowStatus("❌ Incorrect security answer. Please try again.", true);
                    txtSecurityAnswer.Clear();
                    txtSecurityAnswer.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowStatus($"Error: {ex.Message}", true);
            }
        }

        private void BtnBackToLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ShowStatus(string message, bool isError)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = isError ? Color.FromArgb(229, 62, 62) : Color.FromArgb(72, 187, 120);
            lblStatus.Visible = true;

            Timer hideTimer = new Timer { Interval = 5000 };
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