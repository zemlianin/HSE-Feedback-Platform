namespace APICommentBook.Models
{
    public class BaseClass:IStadyPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExternalId { get; set; }
    }
}
