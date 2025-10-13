using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

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
                //this loads users table
                string queryUsers = @"SELECT user_id, name, role, email, age, gender, created_date 
                                     FROM Users ORDER BY created_date DESC";
                dgvUsers.DataSource = DatabaseHelper.ExecuteQuery(queryUsers);

                //this Loads appointments table
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

                //this loads Billing table
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
            RegisterForm regForm = new RegisterForm();
            regForm.FormClosed += (s, args) => LoadData();
            regForm.ShowDialog();
        }

        private void BtnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //this is to safely get the user_id
            var userIdCell = dgvUsers.SelectedRows[0].Cells["user_id"];
            if (userIdCell?.Value == null || userIdCell.Value == DBNull.Value)
            {
                MessageBox.Show("Invalid user data selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = Convert.ToInt32(userIdCell.Value);
            EditUserForm editForm = new EditUserForm(userId);
            editForm.FormClosed += (s, args) => LoadData();
            editForm.ShowDialog();
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            //this ensures a row is selected
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this user?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    //this is to safely get the user_id
                    var userIdCell = dgvUsers.SelectedRows[0].Cells["user_id"];
                    if (userIdCell?.Value == null || userIdCell.Value == DBNull.Value)
                    {
                        MessageBox.Show("Invalid user data selected.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //this converts the user_id and run delete query
                    int userId = Convert.ToInt32(userIdCell.Value);
                    string query = "DELETE FROM Users WHERE user_id = @userId";
                    DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@userId", userId));
                    MessageBox.Show("User deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            //(di ko sure kung gagana ito since gusto ko lang i try and copy yung mga code sa designer.cs)
            //might transfer to another designer instead of having it here
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
            this.Close();
        }
    }
}