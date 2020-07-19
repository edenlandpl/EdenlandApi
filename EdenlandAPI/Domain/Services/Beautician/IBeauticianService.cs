using EdenlandAPI.Domain.Models.Beautician;
using EdenlandAPI.Domain.Services.Communication.Beautician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Services.Beautician
{
    public interface IBeauticianService
    {
        Task<IEnumerable<BeauticianModel>> ListAsyncBeautician();
        Task<BeauticianResponse> SaveAsyncBeautician(BeauticianModel beautician);
        Task<BeauticianResponse> UpdateAsyncBeautician(int id, BeauticianModel beautician);
        Task<BeauticianResponse> DeleteAsyncBeautician(int id);
    }
}
