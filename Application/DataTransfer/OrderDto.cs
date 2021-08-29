using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class OrderSearchDto
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
    }

    public class OrderCreateDto
    {
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<OrderLineDto> OrderLines { get; set; }
    }

    public class OrderEditDto
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
