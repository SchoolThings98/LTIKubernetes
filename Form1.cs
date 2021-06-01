using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTIProject2
{
    public partial class Form1 : Form
    {
        public String ServerIP = "";
        public Form1()
        {
            InitializeComponent();
            buttonCheckNodes.Hide();
            buttonDeployments.Hide();
            buttonNamespaces.Hide();
            buttonPods.Hide();
            buttonServices.Hide();
            listBox1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxIP.Text))
            {
                MessageBox.Show("Inserir ip");
                return;
            }
            /*string pattern = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";
            if (!Regex.IsMatch(textBoxIP.Text, pattern))
            {
                MessageBox.Show("Insira um IP");
                return;
            }*/

            ServerIP = textBoxIP.Text+":8080";
            buttonCheckNodes.Show();
            buttonDeployments.Show();
            buttonNamespaces.Show();
            buttonPods.Show();
            buttonServices.Show();
            listBox1.Show();
            API api = new API();
            var nodes = api.listNodes(ServerIP);
            foreach (var node in nodes)
            {
                listBox1.Items.Add(node["metadata"]["name"]);
            }
        }

        private void buttonCheckNodes_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(ServerIP);
            listBox1.Items.Clear();
            API api = new API();
            var nodes = api.listNodes(ServerIP);
            foreach(var node in nodes)
            {
                listBox1.Items.Add(node["metadata"]["name"]);
            }
        }

        private void buttonNamespaces_Click(object sender, EventArgs e)
        {
            Namespaces namespaces = new Namespaces(ServerIP);
            namespaces.ShowDialog();
        }

        private void buttonPods_Click(object sender, EventArgs e)
        {
            Pods pods = new Pods(ServerIP);
            pods.ShowDialog();
        }

        private void buttonDeployments_Click(object sender, EventArgs e)
        {
            Deployments deployments = new Deployments(ServerIP);
            deployments.ShowDialog();
        }

        private void buttonServices_Click(object sender, EventArgs e)
        {
            Services services = new Services(ServerIP);
            services.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormOneAction formOneAction = new FormOneAction(ServerIP);
            formOneAction.ShowDialog();
        }
    }
}
