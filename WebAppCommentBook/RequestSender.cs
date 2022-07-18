using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace WebAppCommentBook
{
    public class RequestSender
    {
        private static HttpClient _CLIENT;
        private static HttpRequestMessage request;
        public RequestSender()
        {
            if (_CLIENT == null)
            {
                _CLIENT = new HttpClient();
            }
            if (request == null)
            {
                request = new HttpRequestMessage();
            }
        }

       public async Task<string> Get(string path)
        {

            
            var response = await _CLIENT.GetStringAsync(path);

           
            return response;
        }

        public async void Post(string path)
        {
            
            request.RequestUri = new Uri(path);

            var response = await _CLIENT.SendAsync(request);
        }
    }
}
