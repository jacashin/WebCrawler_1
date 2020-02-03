using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCrawler_1.Models;

namespace WebCrawler_1.Data
{
    public class WebCrawler_1Context : DbContext
    {
        public WebCrawler_1Context(DbContextOptions<WebCrawler_1Context> options)
            : base(options)
        {
        }

        public DbSet<GetUrl> GetUrls { get; set; }

        public WebCrawler_1Context()
        {

        }
    }
}
