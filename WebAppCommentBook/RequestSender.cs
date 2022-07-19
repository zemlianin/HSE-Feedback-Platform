using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WebAppCommentBook
{
    public class RequestSender
    {
        private static HttpClient _CLIENT;
       
        public RequestSender()
        {
            if (_CLIENT == null)
            {
                _CLIENT = new HttpClient();
            }
            
        }

       public async Task<string> Get(string path)
        {
            var response = await _CLIENT.GetStringAsync(path);         
            return response;
        }

        public async void Post(string path, string jObject)
        {
            string json = JsonConvert.SerializeObject(1);
            HttpContent content = new StringContent(json);            
            HttpResponseMessage response = await _CLIENT.PostAsync(path, content);      

        }
       
    }
}
