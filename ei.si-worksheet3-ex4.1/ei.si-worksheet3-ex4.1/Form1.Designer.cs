namespace ei_si_worksheet3
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTextToEncrypt = new System.Windows.Forms.TextBox();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textboxEncryptedText = new System.Windows.Forms.TextBox();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDecryptedText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxAlgorithm = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text to Encrypt";
            // 
            // textBoxTextToEncrypt
            // 
            this.textBoxTextToEncrypt.Location = new System.Drawing.Point(16, 30);
            this.textBoxTextToEncrypt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxTextToEncrypt.Name = "textBoxTextToEncrypt";
            this.textBoxTextToEncrypt.Size = new System.Drawing.Size(276, 20);
            this.textBoxTextToEncrypt.TabIndex = 1;
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(185, 56);
            this.buttonEncrypt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(107, 23);
            this.buttonEncrypt.TabIndex = 2;
            this.buttonEncrypt.Text = " Encrypt";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.ButtonEncrypt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Encrypted Text (Base64)";
            // 
            // textboxEncryptedText
            // 
            this.textboxEncryptedText.Location = new System.Drawing.Point(16, 126);
            this.textboxEncryptedText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textboxEncryptedText.Multiline = true;
            this.textboxEncryptedText.Name = "textboxEncryptedText";
            this.textboxEncryptedText.Size = new System.Drawing.Size(276, 94);
            this.textboxEncryptedText.TabIndex = 4;
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(98, 229);
            this.buttonDecrypt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(107, 23);
            this.buttonDecrypt.TabIndex = 5;
            this.buttonDecrypt.Text = "Decrypt";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.ButtonDecrypt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 262);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Decrypted Text";
            // 
            // textBoxDecryptedText
            // 
            this.textBoxDecryptedText.Location = new System.Drawing.Point(16, 288);
            this.textBoxDecryptedText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxDecryptedText.Name = "textBoxDecryptedText";
            this.textBoxDecryptedText.Size = new System.Drawing.Size(276, 20);
            this.textBoxDecryptedText.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Algorithm";
            // 
            // comboBoxAlgorithm
            // 
            this.comboBoxAlgorithm.FormattingEnabled = true;
            this.comboBoxAlgorithm.Items.AddRange(new object[] {
            "AES",
            "TripleDES"});
            this.comboBoxAlgorithm.Location = new System.Drawing.Point(73, 57);
            this.comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            this.comboBoxAlgorithm.Size = new System.Drawing.Size(96, 21);
            this.comboBoxAlgorithm.TabIndex = 9;
            this.comboBoxAlgorithm.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAlgorithm_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 319);
            this.Controls.Add(this.comboBoxAlgorithm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDecryptedText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.textboxEncryptedText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.textBoxTextToEncrypt);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Symmetric Algorithms";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTextToEncrypt;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textboxEncryptedText;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDecryptedText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxAlgorithm;
    }
}

