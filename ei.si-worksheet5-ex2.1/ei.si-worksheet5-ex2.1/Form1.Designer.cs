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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFirstInputData = new System.Windows.Forms.TextBox();
            this.textBoxNextInputData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLastInputData = new System.Windows.Forms.TextBox();
            this.buttonTransformFirstBlock = new System.Windows.Forms.Button();
            this.buttonTransformNextBlock = new System.Windows.Forms.Button();
            this.buttonTransformFinalBlock = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxHashBytes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Input Data: ";
            // 
            // textBoxFirstInputData
            // 
            this.textBoxFirstInputData.Location = new System.Drawing.Point(16, 40);
            this.textBoxFirstInputData.Name = "textBoxFirstInputData";
            this.textBoxFirstInputData.Size = new System.Drawing.Size(195, 20);
            this.textBoxFirstInputData.TabIndex = 1;
            // 
            // textBoxNextInputData
            // 
            this.textBoxNextInputData.Location = new System.Drawing.Point(235, 40);
            this.textBoxNextInputData.Name = "textBoxNextInputData";
            this.textBoxNextInputData.Size = new System.Drawing.Size(208, 20);
            this.textBoxNextInputData.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Next Input Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Input Data:";
            // 
            // textBoxLastInputData
            // 
            this.textBoxLastInputData.Location = new System.Drawing.Point(16, 119);
            this.textBoxLastInputData.Name = "textBoxLastInputData";
            this.textBoxLastInputData.Size = new System.Drawing.Size(195, 20);
            this.textBoxLastInputData.TabIndex = 5;
            // 
            // buttonTransformFirstBlock
            // 
            this.buttonTransformFirstBlock.Location = new System.Drawing.Point(16, 67);
            this.buttonTransformFirstBlock.Name = "buttonTransformFirstBlock";
            this.buttonTransformFirstBlock.Size = new System.Drawing.Size(195, 23);
            this.buttonTransformFirstBlock.TabIndex = 6;
            this.buttonTransformFirstBlock.Text = "SHA256 - TransformBlock";
            this.buttonTransformFirstBlock.UseVisualStyleBackColor = true;
            this.buttonTransformFirstBlock.Click += new System.EventHandler(this.ButtonTransformFirstBlock_Click);
            // 
            // buttonTransformNextBlock
            // 
            this.buttonTransformNextBlock.Location = new System.Drawing.Point(235, 67);
            this.buttonTransformNextBlock.Name = "buttonTransformNextBlock";
            this.buttonTransformNextBlock.Size = new System.Drawing.Size(208, 23);
            this.buttonTransformNextBlock.TabIndex = 7;
            this.buttonTransformNextBlock.Text = "SHA256 - TransformBlock";
            this.buttonTransformNextBlock.UseVisualStyleBackColor = true;
            this.buttonTransformNextBlock.Click += new System.EventHandler(this.ButtonTransformNextBlock_Click);
            // 
            // buttonTransformFinalBlock
            // 
            this.buttonTransformFinalBlock.Location = new System.Drawing.Point(16, 145);
            this.buttonTransformFinalBlock.Name = "buttonTransformFinalBlock";
            this.buttonTransformFinalBlock.Size = new System.Drawing.Size(195, 23);
            this.buttonTransformFinalBlock.TabIndex = 8;
            this.buttonTransformFinalBlock.Text = "SHA256 - TransformFinalBlock";
            this.buttonTransformFinalBlock.UseVisualStyleBackColor = true;
            this.buttonTransformFinalBlock.Click += new System.EventHandler(this.ButtonTransformFinalBlock_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hash Bytes (HEX):";
            // 
            // textBoxHashBytes
            // 
            this.textBoxHashBytes.Location = new System.Drawing.Point(235, 119);
            this.textBoxHashBytes.Multiline = true;
            this.textBoxHashBytes.Name = "textBoxHashBytes";
            this.textBoxHashBytes.Size = new System.Drawing.Size(208, 196);
            this.textBoxHashBytes.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 342);
            this.Controls.Add(this.textBoxHashBytes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonTransformFinalBlock);
            this.Controls.Add(this.buttonTransformNextBlock);
            this.Controls.Add(this.buttonTransformFirstBlock);
            this.Controls.Add(this.textBoxLastInputData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNextInputData);
            this.Controls.Add(this.textBoxFirstInputData);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Hashing Algorithms";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFirstInputData;
        private System.Windows.Forms.TextBox textBoxNextInputData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLastInputData;
        private System.Windows.Forms.Button buttonTransformFirstBlock;
        private System.Windows.Forms.Button buttonTransformNextBlock;
        private System.Windows.Forms.Button buttonTransformFinalBlock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxHashBytes;
    }
}

