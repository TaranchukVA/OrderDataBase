using Microsoft.EntityFrameworkCore;
using OrderDataBase.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDataBase.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        { }
        public DbSet<TOrder> Order { get; set; }
        public DbSet<TProduct> Product { get; set; }
    }
}
