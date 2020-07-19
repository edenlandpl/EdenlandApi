using System.Collections.Generic;
using EdenlandAPI.Domain.Models;
using System.Threading.Tasks;
using EdenlandAPI.Domain.Services.Communication;

namespace EdenlandAPI.Domain.Services
{
    public interface ICategoryService
    {
        // implementation method, asynchronously return an enumeration of categories
        // Task encaplulation the return, indicates asynchrony, asynchronous due to the fact we have wait for the database to complete operation to return the data
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);
    }
}
