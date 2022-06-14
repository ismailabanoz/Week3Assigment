using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3.Data
{
    public  class UnitOfWork : IUnitOfWork
    {
       private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }
        public IDbContextTransaction BeginTransaction()
        {
            return _appDbContext.Database.BeginTransaction();
        }
    }
}
