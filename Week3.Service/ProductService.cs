using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.Data;
using Week3.Data.Models;
using Week3.Service.Dtos;
using Week3.Service.Models;

namespace Week3.Service
{
    public class ProductService:IProductService
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(AppDbContext appDbContext, IUnitOfWork unitOfWork)
        {
            _context = appDbContext;
            _unitOfWork = unitOfWork;
        }
        public Response<List<ProductDto>> GetAll()
        {
            var products = _context.Products.ToList();
            var productDtos=products.Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId
            }).ToList();

            if (!productDtos!.Any())
            {
                return new Response<List<ProductDto>>()
                {
                    Data = null,
                    Errors = new List<string>() { "Ürün mevcut değildir."},
                    Status=404
                };
            }

            return new Response<List<ProductDto>>()
            {
                Data = productDtos,
                Errors = null,
                Status=200
            };
        }
        public void Create(Product product)
        {
            _context.Products.Add(product);
            _unitOfWork.Commit();
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _unitOfWork.Commit();
        }
        public void Delete(int productId)
        {
            _context.Products.Remove(GetById(productId));
            _unitOfWork.Commit();
        }
        public Product GetById(int productId)
        {
            return _context.Set<Product>().SingleOrDefault(p=>p.Id==productId);
        }

        // Stored Procedure kullanma örneği
        public Response<List<ProductFullModel>> GetProductFullModel()
        {
            var fullProductList = "sp_full_products";
            var list = _context.ProductFullModels.FromSqlInterpolated($"exec {fullProductList}").ToList();
            return new Response<List<ProductFullModel>>() { Data = list ,Status=200};
        }

        // Transaction Örneği
        public void Save(Product product)
        {
            _context.Products.Add(product);
            using (var transaction=_unitOfWork.BeginTransaction())
            {
                transaction.Commit();
            }
        }

    }
}
