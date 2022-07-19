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
           // System.IO.File.WriteAllText("output.txt", "111111111111111111");
            this.name = name;
            this.externalId = externalId;
            var request = new RequestSender();

            ViewData["CommentsCourse"] = JsonSerializer.Deserialize<List<Comment>>(
                request.Get($"http://APICommentBook/Get-comments-Courses").Result);
            //System.IO.File.WriteAllText("output.txt", request.Get($"http://APICommentBook/Get-name-Courses-by-externalId?externalId=" + this.externalId).Result);
        }
        public void OnPost(string msg, string name, string email)
        {
            System.IO.File.WriteAllText("output.txt", msg + " " + name + "  " + email);
        }
    }
}
