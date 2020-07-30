using EdenlandAPI.DataContext.Repositories;
using EdenlandAPI.DataContext.Repositories.Beautician;
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
    public class BeauticiansTreatmentsService : IBeauticiansTreatmentsService
    {
        private readonly IBeauticiansTreatmentsRepository _beauticiansTreatmentsRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BeauticiansTreatmentsService(IBeauticiansTreatmentsRepository beauticiansTreatmentsRepository, IUnitOfWork unitOfWork)
        {
            this._beauticiansTreatmentsRepository = beauticiansTreatmentsRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<BeauticiansTreatmentsModel>> ListAsyncBeauticiansTreatments()
        {
            return await _beauticiansTreatmentsRepository.ListAsyncBeauticiansTreatments();
        }
        public async Task<BeauticiansTreatmentsResponse> SaveAsyncBeauticiansTreatments(BeauticiansTreatmentsModel beauticiansTreatments)
        {
            try
            {
                await _beauticiansTreatmentsRepository.AddAsyncBeauticiansTreatments(beauticiansTreatments);
                await _unitOfWork.CompleteAsync();

                return new BeauticiansTreatmentsResponse(beauticiansTreatments);
            }
            catch (Exception ex)
            {
                return new BeauticiansTreatmentsResponse($"An error occured when saving BeauticiansTreatments : {ex.Message}");
            }
        }

        public async Task<BeauticiansTreatmentsResponse> UpdateAsyncBeauticiansTreatments(int id, BeauticiansTreatmentsModel beauticiansTreatments)
        {
            var existingBeauticiansTreatments = await _beauticiansTreatmentsRepository.FindByIdBeauticiansTreatments(id);

            if (existingBeauticiansTreatments == null)
            {
                return new BeauticiansTreatmentsResponse("BeauticiansTreatments Not found");
            }

            try
            {
                _beauticiansTreatmentsRepository.UpdateAsyncBeauticiansTreatments(existingBeauticiansTreatments);
                await _unitOfWork.CompleteAsync();

                return new BeauticiansTreatmentsResponse(existingBeauticiansTreatments);
            }
            catch (Exception ex)
            {
                return new BeauticiansTreatmentsResponse($"An error occured when update BeauticiansTreatments : {ex.Message}");
            }
        }
        public async Task<BeauticiansTreatmentsResponse> RemoveAsyncBeauticiansTreatments(int id)
        {
            var existingBeauticiansTreatments = await _beauticiansTreatmentsRepository.FindByIdBeauticiansTreatments(id);

            if (existingBeauticiansTreatments == null)
            {
                return new BeauticiansTreatmentsResponse("BeauticiansTreatments not found");
            }

            try
            {
                _beauticiansTreatmentsRepository.RemoveAsyncBeauticiansTreatments(existingBeauticiansTreatments);
                await _unitOfWork.CompleteAsync();

                return new BeauticiansTreatmentsResponse(existingBeauticiansTreatments);
            }
            catch (Exception ex)
            {
                return new BeauticiansTreatmentsResponse($"An error when deleting BeauticiansTreatments : {ex.Message}");
            }
        }
    }
}
