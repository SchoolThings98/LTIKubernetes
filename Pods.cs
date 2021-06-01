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
    public partial class Pods : Form
    {
        public String ServerIP = "";
        public Pods(string ip)
        {
            InitializeComponent();
            ServerIP = ip;
        }

        private void Pods_Load(object sender, EventArgs e)
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
            var pods = api.listPods(ServerIP, comboBox1.Text);
            foreach (var pod in pods)
            {
                listBox1.Items.Add(pod["metadata"]["name"]);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) && string.IsNullOrEmpty(textBoxLabel.Text) && string.IsNullOrEmpty(textBoxImgName.Text) && string.IsNullOrEmpty(textBoxImg.Text))
            {
                MessageBox.Show("Um dos campos não foi preenchido");
                return;
            }
            API api = new API();
            var response = api.createPods(ServerIP,comboBox1.Text,textBoxName.Text,textBoxLabel.Text,textBoxImgName.Text,textBoxImg.Text);
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
            var response = api.deletePods(ServerIP,comboBox1.Text,listBox1.SelectedItem.ToString());
            HttpStatusCode code = response.StatusCode;
            if ((int)code != 200)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
        }
    }
}
