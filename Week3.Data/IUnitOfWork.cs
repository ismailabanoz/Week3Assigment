using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3.Data
{
    public interface IUnitOfWork
    {
        int Commit();
        IDbContextTransaction BeginTransaction();
    }
}
