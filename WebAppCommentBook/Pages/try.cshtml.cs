using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppCommentBook.Pages
{
    [IgnoreAntiforgeryToken]
    public class tryModel : PageModel
    {
        public string Message { get; private set; } = "";
        public void OnGet()
        {
            Message = "Введите свое имя";
        }
        public void OnPost(string username)
        {
            Message = $"Ваше имя: {username}";
        }
    }
}
