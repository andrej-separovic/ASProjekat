using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class OrderLine : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
