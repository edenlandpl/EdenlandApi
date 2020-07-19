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
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TreatmentService(ITreatmentRepository treatmentRepository, IUnitOfWork unitOfWork)
        {
            this._treatmentRepository = treatmentRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<TreatmentModel>> ListAsyncTreatment()
        {
            return await _treatmentRepository.ListAsync();
        }
        public async Task<TreatmentResponse> SaveAsyncTreatment(TreatmentModel treatment)
        {
            try
            {
                await _treatmentRepository.AddAsyncTreatment(treatment);
                await _unitOfWork.CompleteAsync();

                return new TreatmentResponse(treatment);
            }
            catch(Exception ex)
            {
                return new TreatmentResponse($"AnError when saving the Treatment: {ex.Message}");
            }
        }
        public async Task<TreatmentResponse> UpdateAsyncTreatment(int id, TreatmentModel treatment)
        {
            var existingTreatment = await _treatmentRepository.FindByIdAsync(id);

            if (existingTreatment == null)
            {
                return new TreatmentResponse("Treatment not found");
            }

            try
            {
                _treatmentRepository.UpdateAsyncTreatment(existingTreatment);
                await _unitOfWork.CompleteAsync();

                return new TreatmentResponse(existingTreatment);
            }
            catch (Exception ex)
            {

                return new TreatmentResponse($"An error occured when updating Treatment: {ex.Message}");
            }
        }

        public async Task<TreatmentResponse> DeleteAsyncTreatment(int id)
        {
            var existingTreatment = await _treatmentRepository.FindByIdAsync(id);

            if (existingTreatment == null)
            {
                return new TreatmentResponse("Treatment not found");
            }

            try
            {
                _treatmentRepository.RemoveAsyncTreatment(existingTreatment);
                await _unitOfWork.CompleteAsync();

                return new TreatmentResponse(existingTreatment);
            }
            catch (Exception ex)
            {
                return new TreatmentResponse($"Ann error occured when deleting the Treatment: {ex.Message}");
            }
        }

    }
}
