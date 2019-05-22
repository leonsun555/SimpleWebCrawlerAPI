using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrawlerAPI.Model
{
    public class Repository : IRepository
    {
        private WebCrawlerDbContext _dbContext;
        public Repository(WebCrawlerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  async Task<List<NewsList>> GetAllAsync()
        {
            var results = await _dbContext.NewsLists.ToListAsync();
            return results;
        }

        public async Task<bool> AddAsync(NewsList newList)
        {
            _dbContext.Add(new NewsList
            {
                id = newList.id,
                date = newList.date,
                description = newList.description,
                imgUrl = newList.imgUrl,
                contextUrl = newList.contextUrl
            });
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
