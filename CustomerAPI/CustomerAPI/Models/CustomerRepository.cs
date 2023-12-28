using CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext appDbContext;
        public CustomerRepository(AppDbContext appDbContext) {
            this.appDbContext = appDbContext;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result = await appDbContext.Customers.AddAsync(customer);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Customer> DeleteCustomer(int customerId)
        {
            var result = await appDbContext.Customers
                .FirstOrDefaultAsync(e=>e.customerId == customerId);
            if (result != null)
            {
                appDbContext.Customers.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            var result = await appDbContext.Customers
                .FirstOrDefaultAsync(e => e.customerId == customerId);
            return result;
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            var result = await appDbContext.Customers
                .FirstOrDefaultAsync(e => e.email == email);
            return result;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await appDbContext.Customers.ToListAsync();
        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var result = await appDbContext.Customers
                .FirstOrDefaultAsync(e => e.customerId == customer.customerId);
            if ( result != null )
            {
                result.firstName = customer.firstName;
                result.lastName = customer.lastName;
                result.email = customer.email;
                result.createdDate = customer.createdDate;
                result.lastUpdatedDate = DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
