using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArticleService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ArticlesController> _logger;
        private List<Article> _articles;

        public ArticlesController(ILogger<ArticlesController> logger)
        {
            _logger = logger;
            _articles = new List<Article>();
        }

        [HttpGet]
        [Route("")]
        [Route("Articles")]
        public IEnumerable<Article> Get()
        {

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Article
            {
                Author = "Test" + index,
                Headline = "Test Headline",
                Text = "Lorem Ipsum",
                Year = 2020
            })
            .ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public Article Get(int id)
        {
            return new Article
            {
                Author = "Test" + id,
                Headline = "Test Headline",
                Text = "Lorem Ipsum",
                Year = 2020
            };
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Article> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Article
            {
                Author = "Test" + index,
                Headline = "Test Headline",
                Text = "Lorem Ipsum",
                Year = 2020
            })
            .ToArray();

        }
    }
}
