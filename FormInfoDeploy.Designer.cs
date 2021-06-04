namespace LTIProject2
{
    partial class FormInfoDeploy
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
            this.labelCImages = new System.Windows.Forms.Label();
            this.labelLabel = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "label";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Containers Images";
            // 
            // labelCImages
            // 
            this.labelCImages.AutoSize = true;
            this.labelCImages.Location = new System.Drawing.Point(202, 178);
            this.labelCImages.Name = "labelCImages";
            this.labelCImages.Size = new System.Drawing.Size(125, 17);
            this.labelCImages.TabIndex = 5;
            this.labelCImages.Text = "Containers Images";
            // 
            // labelLabel
            // 
            this.labelLabel.AutoSize = true;
            this.labelLabel.Location = new System.Drawing.Point(202, 111);
            this.labelLabel.Name = "labelLabel";
            this.labelLabel.Size = new System.Drawing.Size(38, 17);
            this.labelLabel.TabIndex = 4;
            this.labelLabel.Text = "label";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(202, 52);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(43, 17);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "name";
            // 
            // FormInfoDeploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelCImages);
            this.Controls.Add(this.labelLabel);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormInfoDeploy";
            this.Text = "FormInfoDeploy";
            this.Load += new System.EventHandler(this.FormInfoDeploy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCImages;
        private System.Windows.Forms.Label labelLabel;
        private System.Windows.Forms.Label labelName;
    }
}