using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RestSharp.Authenticators;

namespace FrameworkLayer.APIUtils
{
    public class APIUtil
    {
        private RestClient restClient;
        private RestRequest restRequest;

        public APIUtil(string url)
        { 
            restClient = new RestClient(url);
        }

        public RestRequest GetRestRequest(string endpoint, Method method)
        {
            return new RestRequest(endpoint,method);
        }

        public T Get<T>(string endpoint, Dictionary<string,string>headers=null,Dictionary<string,string>parameters=null)
        {
            restRequest = GetRestRequest(endpoint,Method.Get);
            if (headers != null) AddHeaders(headers);
            if(parameters != null) AddParameters(parameters);

            var data = restClient.Execute(restRequest);

            return JsonConvert.DeserializeObject<T>(data.Content);
        }

        public T POST<T>(string endpoint,Object body, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null)
        {
            restRequest = GetRestRequest(endpoint, Method.Post);
            if (headers != null) AddHeaders(headers);
            if (parameters != null) AddParameters(parameters);
            restRequest.AddJsonBody(body);

            //restRequest.Authenticator = new HttpBasicAuthenticator(username,password);
            var data = restClient.Execute(restRequest);

            return JsonConvert.DeserializeObject<T>(data.Content);
        }

        private void AddHeaders(Dictionary<string, string> headers)
        {
            foreach (KeyValuePair<string, string> key in headers)
            {
                restRequest.AddHeader(key.Key, key.Value);
            }
        }

        private void AddParameters(Dictionary<string, string> parameters)
        {
            foreach (KeyValuePair<string, string> key in parameters)
            {
                restRequest.AddParameter(key.Key, key.Value);
            }
        }
    }
}
