using Turbo.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Turbo.BUSINESS.DTOs.Brand;
using Turbo.BUSINESS.Services.Interfaces;
using Turbo.DAL.Repositories.Interfaces;
using AutoMapper;

namespace Turbo.BUSINESS.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repos;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository)
        {
            _repos = brandRepository;
        }

        public async Task<IQueryable<GetBrandDto>> GetAllAsync(Expression<Func<Brand, bool>>? expression = null,
            Expression<Func<Brand, object>>? OrderByExpression = null,
            bool IsDescending = false,
            params string[] Includes)
        {
            var collect = await _repos.GetAllAsync(expression,OrderByExpression,IsDescending,Includes);
            IQueryable<GetBrandDto> result = _mapper.Map<IQueryable<GetBrandDto>>(collect);
            return result;
        }
        public Task<Brand> CreateAsync(CreateBrandDto brand)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Brand> UpdateAsync(UpdateBrandDto brand)
        {
            throw new NotImplementedException();
        }

        public async Task<GetBrandDto> GetByIdAsync(int id,params string[] Includes)
        {
            var a =  await _repos.GetByIdAsync(id, Includes);
            GetBrandDto brand = _mapper.Map<GetBrandDto>(a);
            return brand;
        }

    }
}
