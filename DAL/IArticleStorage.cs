using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleService.DAL
{
    public interface IArticleStorage
    {
        /// <summary>
        /// Fetches specificed Article
        /// </summary>
        /// <param name="id">The ID of the Article to fetch</param>
        /// <returns>Article, null if Article is not found</returns>
        public Article GetArticle(int id);

        /// <summary>
        /// Fetches a list of all articles
        /// </summary>
        /// <returns>List of Articles</returns>
        public IEnumerable<Article> GetAll();

        /// <summary>
        /// Deletes the specified Article
        /// </summary>
        /// <param name="id">The ID of the Article to delete</param>
        /// <returns>True if Article was sucessfully deleted</returns>
        public bool DeleteArticle(int id);

        /// <summary>
        /// Creates an article
        /// </summary>
        /// <param name="article">Article to be created</param>
        /// <returns>Id of newly created Article</returns>
        public int CreateArticle(Article article);

        /// <summary>
        /// Updates specified Article
        /// </summary>
        /// <param name="article">Article to be updated</param>
        /// <returns></returns>
        public bool UpdateArticle(int articleID, Article article);
    }
}
