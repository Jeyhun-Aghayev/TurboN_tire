using DocuSign.eSign.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Turbo.CORE.Entities.Common;
using Turbo.DAL.Context;
using Turbo.DAL.Repositories.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Turbo.DAL.Repositories.Implementatios
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _db;

        public Repository(AppDbContext db)
        {
            _db = db;
        }

        public DbSet<T> Table => _db.Set<T>();

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T,bool>>? expression=null,
            Expression<Func<T,object>>? OrderByExpression=null,
            bool IsDescending = false,
            params string[] Includes
            )
        {
            IQueryable<T> query = Table.Where(b=>!b.IsDeleted);
            if(expression is not null)
            {
                query = query.Where(expression);
            }
            if(OrderByExpression is not null)
            {
                query = IsDescending ? query.OrderByDescending(OrderByExpression) : query.OrderBy(OrderByExpression);
            }
            if (Includes is not null)
            {
                for (int i = 0; i < Includes.Length; i++)
                {
                    query = query.Include(Includes[i]);
                }
            }
            return query;
        }

        public async Task<T> GetByIdAsync(int id, params string[] Includes)
        {
            IQueryable<T> entity =  Table.Where(b => !b.IsDeleted&&b.Id==id);
            if (Includes is not null)
            {
                for (int i = 0; i < Includes.Length; i++)
                {
                    entity = entity.Include(Includes[i]);
                }
            }
            return await entity.FirstOrDefaultAsync();
        }
    }
}
