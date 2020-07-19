using AutoMapper;
using EdenlandAPI.Domain.Models;
using EdenlandAPI.Domain.Services;
using EdenlandAPI.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdenlandAPI.Extensions;

namespace EdenlandAPI.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        // constructor create new instance and receive an instance of ICategoryService
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // method to handle request, framework pipeline handles the serialization of data to a JSON, IEnumerable<Category> type tells the framework that we want to return 
        // an enumaration of categories, and the task type, preceded by the async keyword, tells the pipelinethat this method should be executed asynchronously
        // finally, we have to use await keyword for tasks that can take a while

        // use AutoMapper to handle our objectts mapping
        [HttpGet]
        public async Task<IEnumerable<CategoryResources>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResources>>(categories);
            return resources;
        }

        // Task method are called actions, becouse can return more than one result
        // If is Ok method return 200, if something wrong 400
        // The FromBody attribute tells ASP.NET Core to parse the request body data into our new resource class. 
        //      It means that when a JSON containing the category name is sent to our application, the framework will automatically parse it to our new class.
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            // validate Request Body Using the Model State
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            // map resource to respective model class
            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);


            // after validating the request data and mapping the resources to uor model, we pass it to out service to persist the data
            // if somethng fails, the API returns a bad request, id not API maps the new category (now including data such as the new Id) to our categoryResources and sends it to the client
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResources = _mapper.Map<Category, CategoryResources>(result.Category);
            return Ok(categoryResources);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResources>(result.Category);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Category, CategoryResources>(result.Category);
            return Ok(categoryResource);
        }
        
    }
}
