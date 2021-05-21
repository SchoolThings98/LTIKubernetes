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
    }
}
