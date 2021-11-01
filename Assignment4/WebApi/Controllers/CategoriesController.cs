using System;
using System.Linq;
using DataServiceLib;
using DataServiceLib.Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route(baseCategoriesRoute)]
    public class CategoriesController: Controller
    {
        private const string baseCategoriesRoute = "api/categories";
        private IDataService _dataService;

        public CategoriesController(IDataService dataService)
        {
            _dataService = dataService;
        }
        
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _dataService.GetCategories();
            return Ok(categories.Select(x => GetCategoryViewMode(x)));
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetCategory(int id)
        {
            var category = _dataService.GetCategory(id);

            if (category == null)
                return NotFound();

            return Ok(GetCategoryViewMode(category));
        }
        
        [HttpPost]
        public IActionResult CreateCategory(CategoryViewModel newCategory)
        {
            var category = _dataService.CreateCategory(newCategory.Name, newCategory.Description);

            return Created($"{baseCategoriesRoute}/{category.Id}", category);
        }
        
        [HttpPut("{id:int}")]
        public IActionResult UpdateCategory(int id, CategoryViewModel newCategory)
        {
            var isSucceeded = _dataService.UpdateCategory(newCategory.Id, newCategory.Name, newCategory.Description);

            if (!isSucceeded)
                return NotFound();
            return Ok();
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult CreateCategory(int id)
        {
            var isSucceeded = _dataService.DeleteCategory(id);

            if (!isSucceeded)
                return NotFound();
            return Ok();
        }

        private CategoryViewModel GetCategoryViewMode(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
    }
}