using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTIProject2
{
    class API
    {
        public JArray listNodes(string ip)
        {
            var url = new RestClient("http://"+ip+ "/api/v1/nodes");
            var getRequest = new RestRequest("/", Method.GET);

            IRestResponse getResponse = url.Execute(getRequest);
            Console.WriteLine(getResponse.Content);
            JObject content = JObject.Parse(getResponse.Content);
            Console.WriteLine(content);
            JArray nodes = (JArray)content.SelectToken("items");
            /*Console.WriteLine(nodes);
            foreach(var node in nodes)
            {
                Console.WriteLine(node["metadata"]["name"]);
            }*/
            return nodes;
        }
        public JArray listNamespaces(string ip)
        {
            var url = new RestClient("http://" + ip + "/api/v1/namespaces");
            var getRequest = new RestRequest("/", Method.GET);

            IRestResponse getResponse = url.Execute(getRequest);
            Console.WriteLine(getResponse.Content);
            JObject content = JObject.Parse(getResponse.Content);
            Console.WriteLine(content);
            JArray namespaces = (JArray)content.SelectToken("items");
            return namespaces;
        }
        public void createNamespaces()
        {

        }
        public void deleteNamespaces()
        {

        }
        public JArray listPods(string ip, string namesp)
        {
            var url = new RestClient("http://" + ip + "/api/v1/namespaces/"+namesp+"/pods");
            var getRequest = new RestRequest("/", Method.GET);

            IRestResponse getResponse = url.Execute(getRequest);
            Console.WriteLine(getResponse.Content);
            JObject content = JObject.Parse(getResponse.Content);
            Console.WriteLine(content);
            JArray pods = (JArray)content.SelectToken("items");
            return pods;
        }
        public void createPods()
        {

        }
        public void deletePods()
        {

        }
        public JArray listDeployments(string ip, string namesp)
        {
            var url = new RestClient("http://" + ip + "/apis/apps/v1/namespaces/"+namesp+ "/deployments");
            var getRequest = new RestRequest("/", Method.GET);

            IRestResponse getResponse = url.Execute(getRequest);
            Console.WriteLine(getResponse.Content);
            JObject content = JObject.Parse(getResponse.Content);
            Console.WriteLine(content);
            JArray deployments = (JArray)content.SelectToken("items");
            return deployments;
        }
        public void createDeployments()
        {

        }
        public void deleteDeployments()
        {

        }
        public JArray listServices(string ip, string namesp)
        {
            var url = new RestClient("http://" + ip + "/api/v1/namespaces/" + namesp + "/services");
            var getRequest = new RestRequest("/", Method.GET);

            IRestResponse getResponse = url.Execute(getRequest);
            Console.WriteLine(getResponse.Content);
            JObject content = JObject.Parse(getResponse.Content);
            Console.WriteLine(content);
            JArray services = (JArray)content.SelectToken("items");
            return services;
        }
        public void createServices()
        {

        }
        public void deleteServices()
        {

        }
    }
}
