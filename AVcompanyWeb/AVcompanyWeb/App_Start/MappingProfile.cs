using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AVcompanyWeb.Models;
using AVcompanyWeb.ViewModels;

namespace AVcompanyWeb.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductViewModel, Product>().ReverseMap();
            CreateMap<CategoryViewModel, Category>().ReverseMap();
            CreateMap<UploadViewModel, Upload>().ReverseMap();
            CreateMap<SubCategoryViewModel, SubCategory>().ReverseMap();
            CreateMap<PriceType, PriceTypeViewModel>().ReverseMap();
            CreateMap<WoodProtectionType, WoodProtectionTypeViewModel>().ReverseMap();
            CreateMap<WoodType, WoodType>().ReverseMap();
        }
    }
}