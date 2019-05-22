using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrawlerAPI.Model
{
    public class WebCrawlerDbContext : DbContext
    {
        public WebCrawlerDbContext(DbContextOptions options) : 
            base(options) {
        }

        public WebCrawlerDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<NewsList>().HasKey(c => c.id);
            base.OnModelCreating(builder);
        }

        public DbSet<NewsList> NewsLists { get; set; }
    }
}
