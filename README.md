# 🏥 Health App For Second Year Defence Baby!!!

**Status:** 🟡 Semi-working  
**Note:** Requires **XAMPP** to run.

---

## ⚙️ Requirements
- Install [XAMPP](https://www.apachefriends.org/index.html)  
- 💾 **Recommended:** Install it in your **D:\ drive** instead of **C:\**  
  *(This helps avoid permission issues and missing file path errors.)*

---

## 🗄️ Database Access
Once XAMPP is running:

1. Start **Apache** and **MySQL** from the XAMPP Control Panel.  
2. Open your browser and go to:  
   👉 [http://localhost/phpmyadmin](http://localhost/phpmyadmin)  
3. You can view or modify the database there (default name: `hospital_db`).

---

## 🧹 Resetting the Database

If you want to **wipe or reset** the hospital database completely *(also required if an update was made)*:

1. Open **XAMPP Shell** (click the *Shell* button in the XAMPP Control Panel).  
2. Type the following command:
   ```bash
   mysql -u root -p
When prompted for a password, just press Enter (there isn’t one by default).

Then execute:

sql
Copy code
DROP DATABASE IF EXISTS `hospital_db`;
Restart your app — it will recreate the database automatically if supported.

💡 Notes
The project automatically creates the database and tables when first run.

Designers are outdated.

The name itself is temporary.

Default accounts:

🧑‍💼 Headadmin: Headadmin@hospital.com / admin123

🧾 Receptionist: receptionist@hospital.com / receptionist123

💊 Pharmacist: pharmacist@hospital.com / pharmacist123
