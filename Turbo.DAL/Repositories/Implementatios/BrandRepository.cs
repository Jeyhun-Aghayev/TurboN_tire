using Turbo.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.DAL.Context;
using Turbo.DAL.Repositories.Interfaces;

namespace Turbo.DAL.Repositories.Implementatios
{
    public class BrandRepository:Repository<Brand>,IBrandRepository
    {
        public BrandRepository(AppDbContext db):base(db)
        {
        }

    }
}
