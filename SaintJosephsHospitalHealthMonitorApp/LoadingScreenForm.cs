using MySqlConnector;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class LoadingScreenForm : Form
    {
        private Timer fadeInTimer;
        private Timer progressTimer;
        private Timer fadeOutTimer;
        private float currentOpacity = 0f;
        private int progressValue = 0;
        private int rotationAngle = 0;
        private Timer spinnerTimer;
        private string[] loadingMessages = new string[]
        {
            "Initializing system...",
            "Connecting to database...",
            "Verifying credentials...",
            "Loading modules...",
            "Finalizing setup..."
        };
        private int currentMessageIndex = 0;
        private bool initializationComplete = false;
        private bool hasError = false;
        private string errorMessage = "";
        private bool canProceedToLogin = false;
        private bool isProcessingError = false; 

        public LoadingScreenForm()
        {
            InitializeComponent();
            InitializeLoadingAnimation();
        }

        private void InitializeLoadingAnimation()
        {
            this.Opacity = 0;

            fadeInTimer = new Timer();
            fadeInTimer.Interval = 20;
            fadeInTimer.Tick += FadeInTimer_Tick;
            fadeInTimer.Start();

            progressTimer = new Timer();
            progressTimer.Interval = 50;
            progressTimer.Tick += ProgressTimer_Tick;
        }

        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            if (currentOpacity < 1.0f)
            {
                currentOpacity += 0.05f;
                this.Opacity = Math.Min(currentOpacity, 1.0f);

                if (currentOpacity >= 1.0f)
                {
                    fadeInTimer.Stop();
                    fadeInTimer.Dispose();
                    StartLoadingProcess();
                }
            }
        }

        private async void StartLoadingProcess()
        {
            initializationComplete = false;
            hasError = false;
            errorMessage = "";
            canProceedToLogin = false;
            isProcessingError = false;
            progressValue = 0;
            currentMessageIndex = 0;

            lblStatus.Text = loadingMessages[0];
            lblStatus.ForeColor = Color.FromArgb(113, 128, 150);
            lblProgress.Text = "0%";
            lblProgress.ForeColor = Color.FromArgb(113, 128, 150);

            progressTimer.Start();

            spinnerTimer = new Timer { Interval = 30 };
            spinnerTimer.Tick += (s, e) =>
            {
                rotationAngle = (rotationAngle + 10) % 360;
                panelSpinner.Invalidate();
            };
            spinnerTimer.Start();

            await Task.Run(() =>
            {
                try
                {
                    TestDatabaseConnection();

                    DatabaseHelper.InitializeDatabase();

                    VerifyDatabaseConnection();

                    initializationComplete = true;
                    hasError = false;
                }
                catch (MySqlException mysqlEx)
                {
                    hasError = true;
                    errorMessage = $"MySQL Error #{mysqlEx.Number}: {mysqlEx.Message}";
                    initializationComplete = true;
                }
                catch (Exception ex)
                {
                    hasError = true;
                    errorMessage = $"{ex.GetType().Name}: {ex.Message}";
                    initializationComplete = true;
                }
            });

            if (hasError)
            {
                progressTimer.Stop();
                if (spinnerTimer != null)
                {
                    spinnerTimer.Stop();
                    spinnerTimer.Dispose();
                }
                CompleteLoading();
            }
        }

        private void TestDatabaseConnection()
        {
            try
            {
                using (var conn = new MySqlConnection("Server=localhost;Port=3306;User=root;Password=;"))
                {
                    conn.Open();
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 0 || ex.Number == 2003)
                {
                    throw new Exception("Cannot connect to MySQL!\n\nXAMPP MySQL is not running.");
                }
                throw;
            }
        }
        private void VerifyDatabaseConnection()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("SELECT 1", conn);
                    var result = cmd.ExecuteScalar();
                    if (result == null || Convert.ToInt32(result) != 1)
                    {
                        throw new Exception("Database verification failed");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Database verification failed: {ex.Message}");
            }
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {

            if (hasError && !isProcessingError)
            {
                isProcessingError = true;
                progressTimer.Stop();
                if (spinnerTimer != null)
                {
                    spinnerTimer.Stop();
                    spinnerTimer.Dispose();
                }
                CompleteLoading();
                return;
            }

            if (!initializationComplete)
            {
                if (progressValue < 30)
                {
                    progressValue += 2;
                }
            }
            else if (!hasError) 
            {
                if (progressValue < 100)
                {
                    progressValue += 5;
                }
            }

            if (progressValue <= 100)
            {
                progressBar.Value = Math.Min(progressValue, 100);
                lblProgress.Text = $"{Math.Min(progressValue, 100)}%";

                int newMessageIndex = Math.Min((progressValue / 20), loadingMessages.Length - 1);
                if (newMessageIndex != currentMessageIndex && progressValue < 30)
                {
                    currentMessageIndex = newMessageIndex;
                    lblStatus.Text = loadingMessages[currentMessageIndex];
                }
            }

            if (progressValue >= 100 && !hasError)
            {
                progressTimer.Stop();
                progressTimer.Dispose();

                if (spinnerTimer != null)
                {
                    spinnerTimer.Stop();
                    spinnerTimer.Dispose();
                }

                CompleteLoading();
            }
        }

        private void CompleteLoading()
        {
            if (hasError)
            {
                canProceedToLogin = false;

                lblStatus.Text = "❌ Connection Failed";
                lblStatus.ForeColor = Color.FromArgb(229, 62, 62);
                lblProgress.Text = "ERROR";
                lblProgress.ForeColor = Color.FromArgb(229, 62, 62);
                progressBar.Value = 0;

                string fullErrorMessage = "⚠️ DATABASE INITIALIZATION FAILED ⚠️\n\n";

                if (errorMessage.Contains("Cannot connect") ||
                    errorMessage.Contains("MySQL Error #0") ||
                    errorMessage.Contains("MySQL Error #2003") ||
                    errorMessage.Contains("Unable to connect"))
                {
                    fullErrorMessage += "❌ Cannot connect to MySQL Server\n\n";
                    fullErrorMessage += "REQUIRED STEPS:\n";
                    fullErrorMessage += "━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                    fullErrorMessage += "1. Open XAMPP Control Panel\n";
                    fullErrorMessage += "2. Start MySQL (click 'Start' button)\n";
                    fullErrorMessage += "3. Wait for GREEN 'Running' status\n";
                    fullErrorMessage += "4. Click 'Retry' below\n\n";
                    fullErrorMessage += "━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
                    fullErrorMessage += "Technical Details:\n" + errorMessage + "\n\n";
                    fullErrorMessage += "Would you like to retry?";
                }
                else
                {
                    fullErrorMessage += "Error Details:\n";
                    fullErrorMessage += errorMessage + "\n\n";
                    fullErrorMessage += "Would you like to retry?";
                }

                DialogResult result = MessageBox.Show(
                    fullErrorMessage,
                    "❌ Database Connection Error",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error
                );

                if (result == DialogResult.Retry)
                {
                    isProcessingError = false;
                    RetryConnection();
                }
                else
                {
                    MessageBox.Show(
                        "Application cannot run without database connection.\nExiting...",
                        "Exit",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    Application.Exit();
                }
            }
            else
            {
                canProceedToLogin = true;

                lblStatus.Text = "✓ Ready!";
                lblStatus.ForeColor = Color.FromArgb(72, 187, 120);
                lblProgress.Text = "100%";

                Timer waitTimer = new Timer { Interval = 500 };
                waitTimer.Tick += (s, e) =>
                {
                    waitTimer.Stop();
                    waitTimer.Dispose();
                    FadeOutAndOpenLogin();
                };
                waitTimer.Start();
            }
        }

        private void RetryConnection()
        {
            progressBar.Value = 0;
            lblProgress.Text = "0%";
            lblProgress.ForeColor = Color.FromArgb(113, 128, 150);
            lblStatus.ForeColor = Color.FromArgb(113, 128, 150);
            canProceedToLogin = false;
            StartLoadingProcess();
        }

        private void FadeOutAndOpenLogin()
        {
            if (!canProceedToLogin)
            {
                MessageBox.Show(
                    "SECURITY VIOLATION:\nCannot proceed without successful database initialization.\n\nThe application will now exit.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Application.Exit();
                return;
            }

            fadeOutTimer = new Timer { Interval = 20 };
            fadeOutTimer.Tick += (s, e) =>
            {
                this.Opacity -= 0.05;
                if (this.Opacity <= 0)
                {
                    fadeOutTimer.Stop();
                    fadeOutTimer.Dispose();
                    OpenLoginForm();
                }
            };
            fadeOutTimer.Start();
        }

        private void OpenLoginForm()
        {
            if (!canProceedToLogin)
            {
                MessageBox.Show(
                    "CRITICAL ERROR:\nSecurity check failed!\n\nApplication will exit.",
                    "Security Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Application.Exit();
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    conn.Close();
                }

                LoginForm loginForm = new LoginForm();
                loginForm.FormClosed += (s, args) => Application.Exit();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to verify database connection:\n{ex.Message}\n\nApplication will exit.",
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Application.Exit();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void DrawSpinner(Graphics g)
        {
            if (panelSpinner == null) return;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int centerX = panelSpinner.Width / 2;
            int centerY = panelSpinner.Height / 2;
            int radius = 30;

            using (Pen pen = new Pen(Color.FromArgb(66, 153, 225), 4))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                for (int i = 0; i < 8; i++)
                {
                    float angle = (rotationAngle + i * 45) * (float)Math.PI / 180;
                    int opacity = 255 - (i * 30);
                    pen.Color = Color.FromArgb(Math.Max(50, opacity), 66, 153, 225);

                    float x1 = centerX + (float)Math.Cos(angle) * (radius - 10);
                    float y1 = centerY + (float)Math.Sin(angle) * (radius - 10);
                    float x2 = centerX + (float)Math.Cos(angle) * radius;
                    float y2 = centerY + (float)Math.Sin(angle) * radius;

                    g.DrawLine(pen, x1, y1, x2, y2);
                }
            }
        }

        private void PanelSpinner_Paint(object sender, PaintEventArgs e)
        {
            DrawSpinner(e.Graphics);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            fadeInTimer?.Dispose();
            progressTimer?.Dispose();
            fadeOutTimer?.Dispose();
            spinnerTimer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}