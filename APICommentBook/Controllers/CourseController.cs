using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;

namespace APICommentBook.Controllers {
    [Route("courses")]
    [ApiController]
    public class CourseController : ForumPageBaseController<Course> {
        protected override string tableName => "courses";
    }
}
