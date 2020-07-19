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
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(prop => prop.Category).ToListAsync();
        }
    }
}
