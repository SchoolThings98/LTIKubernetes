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
    public partial class Namespaces : Form
    {
        public String ServerIP = "";
        public Namespaces(string ip)
        {
            InitializeComponent();
            ServerIP = ip;
            
        }

        private void Namespaces_Load(object sender, EventArgs e)
        {
            API api = new API();
            var namespaces = api.listNamespaces(ServerIP);
            textBox1.Hide();
            buttonConfirm.Hide();
            buttonCancel.Hide();
            foreach (var name in namespaces)
            {
                listBoxNamespaces.Items.Add(name["metadata"]["name"]);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            textBox1.Show();
            buttonConfirm.Show();
            buttonCancel.Show();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxNamespaces.SelectedIndex == -1)
            {
                MessageBox.Show("Plesase select one");
                return;
            }
            else
            {
                API api = new API();
                
                var response =api.deleteNamespaces(ServerIP, listBoxNamespaces.SelectedItem.ToString());
                HttpStatusCode code = response.StatusCode;
                if((int)code != 200)
                {
                    MessageBox.Show(response.StatusCode.ToString());
                    return;
                }
                var namespaces = api.listNamespaces(ServerIP);
                listBoxNamespaces.Items.Clear();
                foreach (var name in namespaces)
                {
                    listBoxNamespaces.Items.Add(name["metadata"]["name"]);
                }
            }
            
           
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            API api = new API();
            var response = api.createNamespaces(ServerIP, textBox1.Text);
            HttpStatusCode code = response.StatusCode;
            if ((int)code != 201)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
            textBox1.Hide();
            buttonConfirm.Hide();
            buttonCancel.Hide();
            var namespaces= api.listNamespaces(ServerIP);
            listBoxNamespaces.Items.Clear();
            foreach (var name in namespaces)
            {
                listBoxNamespaces.Items.Add(name["metadata"]["name"]);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBox1.Hide();
            buttonConfirm.Hide();
            buttonCancel.Hide();
        }
    }
}
