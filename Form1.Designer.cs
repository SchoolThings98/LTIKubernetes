namespace LTIProject2
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
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.buttonSetIP = new System.Windows.Forms.Button();
            this.buttonCheckNodes = new System.Windows.Forms.Button();
            this.buttonNamespaces = new System.Windows.Forms.Button();
            this.buttonDeployments = new System.Windows.Forms.Button();
            this.buttonPods = new System.Windows.Forms.Button();
            this.buttonServices = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(77, 28);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(427, 22);
            this.textBoxIP.TabIndex = 0;
            // 
            // buttonSetIP
            // 
            this.buttonSetIP.Location = new System.Drawing.Point(528, 24);
            this.buttonSetIP.Name = "buttonSetIP";
            this.buttonSetIP.Size = new System.Drawing.Size(113, 30);
            this.buttonSetIP.TabIndex = 1;
            this.buttonSetIP.Text = "OK";
            this.buttonSetIP.UseVisualStyleBackColor = true;
            this.buttonSetIP.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCheckNodes
            // 
            this.buttonCheckNodes.Location = new System.Drawing.Point(60, 110);
            this.buttonCheckNodes.Name = "buttonCheckNodes";
            this.buttonCheckNodes.Size = new System.Drawing.Size(108, 30);
            this.buttonCheckNodes.TabIndex = 2;
            this.buttonCheckNodes.Text = "Check Nodes";
            this.buttonCheckNodes.UseVisualStyleBackColor = true;
            this.buttonCheckNodes.Click += new System.EventHandler(this.buttonCheckNodes_Click);
            // 
            // buttonNamespaces
            // 
            this.buttonNamespaces.Location = new System.Drawing.Point(60, 162);
            this.buttonNamespaces.Name = "buttonNamespaces";
            this.buttonNamespaces.Size = new System.Drawing.Size(108, 31);
            this.buttonNamespaces.TabIndex = 3;
            this.buttonNamespaces.Text = "NameSpaces";
            this.buttonNamespaces.UseVisualStyleBackColor = true;
            this.buttonNamespaces.Click += new System.EventHandler(this.buttonNamespaces_Click);
            // 
            // buttonDeployments
            // 
            this.buttonDeployments.Location = new System.Drawing.Point(60, 270);
            this.buttonDeployments.Name = "buttonDeployments";
            this.buttonDeployments.Size = new System.Drawing.Size(108, 30);
            this.buttonDeployments.TabIndex = 4;
            this.buttonDeployments.Text = "Deployments";
            this.buttonDeployments.UseVisualStyleBackColor = true;
            this.buttonDeployments.Click += new System.EventHandler(this.buttonDeployments_Click);
            // 
            // buttonPods
            // 
            this.buttonPods.Location = new System.Drawing.Point(60, 219);
            this.buttonPods.Name = "buttonPods";
            this.buttonPods.Size = new System.Drawing.Size(108, 29);
            this.buttonPods.TabIndex = 5;
            this.buttonPods.Text = "Pods";
            this.buttonPods.UseVisualStyleBackColor = true;
            this.buttonPods.Click += new System.EventHandler(this.buttonPods_Click);
            // 
            // buttonServices
            // 
            this.buttonServices.Location = new System.Drawing.Point(60, 323);
            this.buttonServices.Name = "buttonServices";
            this.buttonServices.Size = new System.Drawing.Size(108, 31);
            this.buttonServices.TabIndex = 6;
            this.buttonServices.Text = "Services";
            this.buttonServices.UseVisualStyleBackColor = true;
            this.buttonServices.Click += new System.EventHandler(this.buttonServices_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(302, 122);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(177, 244);
            this.listBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(385, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Vai adicionar ao ip o porto 8080 nao e preciso colocar no ip";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nodes";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonServices);
            this.Controls.Add(this.buttonPods);
            this.Controls.Add(this.buttonDeployments);
            this.Controls.Add(this.buttonNamespaces);
            this.Controls.Add(this.buttonCheckNodes);
            this.Controls.Add(this.buttonSetIP);
            this.Controls.Add(this.textBoxIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button buttonSetIP;
        private System.Windows.Forms.Button buttonCheckNodes;
        private System.Windows.Forms.Button buttonNamespaces;
        private System.Windows.Forms.Button buttonDeployments;
        private System.Windows.Forms.Button buttonPods;
        private System.Windows.Forms.Button buttonServices;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

