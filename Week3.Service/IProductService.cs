using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.Data.Models;
using Week3.Service.Dtos;
using Week3.Service.Models;

namespace Week3.Service
{
    public interface IProductService
    {
        Response<List<ProductDto>> GetAll();
        void Delete(int productId);
        void Update(Product product);
        void Create(Product product);
        Product GetById(int productId);
    }
}
