using EdenlandAPI.Domain.Models.Beautician;
using EdenlandAPI.Domain.Services.Communication.Beautician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Services.Beautician
{
    public interface IBeauticiansTreatmentsService
    {
        Task<IEnumerable<BeauticiansTreatmentsModel>> ListAsyncBeauticiansTreatments();
        Task<BeauticiansTreatmentsResponse> SaveAsyncBeauticiansTreatments(BeauticiansTreatmentsModel beauticiansTreatments);
        Task<BeauticiansTreatmentsResponse> UpdateAsyncBeauticiansTreatments(int id, BeauticiansTreatmentsModel beauticiansTreatments);
        Task<BeauticiansTreatmentsResponse> RemoveAsyncBeauticiansTreatments(int id);
    }
}
