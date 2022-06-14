using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.Data;
using Week3.Data.Models;

namespace Week3.Service.Models
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
        public void Create(Category category)
        {
            _context.Add(category);
            _unitOfWork.Commit();
        }
        public void Update(Category category)
        {
            _context.Update(category);
            _unitOfWork.Commit();
        }
        public void Delete(int categoryId)
        {
            _context.Remove(GetById(categoryId));
            _unitOfWork.Commit();
        }
        public Category GetById(int categoryId)
        {
            return _context.Set<Category>().SingleOrDefault(p => p.Id == categoryId);
        }
    }
}
