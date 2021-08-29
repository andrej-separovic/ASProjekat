using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.ShippingAddress).IsRequired();
            builder.Property(x => x.OrderDate).IsRequired();
            builder.HasMany(order => order.OrderLines).WithOne(orderLine => orderLine.Order).HasForeignKey(orderLine=>orderLine.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
