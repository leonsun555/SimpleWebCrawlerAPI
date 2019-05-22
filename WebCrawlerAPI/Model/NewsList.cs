using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrawlerAPI.Model
{
    public class NewsList
    {
        public Guid id { get; set; }
        public string date { get; set; }
        public string imgUrl { get; set; }
        public string contextUrl { get; set; }
        public string description { get; set; }

    }
}
