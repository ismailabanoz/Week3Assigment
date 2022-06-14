using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.Data.Models;

namespace Week3.Service
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        void Delete(int categoryId);
        void Update(Category category);
        void Create(Category category);
        Category GetById(int categoryId);
    }
}
