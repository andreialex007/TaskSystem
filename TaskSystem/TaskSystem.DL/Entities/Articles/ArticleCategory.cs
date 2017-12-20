using System.Collections.Generic;

namespace TaskSystem.DL.Entities.Articles
{
    public class ArticleCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentArticleCategoryId { get; set; }
        public ArticleCategory ParentArticleCategory { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
