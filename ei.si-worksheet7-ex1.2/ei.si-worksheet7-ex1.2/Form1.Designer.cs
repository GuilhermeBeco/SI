namespace ei.si_worksheet7
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
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonVerifyAndDecrypt = new System.Windows.Forms.Button();
            this.buttonDecryptFromStore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSignatureWithData = new System.Windows.Forms.Button();
            this.buttonDecryptFromPFX = new System.Windows.Forms.Button();
            this.buttonEncryptAndSign = new System.Windows.Forms.Button();
            this.buttonSignatureWithoutData = new System.Windows.Forms.Button();
            this.buttonEncryptWithStore = new System.Windows.Forms.Button();
            this.buttonVerifySignatureWithData = new System.Windows.Forms.Button();
            this.buttonEncryptWithCER = new System.Windows.Forms.Button();
            this.buttonVerifySignatureWithoutData = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(715, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 16);
            this.label2.TabIndex = 43;
            this.label2.Text = "->";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(715, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 16);
            this.label3.TabIndex = 44;
            this.label3.Text = "->";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "->";
            // 
            // buttonVerifyAndDecrypt
            // 
            this.buttonVerifyAndDecrypt.Location = new System.Drawing.Point(511, 114);
            this.buttonVerifyAndDecrypt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonVerifyAndDecrypt.Name = "buttonVerifyAndDecrypt";
            this.buttonVerifyAndDecrypt.Size = new System.Drawing.Size(188, 33);
            this.buttonVerifyAndDecrypt.TabIndex = 39;
            this.buttonVerifyAndDecrypt.Text = "[Extra] Verify and Decrypt";
            this.buttonVerifyAndDecrypt.UseVisualStyleBackColor = true;
            this.buttonVerifyAndDecrypt.Click += new System.EventHandler(this.ButtonVerifyAndDecrypt_Click);
            // 
            // buttonDecryptFromStore
            // 
            this.buttonDecryptFromStore.Location = new System.Drawing.Point(752, 60);
            this.buttonDecryptFromStore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDecryptFromStore.Name = "buttonDecryptFromStore";
            this.buttonDecryptFromStore.Size = new System.Drawing.Size(188, 33);
            this.buttonDecryptFromStore.TabIndex = 40;
            this.buttonDecryptFromStore.Text = "8) Decrypt (Store)";
            this.buttonDecryptFromStore.UseVisualStyleBackColor = true;
            this.buttonDecryptFromStore.Click += new System.EventHandler(this.ButtonDecryptFromStore_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 16);
            this.label1.TabIndex = 41;
            this.label1.Text = "->";
            // 
            // buttonSignatureWithData
            // 
            this.buttonSignatureWithData.Location = new System.Drawing.Point(16, 17);
            this.buttonSignatureWithData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSignatureWithData.Name = "buttonSignatureWithData";
            this.buttonSignatureWithData.Size = new System.Drawing.Size(188, 33);
            this.buttonSignatureWithData.TabIndex = 31;
            this.buttonSignatureWithData.Text = "1) Sign [withData] (.pfx)";
            this.buttonSignatureWithData.UseVisualStyleBackColor = true;
            this.buttonSignatureWithData.Click += new System.EventHandler(this.ButtonSignatureWithData_Click);
            // 
            // buttonDecryptFromPFX
            // 
            this.buttonDecryptFromPFX.Location = new System.Drawing.Point(752, 15);
            this.buttonDecryptFromPFX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDecryptFromPFX.Name = "buttonDecryptFromPFX";
            this.buttonDecryptFromPFX.Size = new System.Drawing.Size(188, 33);
            this.buttonDecryptFromPFX.TabIndex = 38;
            this.buttonDecryptFromPFX.Text = "6) Decrypt (.pfx)";
            this.buttonDecryptFromPFX.UseVisualStyleBackColor = true;
            this.buttonDecryptFromPFX.Click += new System.EventHandler(this.ButtonDecryptFromPFX_Click);
            // 
            // buttonEncryptAndSign
            // 
            this.buttonEncryptAndSign.Location = new System.Drawing.Point(258, 114);
            this.buttonEncryptAndSign.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEncryptAndSign.Name = "buttonEncryptAndSign";
            this.buttonEncryptAndSign.Size = new System.Drawing.Size(187, 33);
            this.buttonEncryptAndSign.TabIndex = 36;
            this.buttonEncryptAndSign.Text = "[Extra] Encrypt and Sign";
            this.buttonEncryptAndSign.UseVisualStyleBackColor = true;
            this.buttonEncryptAndSign.Click += new System.EventHandler(this.ButtonEncryptAndSign_Click);
            // 
            // buttonSignatureWithoutData
            // 
            this.buttonSignatureWithoutData.Location = new System.Drawing.Point(16, 58);
            this.buttonSignatureWithoutData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSignatureWithoutData.Name = "buttonSignatureWithoutData";
            this.buttonSignatureWithoutData.Size = new System.Drawing.Size(188, 33);
            this.buttonSignatureWithoutData.TabIndex = 32;
            this.buttonSignatureWithoutData.Text = "3) Sign [withoutData] (Store)";
            this.buttonSignatureWithoutData.UseVisualStyleBackColor = true;
            this.buttonSignatureWithoutData.Click += new System.EventHandler(this.ButtonSignatureWithoutData_Click);
            // 
            // buttonEncryptWithStore
            // 
            this.buttonEncryptWithStore.Location = new System.Drawing.Point(511, 61);
            this.buttonEncryptWithStore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEncryptWithStore.Name = "buttonEncryptWithStore";
            this.buttonEncryptWithStore.Size = new System.Drawing.Size(188, 33);
            this.buttonEncryptWithStore.TabIndex = 37;
            this.buttonEncryptWithStore.Text = "7) Encrypt (Store)";
            this.buttonEncryptWithStore.UseVisualStyleBackColor = true;
            this.buttonEncryptWithStore.Click += new System.EventHandler(this.ButtonEncryptWithStore_Click);
            // 
            // buttonVerifySignatureWithData
            // 
            this.buttonVerifySignatureWithData.Location = new System.Drawing.Point(257, 17);
            this.buttonVerifySignatureWithData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonVerifySignatureWithData.Name = "buttonVerifySignatureWithData";
            this.buttonVerifySignatureWithData.Size = new System.Drawing.Size(188, 33);
            this.buttonVerifySignatureWithData.TabIndex = 33;
            this.buttonVerifySignatureWithData.Text = "2) Verify Signature";
            this.buttonVerifySignatureWithData.UseVisualStyleBackColor = true;
            this.buttonVerifySignatureWithData.Click += new System.EventHandler(this.ButtonVerifySignatureWithData_Click);
            // 
            // buttonEncryptWithCER
            // 
            this.buttonEncryptWithCER.Location = new System.Drawing.Point(511, 18);
            this.buttonEncryptWithCER.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEncryptWithCER.Name = "buttonEncryptWithCER";
            this.buttonEncryptWithCER.Size = new System.Drawing.Size(188, 33);
            this.buttonEncryptWithCER.TabIndex = 35;
            this.buttonEncryptWithCER.Text = "5) Encrypt (.cer)";
            this.buttonEncryptWithCER.UseVisualStyleBackColor = true;
            this.buttonEncryptWithCER.Click += new System.EventHandler(this.ButtonEncryptWithCER_Click);
            // 
            // buttonVerifySignatureWithoutData
            // 
            this.buttonVerifySignatureWithoutData.Location = new System.Drawing.Point(258, 61);
            this.buttonVerifySignatureWithoutData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonVerifySignatureWithoutData.Name = "buttonVerifySignatureWithoutData";
            this.buttonVerifySignatureWithoutData.Size = new System.Drawing.Size(187, 33);
            this.buttonVerifySignatureWithoutData.TabIndex = 34;
            this.buttonVerifySignatureWithoutData.Text = "4) Verify Signature";
            this.buttonVerifySignatureWithoutData.UseVisualStyleBackColor = true;
            this.buttonVerifySignatureWithoutData.Click += new System.EventHandler(this.ButtonVerifySignatureWithoutData_Click);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(16, 164);
            this.textBoxInfo.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInfo.Size = new System.Drawing.Size(924, 332);
            this.textBoxInfo.TabIndex = 46;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 511);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonVerifyAndDecrypt);
            this.Controls.Add(this.buttonDecryptFromStore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSignatureWithData);
            this.Controls.Add(this.buttonDecryptFromPFX);
            this.Controls.Add(this.buttonEncryptAndSign);
            this.Controls.Add(this.buttonSignatureWithoutData);
            this.Controls.Add(this.buttonEncryptWithStore);
            this.Controls.Add(this.buttonVerifySignatureWithData);
            this.Controls.Add(this.buttonEncryptWithCER);
            this.Controls.Add(this.buttonVerifySignatureWithoutData);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Using Digital Certificates";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonVerifyAndDecrypt;
        private System.Windows.Forms.Button buttonDecryptFromStore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSignatureWithData;
        private System.Windows.Forms.Button buttonDecryptFromPFX;
        private System.Windows.Forms.Button buttonEncryptAndSign;
        private System.Windows.Forms.Button buttonSignatureWithoutData;
        private System.Windows.Forms.Button buttonEncryptWithStore;
        private System.Windows.Forms.Button buttonVerifySignatureWithData;
        private System.Windows.Forms.Button buttonEncryptWithCER;
        private System.Windows.Forms.Button buttonVerifySignatureWithoutData;
        private System.Windows.Forms.TextBox textBoxInfo;
    }
}

