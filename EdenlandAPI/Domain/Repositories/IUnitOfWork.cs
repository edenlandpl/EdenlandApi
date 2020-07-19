using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Repositories
{
    // class to use transaction - that is basically a feature most databases implement to save data only after a comlex operation finishes
    // this pattern consists of a class that receives our AppDbContext instance as a dependency and eposes nethods to start, complete or abort transactions
    public interface IUnitOfWork
    {
        // method complete data management operations
        Task CompleteAsync();
    }
}
