using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.Data;
using Week3.Data.Models;

namespace Week3.Service
{
    public class ProductFeatureService : IProductFeatureService
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public ProductFeatureService(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public List<ProductFeature> GetAll()
        {
           return _context.ProductFeatures.ToList();
        }
        public void Create(ProductFeature productFeature)
        {
            _context.Add(productFeature);
            _unitOfWork.Commit();
        }
        public void Update(ProductFeature productFeature)
        {
            _context.Update(productFeature);
            _unitOfWork.Commit();
        }
        public void Delete(int productFeatureId)
        {
            _context.Remove(GetById(productFeatureId));
            _unitOfWork.Commit();
        }
        public ProductFeature GetById(int productFeatureId)
        {
            return _context.Set<ProductFeature>().SingleOrDefault(p => p.Id == productFeatureId);
        }
    }
}
