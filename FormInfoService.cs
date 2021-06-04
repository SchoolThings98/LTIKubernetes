using Newtonsoft.Json.Linq;
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
    public partial class FormInfoService : Form
    {
        string ServerIP = "";
        string name = "";
        string serviceName = "";
        public FormInfoService(string ip, string namesp, string service)
        {
            InitializeComponent();
            ServerIP = ip;
            name = namesp;
            serviceName = service;
        }

        private void FormInfoService_Load(object sender, EventArgs e)
        {
            API api = new API();
            var response = api.getServiceInfo(ServerIP, name, serviceName);
            JObject content = JObject.Parse(response.Content);
            labelName.Text= (string)content["metadata"].SelectToken("name");
            labelLabel.Text = (string)content["metadata"]["labels"].SelectToken("app");
            labelProtocol.Text= (string)content["spec"]["ports"][0].SelectToken("protocol");
            labelPort.Text= (string)content["spec"]["ports"][0].SelectToken("port");
            labelPTarget.Text= (string)content["spec"]["ports"][0].SelectToken("targetPort");
            labelNodePort.Text = (string)content["spec"]["ports"][0].SelectToken("nodePort");
            labelType.Text = (string)content["spec"].SelectToken("type");
            labelClusterIP.Text= (string)content["spec"].SelectToken("clusterIP");
        }
    }
}
