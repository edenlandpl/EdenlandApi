using EdenlandAPI.DataContext.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.DataContext.Repositories
{
    public abstract class BaseRepository
    {
        // abstract class don't have direct instance, Baserepository receives an instance of AppDbContext throught dependency injection and exposes a protected property (accesible only for children classes)
        // that gives access to all methods we need to handle database operations
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
