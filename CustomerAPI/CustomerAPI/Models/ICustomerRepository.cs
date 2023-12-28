using CustomerAPI.Models;

namespace CustomerAPI.Models
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int custId);
        Task<Customer> GetCustomerByEmail(string email);
        Task<Customer> AddCustomer (Customer customer);
        Task<Customer> UpdateCustomer (Customer customer);
        Task<Customer> DeleteCustomer (int employeeId);
    }
}
