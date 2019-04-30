namespace Client
{
    partial class FormClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
            this.buttonGenerateSymmetric = new System.Windows.Forms.Button();
            this.buttonGenerateAssymetric = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonShareSecretKey = new System.Windows.Forms.Button();
            this.buttonSharePublicKeys = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonConfirmIntegrity = new System.Windows.Forms.Button();
            this.buttonGetPassword = new System.Windows.Forms.Button();
            this.textBoxNumberOfCharacters = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGenerateSymmetric
            // 
            this.buttonGenerateSymmetric.Location = new System.Drawing.Point(256, 27);
            this.buttonGenerateSymmetric.Name = "buttonGenerateSymmetric";
            this.buttonGenerateSymmetric.Size = new System.Drawing.Size(220, 37);
            this.buttonGenerateSymmetric.TabIndex = 2;
            this.buttonGenerateSymmetric.Text = "2) Gerar Chave Simétrica";
            this.buttonGenerateSymmetric.UseVisualStyleBackColor = true;
            this.buttonGenerateSymmetric.Click += new System.EventHandler(this.ButtonGenerateSymmetric_Click);
            // 
            // buttonGenerateAssymetric
            // 
            this.buttonGenerateAssymetric.Location = new System.Drawing.Point(21, 27);
            this.buttonGenerateAssymetric.Name = "buttonGenerateAssymetric";
            this.buttonGenerateAssymetric.Size = new System.Drawing.Size(202, 37);
            this.buttonGenerateAssymetric.TabIndex = 3;
            this.buttonGenerateAssymetric.Text = "1) Gerar Algorithmo Assimétrico";
            this.buttonGenerateAssymetric.UseVisualStyleBackColor = true;
            this.buttonGenerateAssymetric.Click += new System.EventHandler(this.ButtonGenerateAssymetric_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonGenerateAssymetric);
            this.groupBox2.Controls.Add(this.buttonGenerateSymmetric);
            this.groupBox2.Location = new System.Drawing.Point(13, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 79);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cryptographic Algorithms";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonShareSecretKey);
            this.groupBox3.Controls.Add(this.buttonSharePublicKeys);
            this.groupBox3.Controls.Add(this.buttonConnect);
            this.groupBox3.Controls.Add(this.textBoxPort);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxIP);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(491, 100);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Share Keys";
            // 
            // buttonShareSecretKey
            // 
            this.buttonShareSecretKey.Location = new System.Drawing.Point(257, 59);
            this.buttonShareSecretKey.Name = "buttonShareSecretKey";
            this.buttonShareSecretKey.Size = new System.Drawing.Size(220, 31);
            this.buttonShareSecretKey.TabIndex = 6;
            this.buttonShareSecretKey.Text = "5) Partilhar Chave Secreta";
            this.buttonShareSecretKey.UseVisualStyleBackColor = true;
            this.buttonShareSecretKey.Click += new System.EventHandler(this.ButtonShareSecretKey_Click);
            // 
            // buttonSharePublicKeys
            // 
            this.buttonSharePublicKeys.Location = new System.Drawing.Point(60, 59);
            this.buttonSharePublicKeys.Name = "buttonSharePublicKeys";
            this.buttonSharePublicKeys.Size = new System.Drawing.Size(164, 31);
            this.buttonSharePublicKeys.TabIndex = 5;
            this.buttonSharePublicKeys.Text = "4) Partilhar Chaves Públicas";
            this.buttonSharePublicKeys.UseVisualStyleBackColor = true;
            this.buttonSharePublicKeys.Click += new System.EventHandler(this.ButtonSharePublicKeys_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(323, 15);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(154, 35);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "3) Ligar";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(230, 21);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(75, 20);
            this.textBoxPort.TabIndex = 3;
            this.textBoxPort.Text = "10000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(60, 20);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(108, 20);
            this.textBoxIP.TabIndex = 1;
            this.textBoxIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.buttonConfirmIntegrity);
            this.groupBox1.Controls.Add(this.buttonGetPassword);
            this.groupBox1.Controls.Add(this.textBoxNumberOfCharacters);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 165);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Geração de Palavras Passe";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(101, 129);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.ReadOnly = true;
            this.textBoxPassword.Size = new System.Drawing.Size(376, 20);
            this.textBoxPassword.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Password";
            // 
            // buttonConfirmIntegrity
            // 
            this.buttonConfirmIntegrity.Location = new System.Drawing.Point(279, 57);
            this.buttonConfirmIntegrity.Name = "buttonConfirmIntegrity";
            this.buttonConfirmIntegrity.Size = new System.Drawing.Size(198, 37);
            this.buttonConfirmIntegrity.TabIndex = 8;
            this.buttonConfirmIntegrity.Text = "7) Confirmar Integridade";
            this.buttonConfirmIntegrity.UseVisualStyleBackColor = true;
            this.buttonConfirmIntegrity.Click += new System.EventHandler(this.buttonConfirmIntegrity_Click);
            // 
            // buttonGetPassword
            // 
            this.buttonGetPassword.Location = new System.Drawing.Point(22, 57);
            this.buttonGetPassword.Name = "buttonGetPassword";
            this.buttonGetPassword.Size = new System.Drawing.Size(164, 37);
            this.buttonGetPassword.TabIndex = 7;
            this.buttonGetPassword.Text = "6) Obter Palavra Passe";
            this.buttonGetPassword.UseVisualStyleBackColor = true;
            this.buttonGetPassword.Click += new System.EventHandler(this.buttonGetPassword_Click);
            // 
            // textBoxNumberOfCharacters
            // 
            this.textBoxNumberOfCharacters.Location = new System.Drawing.Point(141, 21);
            this.textBoxNumberOfCharacters.Name = "textBoxNumberOfCharacters";
            this.textBoxNumberOfCharacters.Size = new System.Drawing.Size(164, 20);
            this.textBoxNumberOfCharacters.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Número de Caracteres";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 377);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SI - Teste Prático";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonGenerateSymmetric;
        private System.Windows.Forms.Button buttonGenerateAssymetric;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonShareSecretKey;
        private System.Windows.Forms.Button buttonSharePublicKeys;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonConfirmIntegrity;
        private System.Windows.Forms.Button buttonGetPassword;
        private System.Windows.Forms.TextBox textBoxNumberOfCharacters;
        private System.Windows.Forms.Label label3;
    }
}

