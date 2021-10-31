using DataServiceLib.Domain;

namespace WebApi.ViewModels
{
    public class ProductViewModel
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; } 
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}