namespace APICommentBook.Models
{
    public class BaseClass:IStadyPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //айди родителя(для направления это факультет)
        public int ExternalId { get; set; }
    }
}
