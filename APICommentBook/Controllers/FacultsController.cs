using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;

namespace APICommentBook.Controllers {
    [Route("facults")]
    [ApiController]
    public class FacultsController : ForumPageBaseController<Facult>
    {
        protected override string tableName => "facults";

    }
}
