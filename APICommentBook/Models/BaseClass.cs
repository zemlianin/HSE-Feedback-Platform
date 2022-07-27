namespace APICommentBook
{
    public class BaseClass : IStudyPart
    {
        public int id { get; set; }
        public string name { get; set; }
        //айди родителя(для направления это факультет)
        public int externalId { get; set; }
    }
}
