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
            comboBoxType.Items.Add("ExternalName");
            comboBoxType.Items.Add("ClusterIP");
            comboBoxType.Items.Add("NodePort");
            comboBoxType.Items.Add("LoadBalancer");
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (string.IsNullOrEmpty(textBoxName.Text) && string.IsNullOrEmpty(textBoxPortName.Text) && string.IsNullOrEmpty(textBoxPortOrg.Text) && string.IsNullOrEmpty(textBoxPortTarget.Text) && string.IsNullOrEmpty(textBoxSelName.Text))
            {
                MessageBox.Show("Um dos campos não foi preenchido");
                return;
            }
            if (!int.TryParse(textBoxPortOrg.Text, out a))
            {
                MessageBox.Show("Porto tem de ser um numero");
                return;
            }
            if (!int.TryParse(textBoxPortTarget.Text, out a))
            {
                MessageBox.Show("Porto tem de ser um numero");
                return;
            }
            API api = new API();
            var response = api.createServices(ServerIP,comboBox1.Text,textBoxName.Text,textBoxPortName.Text,Int32.Parse(textBoxPortOrg.Text), Int32.Parse(textBoxPortTarget.Text),textBoxSelName.Text,comboBoxType.Text);
            HttpStatusCode code = response.StatusCode;
            if ((int)code != 201)
            {
                MessageBox.Show(response.StatusCode.ToString());
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Plesase select one");
                return;
            }
            API api = new API();
            var response = api.deleteServices(ServerIP,comboBox1.Text,listBox1.SelectedItem.ToString());
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

            string pattern = @"([\d\.]+)";
            //string pattern = @"(?<![A-Za-z0-9.])[0-9.]+";
            string[] subs = Regex.Split(jsonText, pattern);
            var number = subs.Count();
            string teste = "";
            int a;
            for (int index = 0; index < number; index++)
            {
                if (index == 0)
                {
                    teste = subs[index];
                }
                if (index == 1)
                {
                    teste = teste + subs[index];
                }
                if (index > 1 && !int.TryParse(subs[index], out a))
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
            var response = api.createServiceFile(ServerIP, comboBox1.Text, teste);
        }
    }
}
