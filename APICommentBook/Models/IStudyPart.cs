using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICommentBook
{
    public interface IStudyPart
    {
        public int id { get; set; }
        public string name { get; set; }
        public int externalId { get; set; }
    }
}
