using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) 
        {  
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Customers Table
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    customerId = 1,
                    firstName = "Muhammad",
                    lastName = "Abdullah",
                    email = "muhammad@gmail.com",
                    createdDate = new DateTime(2022, 10, 5),
                    lastUpdatedDate = new DateTime(2023, 10, 10)
                });
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    customerId = 2,
                    firstName = "Touqeer",
                    lastName = "Anwar",
                    email = "tauqeeranwar@gmail.com",
                    createdDate = new DateTime(2022, 10, 5),
                    lastUpdatedDate = new DateTime(2023, 10, 10)
                });
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    customerId = 3,
                    firstName = "Mustafa",
                    lastName = "Anwar",
                    email = "mustafaanwar@gmail.com",
                    createdDate = new DateTime(2022, 10, 5),
                    lastUpdatedDate = new DateTime(2023, 10, 10)
                });
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    customerId = 4,
                    firstName = "Ahmad",
                    lastName = "Abdullah",
                    email = "ahmad@gmail.com",
                    createdDate = new DateTime(2023, 10, 5),
                    lastUpdatedDate = new DateTime(2023, 10, 10)
                });
        }
    }

    
}
