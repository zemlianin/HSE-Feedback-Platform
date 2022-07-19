using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using APICommentBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

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
            var request = new RequestSender();

            ViewData["CommentsCourse"] = System.Text.Json.JsonSerializer.Deserialize<List<Comment>>(
                request.Get($"http://APICommentBook/Get-comments-Courses-by-externalId?externalId={externalId}").Result);
            //System.IO.File.WriteAllText("output.txt", request.Get($"http://APICommentBook/Get-name-Courses-by-externalId?externalId=" + this.externalId).Result);
        }
        public void OnPost(string msgUser, string nameUser, string emailUser, int externalId, string name)
        {
            this.externalId = externalId;
            this.name = name;
            
            var request = new RequestSender();
            
            ViewData["CommentsCourse"] = System.Text.Json.JsonSerializer.Deserialize<List<Comment>>(
                           request.Get($"http://APICommentBook/Get-comments-Courses").Result);
            var list = ViewData["CommentsCourse"];

            var comment = new Comment()
            {
                id = ((List<Comment>)list).Count+1,
                name = nameUser,
                externalId = externalId,
                time = DateTime.Now.ToString(),
                text = msgUser,
            };
            //  var options = new JsonSerializerOptions { WriteIndented = true };
            //  string jsonString = JsonSerializer.Serialize(1, options);
            // request.PostWithBody($"http://APICommentBook/write-comment-course", jsonString);
            string json = JsonConvert.SerializeObject(comment);
            request.Post($"http://APICommentBook/write-comment-course?id={comment.id}&name={comment.name}_{emailUser}&externalId={comment.externalId}&time={comment.time}&text={comment.text}",json);
        }
    }
}
