using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrawler_1.Data
{
    public class WebCrawlerDB : DbContext
    {
        public WebCrawlerDB(DbContextOptions<WebCrawlerDB> options)
            : base(options)
        {

        }
        public DbSet<WebCrawler_1.Models.GetUrlList> UrlLists { get; set; }
    }

        
    
}
