namespace DataServiceLib.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryId { get; set; }        
        public Category Category { get; set; }
    }

    public class ProductByCategoryDto
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
    public class ProductByNameDto
    {
        public string ProductName { get; set; }
    }
    
}