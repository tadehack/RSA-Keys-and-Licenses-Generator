using RSA_Keys.Properties;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace RSA_Keys

{
    public partial class FormMain : Form
    {
        // Additional Imports: (This is being used to efficiently open explorer windows)
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ShellExecute(IntPtr hwnd,
            string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        // Constructor ----------------------------------------------------------------------------
        public FormMain()
        {
            InitializeComponent();
        }

        // Global Variables -----------------------------------------------------------------------
        string keyToGenerateLicense;
        string keyName;
        string keyLenghtName;
        int keyBitLenght;
        int numberOfKeyPairGenerations;
        int numberOfLicenseGenerations;
        bool generateKeysAndLicenses = false;
        bool keyGenerationSuccessful = false;
        bool licenseGenerationSuccessful = false;
        bool usedIntegerUserId = false;

        // Form Behavior --------------------------------------------------------------------------
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lblVersionLabel.Text = "v1.0.2";

            cboKeyLenght.Items.Add(1024);
            cboKeyLenght.Items.Add(2048);
            cboKeyLenght.Items.Add(3072);
            cboKeyLenght.Items.Add(4096);
            cboKeyLenght.Text = Settings.Default.LastKeyBit;

            txtNumberOfKeyPairGenerations.Text = "1";
            txtNumberOfLicenseGenerations.Text = "1";

            txtUserId.Text = Settings.Default.NextUserID;
            txtExpirationDate.Text = Settings.Default.LastExpirationDate;

            CheckDefaultDirectories();
            FetchKeyFiles();
            FetchLicenseFiles();

            lblDirectorySaveStatus.Visible = false;
            txtKeyName.Focus();
        }

        // Main Buttons and ListBoxes -------------------------------------------------------------
        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            if (txtUserId.Text == "")
            {
                txtExpirationDate.Enabled = false;
                btnGenerateLicense.Enabled = false;
                btnGenerateKeysAndLicenses.Enabled = false;
            }
            else
            {
                txtExpirationDate.Enabled = true;
                btnGenerateLicense.Enabled = true;
                btnGenerateKeysAndLicenses.Enabled = true;
            }

            if (!int.TryParse(txtUserId.Text, out int userIdInteger))
            {
                txtNumberOfLicenseGenerations.Text = "1";
                txtNumberOfLicenseGenerations.Enabled = false;
            }
            else
                txtNumberOfLicenseGenerations.Enabled = true;
        }

        private void txtNumberOfKeyPairGenerations_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumberOfKeyPairGenerations.Text, out numberOfKeyPairGenerations) ||
                numberOfKeyPairGenerations < 1)
            {
                txtNumberOfKeyPairGenerations.Text = "1";
            }
        }

        private void txtNumberOfLicenseGenerations_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumberOfLicenseGenerations.Text, out numberOfLicenseGenerations) ||
                numberOfLicenseGenerations < 1)
            {
                txtNumberOfLicenseGenerations.Text = "1";
            }
        }

        private void chkUseKeyBitLenghtOnKeyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkUseKeyBitLenghtOnKeyName.Checked = !chkUseKeyBitLenghtOnKeyName.Checked;
                e.Handled = true;
            }
        }

        private void btnGenerateKeyPair_Click(object sender, EventArgs e)
        {
            lblKeysGenerated.Visible = false;
            lblLicensesGenerated.Visible = false;
            Generate();

            if (keyGenerationSuccessful)
            {
                keyGenerationSuccessful = false;

                Settings.Default.LastKeyBit = cboKeyLenght.Text;
                Settings.Default.Save();

                FetchKeyFiles();
                txtKeyName.Clear();
                lblKeysGenerated.Text = $"{keyBitLenght} Bit Keys Generated!";
                txtKeyName.Focus();
            }
        }

        private void btnGenerateLicense_Click(object sender, EventArgs e)
        {
            lblKeysGenerated.Visible = false;
            lblLicensesGenerated.Visible = false;

            if (lstKeys.SelectedItem == null || string.IsNullOrWhiteSpace(lstKeys.SelectedItem.ToString()))
            {
                MessageBox.Show("No private key selected.", "License Generation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (numberOfLicenseGenerations > 1 && !int.TryParse(txtUserId.Text, out int userID))
            //{
            //    DialogResult resultGenerateLicensesWithoutUserID =
            //        MessageBox.Show("Generate all licenses with a non-integer User ID?\n\n" +
            //        "In order to randomize the licenses signatures, an integer User ID is required, " +
            //        "example: 12345.",
            //        "Non-Integer User ID Warning",
            //        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            //    if (resultGenerateLicensesWithoutUserID == DialogResult.No)
            //        return;
            //}

            // Check if the expiration date input was typed in the correct format:
            // Regex code translation: [<4 digits>-<2 digits>-<2 digits>]
            string correctDatePattern = @"^\d{4}-\d{2}-\d{2}$";
            if (!Regex.IsMatch(txtExpirationDate.Text, correctDatePattern) && txtExpirationDate.Text != "")
            {
                MessageBox.Show("The expiration date must be typed in the format <yyyy-mm-dd>.",
                    "Wrong Date Format", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtExpirationDate.Text = "2030-02-28"; // Set an example date for the user
                txtExpirationDate.Focus();
                return;
            }

            keyToGenerateLicense = lstKeys.SelectedItem.ToString();

            lblLicensesGenerated.Visible = true;

            if (numberOfLicenseGenerations > 1)
            {
                for (int licenseGenerationNumber = 1; licenseGenerationNumber <= numberOfLicenseGenerations; licenseGenerationNumber++)
                {
                    lblLicensesGenerated.Text = $"Generating Licenses... ({licenseGenerationNumber} / {numberOfLicenseGenerations})";
                    lblLicensesGenerated.Update();
                    GenerateLicense(licenseGenerationNumber);
                }
            }
            else
                GenerateLicense(1);

            if (licenseGenerationSuccessful)
            {
                licenseGenerationSuccessful = false;

                if (usedIntegerUserId)
                {
                    usedIntegerUserId = false;
                    txtUserId.Text = Settings.Default.NextUserID;
                }

                Settings.Default.LastExpirationDate = txtExpirationDate.Text;
                Settings.Default.Save();

                FetchLicenseFiles();
                lblLicensesGenerated.Text = "License Generated!";
                lblLicensesGenerated.Visible = true;
            }
        }

        private void btnGenerateKeysAndLicenses_Click(object sender, EventArgs e)
        {
            // Check if the expiration date input was typed in the correct format:
            // Regex code translation: [<4 digits>-<2 digits>-<2 digits>]
            string correctDatePattern = @"^\d{4}-\d{2}-\d{2}$";
            if (!Regex.IsMatch(txtExpirationDate.Text, correctDatePattern) && txtExpirationDate.Text != "")
            {
                MessageBox.Show("The expiration date must be typed in the format <yyyy-mm-dd>.",
                    "Wrong Date Format", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtExpirationDate.Text = "2030-02-28"; // Set an example date for the user
                txtExpirationDate.Focus();
                return;
            }

            //if (numberOfLicenseGenerations > 1 && !int.TryParse(txtUserId.Text, out int userID))
            //{
            //    DialogResult resultGenerateLicensesWithoutUserID =
            //        MessageBox.Show("Generate all licenses with a non-integer User ID?\n\n" +
            //        "In order to randomize the per-key licenses signatures, an integer User ID is required, " +
            //        "example: 12345.",
            //        "Non-Integer User ID Warning",
            //        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            //    if (resultGenerateLicensesWithoutUserID == DialogResult.No)
            //        return;
            //}

            DialogResult resultGenerateKeysAndLicenses =
                    MessageBox.Show("Proceed to generate keys and licenses?\n\n" +
                    "Make sure all of your parameters are correct:\n" +
                    $"Keys Name: {txtKeyName.Text}\n" +
                    $"Key Bits: {cboKeyLenght.Text}\n" +
                    $"No. of Key Generations: {txtNumberOfKeyPairGenerations.Text}\n\n" +
                    $"License UserID / Email: {txtUserId.Text}\n" +
                    $"No. of License Generations per Key: {txtNumberOfLicenseGenerations.Text}\n" +
                    $"Licenses Expiration Date: {txtExpirationDate.Text}",
                    "Generate Keys & Licenses",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (resultGenerateKeysAndLicenses == DialogResult.No)
                return;

            generateKeysAndLicenses = true;
            lblKeysGenerated.Visible = false;
            lblLicensesGenerated.Visible = false;
            Generate();

            if (keyGenerationSuccessful)
            {
                keyGenerationSuccessful = false;

                Settings.Default.LastKeyBit = cboKeyLenght.Text;
                Settings.Default.Save();

                FetchKeyFiles();
                txtKeyName.Clear();
                lblKeysGenerated.Text = $"{keyBitLenght} Bit Keys Generated!";
                txtKeyName.Focus();
            }

            if (licenseGenerationSuccessful)
            {
                licenseGenerationSuccessful = false;

                if (usedIntegerUserId)
                {
                    usedIntegerUserId = false;
                    txtUserId.Text = Settings.Default.NextUserID;
                }
                
                Settings.Default.LastExpirationDate = txtExpirationDate.Text;
                Settings.Default.Save();

                FetchLicenseFiles();
                
                lblLicensesGenerated.Text = "Licenses Generated!";
                lblLicensesGenerated.Visible = true;
            }
        }

        private void lstKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDirectorySaveStatus.Visible = false;
            lblKeysGenerated.Visible = false;
        }

        private void lstLicenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDirectorySaveStatus.Visible = false;
            lblLicensesGenerated.Visible = false;
        }

        private void lstKeys_Enter(object sender, EventArgs e)
        {
            lstLicenses.ClearSelected();
        }

        private void lstLicenses_Enter(object sender, EventArgs e)
        {
            lstKeys.ClearSelected();
        }

        // Methods -------------------------------------------------------------------------------
        private void Generate()
        {
            // Too Many Keys Warning
            if (cboKeyLenght.Text == "1024" && numberOfKeyPairGenerations > 1023)
            {
                TooManyKeysWarning();
                if (resultTooManyKeys == DialogResult.No)
                    return;
            }
            else if (cboKeyLenght.Text == "2048" && numberOfKeyPairGenerations > 255)
            {
                TooManyKeysWarning();
                if (resultTooManyKeys == DialogResult.No)
                    return;
            }
            else if (cboKeyLenght.Text == "3072" && numberOfKeyPairGenerations > 63)
            {
                TooManyKeysWarning();
                if (resultTooManyKeys == DialogResult.No)
                    return;
            }
            else if (cboKeyLenght.Text == "4096" && numberOfKeyPairGenerations > 31)
            {
                TooManyKeysWarning();
                if (resultTooManyKeys == DialogResult.No)
                    return;
            }

            if (txtKeyName.Text == "")
                keyName = "key";
            else
                keyName = txtKeyName.Text;

            if (chkUseKeyBitLenghtOnKeyName.Checked)
                keyLenghtName = $"-{cboKeyLenght.Text}";
            else
                keyLenghtName = null;

            lblKeysGenerated.Text = "Generating Keys Pair...";
            lblKeysGenerated.Visible = true;
            lblKeysGenerated.Update();

            if (numberOfKeyPairGenerations == 1)
            {
                GenerateKeyPair(1);

                if (generateKeysAndLicenses)
                {
                    if (numberOfLicenseGenerations > 1)
                    {
                        for (int licenseGenerationNumber = 1; licenseGenerationNumber <= numberOfLicenseGenerations; licenseGenerationNumber++)
                        {
                            lblLicensesGenerated.Text = $"Generating Licenses... ({licenseGenerationNumber} / {numberOfLicenseGenerations})";
                            lblKeysGenerated.Update();
                            GenerateLicense(licenseGenerationNumber);
                        }
                    }
                    else
                        GenerateLicense(1);
                }
            }
            else
            {
                // Separating the loops here for better performance
                if (generateKeysAndLicenses)
                {
                    for (int keyGenerationNumber = 1; keyGenerationNumber <= numberOfKeyPairGenerations; keyGenerationNumber++)
                    {
                        lblKeysGenerated.Text = $"Generating Keys... ({keyGenerationNumber} / {numberOfKeyPairGenerations})";
                        lblKeysGenerated.Update();
                        GenerateKeyPair(keyGenerationNumber);

                        if (numberOfLicenseGenerations > 1)
                        {
                            for (int licenseGenerationNumber = 1; licenseGenerationNumber <= numberOfLicenseGenerations; licenseGenerationNumber++)
                            {
                                lblLicensesGenerated.Text = $"Generating Licenses... ({licenseGenerationNumber} / {numberOfLicenseGenerations})";
                                lblKeysGenerated.Update();
                                GenerateLicense(licenseGenerationNumber);
                            }
                        }
                        else
                            GenerateLicense(keyGenerationNumber);
                    }

                    generateKeysAndLicenses = false;
                }
                else // Generate Keys Only
                {
                    for (int generationNumber = 1; generationNumber <= numberOfKeyPairGenerations; generationNumber++)
                    {
                        lblKeysGenerated.Text = $"Generating Keys... ({generationNumber} / {numberOfKeyPairGenerations})";
                        lblKeysGenerated.Update();
                        GenerateKeyPair(generationNumber);
                    }
                }
            }
        }

        private void GenerateKeyPair(int generationNumber)
        {
            string privateKeyName = null;
            string publicKeyName = null;

            if (generationNumber > 1)
            {
                privateKeyName = $"private_{keyName}{keyLenghtName}-{generationNumber}.pem";
                publicKeyName = $"public_{keyName}{keyLenghtName}-{generationNumber}.pem";
            }
            else
            {
                privateKeyName = $"private_{keyName}{keyLenghtName}.pem";
                publicKeyName = $"public_{keyName}{keyLenghtName}.pem";
            }

            keyToGenerateLicense = privateKeyName;

            string privateKeyPath = Path.Combine(Settings.Default.KeysDirectory, privateKeyName);
            string publicKeyPath = Path.Combine(Settings.Default.KeysDirectory, publicKeyName);
            keyBitLenght = int.Parse(cboKeyLenght.Text);

            try
            {
                using (var rsa = RSA.Create(keyBitLenght)) // 1024, 2048, 3072, 4096
                {
                    // Private key
                    byte[] privateKeyBytes = rsa.ExportRSAPrivateKey();
                    string privateKeyFormat =
                        "-----BEGIN RSA PRIVATE KEY-----\n" +
                        $"{Convert.ToBase64String(privateKeyBytes, Base64FormattingOptions.InsertLineBreaks)}\n" +
                        "-----END RSA PRIVATE KEY-----";

                    // Public key
                    byte[] publicKeyBytes = rsa.ExportSubjectPublicKeyInfo();
                    string publicKeyFormat =
                        "-----BEGIN RSA PUBLIC KEY-----\n" +
                        $"{Convert.ToBase64String(publicKeyBytes, Base64FormattingOptions.InsertLineBreaks)}\n" +
                        "-----END RSA PUBLIC KEY-----";

                    File.WriteAllText(privateKeyPath, privateKeyFormat);
                    File.WriteAllText(publicKeyPath, publicKeyFormat);
                }

                keyGenerationSuccessful = true;
            }
            catch
            {
                MessageBox.Show("Keys directory is empty, incorrect or protected by Windows.",
                    "Keys Directory Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateLicense(int? generationNumber)
        {
            lblDirectorySaveStatus.Visible = false;

            if (Settings.Default.KeysDirectory == null || Settings.Default.KeysDirectory == "")
            {
                MessageBox.Show("Keys directory is empty.", "Keys Directory Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Settings.Default.LicensesDirectory == null || Settings.Default.LicensesDirectory == "")
            {
                MessageBox.Show("Licenses directory is empty.", "License Directory Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string privateKeyPath = Path.Combine(Settings.Default.KeysDirectory, keyToGenerateLicense);

                // Get the actual key name and use it on the license file name
                string[] splitKeyName = keyToGenerateLicense.Split(["private_", ".pem"],
                    StringSplitOptions.RemoveEmptyEntries);

                string keyActualName = splitKeyName[0];

                string licenseName;
                if (generationNumber > 1 && numberOfLicenseGenerations > 1)
                    licenseName = $"license_{keyActualName}-g{generationNumber}.lic";
                else
                    licenseName = $"license_{keyActualName}.lic";

                string licensePath = Path.Combine(Settings.Default.LicensesDirectory, licenseName);

                string userId = txtUserId.Text;
                string minimumDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                string expirationDate = txtExpirationDate.Text;

                // If using numeric UserID, increment the user-typed UserID per license
                if (int.TryParse(userId, out int userIdInteger))
                {
                    // We do a -1 here so the initial user-typed UserID is not affected on the first gen
                    userIdInteger += generationNumber - 1 ?? 0; // If the value is null, set it to 0
                    userId = userIdInteger.ToString();
                    Settings.Default.NextUserID = (userIdInteger + 1).ToString();
                    usedIntegerUserId = true;
                }

                string licenseData = $"UserID:{userId}\nSigned:{minimumDate}\nExpiration:{expirationDate}";
                byte[] encodedLicenseData = Encoding.UTF8.GetBytes(licenseData);

                string privateKey = File.ReadAllText(privateKeyPath);

                using (var rsa = RSA.Create())
                {
                    rsa.ImportFromPem(privateKey.ToCharArray());

                    byte[] signature = rsa.SignData(encodedLicenseData,
                        HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                    File.WriteAllText(licensePath,
                        $"{licenseData}\nSignature:{Convert.ToBase64String(signature)}");
                }

                licenseGenerationSuccessful = true;
            }
            catch (Exception ex)
            {
                usedIntegerUserId = false;
                MessageBox.Show("There was an error generating your license.\n" +
                    "No private RSA key was selected or the key is not in the PEM PKCS#1 format.\n\n",
                    "License Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Fetch Files -----------------------------------------------------------------------------
        private void FetchKeyFiles()
        {
            try
            {
                if (Settings.Default.KeysDirectory != null || Settings.Default.KeysDirectory != "")
                {
                    txtKeysDirectory.Text = Settings.Default.KeysDirectory;

                    lstKeys.Items.Clear();
                    string[] keyFiles = Directory.GetFiles(txtKeysDirectory.Text);

                    foreach (string keyFile in keyFiles)
                    {
                        string keyFileName = Path.GetFileName(keyFile);
                        lstKeys.Items.Add(keyFileName);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Keys directory is empty, incorrect or protected by Windows.",
                    "Keys Directory Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FetchLicenseFiles()
        {
            try
            {
                if (Settings.Default.LicensesDirectory != null || Settings.Default.LicensesDirectory != "")
                {
                    txtLicensesDirectory.Text = Settings.Default.LicensesDirectory;

                    lstLicenses.Items.Clear();
                    string[] licenseFiles = Directory.GetFiles(txtLicensesDirectory.Text);

                    foreach (string licenseFile in licenseFiles)
                    {
                        string licenseFileName = Path.GetFileName(licenseFile);
                        lstLicenses.Items.Add(licenseFileName);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Licenses directory is empty, incorrect or protected by Windows.",
                    "Licenses Directory Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Directories ----------------------------------------------------------------------------
        private void txtKeysDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtKeysDirectory.Text != Settings.Default.KeysDirectory)
            {
                lblDirectorySaveStatus.ForeColor = Color.Red;
                lblDirectorySaveStatus.Text = "Directories not saved!";
                lblDirectorySaveStatus.Visible = true;
            }
            else
                lblDirectorySaveStatus.Visible = false;
        }

        private void txtLicensesDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtKeysDirectory.Text != Settings.Default.LicensesDirectory)
            {
                lblDirectorySaveStatus.ForeColor = Color.Red;
                lblDirectorySaveStatus.Text = "Directories not saved!";
                lblDirectorySaveStatus.Visible = true;
            }
            else
                lblDirectorySaveStatus.Visible = false;
        }

        // Open Directories ---
        private void btnOpenKeysDirectory_Click(object sender, EventArgs e)
        {
            ShellExecute(IntPtr.Zero, "open", txtKeysDirectory.Text, null, null, 1);
        }

        private void btnOpenLicensesDirectory_Click(object sender, EventArgs e)
        {
            ShellExecute(IntPtr.Zero, "open", txtLicensesDirectory.Text, null, null, 1);
        }

        private void btnOpenRootDirectory_Click(object sender, EventArgs e)
        {
            ShellExecute(IntPtr.Zero, "open", Application.StartupPath, null, null, 1);
        }

        // Change Directories ---
        private void btnChangeKeyDirectory_Click(object sender, EventArgs e)
        {
            lblKeysGenerated.Visible = false;
            lblLicensesGenerated.Visible = false;

            FolderBrowserDialog folderBrowserDialog = new();
            folderBrowserDialog.ShowDialog();
            string keysDirectory = folderBrowserDialog.SelectedPath;

            if (keysDirectory != "")
                txtKeysDirectory.Text = keysDirectory;
        }

        private void btnChangeLicensesDirectory_Click(object sender, EventArgs e)
        {
            lblKeysGenerated.Visible = false;
            lblLicensesGenerated.Visible = false;

            FolderBrowserDialog folderBrowserDialog = new();
            folderBrowserDialog.ShowDialog();
            string licensesDirectory = folderBrowserDialog.SelectedPath;

            if (licensesDirectory != "")
                txtLicensesDirectory.Text = licensesDirectory;
        }

        // Save and Fetch Directories ---
        private void btnSaveAndApplyDirectories_Click(object sender, EventArgs e)
        {
            lblKeysGenerated.Visible = false;
            lblLicensesGenerated.Visible = false;

            Settings.Default.KeysDirectory = txtKeysDirectory.Text;
            Settings.Default.LicensesDirectory = txtLicensesDirectory.Text;
            Settings.Default.Save();

            FetchKeyFiles();
            FetchLicenseFiles();

            lblDirectorySaveStatus.ForeColor = Color.RoyalBlue;
            lblDirectorySaveStatus.Text = "Directories saved and aplied.";
            lblDirectorySaveStatus.Visible = true;
        }

        // Check if the default directories are in place, if not, create them
        private void CheckDefaultDirectories()
        {
            string defaultKeysDirectory = Path.Combine(Application.StartupPath, "Keys");
            string defaultLicensesDirectory = Path.Combine(Application.StartupPath, "Licenses");

            if (!Directory.Exists(defaultKeysDirectory))
            {
                Directory.CreateDirectory(defaultKeysDirectory);
                Settings.Default.KeysDirectory = defaultKeysDirectory;
                Settings.Default.Save();
            }

            if (!Directory.Exists(defaultLicensesDirectory))
            {
                Directory.CreateDirectory(defaultLicensesDirectory);
                Settings.Default.LicensesDirectory = defaultLicensesDirectory;
                Settings.Default.Save();
            }
        }

        // Message Warnings ------------------------------------------------------------------------
        private DialogResult resultTooManyKeys;
        private void TooManyKeysWarning()
        {
            resultTooManyKeys =
                MessageBox.Show($"Are you sure you want to generate " +
                $"{numberOfKeyPairGenerations} keys in the {cboKeyLenght.Text} bits lenght?\n\n" +
                "This process may take some time to complete.\n" +
                "If you'd like to cancel this operation while the keys are being generated, " +
                "you can kill the 'RSA Keys' application via Task Manager.",
                "Too Many Keys Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        // Delete Files - Methods -----------------------------------------------------------------
        private void DeleteKeyFile()
        {
            if (lstKeys.SelectedIndex != -1)
            {
                string[] splitKeyName = null;

                if (lstKeys.SelectedItem.ToString().Contains("private_"))
                {
                    splitKeyName = lstKeys.SelectedItem.ToString().Split(["private_", ".pem"],
                        StringSplitOptions.RemoveEmptyEntries);
                }
                else if (lstKeys.SelectedItem.ToString().Contains("public_"))
                {
                    splitKeyName = lstKeys.SelectedItem.ToString().Split(["public_", ".pem"],
                        StringSplitOptions.RemoveEmptyEntries);
                }
                else
                {
                    MessageBox.Show("The selected file is not an RSA key pair file",
                        "Key Pair Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string keyActualName = splitKeyName[0];

                DialogResult resultDeleteKey =
                    MessageBox.Show($"Delete [{keyActualName}] key pair?",
                    "Delete Key File", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (resultDeleteKey == DialogResult.Yes)
                {
                    string privateKeyFile = Path.Combine(Settings.Default.KeysDirectory,
                        $"private_{keyActualName}.pem");

                    string publicKeyFile = Path.Combine(Settings.Default.KeysDirectory,
                        $"public_{keyActualName}.pem");

                    if (File.Exists(privateKeyFile))
                        File.Delete(privateKeyFile);

                    if (File.Exists(publicKeyFile))
                        File.Delete(publicKeyFile);

                    FetchKeyFiles();

                    MessageBox.Show($"[{keyActualName}] key pair deleted.",
                        "Key Pair Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (lstKeys.Items.Count > 0)
                        lstKeys.SelectedIndex = 0;
                }
            }
        }

        private void DeleteLicenseFile()
        {
            if (lstLicenses.SelectedIndex != -1)
            {
                string licenseName = lstLicenses.SelectedItem.ToString();

                DialogResult resultDeleteLicense =
                    MessageBox.Show($"Delete [{licenseName}] ?",
                    "Delete License File", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (resultDeleteLicense == DialogResult.Yes)
                {
                    string licenseFile = Path.Combine(Settings.Default.LicensesDirectory, licenseName);

                    if (File.Exists(licenseFile))
                        File.Delete(licenseFile);

                    FetchLicenseFiles();

                    MessageBox.Show($"[{licenseName}] was deleted.",
                        "license Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (lstLicenses.Items.Count > 0)
                        lstLicenses.SelectedIndex = 0;
                }
            }
        }

        private void DeleteAllFiles()
        {
            string[] files = null;
            string keyOrLicense = null;

            if (lstKeys.Focused)
            {
                if (!Directory.Exists(Settings.Default.KeysDirectory))
                {
                    MessageBox.Show($"The directory:\n{Settings.Default.KeysDirectory}\ndoes not exist or " +
                        "can't be accessed.", "Wrong Key Directory Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                keyOrLicense = "Key";
                files = Directory.GetFiles(Settings.Default.KeysDirectory);
            }
            else if (lstLicenses.Focused)
            {
                if (!Directory.Exists(Settings.Default.LicensesDirectory))
                {
                    MessageBox.Show($"The directory:\n{Settings.Default.LicensesDirectory}\ndoes not exist or " +
                        "can't be accessed.", "Wrong Licenses Directory Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                keyOrLicense = "License";
                files = Directory.GetFiles(Settings.Default.LicensesDirectory);
            }

            DialogResult resultDeleteAllFiles =
                    MessageBox.Show($"Are you sure you want to delete ALL {keyOrLicense} files?",
                    $"Delete ALL {keyOrLicense} Files", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

            if (resultDeleteAllFiles == DialogResult.No)
                return;

            foreach (string file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch { }
            }

            if (keyOrLicense == "Key")
                FetchKeyFiles();
            else
                FetchLicenseFiles();

            MessageBox.Show($"All {keyOrLicense} files have been deleted.",
                $"All {keyOrLicense} Files Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Keyboard Shortcuts ----------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Delete Key Pair or License
            if (keyData == Keys.Delete)
            {
                if (lstKeys.Focused)
                    DeleteKeyFile();
                else if (lstLicenses.Focused)
                    DeleteLicenseFile();
            }

            // Delete ALL Key Pairs or Licenses
            if (keyData == (Keys.Shift | Keys.Delete))
                DeleteAllFiles();

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
