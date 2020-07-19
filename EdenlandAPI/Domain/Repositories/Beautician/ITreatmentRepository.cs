using EdenlandAPI.Domain.Models.Beautician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Repositories.Beautician
{
    public interface ITreatmentRepository
    {
        Task<IEnumerable<TreatmentModel>> ListAsync();
        Task AddAsyncTreatment(TreatmentModel treatment);
        Task<TreatmentModel> FindByIdAsync(int id);
        void UpdateAsyncTreatment(TreatmentModel treatment);
        void RemoveAsyncTreatment(TreatmentModel treatment);
    }
}
