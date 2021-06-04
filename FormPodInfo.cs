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
    public partial class FormPodInfo : Form
    {
        string ServerIP = "";
        string name = "";
        string podName = "";
        public FormPodInfo(string ip, string namesp, string pod)
        {
            InitializeComponent();
            ServerIP = ip;
            name = namesp;
            podName = pod;
        }

        private void FormPodInfo_Load(object sender, EventArgs e)
        {
            API api = new API();
            var response= api.getPodInfo(ServerIP,name,podName);
            JObject content = JObject.Parse(response.Content);
            labelName.Text= (string)content["metadata"].SelectToken("name");
            labelGName.Text= (string)content["metadata"].SelectToken("generateName");
            labelLabel.Text= (string)content["metadata"]["labels"].SelectToken("app");
            labelCImage.Text= (string)content["spec"]["containers"][0].SelectToken("image");
            //var teste = content["spec"]["containers"];
            labelStatus.Text= (string)content["status"].SelectToken("phase");
        }
    }
}
