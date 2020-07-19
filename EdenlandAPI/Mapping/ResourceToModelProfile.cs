using AutoMapper;
using EdenlandAPI.Domain.Models;
using EdenlandAPI.Domain.Models.Beautician;
using EdenlandAPI.Resources;
using EdenlandAPI.Resources.Beautician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Mapping
{
    // mapping profile to transform models into resources
    public class ResourceToModelProfile : Profile
    {
        // AutoMapper will automatically register this profile when the application starts
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveBeauticianResource, BeauticianModel>();
            CreateMap<SaveTreatmentResource, TreatmentModel>();
        }
    }
}
