using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;

namespace APICommentBook.Controllers { 
    [Route("directions")]
    [ApiController]
    public class DirectionController : ForumPageBaseController<Direction> {
        protected override string tableName => "directions"; 
    }
}
