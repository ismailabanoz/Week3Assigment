using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week3.Data.Models;
using Week3.Service;

namespace Week3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeaturesController : ControllerBase
    {
        private readonly ProductFeatureService _productFeatureService;
        public ProductFeaturesController(ProductFeatureService productFeatureService)
        {
            _productFeatureService = productFeatureService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var productFeatures = _productFeatureService.GetAll();
            return Ok(productFeatures);
        }
        [HttpGet("{productFeatureId}")]
        public IActionResult Get(int productFeatureId)
        {
            var productFeature = _productFeatureService.GetById(productFeatureId);
            return Ok(productFeature);
        }
        [HttpPost]
        public IActionResult Save(ProductFeature productFeatureId)
        {
            _productFeatureService.Create(productFeatureId);
            return Save(productFeatureId);
        }
        [HttpPut]
        public IActionResult Update(ProductFeature productFeatureId)
        {
            _productFeatureService.Update(productFeatureId);
            return Update(productFeatureId);
        }
        [HttpDelete("{productFeatureId}")]
        public IActionResult Delete(int productFeatureId)
        {
            _productFeatureService.Delete(productFeatureId);
            return Delete(productFeatureId);
        }
    }
}
