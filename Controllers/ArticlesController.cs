using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleService.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArticleService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {

        private readonly ILogger<ArticlesController> _logger;
        private IArticleStorage _articleStorage;

        public ArticlesController(ILogger<ArticlesController> logger)
        {
            _logger = logger;
            _articleStorage = ArticleStorage.GetInstance();
        }

        /// <summary>
        /// Default GET landing on /Articles
        /// </summary>
        /// <returns>The content of Readme.txt</returns>
        [HttpGet]
        [Route("")]
        [Route("Articles")]
        public ActionResult<string> Get()
        {
            return FileReader.ReadFile();
            
        }

        /// <summary>
        /// Return specificed Article
        /// </summary>
        /// <param name="id">The ID of the article to return</param>
        /// <returns>Returns Article or 404 if not found</returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Article> Get(int id)
        {
            var article = _articleStorage.GetArticle(id);
            if(article != null)
            {
                return article;
            }
            return NotFound();
        }

        /// <summary>
        /// Returns list of all Articles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<Article>> All()
        {
            return _articleStorage.GetAll().ToArray();
        }

        /// <summary>
        /// Adds article to list
        /// </summary>
        /// <param name="article">The article to add, author, headline, year and text if json</param>
        /// <returns>200 OK and article ID on success</returns>
        [HttpPost]
        public ActionResult<string> CreateArticle(Article article)
        {
            var index = _articleStorage.CreateArticle(article);

            return "The article was created with index " + index;
        }

        /// <summary>
        /// Removes an article from the list
        /// </summary>
        /// <param name="id">The ID of the article to delete</param>
        /// <returns>Returns a confirmation on deletion or 404 if not found</returns>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<string> DeleteArticle(int id)
        {
            if(_articleStorage.DeleteArticle(id))
            {
                return "Article with ID: " + id + " was deleted";
            }
            return NotFound();
        }
    }
}
