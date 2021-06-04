using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

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
            textBoxName.Hide();
            textBoxLabel.Hide();
            textBoxCName.Hide();
            textBoxReplicas.Hide();
            textBoxMLabel.Hide();
            textBoxCImage.Hide();
            textBoxPort.Hide();
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
            textBoxName.Show();
            textBoxLabel.Show();
            textBoxCName.Show();
            textBoxReplicas.Show();
            textBoxMLabel.Show();
            textBoxCImage.Show();
            textBoxPort.Show();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            int a=0;
            if(string.IsNullOrEmpty(textBoxName.Text) && string.IsNullOrEmpty(textBoxLabel.Text) && string.IsNullOrEmpty(textBoxReplicas.Text) && string.IsNullOrEmpty(textBoxMLabel.Text) && string.IsNullOrEmpty(textBoxCName.Text) && string.IsNullOrEmpty(textBoxCImage.Text) && string.IsNullOrEmpty(textBoxPort.Text))
            {
                MessageBox.Show("Um dos campos não foi preenchido");
                return;
            }
            if(!int.TryParse(textBoxPort.Text, out a)){
                MessageBox.Show("Porto tem de ser um numero");
                return;
            }
            if (!int.TryParse(textBoxReplicas.Text, out a))
            {
                MessageBox.Show("Replicas tem de ser um numero");
                return;
            }
            API api = new API();
            var response = api.createDeployments(ServerIP, comboBox1.Text, textBoxName.Text, textBoxLabel.Text, Int32.Parse(textBoxReplicas.Text), textBoxMLabel.Text, textBoxCName.Text, textBoxCImage.Text, Int32.Parse(textBoxPort.Text));
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
            var response = api.deleteDeployments(ServerIP,comboBox1.Text,listBox1.SelectedItem.ToString());
            HttpStatusCode code = response.StatusCode;
            if ((int)code != 200)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
        }

        private void buttonCreateFile_Click(object sender, EventArgs e)
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

            var r = new StreamReader(fileName);
            var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
            var yamlObject = deserializer.Deserialize(r);

            // now convert the object to JSON. Simple!
            Newtonsoft.Json.JsonSerializer js = new Newtonsoft.Json.JsonSerializer();

            var w = new StringWriter();
            js.Serialize(w, yamlObject);
            string jsonText = w.ToString();
            Console.WriteLine(jsonText);
            //jsonText = jsonText.Replace("/ "v":"(\d+)" / g", '"v":$1');
            //string pattern = @"([0-9]+\.{0,1}[0-9]*)";
            //Regex rg = new Regex(pattern);
            //foreach (Match match in Regex.Matches(jsonText, "\"([^\"]*)\""))
            //    Console.WriteLine(match.ToString());
            //string cleanJson = Regex.Replace(jsonText, @"([\d\.]+)", "1");
            //Console.WriteLine(cleanJson);
            //string[] splits = jsonText.Split(':');
            //foreach (var split in splits)
            //{
            //    Console.WriteLine($"<{split}>");
            //}
            string pattern = @"([\d\.]+)";
            //string pattern = @"(?<![A-Za-z0-9.])[0-9.]+";
            string[] subs = Regex.Split(jsonText,pattern);
            var number = subs.Count();
            string teste ="";
            int a;
            for (int index = 0; index < number; index++)
            {
                if(index == 0)
                {
                    teste = subs[index];
                }
                if (index == 1)
                {
                    teste = teste + subs[index];
                }
                if(index>1 && !int.TryParse(subs[index],out a))
                {
                    teste = teste + subs[index];
                }
                if (index > 1 && int.TryParse(subs[index], out a))
                {
                    var tempString = "";
                    teste = teste.Remove(teste.Length - 1);
                    teste = teste + subs[index];
                    index++;
                    tempString = subs[index].Substring(1);
                    teste = teste + tempString;

                }
            }
            
            Console.WriteLine(teste);
            API api = new API();
            var response = api.createDeployFile(ServerIP, comboBox1.Text, teste);
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            FormInfoDeploy deployInfo = new FormInfoDeploy(ServerIP,comboBox1.Text,listBox1.SelectedItem.ToString());
            deployInfo.ShowDialog();
        }
    }
}
