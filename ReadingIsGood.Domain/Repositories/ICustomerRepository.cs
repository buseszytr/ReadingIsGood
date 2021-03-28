using System;
using System.Threading.Tasks;
using ReadingIsGood.Domain.Models;

namespace ReadingIsGood.Domain.Repositories
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        Task<Customer> GetCustomerDetailByIdAsync(Guid customerId);
        Task<Customer> CheckCustomerCreatedAsync(string email, string phone);
    }
}
