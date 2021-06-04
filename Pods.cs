using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

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
            textBoxName.Hide();
            textBoxLabel.Hide();
            textBoxImgName.Hide();
            textBoxImg.Hide();
            buttonCreate.Hide();
            buttonRemove.Hide();
            buttonCreateYALM.Hide();
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
            textBoxName.Show();
            textBoxLabel.Show();
            textBoxImgName.Show();
            textBoxImg.Show();
            buttonCreate.Show();
            buttonRemove.Show();
            buttonCreateYALM.Show();
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

        private void buttonCreateYALM_Click(object sender, EventArgs e)
        {
            var fileName = "";
            openFileDialogYAML.InitialDirectory = Application.StartupPath + @"\templates";
            openFileDialogYAML.Filter = "yaml files (*.yaml)|*.yaml";
            if (openFileDialogYAML.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialogYAML.FileName;
                MessageBox.Show("Ficheiro" + openFileDialogYAML.SafeFileName + " open with SUCCESS! ");
            }
            else
            {
                MessageBox.Show("Erro trying to open the selected file!!!");
                return;
            }
            //var stream = new StreamReader(fileName);
            /*var yaml = new YamlStream();
            using (var reader = new StreamReader(fileName))
            {
                yaml.Load(reader);
            }
            Console.WriteLine(yaml);
            Console.WriteLine(yaml);*/
            var r = new StreamReader(fileName);
            var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
            var yamlObject = deserializer.Deserialize(r);

            // now convert the object to JSON. Simple!
            Newtonsoft.Json.JsonSerializer js = new Newtonsoft.Json.JsonSerializer();

            var w = new StringWriter();
            js.Serialize(w, yamlObject);
            string jsonText = w.ToString();
            Console.WriteLine(jsonText);

            API api = new API();
            var response = api.createPodFile(ServerIP, comboBox1.Text, jsonText);
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            FormPodInfo podInfo = new FormPodInfo(ServerIP,comboBox1.Text,listBox1.SelectedItem.ToString());
            podInfo.ShowDialog();
        }
    }
}
