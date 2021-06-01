using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTIProject2
{
    public partial class Deployments : Form
    {
        public String ServerIP = "";
        public Deployments(string ip)
        {
            InitializeComponent();
            ServerIP = ip;
        }

        private void Deployments_Load(object sender, EventArgs e)
        {
            API api = new API();
            var namespaces = api.listNamespaces(ServerIP);
            foreach (var name in namespaces)
            {
                comboBox1.Items.Add(name["metadata"]["name"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            API api = new API();
            var deployments = api.listDeployments(ServerIP,comboBox1.Text);
            foreach (var deploy in deployments)
            {
                listBox1.Items.Add(deploy["metadata"]["name"]);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            int a=0;
            if(string.IsNullOrEmpty(textBoxName.Text) && string.IsNullOrEmpty(textBoxLabel.Text) && string.IsNullOrEmpty(textBoxReplicas.Text) && string.IsNullOrEmpty(textBoxMLabel.Text) && string.IsNullOrEmpty(textBoxCName.Text) && string.IsNullOrEmpty(textBoxCImage.Text) && string.IsNullOrEmpty(textBoxPort.Text))
            {
                MessageBox.Show("Um dos campos não foi preenchido");
                return;
            }
            if(!int.TryParse(textBoxPort.Text, out a)){
                MessageBox.Show("Porto tem de ser um numero");
                return;
            }
            if (!int.TryParse(textBoxReplicas.Text, out a))
            {
                MessageBox.Show("Replicas tem de ser um numero");
                return;
            }
            API api = new API();
            var response = api.createDeployments(ServerIP, comboBox1.Text, textBoxName.Text, textBoxLabel.Text, Int32.Parse(textBoxReplicas.Text), textBoxMLabel.Text, textBoxCName.Text, textBoxCImage.Text, Int32.Parse(textBoxPort.Text));
            HttpStatusCode code = response.StatusCode;
            if ((int)code != 201)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Plesase select one");
                return;
            }
            API api = new API();
            var response = api.deleteDeployments(ServerIP,comboBox1.Text,listBox1.SelectedItem.ToString());
            HttpStatusCode code = response.StatusCode;
            if ((int)code != 200)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
        }
    }
}
