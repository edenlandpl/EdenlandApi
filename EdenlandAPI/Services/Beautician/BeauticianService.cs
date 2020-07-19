using EdenlandAPI.Domain.Models.Beautician;
using EdenlandAPI.Domain.Repositories;
using EdenlandAPI.Domain.Repositories.Beautician;
using EdenlandAPI.Domain.Services.Beautician;
using EdenlandAPI.Domain.Services.Communication.Beautician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Services.Beautician
{
    public class BeauticianService : IBeauticianService
    {
        private readonly IBeauticianRepository _beauticianRepository;
        private readonly IUnitOfWork _unitOfWork;

        // jeśli błąd z dostępnością - zmień na public interface ICategoryService

        public BeauticianService(IBeauticianRepository beauticianRepository, IUnitOfWork unitOfWork)
        {
            this._beauticianRepository = beauticianRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<BeauticianModel>> ListAsyncBeautician()
        {
            return await _beauticianRepository.ListAync();
        }

        public async Task<BeauticianResponse> SaveAsyncBeautician(BeauticianModel beautician)
        {
            try
            {
                await _beauticianRepository.AddAsyncBeautician(beautician);
                await _unitOfWork.CompleteAsync();

                return new BeauticianResponse(beautician);
            }
            catch (Exception ex)
            {

                return new BeauticianResponse($"An Error when saving the Beautician: {ex.Message}");
            }
        }
        public async Task<BeauticianResponse> UpdateAsyncBeautician(int id, BeauticianModel beautician)
        {
            var existingBeautician = await _beauticianRepository.FindByIdAsync(id);

            if (existingBeautician == null)
            {
                return new BeauticianResponse("Beautician not found");
            }
            try
            {
                _beauticianRepository.UpdateAsyncBeautician(existingBeautician);
                await _unitOfWork.CompleteAsync();

                return new BeauticianResponse(existingBeautician);
            }
            catch (Exception ex)
            {
                return new BeauticianResponse($"An error occured when updating Beautician: {ex.Message}");
            }
        }

        public async Task<BeauticianResponse> DeleteAsyncBeautician(int id)
        {
            var existingBeautician = await _beauticianRepository.FindByIdAsync(id);
            if (existingBeautician == null)
            {
                return new BeauticianResponse("Beautician not found");
            }

            try
            {
                _beauticianRepository.RemoveAsyncBeautician(existingBeautician);
                await _unitOfWork.CompleteAsync();

                return new BeauticianResponse(existingBeautician);
            }
            catch (Exception ex)
            {
                return new BeauticianResponse($"Ann error occured when deleting the Beautician: {ex.Message}");
            }
        }
    }
}
