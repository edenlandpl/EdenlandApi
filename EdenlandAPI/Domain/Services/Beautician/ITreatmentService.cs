using EdenlandAPI.Domain.Models.Beautician;
using EdenlandAPI.Domain.Services.Communication.Beautician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Services.Beautician
{
    public interface ITreatmentService
    {
        Task<IEnumerable<TreatmentModel>> ListAsyncTreatment();
        Task<TreatmentResponse> SaveAsyncTreatment(TreatmentModel treatment);
        Task<TreatmentResponse> UpdateAsyncTreatment(int id, TreatmentModel treatment);
        Task<TreatmentResponse> DeleteAsyncTreatment(int id);
    }
}
