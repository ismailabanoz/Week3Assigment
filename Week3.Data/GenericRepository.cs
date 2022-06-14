using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3.Data
{
    public class GenericRepository<T> : IRepository<T>
        where T:class 
    {
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext appDbContext)
        {
            _dbSet = appDbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            _dbSet.Remove(GetById(id));
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }



        public List<T> GetAll()
        {

            
            return _dbSet.ToList();


        }


        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
