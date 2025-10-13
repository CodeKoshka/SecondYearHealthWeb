using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public class DatabaseHelper
    {
        //this the heart of the program itself its the program that handles the database itself
        //this is XAMPP MySQL connections (raming issue dito peste)
        private static string serverConnectionString = "Server=localhost;Port=3306;User=root;Password=;";
        private static string databaseConnectionString = "Server=localhost;Port=3306;Database=hospital_db;User=root;Password=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(databaseConnectionString);
        }

        public static void InitializeDatabase()
        {
            MySqlConnection conn = null;
            //thallas idea and code to use try and catch to make sure the program doesnt crash when it catches a error
            try
            {
                // Step 1: Connect to MySQL server and create database
                conn = new MySqlConnection(serverConnectionString);
                conn.Open();

                MySqlCommand cmdCreate = new MySqlCommand("CREATE DATABASE IF NOT EXISTS hospital_db", conn);
                cmdCreate.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();

                // Step 2: Connect to the database and create tables
                conn = new MySqlConnection(databaseConnectionString);
                conn.Open();

                //some of this tables are broken so far future fixes when i get a chance
                //this creates the Users table
                string createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        user_id INT PRIMARY KEY AUTO_INCREMENT,
                        name VARCHAR(100) NOT NULL,
                        role VARCHAR(20) NOT NULL,
                        email VARCHAR(100) UNIQUE NOT NULL,
                        password VARCHAR(255) NOT NULL,
                        age INT,
                        gender VARCHAR(10),
                        created_by INT NULL,
                        created_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                        is_active TINYINT(1) DEFAULT 1
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";

                //this creates the patients table
                string createPatientsTable = @"
                    CREATE TABLE IF NOT EXISTS Patients (
                        patient_id INT PRIMARY KEY AUTO_INCREMENT,
                        user_id INT,
                        blood_type VARCHAR(5),
                        allergies VARCHAR(500),
                        medical_history TEXT,
                        emergency_contact VARCHAR(100),
                        phone_number VARCHAR(20),
                        FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";

                //this creates the doctors table
                string createDoctorsTable = @"
                    CREATE TABLE IF NOT EXISTS Doctors (
                        doctor_id INT PRIMARY KEY AUTO_INCREMENT,
                        user_id INT,
                        specialization VARCHAR(100),
                        license_number VARCHAR(50),
                        is_available TINYINT(1) DEFAULT 1,
                        FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";

                //this creates PatientQueue table
                string createQueueTable = @"
                    CREATE TABLE IF NOT EXISTS patientqueue (
                        queue_id INT PRIMARY KEY AUTO_INCREMENT,
                        patient_id INT,
                        doctor_id INT NULL,
                        queue_number INT NOT NULL,
                        priority VARCHAR(20) DEFAULT 'Normal',
                        status VARCHAR(20) DEFAULT 'Waiting',
                        reason_for_visit VARCHAR(500),
                        registered_by INT,
                        queue_date DATE,
                        registered_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                        called_time DATETIME NULL,
                        completed_time DATETIME NULL,
                        FOREIGN KEY (patient_id) REFERENCES Patients(patient_id) ON DELETE CASCADE,
                        FOREIGN KEY (doctor_id) REFERENCES Doctors(doctor_id) ON DELETE SET NULL,
                        FOREIGN KEY (registered_by) REFERENCES Users(user_id) ON DELETE SET NULL
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";

                //this creates Appointments table
                string createAppointmentsTable = @"
                    CREATE TABLE IF NOT EXISTS Appointments (
                        appointment_id INT PRIMARY KEY AUTO_INCREMENT,
                        patient_id INT,
                        doctor_id INT,
                        appointment_date DATETIME NOT NULL,
                        status VARCHAR(20) DEFAULT 'Scheduled',
                        notes VARCHAR(500),
                        created_by INT,
                        FOREIGN KEY (patient_id) REFERENCES Patients(patient_id) ON DELETE CASCADE,
                        FOREIGN KEY (doctor_id) REFERENCES Doctors(doctor_id) ON DELETE CASCADE,
                        FOREIGN KEY (created_by) REFERENCES Users(user_id) ON DELETE SET NULL
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";

                //this creates the medicalrecords table
                string createMedicalRecordsTable = @"
                    CREATE TABLE IF NOT EXISTS medicalrecords (
                        record_id INT PRIMARY KEY AUTO_INCREMENT,
                        patient_id INT,
                        doctor_id INT,
                        diagnosis TEXT,
                        prescription TEXT,
                        lab_tests VARCHAR(500),
                        visit_type VARCHAR(20),
                        record_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (patient_id) REFERENCES Patients(patient_id) ON DELETE CASCADE,
                        FOREIGN KEY (doctor_id) REFERENCES Doctors(doctor_id) ON DELETE CASCADE
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";

                //this creates the billing table
                string createBillingTable = @"
                    CREATE TABLE IF NOT EXISTS Billing (
                        bill_id INT PRIMARY KEY AUTO_INCREMENT,
                        patient_id INT,
                        amount DECIMAL(10,2) NOT NULL,
                        status VARCHAR(20) DEFAULT 'Pending',
                        description VARCHAR(500),
                        bill_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                        created_by INT,
                        FOREIGN KEY (patient_id) REFERENCES Patients(patient_id) ON DELETE CASCADE,
                        FOREIGN KEY (created_by) REFERENCES Users(user_id) ON DELETE SET NULL
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";

                //this creates the staff table
                string createStaffTable = @"
                    CREATE TABLE IF NOT EXISTS Staff (
                        staff_id INT PRIMARY KEY AUTO_INCREMENT,
                        user_id INT,
                        position VARCHAR(50),
                        department VARCHAR(50),
                        FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";

                //this is execute table creation
                ExecuteNonQueryInternal(conn, createUsersTable);
                ExecuteNonQueryInternal(conn, createPatientsTable);
                ExecuteNonQueryInternal(conn, createDoctorsTable);
                ExecuteNonQueryInternal(conn, createStaffTable);
                ExecuteNonQueryInternal(conn, createQueueTable);
                ExecuteNonQueryInternal(conn, createAppointmentsTable);
                ExecuteNonQueryInternal(conn, createMedicalRecordsTable);
                ExecuteNonQueryInternal(conn, createBillingTable);

                //this is to insert default admin user
                string checkAdmin = "SELECT COUNT(*) FROM Users WHERE email = 'admin@hospital.com'";
                object adminResult = ExecuteScalarInternal(conn, checkAdmin);
                long adminExists = Convert.ToInt64(adminResult);

                if (adminExists == 0)
                {
                    string insertAdmin = @"
                        INSERT INTO Users (name, role, email, password, age, gender)
                        VALUES ('Admin User', 'Admin', 'admin@hospital.com', 'admin123', 30, 'Other')";
                    ExecuteNonQueryInternal(conn, insertAdmin);
                }

                //this is to insert default secretary user
                string checkSecretary = "SELECT COUNT(*) FROM Users WHERE email = 'secretary@hospital.com'";
                object secretaryResult = ExecuteScalarInternal(conn, checkSecretary);
                long secretaryExists = Convert.ToInt64(secretaryResult);

                if (secretaryExists == 0)
                {
                    string insertSecretary = @"
                        INSERT INTO Users (name, role, email, password, age, gender)
                        VALUES ('Secretary User', 'Secretary', 'secretary@hospital.com', 'secretary123', 28, 'Female')";
                    ExecuteNonQueryInternal(conn, insertSecretary);

                    string getLastId = "SELECT LAST_INSERT_ID()";
                    object userIdResult = ExecuteScalarInternal(conn, getLastId);
                    long userId = Convert.ToInt64(userIdResult);

                    string insertStaff = @"
                        INSERT INTO Staff (user_id, position, department)
                        VALUES (@userId, 'Receptionist', 'Front Desk')";
                    MySqlCommand cmdStaff = new MySqlCommand(insertStaff, conn);
                    cmdStaff.Parameters.AddWithValue("@userId", userId);
                    cmdStaff.ExecuteNonQuery();
                }
                //will add dafault doctor user havent gotten to do it yet forgot

                MessageBox.Show("Database initialized successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                //we used dollar signs $ instead of doing this "(ex.example + "something")" since sometimes using that method 
                //dont work and have to do a work around this is way easier than using that method

                //added by this just incase something went wrong
                string errorMsg = $"MySQL Error #{ex.Number}:\n{ex.Message}\n\n";
                if (ex.Number == 0)
                {
                    errorMsg += "Cannot connect to MySQL!\n\n";
                    errorMsg += "Solutions:\n";
                    errorMsg += "1. Start XAMPP Control Panel\n";
                    errorMsg += "2. Click 'Start' next to MySQL\n";
                    errorMsg += "3. Wait for green 'Running' status\n";
                    errorMsg += "4. Try again";
                }

                MessageBox.Show(errorMsg, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.GetType().Name}\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        //this is the internal helper methods
        private static void ExecuteNonQueryInternal(MySqlConnection conn, string query)
        {
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private static object ExecuteScalarInternal(MySqlConnection conn, string query)
        {
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                return cmd.ExecuteScalar();
            }
        }

        //this is public methods for application use
        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public static object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);

                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                        return dt;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database query error:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
    }
}


/*
Members and their contributions so far in the program
Tristan: head designer
Marco and Puno: sub designer
Cherry, Stephen, and Carl thalla: Programmers
provided the ideas for the program also helped and contributed to the code aswell

known issues / (tinatamad pang ayusin) by lead programmer ramilo

1.if the admin user table gets deleted it crashes the xampp and had to reinstall the whole xampp
2.alot of the programs dont work right / missing not been fix yet (sobrang raming di gumagana sakit sa ulo) 

(titatamad pakong i dibug one by one total november 10 panaman plano kong matapos to)

future plans / missing stuff

0.need to replace the program name the name right now is temporary
1.the laus easteregg is not been started yet
2.logo for our hospital
3.a new numbering id on the table
4.might do animation transitions (if merong oras) 
5.a better design for the forms the design right now is temporary need help with our designers
(TJ,Puno and Marco kayo na bahala jan kaya ninyo na yan)

final notes by lead programmer
di po pwede gumamit ng sql express naging corrupted download ng sql saka localdb no choice 
xampp po kaylangan naming gamitin instead saka mas madaling install
*/
