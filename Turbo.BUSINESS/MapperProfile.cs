using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.BUSINESS.DTOs.Brand;
using Turbo.CORE.Entities;
namespace Turbo.BUSINESS
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<IQueryable<Brand>, IQueryable<CreateBrandDto>>();
            CreateMap<IQueryable<CreateBrandDto>, IQueryable<Brand>>();
            CreateMap<Brand, CreateBrandDto>();
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<Brand, UpdateBrandDto>();
            CreateMap<UpdateBrandDto, Brand>();
        }
    }
}
