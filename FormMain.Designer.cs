namespace RSA_Keys
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            btnGenerateLicense = new Button();
            lblUserID = new Label();
            lblExpirationDate = new Label();
            txtUserId = new TextBox();
            txtExpirationDate = new TextBox();
            txtKeysDirectory = new TextBox();
            lblKeysDirectory = new Label();
            lstKeys = new ListBox();
            lstLicenses = new ListBox();
            lblLicenses = new Label();
            lblKeys = new Label();
            txtLicensesDirectory = new TextBox();
            lblLicensesDirectory = new Label();
            btnSaveAndApplyDirectories = new Button();
            lblDirectorySaveStatus = new Label();
            btnOpenKeysDirectory = new Button();
            btnOpenLicensesDirectory = new Button();
            pnlDirectories = new Panel();
            btnChangeLicensesDirectory = new Button();
            btnChangeKeyDirectory = new Button();
            btnOpenRootDirectory = new Button();
            txtKeyName = new TextBox();
            label5 = new Label();
            btnGenerateKeyPair = new Button();
            label6 = new Label();
            picLogo = new PictureBox();
            label7 = new Label();
            cboKeyLenght = new ComboBox();
            lblKeysGenerated = new Label();
            txtNumberOfKeyPairGenerations = new TextBox();
            label8 = new Label();
            btnGenerateKeysAndLicenses = new Button();
            chkUseKeyBitLenghtOnKeyName = new CheckBox();
            lblLicensesGenerated = new Label();
            lblVersionLabel = new Label();
            txtNumberOfLicenseGenerations = new TextBox();
            label1 = new Label();
            pnlDirectories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // btnGenerateLicense
            // 
            btnGenerateLicense.Enabled = false;
            btnGenerateLicense.Location = new Point(357, 143);
            btnGenerateLicense.Name = "btnGenerateLicense";
            btnGenerateLicense.Size = new Size(107, 23);
            btnGenerateLicense.TabIndex = 8;
            btnGenerateLicense.Text = "Generate License";
            btnGenerateLicense.UseVisualStyleBackColor = true;
            btnGenerateLicense.Click += btnGenerateLicense_Click;
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Location = new Point(243, 54);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(176, 15);
            lblUserID.TabIndex = 1;
            lblUserID.Text = "License User ID (12345) or Email:";
            // 
            // lblExpirationDate
            // 
            lblExpirationDate.AutoSize = true;
            lblExpirationDate.Location = new Point(355, 97);
            lblExpirationDate.Name = "lblExpirationDate";
            lblExpirationDate.Size = new Size(90, 15);
            lblExpirationDate.TabIndex = 2;
            lblExpirationDate.Text = "Expiration Date:";
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(246, 71);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(217, 23);
            txtUserId.TabIndex = 5;
            txtUserId.TextChanged += txtUserId_TextChanged;
            // 
            // txtExpirationDate
            // 
            txtExpirationDate.Enabled = false;
            txtExpirationDate.Location = new Point(358, 114);
            txtExpirationDate.MaxLength = 10;
            txtExpirationDate.Name = "txtExpirationDate";
            txtExpirationDate.Size = new Size(105, 23);
            txtExpirationDate.TabIndex = 7;
            // 
            // txtKeysDirectory
            // 
            txtKeysDirectory.Location = new Point(18, 26);
            txtKeysDirectory.Name = "txtKeysDirectory";
            txtKeysDirectory.Size = new Size(298, 23);
            txtKeysDirectory.TabIndex = 21;
            txtKeysDirectory.TextChanged += txtKeysDirectory_TextChanged;
            // 
            // lblKeysDirectory
            // 
            lblKeysDirectory.AutoSize = true;
            lblKeysDirectory.Location = new Point(15, 9);
            lblKeysDirectory.Name = "lblKeysDirectory";
            lblKeysDirectory.Size = new Size(85, 15);
            lblKeysDirectory.TabIndex = 5;
            lblKeysDirectory.Text = "Keys Directory:";
            // 
            // lstKeys
            // 
            lstKeys.FormattingEnabled = true;
            lstKeys.Location = new Point(21, 194);
            lstKeys.Name = "lstKeys";
            lstKeys.Size = new Size(217, 274);
            lstKeys.TabIndex = 10;
            lstKeys.SelectedIndexChanged += lstKeys_SelectedIndexChanged;
            lstKeys.Enter += lstKeys_Enter;
            // 
            // lstLicenses
            // 
            lstLicenses.FormattingEnabled = true;
            lstLicenses.Location = new Point(246, 194);
            lstLicenses.Name = "lstLicenses";
            lstLicenses.Size = new Size(217, 274);
            lstLicenses.TabIndex = 11;
            lstLicenses.SelectedIndexChanged += lstLicenses_SelectedIndexChanged;
            lstLicenses.Enter += lstLicenses_Enter;
            // 
            // lblLicenses
            // 
            lblLicenses.AutoSize = true;
            lblLicenses.Location = new Point(243, 177);
            lblLicenses.Name = "lblLicenses";
            lblLicenses.Size = new Size(55, 15);
            lblLicenses.TabIndex = 8;
            lblLicenses.Text = "Licences:";
            // 
            // lblKeys
            // 
            lblKeys.AutoSize = true;
            lblKeys.Location = new Point(18, 177);
            lblKeys.Name = "lblKeys";
            lblKeys.Size = new Size(34, 15);
            lblKeys.TabIndex = 9;
            lblKeys.Text = "Keys:";
            // 
            // txtLicensesDirectory
            // 
            txtLicensesDirectory.Location = new Point(18, 70);
            txtLicensesDirectory.Name = "txtLicensesDirectory";
            txtLicensesDirectory.Size = new Size(298, 23);
            txtLicensesDirectory.TabIndex = 24;
            txtLicensesDirectory.TextChanged += txtLicensesDirectory_TextChanged;
            // 
            // lblLicensesDirectory
            // 
            lblLicensesDirectory.AutoSize = true;
            lblLicensesDirectory.Location = new Point(15, 53);
            lblLicensesDirectory.Name = "lblLicensesDirectory";
            lblLicensesDirectory.Size = new Size(105, 15);
            lblLicensesDirectory.TabIndex = 11;
            lblLicensesDirectory.Text = "Licenses Directory:";
            // 
            // btnSaveAndApplyDirectories
            // 
            btnSaveAndApplyDirectories.Location = new Point(17, 99);
            btnSaveAndApplyDirectories.Name = "btnSaveAndApplyDirectories";
            btnSaveAndApplyDirectories.Size = new Size(300, 23);
            btnSaveAndApplyDirectories.TabIndex = 27;
            btnSaveAndApplyDirectories.Text = "Save and Update Directories";
            btnSaveAndApplyDirectories.UseVisualStyleBackColor = true;
            btnSaveAndApplyDirectories.Click += btnSaveAndApplyDirectories_Click;
            // 
            // lblDirectorySaveStatus
            // 
            lblDirectorySaveStatus.ForeColor = Color.RoyalBlue;
            lblDirectorySaveStatus.Location = new Point(124, 10);
            lblDirectorySaveStatus.Name = "lblDirectorySaveStatus";
            lblDirectorySaveStatus.Size = new Size(195, 15);
            lblDirectorySaveStatus.TabIndex = 13;
            lblDirectorySaveStatus.Text = "Directories saved and applied.";
            lblDirectorySaveStatus.TextAlign = ContentAlignment.MiddleRight;
            lblDirectorySaveStatus.Visible = false;
            // 
            // btnOpenKeysDirectory
            // 
            btnOpenKeysDirectory.Location = new Point(394, 26);
            btnOpenKeysDirectory.Name = "btnOpenKeysDirectory";
            btnOpenKeysDirectory.Size = new Size(67, 23);
            btnOpenKeysDirectory.TabIndex = 23;
            btnOpenKeysDirectory.Text = "Open";
            btnOpenKeysDirectory.UseVisualStyleBackColor = true;
            btnOpenKeysDirectory.Click += btnOpenKeysDirectory_Click;
            // 
            // btnOpenLicensesDirectory
            // 
            btnOpenLicensesDirectory.Location = new Point(394, 70);
            btnOpenLicensesDirectory.Name = "btnOpenLicensesDirectory";
            btnOpenLicensesDirectory.Size = new Size(67, 23);
            btnOpenLicensesDirectory.TabIndex = 26;
            btnOpenLicensesDirectory.Text = "Open";
            btnOpenLicensesDirectory.UseVisualStyleBackColor = true;
            btnOpenLicensesDirectory.Click += btnOpenLicensesDirectory_Click;
            // 
            // pnlDirectories
            // 
            pnlDirectories.Controls.Add(btnChangeLicensesDirectory);
            pnlDirectories.Controls.Add(btnChangeKeyDirectory);
            pnlDirectories.Controls.Add(btnOpenRootDirectory);
            pnlDirectories.Controls.Add(txtKeysDirectory);
            pnlDirectories.Controls.Add(btnOpenLicensesDirectory);
            pnlDirectories.Controls.Add(lblKeysDirectory);
            pnlDirectories.Controls.Add(btnOpenKeysDirectory);
            pnlDirectories.Controls.Add(lblLicensesDirectory);
            pnlDirectories.Controls.Add(lblDirectorySaveStatus);
            pnlDirectories.Controls.Add(txtLicensesDirectory);
            pnlDirectories.Controls.Add(btnSaveAndApplyDirectories);
            pnlDirectories.Location = new Point(3, 468);
            pnlDirectories.Name = "pnlDirectories";
            pnlDirectories.Size = new Size(480, 131);
            pnlDirectories.TabIndex = 20;
            // 
            // btnChangeLicensesDirectory
            // 
            btnChangeLicensesDirectory.Location = new Point(322, 70);
            btnChangeLicensesDirectory.Name = "btnChangeLicensesDirectory";
            btnChangeLicensesDirectory.Size = new Size(67, 23);
            btnChangeLicensesDirectory.TabIndex = 25;
            btnChangeLicensesDirectory.Text = "Change";
            btnChangeLicensesDirectory.UseVisualStyleBackColor = true;
            btnChangeLicensesDirectory.Click += btnChangeLicensesDirectory_Click;
            // 
            // btnChangeKeyDirectory
            // 
            btnChangeKeyDirectory.Location = new Point(322, 26);
            btnChangeKeyDirectory.Name = "btnChangeKeyDirectory";
            btnChangeKeyDirectory.Size = new Size(67, 23);
            btnChangeKeyDirectory.TabIndex = 22;
            btnChangeKeyDirectory.Text = "Change";
            btnChangeKeyDirectory.UseVisualStyleBackColor = true;
            btnChangeKeyDirectory.Click += btnChangeKeyDirectory_Click;
            // 
            // btnOpenRootDirectory
            // 
            btnOpenRootDirectory.Location = new Point(322, 99);
            btnOpenRootDirectory.Name = "btnOpenRootDirectory";
            btnOpenRootDirectory.Size = new Size(139, 23);
            btnOpenRootDirectory.TabIndex = 28;
            btnOpenRootDirectory.Text = "Open Root";
            btnOpenRootDirectory.UseVisualStyleBackColor = true;
            btnOpenRootDirectory.Click += btnOpenRootDirectory_Click;
            // 
            // txtKeyName
            // 
            txtKeyName.Location = new Point(21, 71);
            txtKeyName.Name = "txtKeyName";
            txtKeyName.Size = new Size(217, 23);
            txtKeyName.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 54);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 18;
            label5.Text = "Key Name:";
            // 
            // btnGenerateKeyPair
            // 
            btnGenerateKeyPair.Location = new Point(20, 143);
            btnGenerateKeyPair.Name = "btnGenerateKeyPair";
            btnGenerateKeyPair.Size = new Size(106, 23);
            btnGenerateKeyPair.TabIndex = 4;
            btnGenerateKeyPair.Text = "Generate Keys";
            btnGenerateKeyPair.UseVisualStyleBackColor = true;
            btnGenerateKeyPair.Click += btnGenerateKeyPair_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(59, 11);
            label6.Name = "label6";
            label6.Size = new Size(310, 37);
            label6.TabIndex = 20;
            label6.Text = "RSA - K&L Generator";
            label6.UseMnemonic = false;
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(16, 8);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(40, 40);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 21;
            picLogo.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 97);
            label7.Name = "label7";
            label7.Size = new Size(86, 15);
            label7.TabIndex = 23;
            label7.Text = "Key Bit Lenght:";
            // 
            // cboKeyLenght
            // 
            cboKeyLenght.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKeyLenght.FormattingEnabled = true;
            cboKeyLenght.Location = new Point(21, 114);
            cboKeyLenght.Name = "cboKeyLenght";
            cboKeyLenght.Size = new Size(104, 23);
            cboKeyLenght.TabIndex = 2;
            // 
            // lblKeysGenerated
            // 
            lblKeysGenerated.ForeColor = Color.RoyalBlue;
            lblKeysGenerated.Location = new Point(51, 177);
            lblKeysGenerated.Name = "lblKeysGenerated";
            lblKeysGenerated.Size = new Size(189, 15);
            lblKeysGenerated.TabIndex = 25;
            lblKeysGenerated.Text = "Keys Generated!";
            lblKeysGenerated.TextAlign = ContentAlignment.MiddleRight;
            lblKeysGenerated.Visible = false;
            // 
            // txtNumberOfKeyPairGenerations
            // 
            txtNumberOfKeyPairGenerations.Location = new Point(132, 114);
            txtNumberOfKeyPairGenerations.MaxLength = 4;
            txtNumberOfKeyPairGenerations.Name = "txtNumberOfKeyPairGenerations";
            txtNumberOfKeyPairGenerations.Size = new Size(105, 23);
            txtNumberOfKeyPairGenerations.TabIndex = 3;
            txtNumberOfKeyPairGenerations.TextChanged += txtNumberOfKeyPairGenerations_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(130, 97);
            label8.Name = "label8";
            label8.Size = new Size(88, 15);
            label8.TabIndex = 27;
            label8.Text = "№ of Key Gens:";
            // 
            // btnGenerateKeysAndLicenses
            // 
            btnGenerateKeysAndLicenses.Enabled = false;
            btnGenerateKeysAndLicenses.Location = new Point(131, 143);
            btnGenerateKeysAndLicenses.Name = "btnGenerateKeysAndLicenses";
            btnGenerateKeysAndLicenses.Size = new Size(221, 23);
            btnGenerateKeysAndLicenses.TabIndex = 9;
            btnGenerateKeysAndLicenses.Text = "Generate Keys and Licenses";
            btnGenerateKeysAndLicenses.UseMnemonic = false;
            btnGenerateKeysAndLicenses.UseVisualStyleBackColor = true;
            btnGenerateKeysAndLicenses.Click += btnGenerateKeysAndLicenses_Click;
            // 
            // chkUseKeyBitLenghtOnKeyName
            // 
            chkUseKeyBitLenghtOnKeyName.AutoSize = true;
            chkUseKeyBitLenghtOnKeyName.Font = new Font("Segoe UI", 7F);
            chkUseKeyBitLenghtOnKeyName.Location = new Point(100, 54);
            chkUseKeyBitLenghtOnKeyName.Name = "chkUseKeyBitLenghtOnKeyName";
            chkUseKeyBitLenghtOnKeyName.Size = new Size(142, 16);
            chkUseKeyBitLenghtOnKeyName.TabIndex = 0;
            chkUseKeyBitLenghtOnKeyName.Text = "Insert Key Bit on File Name";
            chkUseKeyBitLenghtOnKeyName.UseVisualStyleBackColor = true;
            chkUseKeyBitLenghtOnKeyName.KeyDown += chkUseKeyBitLenghtOnKeyName_KeyDown;
            // 
            // lblLicensesGenerated
            // 
            lblLicensesGenerated.ForeColor = Color.RoyalBlue;
            lblLicensesGenerated.Location = new Point(299, 177);
            lblLicensesGenerated.Name = "lblLicensesGenerated";
            lblLicensesGenerated.Size = new Size(168, 15);
            lblLicensesGenerated.TabIndex = 30;
            lblLicensesGenerated.Text = "Licenses Generated!";
            lblLicensesGenerated.TextAlign = ContentAlignment.MiddleRight;
            lblLicensesGenerated.Visible = false;
            // 
            // lblVersionLabel
            // 
            lblVersionLabel.AutoSize = true;
            lblVersionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVersionLabel.Location = new Point(364, 28);
            lblVersionLabel.Name = "lblVersionLabel";
            lblVersionLabel.Size = new Size(41, 15);
            lblVersionLabel.TabIndex = 31;
            lblVersionLabel.Text = "v1.0.1";
            lblVersionLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNumberOfLicenseGenerations
            // 
            txtNumberOfLicenseGenerations.Enabled = false;
            txtNumberOfLicenseGenerations.Location = new Point(246, 114);
            txtNumberOfLicenseGenerations.MaxLength = 4;
            txtNumberOfLicenseGenerations.Name = "txtNumberOfLicenseGenerations";
            txtNumberOfLicenseGenerations.Size = new Size(105, 23);
            txtNumberOfLicenseGenerations.TabIndex = 6;
            txtNumberOfLicenseGenerations.TextChanged += txtNumberOfLicenseGenerations_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(244, 97);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 33;
            label1.Text = "№ of Lic. Gens:";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 602);
            Controls.Add(txtNumberOfLicenseGenerations);
            Controls.Add(label1);
            Controls.Add(lblUserID);
            Controls.Add(lblVersionLabel);
            Controls.Add(lblLicensesGenerated);
            Controls.Add(btnGenerateKeysAndLicenses);
            Controls.Add(txtNumberOfKeyPairGenerations);
            Controls.Add(label8);
            Controls.Add(lblKeysGenerated);
            Controls.Add(cboKeyLenght);
            Controls.Add(label7);
            Controls.Add(picLogo);
            Controls.Add(label6);
            Controls.Add(lstKeys);
            Controls.Add(btnGenerateKeyPair);
            Controls.Add(txtKeyName);
            Controls.Add(label5);
            Controls.Add(pnlDirectories);
            Controls.Add(lblKeys);
            Controls.Add(lblLicenses);
            Controls.Add(lstLicenses);
            Controls.Add(txtExpirationDate);
            Controls.Add(txtUserId);
            Controls.Add(lblExpirationDate);
            Controls.Add(btnGenerateLicense);
            Controls.Add(chkUseKeyBitLenghtOnKeyName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RSA Keys and Licenses Generator";
            Load += FormMain_Load;
            pnlDirectories.ResumeLayout(false);
            pnlDirectories.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGenerateLicense;
        private Label lblUserID;
        private Label lblExpirationDate;
        private TextBox txtUserId;
        private TextBox txtExpirationDate;
        private TextBox txtKeysDirectory;
        private Label lblKeysDirectory;
        private ListBox lstKeys;
        private ListBox lstLicenses;
        private Label lblLicenses;
        private Label lblKeys;
        private TextBox txtLicensesDirectory;
        private Label lblLicensesDirectory;
        private Button btnSaveAndApplyDirectories;
        private Label lblDirectorySaveStatus;
        private Button btnOpenKeysDirectory;
        private Button btnOpenLicensesDirectory;
        private Panel pnlDirectories;
        private TextBox txtKeyName;
        private Label label5;
        private Button btnGenerateKeyPair;
        private Label label6;
        private PictureBox picLogo;
        private Label label7;
        private ComboBox cboKeyLenght;
        private Label lblKeysGenerated;
        private TextBox txtNumberOfKeyPairGenerations;
        private Label label8;
        private Button btnGenerateKeysAndLicenses;
        private CheckBox chkUseKeyBitLenghtOnKeyName;
        private Label lblLicensesGenerated;
        private Button btnOpenRootDirectory;
        private Button btnChangeLicensesDirectory;
        private Button btnChangeKeyDirectory;
        private Label lblVersionLabel;
        private TextBox txtNumberOfLicenseGenerations;
        private Label label1;
    }
}
