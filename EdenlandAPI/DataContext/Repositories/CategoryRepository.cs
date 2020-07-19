using EdenlandAPI.DataContext.Context;
using EdenlandAPI.Domain.Models;
using EdenlandAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.DataContext.Repositories
{
    // repository inherits the BaseRepository and implements ICategoryRepository
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        // real implement the repository logic
        public CategoryRepository(AppDbContext context) : base(context) { }

        // the Categories database set access to categories table and call the extension methos ToListAsync, which is responsiblefor transforming the result of a query into collection of categories
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        // here we simply adding a new category to out set
        // when we add a class to s DbSet<> EF Core starts tracking all changes that happen to our model and uses this data to the current state to generate queries that will insert, update or delete models
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
        // EF Core requires the instance of out model to bepassed to the Remove method to correctly understand which model we're deleting, instead of simply passing an Id
        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}
