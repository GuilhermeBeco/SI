namespace WindowsClient
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnGetUsers = new System.Windows.Forms.Button();
            this.lboxUsers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetDescription = new System.Windows.Forms.Button();
            this.txtMyDescription = new System.Windows.Forms.TextBox();
            this.btnSetDescription = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetUsersCertificate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(16, 30);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(278, 20);
            this.txtLogin.TabIndex = 1;
            this.txtLogin.Text = "si";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(16, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(278, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "123";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnGetUsers
            // 
            this.btnGetUsers.Location = new System.Drawing.Point(16, 98);
            this.btnGetUsers.Name = "btnGetUsers";
            this.btnGetUsers.Size = new System.Drawing.Size(278, 23);
            this.btnGetUsers.TabIndex = 4;
            this.btnGetUsers.Text = "Get Users";
            this.btnGetUsers.UseVisualStyleBackColor = true;
            this.btnGetUsers.Click += new System.EventHandler(this.BtnGetUsers_Click);
            // 
            // lboxUsers
            // 
            this.lboxUsers.FormattingEnabled = true;
            this.lboxUsers.Location = new System.Drawing.Point(319, 30);
            this.lboxUsers.Name = "lboxUsers";
            this.lboxUsers.Size = new System.Drawing.Size(261, 121);
            this.lboxUsers.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Users";
            // 
            // btnGetDescription
            // 
            this.btnGetDescription.Location = new System.Drawing.Point(319, 157);
            this.btnGetDescription.Name = "btnGetDescription";
            this.btnGetDescription.Size = new System.Drawing.Size(260, 23);
            this.btnGetDescription.TabIndex = 7;
            this.btnGetDescription.Text = "Get Selected User Description";
            this.btnGetDescription.UseVisualStyleBackColor = true;
            this.btnGetDescription.Click += new System.EventHandler(this.BtnGetDescription_Click);
            // 
            // txtMyDescription
            // 
            this.txtMyDescription.Location = new System.Drawing.Point(16, 193);
            this.txtMyDescription.Multiline = true;
            this.txtMyDescription.Name = "txtMyDescription";
            this.txtMyDescription.Size = new System.Drawing.Size(278, 80);
            this.txtMyDescription.TabIndex = 8;
            // 
            // btnSetDescription
            // 
            this.btnSetDescription.Location = new System.Drawing.Point(16, 279);
            this.btnSetDescription.Name = "btnSetDescription";
            this.btnSetDescription.Size = new System.Drawing.Size(278, 23);
            this.btnSetDescription.TabIndex = 9;
            this.btnSetDescription.Text = "Set My Description";
            this.btnSetDescription.UseVisualStyleBackColor = true;
            this.btnSetDescription.Click += new System.EventHandler(this.BtnSetDescription_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(319, 186);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(260, 77);
            this.txtDescription.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Description";
            // 
            // btnGetUsersCertificate
            // 
            this.btnGetUsersCertificate.Location = new System.Drawing.Point(16, 128);
            this.btnGetUsersCertificate.Name = "btnGetUsersCertificate";
            this.btnGetUsersCertificate.Size = new System.Drawing.Size(278, 23);
            this.btnGetUsersCertificate.TabIndex = 11;
            this.btnGetUsersCertificate.Text = "Get Users (Certificate)";
            this.btnGetUsersCertificate.UseVisualStyleBackColor = true;
            this.btnGetUsersCertificate.Click += new System.EventHandler(this.btnGetUsersCertificate_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 323);
            this.Controls.Add(this.btnGetUsersCertificate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSetDescription);
            this.Controls.Add(this.txtMyDescription);
            this.Controls.Add(this.btnGetDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lboxUsers);
            this.Controls.Add(this.btnGetUsers);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "WindowsClient";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnGetUsers;
        private System.Windows.Forms.ListBox lboxUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetDescription;
        private System.Windows.Forms.TextBox txtMyDescription;
        private System.Windows.Forms.Button btnSetDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetUsersCertificate;
    }
}

