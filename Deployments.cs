using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
