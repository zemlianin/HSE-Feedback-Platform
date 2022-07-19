using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using APICommentBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppCommentBook.Pages
{
    public class OneCourseModel : PageModel
    {
        public int externalId { get; set; }

        public string name { get; set; }
        public void OnGet(int externalId, string name)
        {
            this.name = name;
            this.externalId = externalId;
            /*var request = new RequestSender();

            ViewData["Courses"] = JsonSerializer.Deserialize<List<BaseClass>>(
                request.Get($"http://APICommentBook/Get-name-Courses-by-externalId?externalId=" + this.externalId).Result);
            //System.IO.File.WriteAllText("output.txt", request.Get($"http://APICommentBook/Get-name-Courses-by-externalId?externalId=" + this.externalId).Result);*/
        }
    }
}
