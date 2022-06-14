using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week3.Data.Models;
using Week3.Service;

namespace Week3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var response =  _productService.GetAll();
            return new ObjectResult(response) { StatusCode=response.Status}; 
        }
        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            var product = _productService.GetById(productId);
            return Ok(product);
        }
        [HttpGet("GetProductFull")]
        public IActionResult GetProductFull()
        {
            var response = _productService.GetProductFullModel();
            return new ObjectResult(response) { StatusCode = response.Status };
        }
        [HttpPost]
        public IActionResult Save(Product product)
        {
            _productService.Create(product);
            return Save(product);
        }
        [HttpPut]
        public IActionResult Update(Product product)
        {
            _productService.Update(product);
            return Update(product);
        }
        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            return Delete(productId);
        }
    }
}
