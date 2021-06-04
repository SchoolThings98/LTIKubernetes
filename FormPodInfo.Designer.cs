namespace LTIProject2
{
    partial class FormPodInfo
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCImage = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelLabel = new System.Windows.Forms.Label();
            this.labelGName = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "generated name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "labels";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "container image";
            // 
            // labelCImage
            // 
            this.labelCImage.AutoSize = true;
            this.labelCImage.Location = new System.Drawing.Point(239, 200);
            this.labelCImage.Name = "labelCImage";
            this.labelCImage.Size = new System.Drawing.Size(109, 17);
            this.labelCImage.TabIndex = 9;
            this.labelCImage.Text = "container image";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(239, 243);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(48, 17);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Status";
            // 
            // labelLabel
            // 
            this.labelLabel.AutoSize = true;
            this.labelLabel.Location = new System.Drawing.Point(239, 148);
            this.labelLabel.Name = "labelLabel";
            this.labelLabel.Size = new System.Drawing.Size(45, 17);
            this.labelLabel.TabIndex = 7;
            this.labelLabel.Text = "labels";
            // 
            // labelGName
            // 
            this.labelGName.AutoSize = true;
            this.labelGName.Location = new System.Drawing.Point(239, 102);
            this.labelGName.Name = "labelGName";
            this.labelGName.Size = new System.Drawing.Size(112, 17);
            this.labelGName.TabIndex = 6;
            this.labelGName.Text = "generated name";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(239, 53);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(43, 17);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "name";
            // 
            // FormPodInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelCImage);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelLabel);
            this.Controls.Add(this.labelGName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormPodInfo";
            this.Text = "FormPodInfo";
            this.Load += new System.EventHandler(this.FormPodInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCImage;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelLabel;
        private System.Windows.Forms.Label labelGName;
        private System.Windows.Forms.Label labelName;
    }
}