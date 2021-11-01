using System;
using System.Collections.Generic;

namespace DataServiceLib.Domain
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

    }
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Required { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }        
    }
}