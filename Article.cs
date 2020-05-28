using System;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ArticleService
{
    public class Article
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string Headline { get; set; }

        public string Text { get; set; }

        public int Year {get; set;}
    }
}
