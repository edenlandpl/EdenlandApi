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
    public class BeauticianRepository : BaseRepository, IBeauticianRepository
    {
        public BeauticianRepository(AppDbContext context) : base(context) { }

        // tutaj zmienione - sprawdź czy poprawnie działa
        public async Task<IEnumerable<BeauticianModel>> ListAync()
        {
            // dobre do uruchomienia many-to-many - ze środkowego modelu
            var x = _context.BeaticiansTreatments.Include(s => s.Treatment).Include(p => p.Beautician).ToList();
            // nie działa
            //var bea = _context.Beauticians.Include(p => p.BeauticiansTreatments).ThenInclude(s => s.Select( s => s.Treatments)).ToList();
            return await _context.Beauticians.Include(p => p.Treatments).ToListAsync();
        }

        public async Task AddAsyncBeautician(BeauticianModel beautician)
        {
            await _context.Beauticians.AddAsync(beautician);
        }

        public async Task<BeauticianModel> FindByIdAsync(int id)
        {
            return await _context.Beauticians.FindAsync(id);
        }

        public void UpdateAsyncBeautician(BeauticianModel beautician)
        {
            _context.Beauticians.Update(beautician);
        }
        // EF Core requires the instance of out model to bepassed to the Remove method to correctly understand which model we're deleting, instead of simply passing an Id
        public void RemoveAsyncBeautician(BeauticianModel beautician)
        {
            _context.Beauticians.Remove(beautician);
        }
    }
}
