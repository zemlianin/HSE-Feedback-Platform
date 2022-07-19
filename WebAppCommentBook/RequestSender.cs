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
            
          //  File.WriteAllText("output.txt", request.RequestUri.ToString()+" 1");
        }
        public async void PostWithBody(string path,string jObject)
        {
            // var content = new FormUrlEncodedContent(values);
            var content = new StringContent(jObject.ToString());

            var response = await _CLIENT.PostAsync(path, content);

        //    var responseString = await response.Content.ReadAsStringAsync();
              File.WriteAllText("output.txt", " 1");
       //     var response = _CLIENT.SendAsync(request);
        }
    }
}
