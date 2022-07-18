using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using APICommentBook.Models;

namespace WebAppCommentBook.Pages
{
    public class FacultsModel : PageModel
    {
        public  void OnGet()
        {

            var request = new RequestSender();
            ViewData["Facults"] = JsonSerializer.Deserialize<List<BaseClass>>(request.Get("http://APICommentBook/Get-name-Facults").Result);
            
        }
    }
}
