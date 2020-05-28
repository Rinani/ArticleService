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

        [HttpGet]
        [Route("")]
        [Route("Articles")]
        public ActionResult<string> Get()
        {
            return FileReader.ReadFile();
            
        }

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

        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<Article>> All()
        {
            return _articleStorage.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult<string> CreateArticle(Article article)
        {
            var index = _articleStorage.CreateArticle(article);

            return "The article was created with index " + index;
        }

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
