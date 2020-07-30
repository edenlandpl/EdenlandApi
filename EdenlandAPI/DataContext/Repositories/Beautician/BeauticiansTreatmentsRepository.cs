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
    public class BeauticiansTreatmentsRepository : BaseRepository, IBeauticiansTreatmentsRepository
    {

        public BeauticiansTreatmentsRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<BeauticiansTreatmentsModel>> ListAsyncBeauticiansTreatments()
        {
            // dobre do uruchomienia many-to-many - ze środkowego modelu
            return await _context.BeaticiansTreatments.Include(s => s.Treatment).Include(p => p.Beautician).ToListAsync();            
        }
        public async Task AddAsyncBeauticiansTreatments(BeauticiansTreatmentsModel beauticiansTreatments)
        {
            await _context.BeaticiansTreatments.AddAsync(beauticiansTreatments);
        }

        public async Task<BeauticiansTreatmentsModel> FindByIdBeauticiansTreatments(int id)
        {
            return await _context.BeaticiansTreatments.FindAsync(id);
        }        
        
        public void UpdateAsyncBeauticiansTreatments(BeauticiansTreatmentsModel beauticiansTreatments)
        {
            _context.BeaticiansTreatments.Update(beauticiansTreatments);
        }       
        public void RemoveAsyncBeauticiansTreatments(BeauticiansTreatmentsModel beauticiansTreatments)
        {
            _context.BeaticiansTreatments.Remove(beauticiansTreatments);
        }
    }
}