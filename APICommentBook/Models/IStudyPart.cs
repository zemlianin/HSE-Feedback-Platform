using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICommentBook.Models
{
    interface IStudyPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExternalId { get; set; }
    }
}
