using System.Collections.Generic;
using System.Linq;
using DataServiceLib.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataServiceLib
{
    public class DataService: IDataService
    {

        private readonly NorthwindContext _ctx;

        public DataService()
        {
            _ctx = new NorthwindContext();
        }

        public static DataService CreateInstance()
        {
            return new DataService();
        }

        public Category GetCategory(int id)
        {
            return _ctx.Categories.Find(id);
        }
        
        public IList<Category> GetCategories()
        {
            return _ctx.Categories.ToList();
        }

        public Category CreateCategory(string name, string description)
        {
            var category = new Category()
            {
                Id = _ctx.Categories.Max(x => x.Id) + 1,
                Name = name,
                Description = description,
            };
            _ctx.Add(category);
            _ctx.SaveChanges();
            return category;
        }
        
        public bool DeleteCategory(int id)
        {
            var categoryToRemove = _ctx.Categories.Find(id);
            if (categoryToRemove == null)
                return false;
            _ctx.Categories.Remove(categoryToRemove);
            return _ctx.SaveChanges() > 0;
        }
        
        public bool UpdateCategory(int id, string name, string description)
        {
            var categoryToUpdate = _ctx.Categories.Find(id);
            if (categoryToUpdate == null)
                return false;
            categoryToUpdate.Name = name;
            categoryToUpdate.Description = description;
            return _ctx.SaveChanges() > 0;
        }

        public Product GetProduct(int id)
        {
            return _ctx.Products.Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
        }

        public IList<ProductByCategoryDto> GetProductByCategory(int categoryId)
        {
            return _ctx.Products.Where(x => x.CategoryId == categoryId)
                .Include(x => x.Category)
                .Select(x => new ProductByCategoryDto()
                {
                    Name = x.Name,
                    CategoryName = x.Category.Name,
                })
                .ToList();
        }

        public IList<ProductByNameDto> GetProductByName(string name)
        {
            return _ctx.Products.Where(x => x.Name.Contains(name))
                .Select(x => new ProductByNameDto()
                {
                    ProductName = x.Name,
                })
                .ToList();
        }
        
        public IList<Product> GetProducts()
        {
            return _ctx.Products.ToList();
        }

        public bool DeleteProduct(int id)
        {
            var productToRemove = _ctx.Products.Find(id);
            if (productToRemove == null)
                return false;
            _ctx.Products.Remove(productToRemove);
            return _ctx.SaveChanges() > 0;
        }

        public Order GetOrder(int id)
        {
            return _ctx.Orders
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
        }

        public IList<Order> GetOrders()
        {
            return _ctx.Orders.ToList();
        }

        public IList<OrderDetails> GetOrderDetailsByOrderId(int orderId)
        {
            return _ctx.OrdersDetails.Where(x => x.OrderId == orderId)
                .Include(x => x.Order)
                .Include(x => x.Product)
                .ToList();
        }
        
        public IList<OrderDetails> GetOrderDetailsByProductId(int productId)
        {
            return _ctx.OrdersDetails.Where(x => x.ProductId == productId)
                .Include(x => x.Order)
                .Include(x => x.Product)
                .ToList();
        }
    }
}