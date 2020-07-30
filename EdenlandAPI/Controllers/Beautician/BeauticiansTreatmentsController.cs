using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EdenlandAPI.Domain.Models.Beautician;
using EdenlandAPI.Domain.Services.Beautician;
using EdenlandAPI.Resources.Beautician;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdenlandAPI.Controllers.Beautician
{
    [Route("api/[controller]")]
    public class BeauticiansTreatmentsController : ControllerBase
    {
        private readonly IBeauticiansTreatmentsService _beauticiansTreatmentsService;
        private readonly IMapper _mapper;

        public BeauticiansTreatmentsController(IBeauticiansTreatmentsService beauticiansTreatmentsService, IMapper mapper)
        {
            _beauticiansTreatmentsService = beauticiansTreatmentsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BeauticiansTreatmentsResources>> GetAllAsyncBeauticiansTreatments()
        {
            var beauticiansTreatments = await _beauticiansTreatmentsService.ListAsyncBeauticiansTreatments();
            var resources = _mapper.Map<IEnumerable<BeauticiansTreatmentsModel>, IEnumerable<BeauticiansTreatmentsResources>>(beauticiansTreatments);

            return resources;
        }
    }
}