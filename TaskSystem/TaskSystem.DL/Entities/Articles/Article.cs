using System.Collections.Generic;

namespace TaskSystem.DL.Entities.Articles
{
    public class Article : IPkidEntity
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int ArticleCategoryId { get; set; }
        public ArticleCategory ArticleCategory { get; set; }

        public ICollection<ArticleAttachment> ArticleAttachments { get; set; }
    }
}
