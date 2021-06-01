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
        public IRestResponse createPods(string ip, string namesp, string podname, string podlabel, string imgname, string img)
        {
            var url = new RestClient("http://" + ip + "/api/v1/namespaces/" + namesp + "/pods");
            var postRequest = new RestRequest("/", Method.POST);
            //var json = "{\"apiVersion\": \"v1\",\"kind\": \"Pod\",\"metadata\": {\"name\": \"nginxTeste\"},\"spec\": {\"containers\": [{\"name\": \"nginx\",\"image\": \"nginx:1.7.9\",\"ports\": [{\"containerPort\": 80}]}]}}";
            var json = "{\"apiVersion\": \"v1\",\"kind\": \"Pod\",\"metadata\":{\"name\": \""+podname+"\",\"label\":\""+podlabel+"\"},\"spec\":{\"containers\":[{\"name\":\""+imgname+"\",\"image\":\""+img+"\"}]}}";
            postRequest.AddJsonBody(json);
            IRestResponse response = url.Execute(postRequest);
            Console.WriteLine(response);
            return response;
        }
        public IRestResponse deletePods(string ip, string namesp, string podname)
        {
            var url = new RestClient("http://" + ip + "/api/v1/namespaces/" + namesp + "/pods/"+podname);
            var deleteRequest = new RestRequest("/", Method.DELETE);
            IRestResponse response = url.Execute(deleteRequest);
            Console.WriteLine(response);
            return response;
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
        public IRestResponse createDeployments(string ip, string namesp, string deployname, string deploylabel,int replicas, string matchlabel, string cname, string cimage, int port)
        {
            var url = new RestClient("http://" + ip + "/apis/apps/v1/namespaces/" + namesp + "/deployments");
            var postRequest = new RestRequest("/", Method.POST);
            var json = "{\"apiVersion\": \"apps/v1\",\"kind\": \"Deployment\",\"metadata\": {\"name\": \""+deployname+"\",\"labels\": {\"app\": \""+deploylabel+"\"}},\"spec\": {\"replicas\": "+replicas+",\"selector\": {\"matchLabels\": {\"app\": \""+matchlabel+"\"}},\"template\": {\"metadata\": {\"labels\": {\"app\": \""+matchlabel+"\"}},\"spec\": {\"containers\": [{\"name\": \""+cname+"\",\"image\": \""+cimage+"\",\"ports\": [{\"containerPort\": "+port+"}]}]}}}}";
            postRequest.AddJsonBody(json);
            IRestResponse response = url.Execute(postRequest);
            Console.WriteLine(response);
            return response;
        }
        public IRestResponse deleteDeployments(string ip, string namesp, string deployname)
        {
            var url = new RestClient("http://" + ip + "/apis/apps/v1/namespaces/" + namesp + "/deployments/"+deployname);
            var deleteRequest = new RestRequest("/", Method.DELETE);
            IRestResponse response = url.Execute(deleteRequest);
            Console.WriteLine(response);
            return response;
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
        public IRestResponse createServices(string ip, string namesp, string servicename, string portname, int portorg, int porttarget, string selectorname, string type)
        {
            var url = new RestClient("http://" + ip + "/api/v1/namespaces/" + namesp + "/services");
            var postRequest = new RestRequest("/", Method.POST);
            var json = "{\"kind\": \"Service\",\"apiVersion\": \"v1\",\"metadata\": {\"name\": \""+servicename+"\"},\"spec\": {\"ports\": [{\"name\": \""+portname+"\",\"port\": "+portorg+",\"targetPort\": "+porttarget+"}],\"selector\": {\"app\": \""+selectorname+"\"},\"type\": \""+type+"\"}}";
            postRequest.AddJsonBody(json);
            IRestResponse response = url.Execute(postRequest);
            Console.WriteLine(response);
            return response;
        }
        public IRestResponse deleteServices(string ip, string namesp, string servicename)
        {
            var url = new RestClient("http://" + ip + "/api/v1/namespaces/" + namesp + "/services/"+servicename);
            var deleteRequest = new RestRequest("/", Method.DELETE);
            IRestResponse response = url.Execute(deleteRequest);
            Console.WriteLine(response);
            return response;
        }

        public IRestResponse createAll(string ip, string namesp, string deployname, string deploylabel, int replicas, string matchlabel, string cname, string cimage, int port, string portname,int porttarget,string type, string servicename)
        {
            //DEPLOY
            var url = new RestClient("http://" + ip + "/apis/apps/v1/namespaces/" + namesp + "/deployments");
            var postRequest = new RestRequest("/", Method.POST);
            var json = "{\"apiVersion\": \"apps/v1\",\"kind\": \"Deployment\",\"metadata\": {\"name\": \"" + deployname + "\",\"labels\": {\"app\": \"" + deploylabel + "\"}},\"spec\": {\"replicas\": " + replicas + ",\"selector\": {\"matchLabels\": {\"app\": \"" + matchlabel + "\"}},\"template\": {\"metadata\": {\"labels\": {\"app\": \"" + matchlabel + "\"}},\"spec\": {\"containers\": [{\"name\": \"" + cname + "\",\"image\": \"" + cimage + "\",\"ports\": [{\"containerPort\": " + port + "}]}]}}}}";
            postRequest.AddJsonBody(json);
            IRestResponse response = url.Execute(postRequest);
            Console.WriteLine(response);
            //SERVICE
            var url2 = new RestClient("http://" + ip + "/api/v1/namespaces/" + namesp + "/services");
            var postRequest2 = new RestRequest("/", Method.POST);
            var json2 = "{\"kind\": \"Service\",\"apiVersion\": \"v1\",\"metadata\": {\"name\": \"" + servicename + "\"},\"spec\": {\"ports\": [{\"name\": \"" + portname + "\",\"port\": " + port + ",\"targetPort\": " + porttarget + "}],\"selector\": {\"app\": \"" + deployname + "\"},\"type\": \"" + type + "\"}}";
            postRequest2.AddJsonBody(json2);
            IRestResponse response2 = url2.Execute(postRequest2);
            Console.WriteLine(response2);
            return response2;
        }
    }
}
