using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrawlerAPI.Model
{
    public interface IRepository
    {
        Task<List<NewsList>> GetAllAsync();
        Task<bool> AddAsync(NewsList newList);
    }
}
