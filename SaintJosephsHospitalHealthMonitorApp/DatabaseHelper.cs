using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
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

                conn = new MySqlConnection(serverConnectionString);
                conn.Open();

                MySqlCommand cmdCreate = new MySqlCommand("CREATE DATABASE IF NOT EXISTS hospital_db", conn);
                cmdCreate.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();


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
                    is_active TINYINT(1) DEFAULT 1,
                    FOREIGN KEY (created_by) REFERENCES Users(user_id) ON DELETE SET NULL
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

                //this creates the ENHANCED billing table with all new features
                string createBillingTable = @"
                    CREATE TABLE IF NOT EXISTS Billing (
                        bill_id INT PRIMARY KEY AUTO_INCREMENT,
                        patient_id INT,
                        amount DECIMAL(10,2) NOT NULL,
                        subtotal DECIMAL(10,2) DEFAULT 0.00,
                        discount_percent DECIMAL(5,2) DEFAULT 0.00,
                        discount_amount DECIMAL(10,2) DEFAULT 0.00,
                        tax_percent DECIMAL(5,2) DEFAULT 0.00,
                        tax_amount DECIMAL(10,2) DEFAULT 0.00,
                        status VARCHAR(20) DEFAULT 'Pending',
                        description TEXT,
                        payment_method VARCHAR(50) DEFAULT 'Cash',
                        notes TEXT,
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


                string createMedicineInventoryTable = @"
                CREATE TABLE IF NOT EXISTS MedicineInventory (
                    medicine_id INT PRIMARY KEY AUTO_INCREMENT,
                    medicine_name VARCHAR(200) NOT NULL,
                    generic_name VARCHAR(200),
                    brand_name VARCHAR(200),
                    category VARCHAR(100),
                    dosage_form VARCHAR(50),
                    strength VARCHAR(50),
                    quantity INT NOT NULL DEFAULT 0,
                    unit VARCHAR(20) NOT NULL,
                    reorder_level INT NOT NULL DEFAULT 10,
                    cost_price DECIMAL(10,2),
                    selling_price DECIMAL(10,2) NOT NULL,
                    supplier VARCHAR(200),
                    batch_number VARCHAR(100),
                    expiry_date DATE,
                    is_controlled TINYINT(1) DEFAULT 0,
                    requires_approval TINYINT(1) DEFAULT 0,
                    storage_location VARCHAR(100),
                    created_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updated_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                    created_by INT,
                    FOREIGN KEY (created_by) REFERENCES Users(user_id) ON DELETE SET NULL
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";


                string createMedicationOrdersTable = @"
                CREATE TABLE IF NOT EXISTS MedicationOrders (
                    order_id INT PRIMARY KEY AUTO_INCREMENT,
                    patient_id INT NOT NULL,
                    doctor_id INT NOT NULL,
                    medicine_name VARCHAR(200) NOT NULL,
                    dosage VARCHAR(100) NOT NULL,
                    frequency VARCHAR(100) NOT NULL,
                    duration VARCHAR(100),
                    quantity INT NOT NULL,
                    priority VARCHAR(20) DEFAULT 'Normal',
                    status VARCHAR(20) DEFAULT 'Pending',
                    special_instructions TEXT,
                    order_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    validated_by INT NULL,
                    validated_date DATETIME NULL,
                    dispensed_by INT NULL,
                    dispensed_date DATETIME NULL,
                    completed_date DATETIME NULL,
                    notes TEXT,
                    FOREIGN KEY (patient_id) REFERENCES Patients(patient_id) ON DELETE CASCADE,
                    FOREIGN KEY (doctor_id) REFERENCES Doctors(doctor_id) ON DELETE CASCADE,
                    FOREIGN KEY (validated_by) REFERENCES Users(user_id) ON DELETE SET NULL,
                    FOREIGN KEY (dispensed_by) REFERENCES Users(user_id) ON DELETE SET NULL
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";


                string createDispensingRecordsTable = @"
                CREATE TABLE IF NOT EXISTS DispensingRecords (
                    dispense_id INT PRIMARY KEY AUTO_INCREMENT,
                    order_id INT,
                    medicine_id INT NOT NULL,
                    patient_id INT NOT NULL,
                    quantity_dispensed INT NOT NULL,
                    unit_price DECIMAL(10,2) NOT NULL,
                    total_amount DECIMAL(10,2) NOT NULL,
                    batch_number VARCHAR(100),
                    dispensed_by INT NOT NULL,
                    dispensed_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    inventory_deducted TINYINT(1) DEFAULT 1,
                    billing_added TINYINT(1) DEFAULT 1,
                    patient_type VARCHAR(20) DEFAULT 'Outpatient',
                    notes TEXT,
                    FOREIGN KEY (order_id) REFERENCES MedicationOrders(order_id) ON DELETE SET NULL,
                    FOREIGN KEY (medicine_id) REFERENCES MedicineInventory(medicine_id) ON DELETE RESTRICT,
                    FOREIGN KEY (patient_id) REFERENCES Patients(patient_id) ON DELETE CASCADE,
                    FOREIGN KEY (dispensed_by) REFERENCES Users(user_id) ON DELETE RESTRICT
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";


                string createMedicationReturnsTable = @"
                CREATE TABLE IF NOT EXISTS MedicationReturns (
                    return_id INT PRIMARY KEY AUTO_INCREMENT,
                    dispense_id INT,
                    order_id INT,
                    medicine_id INT NOT NULL,
                    patient_id INT NOT NULL,
                    quantity_returned INT NOT NULL,
                    return_reason VARCHAR(500) NOT NULL,
                    return_type VARCHAR(50) DEFAULT 'Full',
                    refund_amount DECIMAL(10,2),
                    returned_to_stock TINYINT(1) DEFAULT 0,
                    processed_by INT NOT NULL,
                    return_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    approved_by INT NULL,
                    approval_date DATETIME NULL,
                    status VARCHAR(20) DEFAULT 'Pending',
                    notes TEXT,
                    FOREIGN KEY (dispense_id) REFERENCES DispensingRecords(dispense_id) ON DELETE SET NULL,
                    FOREIGN KEY (order_id) REFERENCES MedicationOrders(order_id) ON DELETE SET NULL,
                    FOREIGN KEY (medicine_id) REFERENCES MedicineInventory(medicine_id) ON DELETE RESTRICT,
                    FOREIGN KEY (patient_id) REFERENCES Patients(patient_id) ON DELETE CASCADE,
                    FOREIGN KEY (processed_by) REFERENCES Users(user_id) ON DELETE RESTRICT,
                    FOREIGN KEY (approved_by) REFERENCES Users(user_id) ON DELETE SET NULL
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";


                string createControlledSubstanceLogTable = @"
                CREATE TABLE IF NOT EXISTS ControlledSubstanceLog (
                    log_id INT PRIMARY KEY AUTO_INCREMENT,
                    medicine_id INT NOT NULL,
                    dispense_id INT,
                    patient_id INT NOT NULL,
                    quantity INT NOT NULL,
                    action_type VARCHAR(50) NOT NULL,
                    dispensed_by INT NOT NULL,
                    approved_by INT,
                    witness_by INT,
                    log_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    reason TEXT,
                    notes TEXT,
                    FOREIGN KEY (medicine_id) REFERENCES MedicineInventory(medicine_id) ON DELETE RESTRICT,
                    FOREIGN KEY (dispense_id) REFERENCES DispensingRecords(dispense_id) ON DELETE SET NULL,
                    FOREIGN KEY (patient_id) REFERENCES Patients(patient_id) ON DELETE CASCADE,
                    FOREIGN KEY (dispensed_by) REFERENCES Users(user_id) ON DELETE RESTRICT,
                    FOREIGN KEY (approved_by) REFERENCES Users(user_id) ON DELETE SET NULL,
                    FOREIGN KEY (witness_by) REFERENCES Users(user_id) ON DELETE SET NULL
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";


                string createStockAdjustmentTable = @"
                CREATE TABLE IF NOT EXISTS StockAdjustment (
                    adjustment_id INT PRIMARY KEY AUTO_INCREMENT,
                    medicine_id INT NOT NULL,
                    adjustment_type VARCHAR(50) NOT NULL,
                    quantity_change INT NOT NULL,
                    previous_quantity INT NOT NULL,
                    new_quantity INT NOT NULL,
                    reason VARCHAR(500) NOT NULL,
                    batch_number VARCHAR(100),
                    adjusted_by INT NOT NULL,
                    adjustment_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    notes TEXT,
                    FOREIGN KEY (medicine_id) REFERENCES MedicineInventory(medicine_id) ON DELETE RESTRICT,
                    FOREIGN KEY (adjusted_by) REFERENCES Users(user_id) ON DELETE RESTRICT
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4";

                string updateBillingTable = @"
                        ALTER TABLE Billing 
                        ADD COLUMN IF NOT EXISTS subtotal DECIMAL(10,2) DEFAULT 0.00 AFTER amount,
                        ADD COLUMN IF NOT EXISTS discount_percent DECIMAL(5,2) DEFAULT 0.00 AFTER subtotal,
                        ADD COLUMN IF NOT EXISTS discount_amount DECIMAL(10,2) DEFAULT 0.00 AFTER discount_percent,
                        ADD COLUMN IF NOT EXISTS tax_percent DECIMAL(5,2) DEFAULT 0.00 AFTER discount_amount,
                        ADD COLUMN IF NOT EXISTS tax_amount DECIMAL(10,2) DEFAULT 0.00 AFTER tax_percent,
                        MODIFY COLUMN description TEXT,
                        ADD COLUMN IF NOT EXISTS payment_method VARCHAR(50) DEFAULT 'Cash' AFTER description,
                        ADD COLUMN IF NOT EXISTS notes TEXT AFTER payment_method";

                //this is execute table creation
                ExecuteNonQueryInternal(conn, createUsersTable);
                ExecuteNonQueryInternal(conn, createPatientsTable);
                ExecuteNonQueryInternal(conn, createDoctorsTable);
                ExecuteNonQueryInternal(conn, createStaffTable);
                ExecuteNonQueryInternal(conn, createQueueTable);
                ExecuteNonQueryInternal(conn, createAppointmentsTable);
                ExecuteNonQueryInternal(conn, createMedicalRecordsTable);
                ExecuteNonQueryInternal(conn, createBillingTable);
                ExecuteNonQueryInternal(conn, createMedicineInventoryTable);
                ExecuteNonQueryInternal(conn, createMedicationOrdersTable);
                ExecuteNonQueryInternal(conn, createDispensingRecordsTable);
                ExecuteNonQueryInternal(conn, createMedicationReturnsTable);
                ExecuteNonQueryInternal(conn, createControlledSubstanceLogTable);
                ExecuteNonQueryInternal(conn, createStockAdjustmentTable);
                ExecuteNonQueryInternal(conn, updateBillingTable);

                //this is to insert default admin user
                string checkHeadadmin = "SELECT COUNT(*) FROM Users WHERE email = 'Headadmin@hospital.com'";
                object adminResult = ExecuteScalarInternal(conn, checkHeadadmin);
                long HeadadminExists = Convert.ToInt64(adminResult);

                if (HeadadminExists == 0)
                {
                    string insertHeadadmin = @"
        INSERT INTO Users (name, role, email, password, age, gender, created_by)
        VALUES ('Hospital Admin', 'Headadmin', 'Headadmin@hospital.com', 'admin123', 30, 'Other', NULL)";
                    ExecuteNonQueryInternal(conn, insertHeadadmin);
                }


                string checkReceptionist = "SELECT COUNT(*) FROM Users WHERE email = 'receptionist@hospital.com'";
                object receptionistResult = ExecuteScalarInternal(conn, checkReceptionist);
                long receptionistExists = Convert.ToInt64(receptionistResult);

                if (receptionistExists == 0)
                {
                    string getAdminId = "SELECT user_id FROM Users WHERE email = 'Headadmin@hospital.com'";
                    object adminIdResult = ExecuteScalarInternal(conn, getAdminId);
                    long adminId = Convert.ToInt64(adminIdResult);

                    string insertreceptionist = @"
        INSERT INTO Users (name, role, email, password, age, gender, created_by)
        VALUES ('receptionist User', 'Receptionist', 'receptionist@hospital.com', 'receptionist123', 28, 'Female', @createdBy)";
                    MySqlCommand cmdReceptionist = new MySqlCommand(insertreceptionist, conn);
                    cmdReceptionist.Parameters.AddWithValue("@createdBy", adminId);
                    cmdReceptionist.ExecuteNonQuery();
                }

                string checkPharmacist = "SELECT COUNT(*) FROM Users WHERE email = 'pharmacist@hospital.com'";
                object pharmacistResult = ExecuteScalarInternal(conn, checkPharmacist);
                long pharmacistExists = Convert.ToInt64(pharmacistResult);

                if (pharmacistExists == 0)
                {
                    string getAdminId = "SELECT user_id FROM Users WHERE email = 'Headadmin@hospital.com'";
                    object adminIdResult = ExecuteScalarInternal(conn, getAdminId);
                    long adminId = Convert.ToInt64(adminIdResult);

                    string insertPharmacist = @"
        INSERT INTO Users (name, role, email, password, age, gender, created_by)
        VALUES ('Pharmacy Staff', 'Pharmacist', 'pharmacist@hospital.com', 'pharmacist123', 30, 'Other', @createdBy)";
                    MySqlCommand cmdPharmacist = new MySqlCommand(insertPharmacist, conn);
                    cmdPharmacist.Parameters.AddWithValue("@createdBy", adminId);
                    cmdPharmacist.ExecuteNonQuery();


                    string getPharmacistId = "SELECT user_id FROM Users WHERE email = 'pharmacist@hospital.com'";
                    object pharmacistIdResult = ExecuteScalarInternal(conn, getPharmacistId);
                    long pharmacistId = Convert.ToInt64(pharmacistIdResult);


                    string insertPharmacistStaff = @"
        INSERT INTO Staff (user_id, position, department)
        VALUES (@userId, 'Pharmacist', 'Pharmacy')";
                    MySqlCommand cmdPharmacistStaff = new MySqlCommand(insertPharmacistStaff, conn);
                    cmdPharmacistStaff.Parameters.AddWithValue("@userId", pharmacistId);
                    cmdPharmacistStaff.ExecuteNonQuery();
                }

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


missing stuff / unfinished (top priority) pag di natapos magigisa tayo

1. billing FIXED - enhanced with realistic features
2. security dipa added

future plans 

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


Update
1.halos fix na lahat need nalang padebug patulong nalang
2.pag ok na lahat billing nalang need ko i update - BILLING DONE!
3.pag fix na yung billing design na
4.pag tapos na doon ko lalagyan lahat ng comments mashadong tamad para maglagay

sa mga designers gamitin ninyo yung mga ui ko as reference papagandahin ninyo lang
yung probided na sa designer.cs paramakita yung design shift + f7 pag yung code f7 lang*/