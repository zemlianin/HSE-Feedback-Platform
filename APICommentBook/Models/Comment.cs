namespace APICommentBook {
    public class Comment {
        public int id { get; set; }
        //Имя пользователя.
        public string name { get; set; }
        //Айди элемента к которому коментарий.
        public int externalId { get; set; }
        //Время оставления комментария
        public string time { get; set; }
        //Содержимое
        public string text { get; set; }
    }
}
