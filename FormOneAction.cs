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
    public partial class FormOneAction : Form
    {
        String ServerIP = "";
        public FormOneAction(string ip)
        {
            InitializeComponent();
            ServerIP = ip;
        }

        private void FormOneAction_Load(object sender, EventArgs e)
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

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            API api = new API();
            var response = api.createAll(ServerIP,comboBox1.Text,textBoxName.Text,textBoxLabel.Text, Int32.Parse(textBoxReplicas.Text),textBoxMatchLabel.Text,textBoxCName.Text,textBoxCImage.Text,Int32.Parse(textBoxPort.Text),textBoxPortName.Text,Int32.Parse(textBoxPortTarget.Text),comboBoxType.Text,textBoxSName.Text);
        }
    }
}
