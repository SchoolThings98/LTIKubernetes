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
        public IRestResponse createNamespaces(string ip, string name)
        {
            var url = new RestClient("http://" + ip + "/api/v1/namespaces");
            var postRequest = new RestRequest("/", Method.POST);
            var json = "{\"apiVersion\": \"v1\",\"kind\": \"Namespace\",\"metadata\": {\"name\": \""+name+"\"}}";
            postRequest.AddJsonBody(json);
            IRestResponse response = url.Execute(postRequest);
            Console.WriteLine(response);
            return response;
        }
        public IRestResponse deleteNamespaces(string ip, string namesp)
        {
            var url = new RestClient("http://" + ip + "/api/v1/namespaces/"+namesp);
            var deleteRequest = new RestRequest("/", Method.DELETE);

            IRestResponse response = url.Execute(deleteRequest);
            Console.WriteLine(response);
            return response;
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
        public void createPods(string ip, string namesp, string pod)
        {
            var url = new RestClient("http://" + ip + "/api/v1/namespaces/" + namesp + "/pods");
            var postRequest = new RestRequest("/", Method.POST);
            var json = "{\"apiVersion\": \"v1\",\"kind\": \"Pod\",\"metadata\": {\"name\": \"nginxTeste\"},\"spec\": {\"containers\": [{\"name\": \"nginx\",\"image\": \"nginx:1.7.9\",\"ports\": [{\"containerPort\": 80}]}]}}";
        }
        public void deletePods(string ip, string namesp, string podname)
        {
            var url = new RestClient("http://" + ip + "/api/v1/namespaces/" + namesp + "/pods/"+podname);
            var deleteRequest = new RestRequest("/", Method.DELETE);
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
        public void createDeployments(string ip, string namesp, string deploy)
        {
            var url = new RestClient("http://" + ip + "/apis/apps/v1/namespaces/" + namesp + "/deployments");
            var postRequest = new RestRequest("/", Method.POST);
        }
        public void deleteDeployments(string ip, string namesp, string deployname)
        {
            var url = new RestClient("http://" + ip + "/apis/apps/v1/namespaces/" + namesp + "/deployments/"+deployname);
            var deleteRequest = new RestRequest("/", Method.DELETE);
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
        public void createServices(string ip, string namesp, string service)
        {
            var url = new RestClient("http://" + ip + "/api/v1/namespaces/" + namesp + "/services");
            var postRequest = new RestRequest("/", Method.POST);
        }
        public void deleteServices(string ip, string namesp, string servicename)
        {
            var url = new RestClient("http://" + ip + "/api/v1/namespaces/" + namesp + "/services/"+servicename);
            var deleteRequest = new RestRequest("/", Method.DELETE);
        }
    }
}
