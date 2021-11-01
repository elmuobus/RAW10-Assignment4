using System.Collections.Generic;
using DataServiceLib.Domain;

namespace DataServiceLib
{
    public interface IDataService
    {
        public Category GetCategory(int id);
        public IList<Category> GetCategories();
        public Category CreateCategory(string name, string description);
        public bool DeleteCategory(int id);
        public bool UpdateCategory(int id, string name, string description);
        public Product GetProduct(int id);
        public IList<ProductByCategoryDto> GetProductByCategory(int categoryId);
        public IList<ProductByNameDto> GetProductByName(string name);
        public IList<Product> GetProducts();
        public bool DeleteProduct(int id);
        public Order GetOrder(int id);
        public IList<Order> GetOrders();
        public IList<OrderDetails> GetOrderDetailsByOrderId(int orderId);
        public IList<OrderDetails> GetOrderDetailsByProductId(int productId);
    }
}