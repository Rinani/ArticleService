using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleService.DAL
{
    public class ArticleStorage : IArticleStorage
    {
        private List<Article> _articles;

        private int _index = 1;

        static ArticleStorage _instance = new ArticleStorage();

        public static ArticleStorage GetInstance()
        {
            return _instance;
        }

        private ArticleStorage()
        {
            _articles = new List<Article>();

            CreateArticle(new Article() { Author = "Rasmus", Headline = "The Article", Year = 2020, Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
            CreateArticle(new Article() { Author = "Rasmus A Larsen", Headline = "The Second Article", Year = 2020, Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
            CreateArticle(new Article() { Author = "Rasmus Anegaard Larsen", Headline = "The Third Article", Year = 2020, Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
            CreateArticle(new Article() { Author = "Rasmus Larsen", Headline = "The Fourth Article", Year = 2020, Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
            CreateArticle(new Article() { Author = "Mr. Larsen", Headline = "The Fifth Article", Year = 2020, Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
        }


        public int CreateArticle(Article article)
        {
            article.ID = _index++;
            _articles.Add(article);
            return article.ID;
        }

        public bool DeleteArticle(int id)
        {
            var articleToRemove = GetArticle(id);
            if(articleToRemove != null)
            {
            _articles.Remove(articleToRemove);
                return true;
            }
            return false;
        }

        public IEnumerable<Article> GetAll()
        {
            return _articles;
        }

        public Article GetArticle(int id)
        {
            return _articles.FirstOrDefault(a => a.ID == id);
        }

        public bool UpdateArticle(int articleID, Article article)
        {
            var articleIndexToUpdate = _articles.FindIndex(a => a.ID == articleID);
            if (articleIndexToUpdate != -1)
            {
                _articles[articleIndexToUpdate] = article;
                return true;
            }
            return false;
        }

    }
}
