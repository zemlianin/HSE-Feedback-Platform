using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using APICommentBook;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebAppCommentBook.Pages
{
    public class CoursesModel : PageModel
    {
        public int externalId { get; set; }

        public string name { get; set; }
        public void OnGet(int externalId, string name)
        {
            this.name = name;
            this.externalId = externalId;
            var request = new RequestSender();

            ViewData["Courses"] = System.Text.Json.JsonSerializer.Deserialize<List<BaseClass>>(
                request.Get($"http://APICommentBook/courses/get-names-by-externalId?externalId=" + this.externalId).Result);
            //System.IO.File.WriteAllText("output.txt", request.Get($"http://APICommentBook/courses/get-names-by-externalId?externalId=" + this.externalId).Result);
            ViewData["CommentsDirection"] = System.Text.Json.JsonSerializer.Deserialize<List<Comment>>(
                request.Get($"http://APICommentBook/directions/get-comments-by-externalId?externalId={externalId}").Result);
        }

        public void OnPost(string msgUser, string nameUser, string emailUser, int externalId, string name)
        {
            this.externalId = externalId;
            this.name = name;

            var request = new RequestSender();
            ViewData["Courses"] = System.Text.Json.JsonSerializer.Deserialize<List<BaseClass>>(
                request.Get($"http://APICommentBook/Get-name-Directions-by-externalId?externalId=" + externalId).Result);
            ViewData["CommentsDirection"] = System.Text.Json.JsonSerializer.Deserialize<List<Comment>>(
                           request.Get($"http://APICommentBook/Get-comments-Directions-by-externalId?externalId={externalId}").Result);
            var list = ViewData["CommentsDirection"];

  

            var comment = new Comment()
            {
                id = 1,
                name = nameUser,
                externalId = externalId,
                time = DateTime.Now.ToString(),
                text = msgUser,
            };
            string json = JsonConvert.SerializeObject(comment);
            request.Post($"http://APICommentBook/write-comment-direction?id={comment.id}&name={comment.name}_{emailUser}&externalId={comment.externalId}&time={comment.time}&text={comment.text}", json);
        }
    }
}
