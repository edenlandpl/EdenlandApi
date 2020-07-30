using AutoMapper;
using EdenlandAPI.Domain.Models;
using EdenlandAPI.Domain.Models.Beautician;
using EdenlandAPI.Extensions;
using EdenlandAPI.Resources;
using EdenlandAPI.Resources.Beautician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Mapping
{
    public class ModelToResourcesProfile : Profile
    {
        // inherits Profile, check how put mapping will work
        public ModelToResourcesProfile()
        {
            // create map beetwen Category model and CategoryResources class
            CreateMap<Category, CategoryResources>();

            // configure our mapping between model and resources
            // this syntax tells AutoMapper to use the new extension method to convert out EUnitOfMeasurement value into a string containing its description
            CreateMap<Product, ProductResource>().ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));

            //CreateMap<BeauticianModel, BeauticianResources>().ForMember(be => be.Treatments, opt => opt.MapFrom(d => d.Treatments
            //    .Select(y => y.Treatment).ToList()));

            //CreateMap<TreatmentModel, TreatmentResources>().ForMember(tr => tr.Beauticians, opt => opt.MapFrom(d => d.Beauticians
            //    .Select(y => y.Beautician).ToList()));

            //CreateMap<BeauticiansTreatmentsModel, BeauticiansTreatmentsResources>();

            // to check this 
            //CreateMap<BeauticiansTreatmentsModel, BeauticiansTreatmentsResources>()
            //    .ForMember(bt => bt.Beauticians, opt => opt.MapFrom(src => src.Treatment
            //    .Select(y => y.Beauticians).ToList()))
            //    .ForMember(bt => bt.Treatments, opt => opt.MapFrom(src => src.Beautician
            //    .Select(y => y.Treatments).ToList()));


            //CreateMap<BeauticianModel, BeauticianResources>().ForMember(be => be.Treatments, opt => opt.MapFrom(d => d.Treatments
            //.Select(y => y.TreatmentId).ToList()));

            //CreateMap<TreatmentModel, TreatmentResources>().ForMember(tr => tr.Beauticians, opt => opt.MapFrom(d => d.Beauticians
            //.Select(y => y.BeauticianId).ToList()));


            CreateMap<BeauticianModel, BeauticianResources>();
            CreateMap<TreatmentModel, TreatmentResources>();
        }
    }
}
