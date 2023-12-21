using DocuSign.eSign.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Turbo.CORE.Entities.Common;

namespace Turbo.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        DbSet<T> Table { get; }
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>? OrderByExpression = null,
            bool IsDescending = false,
            params string[] Includes
            );
        Task<T> GetByIdAsync(int id, params string[] Includes);
    }
}
