using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week3.Data.Models;
using Week3.Service;
using Week3.Service.Models;

namespace Week3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }
        [HttpGet("{categoryId}")]
        public IActionResult Get(int categoryId)
        {
            var category = _categoryService.GetById(categoryId);
            return Ok(category);
        }
        [HttpPost]
        public IActionResult Save(Category category)
        {
            _categoryService.Create(category);
            return Save(category);
        }
        [HttpPut]
        public IActionResult Update(Category category)
        {
            _categoryService.Update(category);
            return Update(category);
        }
        [HttpDelete("{categoryId}")]
        public IActionResult Delete(int categoryId)
        {
            _categoryService.Delete(categoryId);
            return Delete(categoryId);
        }
    }
}
