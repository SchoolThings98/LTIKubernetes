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
    public partial class Services : Form
    {
        public String ServerIP = "";
        public Services(string ip)
        {
            InitializeComponent();
            ServerIP = ip;
        }

        private void Services_Load(object sender, EventArgs e)
        {
            API api = new API();
            var namespaces = api.listNamespaces(ServerIP);
            foreach (var name in namespaces)
            {
                comboBox1.Items.Add(name["metadata"]["name"]);
            }
            comboBoxType.Items.Add("ExternalName");
            comboBoxType.Items.Add("ClusterIP");
            comboBoxType.Items.Add("NodePort");
            comboBoxType.Items.Add("LoadBalancer");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            API api = new API();
            var services = api.listServices(ServerIP, comboBox1.Text);
            foreach (var service in services)
            {
                listBox1.Items.Add(service["metadata"]["name"]);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (string.IsNullOrEmpty(textBoxName.Text) && string.IsNullOrEmpty(textBoxPortName.Text) && string.IsNullOrEmpty(textBoxPortOrg.Text) && string.IsNullOrEmpty(textBoxPortTarget.Text) && string.IsNullOrEmpty(textBoxSelName.Text))
            {
                MessageBox.Show("Um dos campos não foi preenchido");
                return;
            }
            if (!int.TryParse(textBoxPortOrg.Text, out a))
            {
                MessageBox.Show("Porto tem de ser um numero");
                return;
            }
            if (!int.TryParse(textBoxPortTarget.Text, out a))
            {
                MessageBox.Show("Porto tem de ser um numero");
                return;
            }
            API api = new API();
            var response = api.createServices(ServerIP,comboBox1.Text,textBoxName.Text,textBoxPortName.Text,Int32.Parse(textBoxPortOrg.Text), Int32.Parse(textBoxPortTarget.Text),textBoxSelName.Text,comboBoxType.Text);
            HttpStatusCode code = response.StatusCode;
            if ((int)code != 201)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Plesase select one");
                return;
            }
            API api = new API();
            var response = api.deleteServices(ServerIP,comboBox1.Text,listBox1.SelectedItem.ToString());
            HttpStatusCode code = response.StatusCode;
            if ((int)code != 200)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
        }
    }
}
