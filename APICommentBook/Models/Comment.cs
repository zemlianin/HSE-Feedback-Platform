namespace APICommentBook.Models
{
    public class Comment
    {
        public int Id { get; set; }
        //Имя пользователя.
        public string Name { get; set; }
        //Айди элемента к которому коментарий.
        public int ExternalId { get; set; }
        //Время оставления комментария
        public string Time { get; set; }
        //Содержимое
        public string Text { get; set; }
    }
}
