using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class AdminDashboard : Form
    {
        private User currentUser;

        public AdminDashboard(User user)
        {
            currentUser = user;
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {currentUser.Name} (Admin)";
            LoadData();
        }

        private void LoadData()
        {
            try
            {

                string queryUsers = @"
        SELECT u.user_id, u.name, u.role, u.email, u.created_date, 
               IFNULL(uc.name, 'System') AS created_by
        FROM Users u
        LEFT JOIN Users uc ON u.created_by = uc.user_id
        ORDER BY u.created_date DESC";
                dgvUsers.DataSource = DatabaseHelper.ExecuteQuery(queryUsers);


                string queryAppointments = @"
            SELECT a.appointment_id, u1.name AS Patient, u2.name AS Doctor, 
                   a.appointment_date, a.status, a.notes
            FROM Appointments a
            INNER JOIN Patients p ON a.patient_id = p.patient_id
            INNER JOIN Users u1 ON p.user_id = u1.user_id
            INNER JOIN Doctors d ON a.doctor_id = d.doctor_id
            INNER JOIN Users u2 ON d.user_id = u2.user_id
            ORDER BY a.appointment_date DESC";
                dgvAppointments.DataSource = DatabaseHelper.ExecuteQuery(queryAppointments);


                string queryBilling = @"
            SELECT b.bill_id, u.name AS Patient, b.amount, b.status, 
                   b.description, b.bill_date
            FROM Billing b
            INNER JOIN Patients p ON b.patient_id = p.patient_id
            INNER JOIN Users u ON p.user_id = u.user_id
            ORDER BY b.bill_date DESC";
                dgvBilling.DataSource = DatabaseHelper.ExecuteQuery(queryBilling);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            RegisterForm userForm = new RegisterForm(currentUser.UserId, currentUser.Role);
            userForm.FormClosed += (s, args) => LoadData();
            userForm.ShowDialog();
        }

        private void BtnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var userIdCell = dgvUsers.SelectedRows[0].Cells["user_id"];
            var roleCell = dgvUsers.SelectedRows[0].Cells["role"];

            if (userIdCell?.Value == null || userIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid user data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string userRole = roleCell?.Value?.ToString() ?? "";

            int userId = Convert.ToInt32(userIdCell.Value);

            RegisterForm editForm = new RegisterForm(userId);
            editForm.FormClosed += (s, args) => LoadData();
            editForm.ShowDialog();
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {

            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var userIdCell = dgvUsers.SelectedRows[0].Cells["user_id"];
            var roleCell = dgvUsers.SelectedRows[0].Cells["role"];
            var nameCell = dgvUsers.SelectedRows[0].Cells["name"];
            var emailCell = dgvUsers.SelectedRows[0].Cells["email"];

            if (userIdCell?.Value == null || userIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid user data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(userIdCell.Value);
            string userRole = roleCell?.Value?.ToString() ?? "";
            string userName = nameCell?.Value?.ToString() ?? "Unknown";
            string userEmail = emailCell?.Value?.ToString() ?? "";


            if (userRole == "Headadmin")
            {
                MessageBox.Show("Cannot delete Headadmin users.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (userEmail == "Headadmin@hospital.com" ||
                userEmail == "receptionist@hospital.com" ||
                userEmail == "pharmacist@hospital.com")
            {
                MessageBox.Show("Cannot delete default system accounts.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (userId == currentUser.UserId)
            {
                MessageBox.Show("You cannot delete your own account.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult deleteChoice = MessageBox.Show(
                $"How do you want to remove {userName}?\n\n" +
                "YES = Permanently Delete (cannot be undone)\n" +
                "NO = Deactivate (can be reactivated later)\n" +
                "CANCEL = Cancel operation",
                "Delete or Deactivate?",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (deleteChoice == DialogResult.Cancel)
                return;

            try
            {
                if (deleteChoice == DialogResult.Yes)
                {

                    string query = "DELETE FROM Users WHERE user_id = @userId";
                    DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@userId", userId));
                    MessageBox.Show("User permanently deleted.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    string query = "UPDATE Users SET is_active = 0 WHERE user_id = @userId";
                    DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@userId", userId));
                    MessageBox.Show("User deactivated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        //this opens the form to create a new appointment
        private void BtnAddAppointment_Click(object sender, EventArgs e)
        {
            AppointmentForm apptForm = new AppointmentForm();
            //this is when the form closes reload data to show any changes
            apptForm.FormClosed += (s, args) => LoadData();
            apptForm.ShowDialog();
        }
        //this allows the admin to update the status of the selected appointment
        private void BtnEditAppointment_Click(object sender, EventArgs e)
        {
            //this ensures a row is selected
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //this is to safely get appointment_id
            var apptIdCell = dgvAppointments.SelectedRows[0].Cells["appointment_id"];
            if (apptIdCell?.Value == null || apptIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid appointment data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int apptId = Convert.ToInt32(apptIdCell.Value);

            //made a small popup form for editing the status
            Form statusForm = new Form();
            statusForm.Text = "Update Appointment Status";
            statusForm.Size = new Size(350, 200);
            statusForm.StartPosition = FormStartPosition.CenterParent;

            Label lbl = new Label();
            lbl.Text = "Select New Status:";
            lbl.Location = new Point(20, 20);
            lbl.AutoSize = true;

            ComboBox cmbStatus = new ComboBox();
            cmbStatus.Location = new Point(20, 50);
            cmbStatus.Size = new Size(290, 25);
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new string[] { "Scheduled", "Completed", "Cancelled", "No-Show" });
            cmbStatus.SelectedIndex = 0;

            Button btnSave = new Button();
            btnSave.Text = "Update";
            btnSave.Location = new Point(20, 100);
            btnSave.Size = new Size(130, 35);
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += (s, ev) =>
            {
                try
                {
                    string query = "UPDATE Appointments SET status = @status WHERE appointment_id = @id";
                    DatabaseHelper.ExecuteNonQuery(query,
                        new MySqlParameter("@status", cmbStatus.SelectedItem?.ToString() ?? "Scheduled"),
                        new MySqlParameter("@id", apptId));
                    MessageBox.Show("Status updated successfully!");
                    statusForm.Close();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            };

            //this adds UI elements to the form
            statusForm.Controls.AddRange(new Control[] { lbl, cmbStatus, btnSave });
            statusForm.ShowDialog();
        }

        //this deletes the selected appointment
        private void BtnDeleteAppointment_Click(object sender, EventArgs e)
        {
            //this ensures a row is selected
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Cancel this appointment?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    //this is to safely get appointment_id
                    var apptIdCell = dgvAppointments.SelectedRows[0].Cells["appointment_id"];
                    if (apptIdCell?.Value == null || apptIdCell.Value == DBNull.Value)
                    {
                        MessageBox.Show("Invalid appointment data selected.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int apptId = Convert.ToInt32(apptIdCell.Value);
                    string query = "DELETE FROM Appointments WHERE appointment_id = @id";
                    DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@id", apptId));
                    MessageBox.Show("Appointment cancelled.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        //this opens billing form to create a new bill
        private void BtnAddBill_Click(object sender, EventArgs e)
        {
            BillingForm billForm = new BillingForm();
            billForm.FormClosed += (s, args) => LoadData();
            billForm.ShowDialog();
        }

        //this meant to mark the selected bill as paid
        private void BtnUpdateBill_Click(object sender, EventArgs e)
        {
            // Must select a bill first
            if (dgvBilling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bill.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //this is to safely get bill_id
            var billIdCell = dgvBilling.SelectedRows[0].Cells["bill_id"];
            if (billIdCell?.Value == null || billIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid bill data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int billId = Convert.ToInt32(billIdCell.Value);

            //this is to confirm before updating (just incase)
            DialogResult result = MessageBox.Show("Mark this bill as Paid?",
                "Update Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = "UPDATE Billing SET status = 'Paid' WHERE bill_id = @id";
                    DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@id", billId));
                    MessageBox.Show("Payment status updated!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }
    }
}