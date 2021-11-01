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
    public class ProductsController: Controller
    {
        private const string baseCategoriesRoute = "api/products";
        private IDataService _dataService;

        public ProductsController(IDataService dataService)
        {
            _dataService = dataService;
        }
        
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _dataService.GetProducts();
            return Ok(products.Select(x => GetProductViewMode(x)));
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            var product = _dataService.GetProduct(id);

            if (product == null)
                return NotFound();

            return Ok(GetProductViewMode(product));
        }
        
        [HttpGet("category/{id:int}")]
        public IActionResult GetProductByCategory(int id)
        {
            var products = _dataService.GetProductByCategory(id);

            if (products.Count == 0)
                return NotFound(products);

            return Ok(products);
        }
        
        [HttpGet("name/{str}")]
        public IActionResult GetProductByName(string str)
        {
            var products = _dataService.GetProductByName(str);

            if (products.Count == 0)
                return NotFound(products);

            return Ok(products);
        }

        private ProductViewModel GetProductViewMode(Product category)
        {
            return new ProductViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Category = category.Category
            };
        }
    }
}