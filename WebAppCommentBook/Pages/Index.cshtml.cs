using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using APICommentBook;

namespace WebAppCommentBook.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public async Task OnGet()
        {
            var request = new RequestSender();

            ViewData["Facults"] = JsonSerializer.Deserialize<List<BaseClass>>(request.Get("http://APICommentBook/facults/get-names").Result);


           
        }
       
    }
}
