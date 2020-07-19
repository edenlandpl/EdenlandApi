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
    public class BeauticianController : Controller
    {
        private readonly IBeauticianService _beauticianService;
        private readonly IMapper _mapper;

        public BeauticianController(IBeauticianService beauticianService, IMapper mapper)
        {
            _beauticianService = beauticianService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BeauticianResources>> GetAllAsyncBeautician()
        {
            var beauticians = await _beauticianService.ListAsyncBeautician();
            var resources = _mapper.Map<IEnumerable<BeauticianModel>, IEnumerable<BeauticianResources>>(beauticians);
            return resources;
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetBeautician(int id)
        {
            var beauticians = await _beauticianService.ListAsyncBeautician();
            var resources = _mapper.Map<IEnumerable<BeauticianModel>, IEnumerable<BeauticianResources>>(beauticians);

            return Ok(resources);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsyncBeautician([FromBody] SaveBeauticianResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            var beautician = _mapper.Map<SaveBeauticianResource, BeauticianModel>(resource);
            var result = await _beauticianService.SaveAsyncBeautician(beautician);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var beauticianResources = _mapper.Map<SaveBeauticianResource, BeauticianModel>(resource);
            return Ok(beauticianResources);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsyncBeautician(int id, [FromBody] SaveBeauticianResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            var beautician = _mapper.Map<SaveBeauticianResource, BeauticianModel>(resource);
            var result = await _beauticianService.UpdateAsyncBeautician(id, beautician);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var beauticianResource = _mapper.Map<BeauticianModel, BeauticianResources>(result.Beautician);
            return Ok(beauticianResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsyncBeautician(int id)
        {
            var result = await _beauticianService.DeleteAsyncBeautician(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var beauticianResource = _mapper.Map<BeauticianModel, BeauticianResources>(result.Beautician);
            return Ok(beauticianResource);
        }
    }
}