using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.Data.Models;

namespace Week3.Service
{
    public interface IProductFeatureService
    {
        List<ProductFeature> GetAll();
        void Delete(int productFeatureId);
        void Update(ProductFeature productFeature);
        void Create(ProductFeature productFeature);
        ProductFeature GetById(int productFeatureId);
    }
}
