using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EdenlandAPI.Domain.Models.Beautician;
using EdenlandAPI.Domain.Services.Beautician;
using EdenlandAPI.Extensions;
using EdenlandAPI.Resources.Beautician;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdenlandAPI.Controllers.Beautician
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : Controller
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IMapper _mapper;

        public TreatmentController(ITreatmentService treatmentService, IMapper mapper)
        {
            _treatmentService = treatmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TreatmentResources>> GetAllAsyncTreatment()
        {
            var treatments = await _treatmentService.ListAsyncTreatment();
            var resources = _mapper.Map<IEnumerable<TreatmentModel>, IEnumerable<TreatmentResources>>(treatments);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsyncTreatment([FromBody] SaveTreatmentResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            var treatment = _mapper.Map<SaveTreatmentResource, TreatmentModel>(resource);
            var result = await _treatmentService.SaveAsyncTreatment(treatment);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var treatmentResources = _mapper.Map<SaveTreatmentResource, TreatmentModel>(resource);
            return Ok(treatmentResources);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsyncTreatment(int id, [FromBody] SaveTreatmentResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            var treatment = _mapper.Map<SaveTreatmentResource, TreatmentModel>(resource);
            var result = await _treatmentService.UpdateAsyncTreatment(id, treatment);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var treatmentResource = _mapper.Map<TreatmentModel, TreatmentResources>(result.Treatment);
            return Ok(treatmentResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncTreatment(int id)
        {
            var result = await _treatmentService.DeleteAsyncTreatment(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var treatmenResource = _mapper.Map<TreatmentModel, TreatmentResources>(result.Treatment);
            return Ok(treatmenResource);
        }
    }
}