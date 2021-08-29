using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.OS).IsRequired();
            builder.Property(x => x.CPU).IsRequired();
            builder.Property(x => x.GPU).IsRequired();
            builder.Property(x => x.RAM).IsRequired();
            builder.Property(x => x.Storage).IsRequired();
            builder.Property(x => x.PSU).IsRequired();
            builder.Property(x => x.FormFactor).IsRequired();
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x => x.Warranty).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasMany(product => product.OrderLines).WithOne(orderLine => orderLine.Product).HasForeignKey(orderLine => orderLine.ProductId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
