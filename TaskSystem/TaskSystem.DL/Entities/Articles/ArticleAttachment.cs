namespace TaskSystem.DL.Entities.Articles
{
    public class ArticleAttachment : IPkidEntity
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
