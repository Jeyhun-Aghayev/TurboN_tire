using Turbo.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Turbo.BUSINESS.DTOs.Brand;

namespace Turbo.BUSINESS.Services.Interfaces
{
    public interface IBrandService
    {
        Task<IQueryable<GetBrandDto>> GetAllAsync(Expression<Func<Brand, bool>>? expression = null,
            Expression<Func<Brand, object>>? OrderByExpression = null,
            bool IsDescending = false,
            params string[] Includes);
        Task<GetBrandDto> GetByIdAsync(int id,params string[] Includes);
        Task<Brand> UpdateAsync(UpdateBrandDto brand);
        Task<Brand> CreateAsync(CreateBrandDto brand);
        void DeleteAsync(int id);

    }
}
