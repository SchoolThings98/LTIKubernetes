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
            foreach (var name in namespaces)
            {
                listBoxNamespaces.Items.Add(name["metadata"]["name"]);
            }
        }
    }
}
