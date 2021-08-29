using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OS { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string PSU { get; set; }
        public string FormFactor { get; set; }
        public string ImageUrl { get; set; }
        public int Warranty { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }

    public class ProductNoIdDto
    {
        public string Name { get; set; }
        public string OS { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string PSU { get; set; }
        public string FormFactor { get; set; }
        public string ImageUrl { get; set; }
        public int Warranty { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }

    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string OS { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string PSU { get; set; }
        public string FormFactor { get; set; }
        public string ImageUrl { get; set; }
        public int Warranty { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
    }
}
