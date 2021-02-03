using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : Db tabloları ile proje classlarını bağlamak
    class NorthwindContext : DbContext
    {
        // aşağıdaki metot senin projenin hangi veritabanı ile ilişkili olduğunu belirteceğimiz metottur.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\ProjectsV13; Database = Northwind; Trusted_Connection = true"); // sql server kullanıcaz ve ona bu şekilde bağlan diyoruz.
            
        }
        public DbSet<Product> Products { get; set; } // DbSet<Entities.Product> benim entitydeki product classımı nortwind'deki Products'a bağla
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
