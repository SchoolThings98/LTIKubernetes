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
    public partial class FormInfoDeploy : Form
    {
        string ServerIP = "";
        string name = "";
        string deployName = "";
        public FormInfoDeploy(string ip, string namesp, string deploy)
        {
            InitializeComponent();
            ServerIP = ip;
            name = namesp;
            deployName = deploy;
        }

        private void FormInfoDeploy_Load(object sender, EventArgs e)
        {
            API api = new API();
            var response =api.getDeployInfo(ServerIP, name, deployName);
            JObject content = JObject.Parse(response.Content);
            labelName.Text = (string)content["metadata"].SelectToken("name");
            labelLabel.Text = (string)content["metadata"]["labels"].SelectToken("app");
            labelCImages.Text = (string)content["spec"]["template"]["spec"]["containers"][0].SelectToken("image");
        }
    }
}
