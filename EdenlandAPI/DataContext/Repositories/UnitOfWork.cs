using EdenlandAPI.DataContext.Context;
using EdenlandAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.DataContext.Repositories
{
    // simply implementation that will only save all changes into the database after you finish modyfifying it using your repositories
    // EF Core already implement the repository pattern and unit of work - we don't have to care abour a rollback method
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
