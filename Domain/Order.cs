using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Order : BaseEntity
    {
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
