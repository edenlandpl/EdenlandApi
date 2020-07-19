using EdenlandAPI.DataContext.Context;
using EdenlandAPI.Domain.Models.Beautician;
using EdenlandAPI.Domain.Repositories.Beautician;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.DataContext.Repositories.Beautician
{
    public class TreatmentRepository : BaseRepository, ITreatmentRepository
    {
        public TreatmentRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<TreatmentModel>> ListAsync()
        {
            return await _context.Treatments.Include(p => p.Beauticians).ToListAsync();
        }

        public async Task AddAsyncTreatment(TreatmentModel treatment)
        {
            await _context.Treatments.AddAsync(treatment);
        }

        public async Task<TreatmentModel> FindByIdAsync(int id)
        {
            return await _context.Treatments.FindAsync(id);
        }

        public void UpdateAsyncTreatment(TreatmentModel treatment)
        {
            _context.Treatments.Update(treatment);
        }

        public void RemoveAsyncTreatment(TreatmentModel treatment)
        {
            _context.Treatments.Remove(treatment);
        }
    }
}
