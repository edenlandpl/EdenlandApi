using EdenlandAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Repositories
{
    // interface to talk with database, encapsulate logic to handle data access
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);
        // method asynchrously return a category from database
        Task<Category> FindByIdAsync(int id);
        // method Update isn't asynchrously since EF Core API does not require an asynchronos methos to update model
        void Update(Category category);
        void Remove(Category category);
    }
}
