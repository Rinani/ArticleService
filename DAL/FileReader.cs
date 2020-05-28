using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleService.DAL
{
    public static class FileReader
    {
        public static string ReadFile()
        {
            var lines = File.ReadAllText(@".\Readme.txt");

            return lines;
        }
    }
}
