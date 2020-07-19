using EdenlandAPI.Domain.Models.Beautician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Repositories.Beautician
{
    public interface IBeauticianRepository
    {
        Task<IEnumerable<BeauticianModel>> ListAync();
        Task AddAsyncBeautician(BeauticianModel beautician);
        Task<BeauticianModel> FindByIdAsync(int id);
        void UpdateAsyncBeautician(BeauticianModel beautician);
        void RemoveAsyncBeautician(BeauticianModel beautician);
    }
}
