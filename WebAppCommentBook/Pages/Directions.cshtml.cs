using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using APICommentBook.Models;
using System.Text.Json;


namespace WebAppCommentBook.Pages
{
    public class DirectionsModel : PageModel
    {
        public int externalId { get; set; }

        public string name { get; set; }
        public void OnGet(int externalId,string name)
        {
            this.name = name;
            this.externalId= externalId;
            var request = new RequestSender();
            
            ViewData["Directions"] = JsonSerializer.Deserialize<List<BaseClass>>(
                request.Get($"http://APICommentBook/Get-name-Directions-by-externalId?externalId="+externalId).Result);
         //  System.IO.File.WriteAllText("output.txt", externalId.ToString());
        }
      
    }
}
