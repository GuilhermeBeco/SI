namespace ei_si_worksheet4
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonGererateKeys = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxPublicKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textboxBothKeys = new System.Windows.Forms.TextBox();
            this.buttonSavePublicKey = new System.Windows.Forms.Button();
            this.buttonSaveKeys = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.textboxSymmetricKeyDecrypted = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textboxBitSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textboxSymmetricKeyEncrtypted = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.textboxSymmentricKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGererateKeys
            // 
            this.buttonGererateKeys.Location = new System.Drawing.Point(13, 13);
            this.buttonGererateKeys.Name = "buttonGererateKeys";
            this.buttonGererateKeys.Size = new System.Drawing.Size(199, 23);
            this.buttonGererateKeys.TabIndex = 0;
            this.buttonGererateKeys.Text = "Generate Keys (Private / Public)";
            this.buttonGererateKeys.UseVisualStyleBackColor = true;
            this.buttonGererateKeys.Click += new System.EventHandler(this.ButtonGererateKeys_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Public Key";
            // 
            // textboxPublicKey
            // 
            this.textboxPublicKey.Location = new System.Drawing.Point(13, 60);
            this.textboxPublicKey.Multiline = true;
            this.textboxPublicKey.Name = "textboxPublicKey";
            this.textboxPublicKey.Size = new System.Drawing.Size(492, 53);
            this.textboxPublicKey.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Private / Public Key";
            // 
            // textboxBothKeys
            // 
            this.textboxBothKeys.Location = new System.Drawing.Point(13, 146);
            this.textboxBothKeys.Multiline = true;
            this.textboxBothKeys.Name = "textboxBothKeys";
            this.textboxBothKeys.Size = new System.Drawing.Size(492, 119);
            this.textboxBothKeys.TabIndex = 4;
            // 
            // buttonSavePublicKey
            // 
            this.buttonSavePublicKey.Location = new System.Drawing.Point(365, 31);
            this.buttonSavePublicKey.Name = "buttonSavePublicKey";
            this.buttonSavePublicKey.Size = new System.Drawing.Size(139, 23);
            this.buttonSavePublicKey.TabIndex = 5;
            this.buttonSavePublicKey.Text = "Save PublicKey.txt";
            this.buttonSavePublicKey.UseVisualStyleBackColor = true;
            this.buttonSavePublicKey.Click += new System.EventHandler(this.ButtonSavePublicKey_Click);
            // 
            // buttonSaveKeys
            // 
            this.buttonSaveKeys.Location = new System.Drawing.Point(365, 117);
            this.buttonSaveKeys.Name = "buttonSaveKeys";
            this.buttonSaveKeys.Size = new System.Drawing.Size(138, 23);
            this.buttonSaveKeys.TabIndex = 6;
            this.buttonSaveKeys.Text = "Save PrivatePublicKey.txt";
            this.buttonSaveKeys.UseVisualStyleBackColor = true;
            this.buttonSaveKeys.Click += new System.EventHandler(this.ButtonSaveKeys_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonDecrypt);
            this.panel1.Controls.Add(this.textboxSymmetricKeyDecrypted);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textboxBitSize);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textboxSymmetricKeyEncrtypted);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.buttonEncrypt);
            this.panel1.Controls.Add(this.textboxSymmentricKey);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 169);
            this.panel1.TabIndex = 7;
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(369, 129);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(116, 23);
            this.buttonDecrypt.TabIndex = 9;
            this.buttonDecrypt.Text = "Decrypt";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.ButtonDecrypt_Click);
            // 
            // textboxSymmetricKeyDecrypted
            // 
            this.textboxSymmetricKeyDecrypted.Location = new System.Drawing.Point(138, 133);
            this.textboxSymmetricKeyDecrypted.Name = "textboxSymmetricKeyDecrypted";
            this.textboxSymmetricKeyDecrypted.Size = new System.Drawing.Size(225, 20);
            this.textboxSymmetricKeyDecrypted.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Decrypted Symmetric Key";
            // 
            // textboxBitSize
            // 
            this.textboxBitSize.Location = new System.Drawing.Point(12, 92);
            this.textboxBitSize.Name = "textboxBitSize";
            this.textboxBitSize.Size = new System.Drawing.Size(100, 20);
            this.textboxBitSize.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Number of Bits";
            // 
            // textboxSymmetricKeyEncrtypted
            // 
            this.textboxSymmetricKeyEncrtypted.Location = new System.Drawing.Point(138, 39);
            this.textboxSymmetricKeyEncrtypted.Multiline = true;
            this.textboxSymmetricKeyEncrtypted.Name = "textboxSymmetricKeyEncrtypted";
            this.textboxSymmetricKeyEncrtypted.Size = new System.Drawing.Size(348, 74);
            this.textboxSymmetricKeyEncrtypted.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Encrypted Symmetric Key";
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(369, 7);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(117, 23);
            this.buttonEncrypt.TabIndex = 2;
            this.buttonEncrypt.Text = "Encrypt";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.ButtonEncrypt_Click);
            // 
            // textboxSymmentricKey
            // 
            this.textboxSymmentricKey.Location = new System.Drawing.Point(138, 9);
            this.textboxSymmentricKey.Name = "textboxSymmentricKey";
            this.textboxSymmentricKey.Size = new System.Drawing.Size(225, 20);
            this.textboxSymmentricKey.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Symmetric Key to Encrypt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 452);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonSaveKeys);
            this.Controls.Add(this.buttonSavePublicKey);
            this.Controls.Add(this.textboxBothKeys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textboxPublicKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGererateKeys);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Assymetric Algorithms";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGererateKeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxPublicKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textboxBothKeys;
        private System.Windows.Forms.Button buttonSavePublicKey;
        private System.Windows.Forms.Button buttonSaveKeys;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.TextBox textboxSymmetricKeyDecrypted;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textboxBitSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textboxSymmetricKeyEncrtypted;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.TextBox textboxSymmentricKey;
        private System.Windows.Forms.Label label3;
    }
}

