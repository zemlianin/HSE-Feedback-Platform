namespace APICommentBook.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExternalId { get; set; }
        public string Time { get; set; }
        public string Text { get; set; }
    }
}
