using EdenlandAPI.Domain.Models;
using EdenlandAPI.Domain.Repositories;
using EdenlandAPI.Domain.Services;
using EdenlandAPI.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Services
{
    public class CategoryService : ICategoryService
    {
        // get from category repository a list of objects
        // implementation real logic to the category repository
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        // jeśli błąd z dostępnością - zmień na public interface ICategoryService
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        // listing method, using instance of ICategoryRepository to return the data
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        // first, we try add the new category to the database and hen the API try to save it, wrapping everything inside a try-catch block
        // if fails, the API calls fictional logging service and return a response indicating failure
        // if the process finishes with no problems, the application returns a success response, sending out category data
        public async Task<CategoryResponse> SaveAsync(Category category)
        {
        //Tip: In real world applications, you shouldn’t wrap everything inside a generic try-catch block, but instead you should handle all possible errors separately.
        //Simply adding a try-catch block won’t cover most of the possible failing scenarios. Be sure to correct implement error handling
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                // Do some logging staff
                return new CategoryResponse($"An error occured when saving the category: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            // API tries to get category from the database, if result is null we return response telling that the category does not exist
            if (existingCategory == null)
            {
                return new CategoryResponse("Category not found");
            }
            // if category exist we need to set its new name
            //API then, tries to save changes, when process completes, the service returns a success response, if not logging logic executes
            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoryResponse($"An error occured when updating the category: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
            {
                return new CategoryResponse("Category not found");               
            } 

            try
                {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
                }
                catch (Exception ex)
                {

                return new CategoryResponse($"An error occured when deleting the category: {ex.Message}");
                }
        }
    }
}
