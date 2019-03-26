namespace ei.si.worksheet5
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
            this.textBoxDataToHash = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMD5ComputeHash = new System.Windows.Forms.Button();
            this.buttonSHA1ComputeHash = new System.Windows.Forms.Button();
            this.buttonSHA256ComputeHash = new System.Windows.Forms.Button();
            this.buttonSHA512ComputeHash = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHashBytes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxDataToHash
            // 
            this.textBoxDataToHash.Location = new System.Drawing.Point(12, 28);
            this.textBoxDataToHash.Multiline = true;
            this.textBoxDataToHash.Name = "textBoxDataToHash";
            this.textBoxDataToHash.Size = new System.Drawing.Size(558, 46);
            this.textBoxDataToHash.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data to comput Hash";
            // 
            // buttonMD5ComputeHash
            // 
            this.buttonMD5ComputeHash.Location = new System.Drawing.Point(12, 80);
            this.buttonMD5ComputeHash.Name = "buttonMD5ComputeHash";
            this.buttonMD5ComputeHash.Size = new System.Drawing.Size(135, 23);
            this.buttonMD5ComputeHash.TabIndex = 2;
            this.buttonMD5ComputeHash.Text = "MD5 Compute Hash";
            this.buttonMD5ComputeHash.UseVisualStyleBackColor = true;
            this.buttonMD5ComputeHash.Click += new System.EventHandler(this.ButtonMD5ComputeHash_Click);
            // 
            // buttonSHA1ComputeHash
            // 
            this.buttonSHA1ComputeHash.Location = new System.Drawing.Point(153, 80);
            this.buttonSHA1ComputeHash.Name = "buttonSHA1ComputeHash";
            this.buttonSHA1ComputeHash.Size = new System.Drawing.Size(135, 23);
            this.buttonSHA1ComputeHash.TabIndex = 3;
            this.buttonSHA1ComputeHash.Text = "SHA1 Compute Hash";
            this.buttonSHA1ComputeHash.UseVisualStyleBackColor = true;
            this.buttonSHA1ComputeHash.Click += new System.EventHandler(this.ButtonSHA1ComputeHash_Click);
            // 
            // buttonSHA256ComputeHash
            // 
            this.buttonSHA256ComputeHash.Location = new System.Drawing.Point(294, 80);
            this.buttonSHA256ComputeHash.Name = "buttonSHA256ComputeHash";
            this.buttonSHA256ComputeHash.Size = new System.Drawing.Size(135, 23);
            this.buttonSHA256ComputeHash.TabIndex = 4;
            this.buttonSHA256ComputeHash.Text = "SHA256 Compute Hash";
            this.buttonSHA256ComputeHash.UseVisualStyleBackColor = true;
            this.buttonSHA256ComputeHash.Click += new System.EventHandler(this.ButtonSHA256ComputeHash_Click);
            // 
            // buttonSHA512ComputeHash
            // 
            this.buttonSHA512ComputeHash.Location = new System.Drawing.Point(435, 80);
            this.buttonSHA512ComputeHash.Name = "buttonSHA512ComputeHash";
            this.buttonSHA512ComputeHash.Size = new System.Drawing.Size(135, 23);
            this.buttonSHA512ComputeHash.TabIndex = 5;
            this.buttonSHA512ComputeHash.Text = "SHA512 Compute Hash";
            this.buttonSHA512ComputeHash.UseVisualStyleBackColor = true;
            this.buttonSHA512ComputeHash.Click += new System.EventHandler(this.ButtonSHA512ComputeHash_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hash Bytes (HEX)";
            // 
            // textBoxHashBytes
            // 
            this.textBoxHashBytes.Location = new System.Drawing.Point(12, 137);
            this.textBoxHashBytes.Multiline = true;
            this.textBoxHashBytes.Name = "textBoxHashBytes";
            this.textBoxHashBytes.Size = new System.Drawing.Size(558, 112);
            this.textBoxHashBytes.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 259);
            this.Controls.Add(this.textBoxHashBytes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSHA512ComputeHash);
            this.Controls.Add(this.buttonSHA256ComputeHash);
            this.Controls.Add(this.buttonSHA1ComputeHash);
            this.Controls.Add(this.buttonMD5ComputeHash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDataToHash);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Hashing Algorithms";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDataToHash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonMD5ComputeHash;
        private System.Windows.Forms.Button buttonSHA1ComputeHash;
        private System.Windows.Forms.Button buttonSHA256ComputeHash;
        private System.Windows.Forms.Button buttonSHA512ComputeHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHashBytes;
    }
}

