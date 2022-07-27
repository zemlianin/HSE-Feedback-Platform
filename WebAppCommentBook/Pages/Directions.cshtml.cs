using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using APICommentBook;
using Newtonsoft.Json;

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
            
            ViewData["Directions"] = System.Text.Json.JsonSerializer.Deserialize<List<BaseClass>>(
                request.Get($"http://APICommentBook/directions/get-names-by-externalId?externalId=" +externalId).Result);

            ViewData["CommentsFacult"] = System.Text.Json.JsonSerializer.Deserialize<List<Comment>>(
                request.Get($"http://APICommentBook/facults/get-comments-by-externalId?externalId={externalId}").Result);

        }

        public void OnPost(string msgUser, string nameUser, string emailUser, int externalId, string name)
        {
            this.externalId = externalId;
            this.name = name;

            var request = new RequestSender();
            ViewData["Directions"] = System.Text.Json.JsonSerializer.Deserialize<List<BaseClass>>(
                request.Get($"http://APICommentBook/directions/get-names-by-externalId?externalId=" + externalId).Result);
            ViewData["CommentsFacult"] = System.Text.Json.JsonSerializer.Deserialize<List<Comment>>(
                           request.Get($"http://APICommentBook/facults/get-comments-by-externalId?externalId={externalId}").Result);
            var list = ViewData["CommentsFacult"];

            var comment = new Comment()
            {
                id = ((List<Comment>)list).Count + 1,
                name = nameUser,
                externalId = externalId,
                time = DateTime.Now.ToString(),
                text = msgUser,
            };
            string json = JsonConvert.SerializeObject(comment);
            request.Post($"http://APICommentBook/facults/write-comment?id={comment.id}&name={comment.name}_{emailUser}&externalId={comment.externalId}&time={comment.time}&text={comment.text}", json);
        }

    }
}
