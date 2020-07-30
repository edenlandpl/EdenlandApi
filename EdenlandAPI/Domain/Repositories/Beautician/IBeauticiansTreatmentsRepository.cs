using EdenlandAPI.Domain.Models.Beautician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Repositories.Beautician
{
    public interface IBeauticiansTreatmentsRepository
    {
        Task<IEnumerable<BeauticiansTreatmentsModel>> ListAsyncBeauticiansTreatments();
        Task AddAsyncBeauticiansTreatments(BeauticiansTreatmentsModel beauticiansTreatments);
        Task<BeauticiansTreatmentsModel> FindByIdBeauticiansTreatments(int id);
        void UpdateAsyncBeauticiansTreatments(BeauticiansTreatmentsModel beauticiansTreatments);
        void RemoveAsyncBeauticiansTreatments(BeauticiansTreatmentsModel beauticiansTreatments);
    }
}
