namespace LTIProject2
{
    partial class Namespaces
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
            this.listBoxNamespaces = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxNamespaces
            // 
            this.listBoxNamespaces.FormattingEnabled = true;
            this.listBoxNamespaces.ItemHeight = 16;
            this.listBoxNamespaces.Location = new System.Drawing.Point(476, 52);
            this.listBoxNamespaces.Name = "listBoxNamespaces";
            this.listBoxNamespaces.Size = new System.Drawing.Size(276, 276);
            this.listBoxNamespaces.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Namespace";
            // 
            // Namespaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxNamespaces);
            this.Name = "Namespaces";
            this.Text = "Namespaces";
            this.Load += new System.EventHandler(this.Namespaces_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxNamespaces;
        private System.Windows.Forms.Label label1;
    }
}