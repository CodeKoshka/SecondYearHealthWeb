namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class MedicalRecordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            panelCauseProblem = new Panel();
            lblCauseProblem = new Label();
            chkCarAccident = new CheckBox();
            chkWorkInjury = new CheckBox();
            chkGradualOnset = new CheckBox();
            chkOther = new CheckBox();
            txtOtherCause = new TextBox();
            lblProblemStarted = new Label();
            txtProblemStarted = new TextBox();
            panelCardiacSymptoms = new Panel();
            lblCardiacSymptoms = new Label();
            chkChestPain = new CheckBox();
            chkShortBreath = new CheckBox();
            chkPalpitations = new CheckBox();
            chkDizziness = new CheckBox();
            chkFatigue = new CheckBox();
            chkSwelling = new CheckBox();
            chkIrregularHeartbeat = new CheckBox();
            chkFainting = new CheckBox();
            panelPastHistory = new Panel();
            lblPastHistory = new Label();
            chkHeartProblems = new CheckBox();
            chkHighBloodPressure = new CheckBox();
            chkHighCholesterol = new CheckBox();
            chkPacemaker = new CheckBox();
            chkStroke = new CheckBox();
            chkBreathingProblems = new CheckBox();
            chkDiabetes = new CheckBox();
            chkKidneyProblems = new CheckBox();
            chkSmoking = new CheckBox();
            chkAlcoholUse = new CheckBox();
            chkSleepApnea = new CheckBox();
            chkTumorCancer = new CheckBox();
            chkPregnant = new CheckBox();
            chkGallbladderLiver = new CheckBox();
            chkBoneJoint = new CheckBox();
            chkAnxietyAttacks = new CheckBox();
            chkDepression = new CheckBox();
            chkBowelBladder = new CheckBox();
            chkCurrentWound = new CheckBox();
            chkElectricalImplants = new CheckBox();
            chkDrugUse = new CheckBox();
            chkHeadaches = new CheckBox();
            panelSurgeries = new Panel();
            lblSurgeries = new Label();
            chkNoSurgeries = new CheckBox();
            chkYesSurgery = new CheckBox();
            txtSurgeryDetails = new TextBox();
            panelMedications = new Panel();
            lblMedications = new Label();
            chkNoMedication = new CheckBox();
            txtMedications = new TextBox();
            panelAllergies = new Panel();
            lblAllergies = new Label();
            chkNoKnownAllergies = new CheckBox();
            chkLatexAllergy = new CheckBox();
            chkIodineAllergy = new CheckBox();
            chkBromineAllergy = new CheckBox();
            lblOtherAllergies = new Label();
            txtOtherAllergies = new TextBox();
            panelAdditional = new Panel();
            lblDoctorsNotes = new Label();
            txtAdditionalComments = new TextBox();
            panelSignature = new Panel();
            lblSignature = new Label();
            txtDoctorSignature = new TextBox();
            lblDate = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            lblAdditionalComments = new Label();
            chkReligiousCultural = new CheckBox();
            panelHeader.SuspendLayout();
            panelCauseProblem.SuspendLayout();
            panelCardiacSymptoms.SuspendLayout();
            panelPastHistory.SuspendLayout();
            panelSurgeries.SuspendLayout();
            panelMedications.SuspendLayout();
            panelAllergies.SuspendLayout();
            panelAdditional.SuspendLayout();
            panelSignature.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(220, 53, 69);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1103, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(611, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "❤️ CARDIAC ASSESSMENT - MEDICAL REPORT";
            // 
            // panelCauseProblem
            // 
            panelCauseProblem.BackColor = Color.White;
            panelCauseProblem.BorderStyle = BorderStyle.FixedSingle;
            panelCauseProblem.Controls.Add(lblCauseProblem);
            panelCauseProblem.Controls.Add(chkCarAccident);
            panelCauseProblem.Controls.Add(chkWorkInjury);
            panelCauseProblem.Controls.Add(chkGradualOnset);
            panelCauseProblem.Controls.Add(chkOther);
            panelCauseProblem.Controls.Add(txtOtherCause);
            panelCauseProblem.Controls.Add(lblProblemStarted);
            panelCauseProblem.Controls.Add(txtProblemStarted);
            panelCauseProblem.Location = new Point(30, 232);
            panelCauseProblem.Name = "panelCauseProblem";
            panelCauseProblem.Size = new Size(1040, 130);
            panelCauseProblem.TabIndex = 2;
            // 
            // lblCauseProblem
            // 
            lblCauseProblem.AutoSize = true;
            lblCauseProblem.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCauseProblem.Location = new Point(10, 10);
            lblCauseProblem.Name = "lblCauseProblem";
            lblCauseProblem.Size = new Size(193, 20);
            lblCauseProblem.TabIndex = 0;
            lblCauseProblem.Text = "Cause of Current Problem:";
            // 
            // chkCarAccident
            // 
            chkCarAccident.Font = new Font("Segoe UI", 10F);
            chkCarAccident.Location = new Point(20, 40);
            chkCarAccident.Name = "chkCarAccident";
            chkCarAccident.Size = new Size(200, 24);
            chkCarAccident.TabIndex = 1;
            chkCarAccident.Text = "Car Accident";
            // 
            // chkWorkInjury
            // 
            chkWorkInjury.Font = new Font("Segoe UI", 10F);
            chkWorkInjury.Location = new Point(240, 40);
            chkWorkInjury.Name = "chkWorkInjury";
            chkWorkInjury.Size = new Size(200, 24);
            chkWorkInjury.TabIndex = 2;
            chkWorkInjury.Text = "Work Injury";
            // 
            // chkGradualOnset
            // 
            chkGradualOnset.Font = new Font("Segoe UI", 10F);
            chkGradualOnset.Location = new Point(460, 40);
            chkGradualOnset.Name = "chkGradualOnset";
            chkGradualOnset.Size = new Size(200, 24);
            chkGradualOnset.TabIndex = 3;
            chkGradualOnset.Text = "Gradual Onset";
            // 
            // chkOther
            // 
            chkOther.Font = new Font("Segoe UI", 10F);
            chkOther.Location = new Point(680, 40);
            chkOther.Name = "chkOther";
            chkOther.Size = new Size(100, 24);
            chkOther.TabIndex = 4;
            chkOther.Text = "Other:";
            // 
            // txtOtherCause
            // 
            txtOtherCause.Font = new Font("Segoe UI", 10F);
            txtOtherCause.Location = new Point(780, 38);
            txtOtherCause.Name = "txtOtherCause";
            txtOtherCause.Size = new Size(240, 25);
            txtOtherCause.TabIndex = 5;
            // 
            // lblProblemStarted
            // 
            lblProblemStarted.AutoSize = true;
            lblProblemStarted.Font = new Font("Segoe UI", 10F);
            lblProblemStarted.Location = new Point(20, 80);
            lblProblemStarted.Name = "lblProblemStarted";
            lblProblemStarted.Size = new Size(193, 19);
            lblProblemStarted.TabIndex = 6;
            lblProblemStarted.Text = "When did your problem start?";
            // 
            // txtProblemStarted
            // 
            txtProblemStarted.Font = new Font("Segoe UI", 10F);
            txtProblemStarted.Location = new Point(270, 77);
            txtProblemStarted.Name = "txtProblemStarted";
            txtProblemStarted.Size = new Size(750, 25);
            txtProblemStarted.TabIndex = 7;
            // 
            // panelCardiacSymptoms
            // 
            panelCardiacSymptoms.BackColor = Color.FromArgb(255, 243, 243);
            panelCardiacSymptoms.BorderStyle = BorderStyle.FixedSingle;
            panelCardiacSymptoms.Controls.Add(lblCardiacSymptoms);
            panelCardiacSymptoms.Controls.Add(chkChestPain);
            panelCardiacSymptoms.Controls.Add(chkShortBreath);
            panelCardiacSymptoms.Controls.Add(chkPalpitations);
            panelCardiacSymptoms.Controls.Add(chkDizziness);
            panelCardiacSymptoms.Controls.Add(chkFatigue);
            panelCardiacSymptoms.Controls.Add(chkSwelling);
            panelCardiacSymptoms.Controls.Add(chkIrregularHeartbeat);
            panelCardiacSymptoms.Controls.Add(chkFainting);
            panelCardiacSymptoms.Location = new Point(30, 86);
            panelCardiacSymptoms.Name = "panelCardiacSymptoms";
            panelCardiacSymptoms.Size = new Size(1040, 140);
            panelCardiacSymptoms.TabIndex = 1;
            // 
            // lblCardiacSymptoms
            // 
            lblCardiacSymptoms.AutoSize = true;
            lblCardiacSymptoms.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCardiacSymptoms.ForeColor = Color.FromArgb(220, 53, 69);
            lblCardiacSymptoms.Location = new Point(10, 10);
            lblCardiacSymptoms.Name = "lblCardiacSymptoms";
            lblCardiacSymptoms.Size = new Size(369, 21);
            lblCardiacSymptoms.TabIndex = 0;
            lblCardiacSymptoms.Text = "⚠️ CARDIAC SYMPTOMS (Check all that apply):";
            // 
            // chkChestPain
            // 
            chkChestPain.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkChestPain.ForeColor = Color.FromArgb(220, 53, 69);
            chkChestPain.Location = new Point(20, 45);
            chkChestPain.Name = "chkChestPain";
            chkChestPain.Size = new Size(240, 24);
            chkChestPain.TabIndex = 1;
            chkChestPain.Text = "Chest Pain/Discomfort";
            // 
            // chkShortBreath
            // 
            chkShortBreath.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkShortBreath.ForeColor = Color.FromArgb(220, 53, 69);
            chkShortBreath.Location = new Point(280, 45);
            chkShortBreath.Name = "chkShortBreath";
            chkShortBreath.Size = new Size(240, 24);
            chkShortBreath.TabIndex = 2;
            chkShortBreath.Text = "Shortness of Breath";
            // 
            // chkPalpitations
            // 
            chkPalpitations.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkPalpitations.ForeColor = Color.FromArgb(220, 53, 69);
            chkPalpitations.Location = new Point(540, 45);
            chkPalpitations.Name = "chkPalpitations";
            chkPalpitations.Size = new Size(240, 24);
            chkPalpitations.TabIndex = 3;
            chkPalpitations.Text = "Heart Palpitations";
            // 
            // chkDizziness
            // 
            chkDizziness.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkDizziness.ForeColor = Color.FromArgb(220, 53, 69);
            chkDizziness.Location = new Point(800, 45);
            chkDizziness.Name = "chkDizziness";
            chkDizziness.Size = new Size(220, 24);
            chkDizziness.TabIndex = 4;
            chkDizziness.Text = "Dizziness/Lightheaded";
            // 
            // chkFatigue
            // 
            chkFatigue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkFatigue.ForeColor = Color.FromArgb(220, 53, 69);
            chkFatigue.Location = new Point(20, 75);
            chkFatigue.Name = "chkFatigue";
            chkFatigue.Size = new Size(240, 24);
            chkFatigue.TabIndex = 5;
            chkFatigue.Text = "Unusual Fatigue";
            // 
            // chkSwelling
            // 
            chkSwelling.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkSwelling.ForeColor = Color.FromArgb(220, 53, 69);
            chkSwelling.Location = new Point(280, 75);
            chkSwelling.Name = "chkSwelling";
            chkSwelling.Size = new Size(240, 24);
            chkSwelling.TabIndex = 6;
            chkSwelling.Text = "Swelling (Legs/Ankles)";
            // 
            // chkIrregularHeartbeat
            // 
            chkIrregularHeartbeat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkIrregularHeartbeat.ForeColor = Color.FromArgb(220, 53, 69);
            chkIrregularHeartbeat.Location = new Point(540, 75);
            chkIrregularHeartbeat.Name = "chkIrregularHeartbeat";
            chkIrregularHeartbeat.Size = new Size(240, 24);
            chkIrregularHeartbeat.TabIndex = 7;
            chkIrregularHeartbeat.Text = "Irregular Heartbeat";
            // 
            // chkFainting
            // 
            chkFainting.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkFainting.ForeColor = Color.FromArgb(220, 53, 69);
            chkFainting.Location = new Point(800, 75);
            chkFainting.Name = "chkFainting";
            chkFainting.Size = new Size(220, 24);
            chkFainting.TabIndex = 8;
            chkFainting.Text = "Fainting Episodes";
            // 
            // panelPastHistory
            // 
            panelPastHistory.BackColor = Color.White;
            panelPastHistory.BorderStyle = BorderStyle.FixedSingle;
            panelPastHistory.Controls.Add(lblPastHistory);
            panelPastHistory.Controls.Add(chkHeartProblems);
            panelPastHistory.Controls.Add(chkHighBloodPressure);
            panelPastHistory.Controls.Add(chkHighCholesterol);
            panelPastHistory.Controls.Add(chkPacemaker);
            panelPastHistory.Controls.Add(chkStroke);
            panelPastHistory.Controls.Add(chkBreathingProblems);
            panelPastHistory.Controls.Add(chkDiabetes);
            panelPastHistory.Controls.Add(chkKidneyProblems);
            panelPastHistory.Controls.Add(chkSmoking);
            panelPastHistory.Controls.Add(chkAlcoholUse);
            panelPastHistory.Controls.Add(chkSleepApnea);
            panelPastHistory.Controls.Add(chkTumorCancer);
            panelPastHistory.Controls.Add(chkPregnant);
            panelPastHistory.Controls.Add(chkGallbladderLiver);
            panelPastHistory.Controls.Add(chkBoneJoint);
            panelPastHistory.Controls.Add(chkAnxietyAttacks);
            panelPastHistory.Controls.Add(chkDepression);
            panelPastHistory.Controls.Add(chkBowelBladder);
            panelPastHistory.Controls.Add(chkCurrentWound);
            panelPastHistory.Controls.Add(chkElectricalImplants);
            panelPastHistory.Controls.Add(chkDrugUse);
            panelPastHistory.Controls.Add(chkHeadaches);
            panelPastHistory.Location = new Point(30, 368);
            panelPastHistory.Name = "panelPastHistory";
            panelPastHistory.Size = new Size(1040, 229);
            panelPastHistory.TabIndex = 3;
            // 
            // lblPastHistory
            // 
            lblPastHistory.AutoSize = true;
            lblPastHistory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPastHistory.Location = new Point(10, 10);
            lblPastHistory.Name = "lblPastHistory";
            lblPastHistory.Size = new Size(509, 20);
            lblPastHistory.TabIndex = 0;
            lblPastHistory.Text = "Past Medical History - Does the Patient have a history of the following?";
            // 
            // chkHeartProblems
            // 
            chkHeartProblems.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkHeartProblems.ForeColor = Color.FromArgb(220, 53, 69);
            chkHeartProblems.Location = new Point(20, 45);
            chkHeartProblems.Name = "chkHeartProblems";
            chkHeartProblems.Size = new Size(230, 24);
            chkHeartProblems.TabIndex = 1;
            chkHeartProblems.Text = "Heart Problems";
            // 
            // chkHighBloodPressure
            // 
            chkHighBloodPressure.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkHighBloodPressure.ForeColor = Color.FromArgb(220, 53, 69);
            chkHighBloodPressure.Location = new Point(270, 45);
            chkHighBloodPressure.Name = "chkHighBloodPressure";
            chkHighBloodPressure.Size = new Size(230, 24);
            chkHighBloodPressure.TabIndex = 2;
            chkHighBloodPressure.Text = "High Blood Pressure";
            // 
            // chkHighCholesterol
            // 
            chkHighCholesterol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkHighCholesterol.ForeColor = Color.FromArgb(220, 53, 69);
            chkHighCholesterol.Location = new Point(520, 45);
            chkHighCholesterol.Name = "chkHighCholesterol";
            chkHighCholesterol.Size = new Size(230, 24);
            chkHighCholesterol.TabIndex = 3;
            chkHighCholesterol.Text = "High Cholesterol";
            // 
            // chkPacemaker
            // 
            chkPacemaker.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkPacemaker.ForeColor = Color.FromArgb(220, 53, 69);
            chkPacemaker.Location = new Point(770, 45);
            chkPacemaker.Name = "chkPacemaker";
            chkPacemaker.Size = new Size(230, 24);
            chkPacemaker.TabIndex = 4;
            chkPacemaker.Text = "Pacemaker";
            // 
            // chkStroke
            // 
            chkStroke.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkStroke.ForeColor = Color.FromArgb(220, 53, 69);
            chkStroke.Location = new Point(20, 75);
            chkStroke.Name = "chkStroke";
            chkStroke.Size = new Size(230, 24);
            chkStroke.TabIndex = 5;
            chkStroke.Text = "Stroke/TIA";
            // 
            // chkBreathingProblems
            // 
            chkBreathingProblems.Font = new Font("Segoe UI", 10F);
            chkBreathingProblems.Location = new Point(270, 75);
            chkBreathingProblems.Name = "chkBreathingProblems";
            chkBreathingProblems.Size = new Size(230, 24);
            chkBreathingProblems.TabIndex = 6;
            chkBreathingProblems.Text = "Breathing Problems";
            // 
            // chkDiabetes
            // 
            chkDiabetes.Font = new Font("Segoe UI", 10F);
            chkDiabetes.Location = new Point(520, 75);
            chkDiabetes.Name = "chkDiabetes";
            chkDiabetes.Size = new Size(230, 24);
            chkDiabetes.TabIndex = 7;
            chkDiabetes.Text = "Diabetes";
            // 
            // chkKidneyProblems
            // 
            chkKidneyProblems.Font = new Font("Segoe UI", 10F);
            chkKidneyProblems.Location = new Point(770, 75);
            chkKidneyProblems.Name = "chkKidneyProblems";
            chkKidneyProblems.Size = new Size(230, 24);
            chkKidneyProblems.TabIndex = 8;
            chkKidneyProblems.Text = "Kidney Problems";
            // 
            // chkSmoking
            // 
            chkSmoking.Font = new Font("Segoe UI", 10F);
            chkSmoking.Location = new Point(20, 105);
            chkSmoking.Name = "chkSmoking";
            chkSmoking.Size = new Size(230, 24);
            chkSmoking.TabIndex = 9;
            chkSmoking.Text = "Smoking";
            // 
            // chkAlcoholUse
            // 
            chkAlcoholUse.Font = new Font("Segoe UI", 10F);
            chkAlcoholUse.Location = new Point(270, 105);
            chkAlcoholUse.Name = "chkAlcoholUse";
            chkAlcoholUse.Size = new Size(230, 24);
            chkAlcoholUse.TabIndex = 10;
            chkAlcoholUse.Text = "Heavy Alcohol Use";
            // 
            // chkSleepApnea
            // 
            chkSleepApnea.Font = new Font("Segoe UI", 10F);
            chkSleepApnea.Location = new Point(520, 105);
            chkSleepApnea.Name = "chkSleepApnea";
            chkSleepApnea.Size = new Size(230, 24);
            chkSleepApnea.TabIndex = 11;
            chkSleepApnea.Text = "Sleep Apnea";
            // 
            // chkTumorCancer
            // 
            chkTumorCancer.Font = new Font("Segoe UI", 10F);
            chkTumorCancer.Location = new Point(770, 105);
            chkTumorCancer.Name = "chkTumorCancer";
            chkTumorCancer.Size = new Size(230, 24);
            chkTumorCancer.TabIndex = 12;
            chkTumorCancer.Text = "Tumor/Cancer";
            // 
            // chkPregnant
            // 
            chkPregnant.Font = new Font("Segoe UI", 10F);
            chkPregnant.Location = new Point(20, 135);
            chkPregnant.Name = "chkPregnant";
            chkPregnant.Size = new Size(230, 24);
            chkPregnant.TabIndex = 13;
            chkPregnant.Text = "Pregnant";
            // 
            // chkGallbladderLiver
            // 
            chkGallbladderLiver.Font = new Font("Segoe UI", 10F);
            chkGallbladderLiver.Location = new Point(270, 135);
            chkGallbladderLiver.Name = "chkGallbladderLiver";
            chkGallbladderLiver.Size = new Size(230, 24);
            chkGallbladderLiver.TabIndex = 14;
            chkGallbladderLiver.Text = "Gallbladder/Liver";
            // 
            // chkBoneJoint
            // 
            chkBoneJoint.Font = new Font("Segoe UI", 10F);
            chkBoneJoint.Location = new Point(520, 135);
            chkBoneJoint.Name = "chkBoneJoint";
            chkBoneJoint.Size = new Size(230, 24);
            chkBoneJoint.TabIndex = 15;
            chkBoneJoint.Text = "Bone/Joint Problems";
            // 
            // chkAnxietyAttacks
            // 
            chkAnxietyAttacks.Font = new Font("Segoe UI", 10F);
            chkAnxietyAttacks.Location = new Point(770, 135);
            chkAnxietyAttacks.Name = "chkAnxietyAttacks";
            chkAnxietyAttacks.Size = new Size(230, 24);
            chkAnxietyAttacks.TabIndex = 16;
            chkAnxietyAttacks.Text = "Anxiety Attacks";
            // 
            // chkDepression
            // 
            chkDepression.Font = new Font("Segoe UI", 10F);
            chkDepression.Location = new Point(20, 165);
            chkDepression.Name = "chkDepression";
            chkDepression.Size = new Size(230, 24);
            chkDepression.TabIndex = 17;
            chkDepression.Text = "Depression";
            // 
            // chkBowelBladder
            // 
            chkBowelBladder.Font = new Font("Segoe UI", 10F);
            chkBowelBladder.Location = new Point(270, 165);
            chkBowelBladder.Name = "chkBowelBladder";
            chkBowelBladder.Size = new Size(230, 24);
            chkBowelBladder.TabIndex = 18;
            chkBowelBladder.Text = "Bowel/Bladder";
            // 
            // chkCurrentWound
            // 
            chkCurrentWound.Font = new Font("Segoe UI", 10F);
            chkCurrentWound.Location = new Point(520, 165);
            chkCurrentWound.Name = "chkCurrentWound";
            chkCurrentWound.Size = new Size(230, 24);
            chkCurrentWound.TabIndex = 19;
            chkCurrentWound.Text = "Wound/Skin Problems";
            // 
            // chkElectricalImplants
            // 
            chkElectricalImplants.Font = new Font("Segoe UI", 10F);
            chkElectricalImplants.Location = new Point(770, 165);
            chkElectricalImplants.Name = "chkElectricalImplants";
            chkElectricalImplants.Size = new Size(230, 24);
            chkElectricalImplants.TabIndex = 20;
            chkElectricalImplants.Text = "Electrical Implants";
            // 
            // chkDrugUse
            // 
            chkDrugUse.Font = new Font("Segoe UI", 10F);
            chkDrugUse.Location = new Point(20, 195);
            chkDrugUse.Name = "chkDrugUse";
            chkDrugUse.Size = new Size(230, 24);
            chkDrugUse.TabIndex = 21;
            chkDrugUse.Text = "Drug Use";
            // 
            // chkHeadaches
            // 
            chkHeadaches.Font = new Font("Segoe UI", 10F);
            chkHeadaches.Location = new Point(270, 195);
            chkHeadaches.Name = "chkHeadaches";
            chkHeadaches.Size = new Size(230, 24);
            chkHeadaches.TabIndex = 22;
            chkHeadaches.Text = "Headaches";
            // 
            // panelSurgeries
            // 
            panelSurgeries.BackColor = Color.White;
            panelSurgeries.BorderStyle = BorderStyle.FixedSingle;
            panelSurgeries.Controls.Add(lblSurgeries);
            panelSurgeries.Controls.Add(chkNoSurgeries);
            panelSurgeries.Controls.Add(chkYesSurgery);
            panelSurgeries.Controls.Add(txtSurgeryDetails);
            panelSurgeries.Location = new Point(30, 603);
            panelSurgeries.Name = "panelSurgeries";
            panelSurgeries.Size = new Size(1040, 140);
            panelSurgeries.TabIndex = 4;
            // 
            // lblSurgeries
            // 
            lblSurgeries.AutoSize = true;
            lblSurgeries.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSurgeries.Location = new Point(10, 10);
            lblSurgeries.Name = "lblSurgeries";
            lblSurgeries.Size = new Size(197, 20);
            lblSurgeries.TabIndex = 0;
            lblSurgeries.Text = "Surgeries/Hospitalizations:";
            // 
            // chkNoSurgeries
            // 
            chkNoSurgeries.Font = new Font("Segoe UI", 10F);
            chkNoSurgeries.Location = new Point(20, 40);
            chkNoSurgeries.Name = "chkNoSurgeries";
            chkNoSurgeries.Size = new Size(150, 24);
            chkNoSurgeries.TabIndex = 1;
            chkNoSurgeries.Text = "No Surgeries";
            chkNoSurgeries.CheckedChanged += ChkNoSurgeries_CheckedChanged;
            // 
            // chkYesSurgery
            // 
            chkYesSurgery.Font = new Font("Segoe UI", 10F);
            chkYesSurgery.Location = new Point(200, 40);
            chkYesSurgery.Name = "chkYesSurgery";
            chkYesSurgery.Size = new Size(200, 24);
            chkYesSurgery.TabIndex = 2;
            chkYesSurgery.Text = "Yes (Details below)";
            chkYesSurgery.CheckedChanged += ChkYesSurgery_CheckedChanged;
            // 
            // txtSurgeryDetails
            // 
            txtSurgeryDetails.Font = new Font("Segoe UI", 10F);
            txtSurgeryDetails.Location = new Point(20, 70);
            txtSurgeryDetails.Multiline = true;
            txtSurgeryDetails.Name = "txtSurgeryDetails";
            txtSurgeryDetails.ScrollBars = ScrollBars.Vertical;
            txtSurgeryDetails.Size = new Size(1000, 55);
            txtSurgeryDetails.TabIndex = 3;
            // 
            // panelMedications
            // 
            panelMedications.BackColor = Color.White;
            panelMedications.BorderStyle = BorderStyle.FixedSingle;
            panelMedications.Controls.Add(lblMedications);
            panelMedications.Controls.Add(chkNoMedication);
            panelMedications.Controls.Add(txtMedications);
            panelMedications.Location = new Point(30, 749);
            panelMedications.Name = "panelMedications";
            panelMedications.Size = new Size(1040, 180);
            panelMedications.TabIndex = 5;
            // 
            // lblMedications
            // 
            lblMedications.AutoSize = true;
            lblMedications.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMedications.Location = new Point(10, 10);
            lblMedications.Name = "lblMedications";
            lblMedications.Size = new Size(330, 20);
            lblMedications.TabIndex = 0;
            lblMedications.Text = "Current Medications (including cardiac meds):";
            // 
            // chkNoMedication
            // 
            chkNoMedication.Font = new Font("Segoe UI", 10F);
            chkNoMedication.Location = new Point(20, 40);
            chkNoMedication.Name = "chkNoMedication";
            chkNoMedication.Size = new Size(200, 24);
            chkNoMedication.TabIndex = 1;
            chkNoMedication.Text = "No Medication";
            // 
            // txtMedications
            // 
            txtMedications.Font = new Font("Segoe UI", 10F);
            txtMedications.Location = new Point(20, 70);
            txtMedications.Multiline = true;
            txtMedications.Name = "txtMedications";
            txtMedications.PlaceholderText = "Enter medications, one per line:\nExample: Aspirin 81mg - Blood thinner\nLisinopril 10mg - Blood pressure";
            txtMedications.ScrollBars = ScrollBars.Vertical;
            txtMedications.Size = new Size(1000, 95);
            txtMedications.TabIndex = 2;
            // 
            // panelAllergies
            // 
            panelAllergies.BackColor = Color.White;
            panelAllergies.BorderStyle = BorderStyle.FixedSingle;
            panelAllergies.Controls.Add(lblAllergies);
            panelAllergies.Controls.Add(chkNoKnownAllergies);
            panelAllergies.Controls.Add(chkLatexAllergy);
            panelAllergies.Controls.Add(chkIodineAllergy);
            panelAllergies.Controls.Add(chkBromineAllergy);
            panelAllergies.Controls.Add(lblOtherAllergies);
            panelAllergies.Controls.Add(txtOtherAllergies);
            panelAllergies.Location = new Point(30, 935);
            panelAllergies.Name = "panelAllergies";
            panelAllergies.Size = new Size(1040, 120);
            panelAllergies.TabIndex = 6;
            // 
            // lblAllergies
            // 
            lblAllergies.AutoSize = true;
            lblAllergies.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAllergies.Location = new Point(10, 10);
            lblAllergies.Name = "lblAllergies";
            lblAllergies.Size = new Size(74, 20);
            lblAllergies.TabIndex = 0;
            lblAllergies.Text = "Allergies:";
            // 
            // chkNoKnownAllergies
            // 
            chkNoKnownAllergies.Font = new Font("Segoe UI", 10F);
            chkNoKnownAllergies.Location = new Point(20, 40);
            chkNoKnownAllergies.Name = "chkNoKnownAllergies";
            chkNoKnownAllergies.Size = new Size(200, 24);
            chkNoKnownAllergies.TabIndex = 1;
            chkNoKnownAllergies.Text = "No Known Allergies";
            // 
            // chkLatexAllergy
            // 
            chkLatexAllergy.Font = new Font("Segoe UI", 10F);
            chkLatexAllergy.Location = new Point(250, 40);
            chkLatexAllergy.Name = "chkLatexAllergy";
            chkLatexAllergy.Size = new Size(150, 24);
            chkLatexAllergy.TabIndex = 2;
            chkLatexAllergy.Text = "Latex";
            // 
            // chkIodineAllergy
            // 
            chkIodineAllergy.Font = new Font("Segoe UI", 10F);
            chkIodineAllergy.Location = new Point(430, 40);
            chkIodineAllergy.Name = "chkIodineAllergy";
            chkIodineAllergy.Size = new Size(150, 24);
            chkIodineAllergy.TabIndex = 3;
            chkIodineAllergy.Text = "Iodine";
            // 
            // chkBromineAllergy
            // 
            chkBromineAllergy.Font = new Font("Segoe UI", 10F);
            chkBromineAllergy.Location = new Point(610, 40);
            chkBromineAllergy.Name = "chkBromineAllergy";
            chkBromineAllergy.Size = new Size(150, 24);
            chkBromineAllergy.TabIndex = 4;
            chkBromineAllergy.Text = "Bromine";
            // 
            // lblOtherAllergies
            // 
            lblOtherAllergies.AutoSize = true;
            lblOtherAllergies.Font = new Font("Segoe UI", 10F);
            lblOtherAllergies.Location = new Point(20, 75);
            lblOtherAllergies.Name = "lblOtherAllergies";
            lblOtherAllergies.Size = new Size(48, 19);
            lblOtherAllergies.TabIndex = 5;
            lblOtherAllergies.Text = "Other:";
            // 
            // txtOtherAllergies
            // 
            txtOtherAllergies.Font = new Font("Segoe UI", 10F);
            txtOtherAllergies.Location = new Point(80, 73);
            txtOtherAllergies.Name = "txtOtherAllergies";
            txtOtherAllergies.Size = new Size(940, 25);
            txtOtherAllergies.TabIndex = 6;
            // 
            // panelAdditional
            // 
            panelAdditional.BackColor = Color.White;
            panelAdditional.BorderStyle = BorderStyle.FixedSingle;
            panelAdditional.Controls.Add(lblDoctorsNotes);
            panelAdditional.Controls.Add(txtAdditionalComments);
            panelAdditional.Location = new Point(30, 1061);
            panelAdditional.Name = "panelAdditional";
            panelAdditional.Size = new Size(1040, 150);
            panelAdditional.TabIndex = 7;
            // 
            // lblDoctorsNotes
            // 
            lblDoctorsNotes.AutoSize = true;
            lblDoctorsNotes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDoctorsNotes.ForeColor = Color.FromArgb(26, 32, 44);
            lblDoctorsNotes.Location = new Point(10, 10);
            lblDoctorsNotes.Name = "lblDoctorsNotes";
            lblDoctorsNotes.Size = new Size(270, 19);
            lblDoctorsNotes.TabIndex = 0;
            lblDoctorsNotes.Text = "Doctor's Notes / Additional Comments:";
            // 
            // txtAdditionalComments
            // 
            txtAdditionalComments.Font = new Font("Segoe UI", 10F);
            txtAdditionalComments.Location = new Point(20, 40);
            txtAdditionalComments.Multiline = true;
            txtAdditionalComments.Name = "txtAdditionalComments";
            txtAdditionalComments.PlaceholderText = "Enter any additional notes, observations, or recommendations for the patient's care...";
            txtAdditionalComments.ScrollBars = ScrollBars.Vertical;
            txtAdditionalComments.Size = new Size(1000, 90);
            txtAdditionalComments.TabIndex = 1;
            // 
            // panelSignature
            // 
            panelSignature.BackColor = Color.FromArgb(248, 249, 250);
            panelSignature.BorderStyle = BorderStyle.FixedSingle;
            panelSignature.Controls.Add(lblSignature);
            panelSignature.Controls.Add(txtDoctorSignature);
            panelSignature.Controls.Add(lblDate);
            panelSignature.Location = new Point(30, 1217);
            panelSignature.Name = "panelSignature";
            panelSignature.Size = new Size(1040, 80);
            panelSignature.TabIndex = 8;
            // 
            // lblSignature
            // 
            lblSignature.AutoSize = true;
            lblSignature.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSignature.Location = new Point(20, 30);
            lblSignature.Name = "lblSignature";
            lblSignature.Size = new Size(149, 20);
            lblSignature.TabIndex = 0;
            lblSignature.Text = "Physician Signature:";
            // 
            // txtDoctorSignature
            // 
            txtDoctorSignature.Font = new Font("Segoe UI", 11F);
            txtDoctorSignature.Location = new Point(180, 27);
            txtDoctorSignature.Name = "txtDoctorSignature";
            txtDoctorSignature.Size = new Size(400, 27);
            txtDoctorSignature.TabIndex = 1;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 11F);
            lblDate.Location = new Point(620, 30);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(44, 20);
            lblDate.TabIndex = 2;
            lblDate.Text = "Date:";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(30, 1303);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(520, 55);
            btnSave.TabIndex = 9;
            btnSave.Text = "💾 SAVE MEDICAL RECORD";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(560, 1303);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(510, 55);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "❌ CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // lblAdditionalComments
            // 
            lblAdditionalComments.Location = new Point(0, 0);
            lblAdditionalComments.Name = "lblAdditionalComments";
            lblAdditionalComments.Size = new Size(100, 23);
            lblAdditionalComments.TabIndex = 0;
            lblAdditionalComments.Visible = false;
            // 
            // chkReligiousCultural
            // 
            chkReligiousCultural.Location = new Point(0, 0);
            chkReligiousCultural.Name = "chkReligiousCultural";
            chkReligiousCultural.Size = new Size(104, 24);
            chkReligiousCultural.TabIndex = 0;
            chkReligiousCultural.Visible = false;
            // 
            // MedicalRecordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1120, 1061);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(panelSignature);
            Controls.Add(panelAdditional);
            Controls.Add(panelAllergies);
            Controls.Add(panelMedications);
            Controls.Add(panelSurgeries);
            Controls.Add(panelPastHistory);
            Controls.Add(panelCauseProblem);
            Controls.Add(panelCardiacSymptoms);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MedicalRecordForm";
            StartPosition = FormStartPosition.CenterParent;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCauseProblem.ResumeLayout(false);
            panelCauseProblem.PerformLayout();
            panelCardiacSymptoms.ResumeLayout(false);
            panelCardiacSymptoms.PerformLayout();
            panelPastHistory.ResumeLayout(false);
            panelPastHistory.PerformLayout();
            panelSurgeries.ResumeLayout(false);
            panelSurgeries.PerformLayout();
            panelMedications.ResumeLayout(false);
            panelMedications.PerformLayout();
            panelAllergies.ResumeLayout(false);
            panelAllergies.PerformLayout();
            panelAdditional.ResumeLayout(false);
            panelAdditional.PerformLayout();
            panelSignature.ResumeLayout(false);
            panelSignature.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Button btnSave;
        private Button btnCancel;
        private Panel panelCauseProblem;
        private Panel panelCardiacSymptoms;
        private Panel panelPastHistory;
        private Panel panelSurgeries;
        private Panel panelMedications;
        private Panel panelAllergies;
        private Panel panelAdditional;
        private Panel panelSignature;
        private CheckBox chkChestPain;
        private CheckBox chkShortBreath;
        private CheckBox chkPalpitations;
        private CheckBox chkDizziness;
        private CheckBox chkFatigue;
        private CheckBox chkSwelling;
        private CheckBox chkIrregularHeartbeat;
        private CheckBox chkFainting;
        private CheckBox chkCarAccident;
        private CheckBox chkWorkInjury;
        private CheckBox chkGradualOnset;
        private CheckBox chkOther;
        private CheckBox chkBreathingProblems;
        private CheckBox chkPregnant;
        private CheckBox chkHeartProblems;
        private CheckBox chkCurrentWound;
        private CheckBox chkPacemaker;
        private CheckBox chkDiabetes;
        private CheckBox chkTumorCancer;
        private CheckBox chkAnxietyAttacks;
        private CheckBox chkSleepApnea;
        private CheckBox chkStroke;
        private CheckBox chkBoneJoint;
        private CheckBox chkKidneyProblems;
        private CheckBox chkGallbladderLiver;
        private CheckBox chkElectricalImplants;
        private CheckBox chkDepression;
        private CheckBox chkBowelBladder;
        private CheckBox chkAlcoholUse;
        private CheckBox chkDrugUse;
        private CheckBox chkSmoking;
        private CheckBox chkHeadaches;
        private CheckBox chkHighBloodPressure;
        private CheckBox chkHighCholesterol;
        private CheckBox chkNoSurgeries;
        private CheckBox chkYesSurgery;
        private CheckBox chkNoMedication;
        private CheckBox chkNoKnownAllergies;
        private CheckBox chkLatexAllergy, chkIodineAllergy, chkBromineAllergy;
        private CheckBox chkReligiousCultural;
        private TextBox txtOtherCause;
        private TextBox txtProblemStarted;
        private TextBox txtSurgeryDetails;
        private TextBox txtMedications;
        private TextBox txtOtherAllergies;
        private TextBox txtAdditionalComments;
        private TextBox txtDoctorSignature;
        private Label lblCauseProblem;
        private Label lblCardiacSymptoms;
        private Label lblProblemStarted;
        private Label lblPastHistory;
        private Label lblSurgeries;
        private Label lblMedications;
        private Label lblAllergies;
        private Label lblOtherAllergies;
        private Label lblDoctorsNotes;
        private Label lblAdditionalComments;
        private Label lblSignature;
        private Label lblDate;
    }
}