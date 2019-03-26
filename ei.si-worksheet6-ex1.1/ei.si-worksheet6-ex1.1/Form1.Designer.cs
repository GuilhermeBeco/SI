namespace ei.si.worksheet6
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
            this.textBoxOriginalMessage = new System.Windows.Forms.TextBox();
            this.buttonSignHash = new System.Windows.Forms.Button();
            this.buttonSignData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMessageDigest = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDigitalSignature = new System.Windows.Forms.TextBox();
            this.buttonVerifyHash = new System.Windows.Forms.Button();
            this.buttonVerifyData = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMessageDigestBits = new System.Windows.Forms.TextBox();
            this.textBoxDigitalSignatureBits = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Original Message to be Signed";
            // 
            // textBoxOriginalMessage
            // 
            this.textBoxOriginalMessage.Location = new System.Drawing.Point(12, 29);
            this.textBoxOriginalMessage.Name = "textBoxOriginalMessage";
            this.textBoxOriginalMessage.Size = new System.Drawing.Size(552, 20);
            this.textBoxOriginalMessage.TabIndex = 1;
            // 
            // buttonSignHash
            // 
            this.buttonSignHash.Location = new System.Drawing.Point(12, 65);
            this.buttonSignHash.Name = "buttonSignHash";
            this.buttonSignHash.Size = new System.Drawing.Size(223, 23);
            this.buttonSignHash.TabIndex = 2;
            this.buttonSignHash.Text = "Sign Hash";
            this.buttonSignHash.UseVisualStyleBackColor = true;
            this.buttonSignHash.Click += new System.EventHandler(this.ButtonSignHash_Click);
            // 
            // buttonSignData
            // 
            this.buttonSignData.Location = new System.Drawing.Point(341, 65);
            this.buttonSignData.Name = "buttonSignData";
            this.buttonSignData.Size = new System.Drawing.Size(223, 23);
            this.buttonSignData.TabIndex = 3;
            this.buttonSignData.Text = "Sign Data";
            this.buttonSignData.UseVisualStyleBackColor = true;
            this.buttonSignData.Click += new System.EventHandler(this.ButtonSignData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hash Bytes of Original Message (Message Digest)";
            // 
            // textBoxMessageDigest
            // 
            this.textBoxMessageDigest.Location = new System.Drawing.Point(12, 125);
            this.textBoxMessageDigest.Multiline = true;
            this.textBoxMessageDigest.Name = "textBoxMessageDigest";
            this.textBoxMessageDigest.Size = new System.Drawing.Size(552, 87);
            this.textBoxMessageDigest.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Digital Signature (Encrypted Message Digest)";
            // 
            // textBoxDigitalSignature
            // 
            this.textBoxDigitalSignature.Location = new System.Drawing.Point(12, 256);
            this.textBoxDigitalSignature.Multiline = true;
            this.textBoxDigitalSignature.Name = "textBoxDigitalSignature";
            this.textBoxDigitalSignature.Size = new System.Drawing.Size(552, 159);
            this.textBoxDigitalSignature.TabIndex = 7;
            // 
            // buttonVerifyHash
            // 
            this.buttonVerifyHash.Location = new System.Drawing.Point(12, 430);
            this.buttonVerifyHash.Name = "buttonVerifyHash";
            this.buttonVerifyHash.Size = new System.Drawing.Size(223, 23);
            this.buttonVerifyHash.TabIndex = 8;
            this.buttonVerifyHash.Text = "Verify Hash";
            this.buttonVerifyHash.UseVisualStyleBackColor = true;
            this.buttonVerifyHash.Click += new System.EventHandler(this.ButtonVerifyHash_Click);
            // 
            // buttonVerifyData
            // 
            this.buttonVerifyData.Location = new System.Drawing.Point(341, 430);
            this.buttonVerifyData.Name = "buttonVerifyData";
            this.buttonVerifyData.Size = new System.Drawing.Size(223, 23);
            this.buttonVerifyData.TabIndex = 9;
            this.buttonVerifyData.Text = "Verify Data";
            this.buttonVerifyData.UseVisualStyleBackColor = true;
            this.buttonVerifyData.Click += new System.EventHandler(this.ButtonVerifyData_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(572, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "bits:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(572, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "bits:";
            // 
            // textBoxMessageDigestBits
            // 
            this.textBoxMessageDigestBits.Enabled = false;
            this.textBoxMessageDigestBits.Location = new System.Drawing.Point(575, 125);
            this.textBoxMessageDigestBits.Name = "textBoxMessageDigestBits";
            this.textBoxMessageDigestBits.Size = new System.Drawing.Size(37, 20);
            this.textBoxMessageDigestBits.TabIndex = 12;
            // 
            // textBoxDigitalSignatureBits
            // 
            this.textBoxDigitalSignatureBits.Enabled = false;
            this.textBoxDigitalSignatureBits.Location = new System.Drawing.Point(575, 256);
            this.textBoxDigitalSignatureBits.Name = "textBoxDigitalSignatureBits";
            this.textBoxDigitalSignatureBits.Size = new System.Drawing.Size(37, 20);
            this.textBoxDigitalSignatureBits.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 465);
            this.Controls.Add(this.textBoxDigitalSignatureBits);
            this.Controls.Add(this.textBoxMessageDigestBits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonVerifyData);
            this.Controls.Add(this.buttonVerifyHash);
            this.Controls.Add(this.textBoxDigitalSignature);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMessageDigest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSignData);
            this.Controls.Add(this.buttonSignHash);
            this.Controls.Add(this.textBoxOriginalMessage);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Digital Signature";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxOriginalMessage;
        private System.Windows.Forms.Button buttonSignHash;
        private System.Windows.Forms.Button buttonSignData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMessageDigest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDigitalSignature;
        private System.Windows.Forms.Button buttonVerifyHash;
        private System.Windows.Forms.Button buttonVerifyData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMessageDigestBits;
        private System.Windows.Forms.TextBox textBoxDigitalSignatureBits;
    }
}

