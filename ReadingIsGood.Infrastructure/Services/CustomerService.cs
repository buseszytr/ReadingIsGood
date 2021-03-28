using ReadingIsGood.Domain.Models;
using ReadingIsGood.Domain.Repositories;
using ReadingIsGood.Domain.ResponseModels;
using ReadingIsGood.Domain.Services;
using System;
using System.Threading.Tasks;

namespace ReadingIsGood.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CustomerResponse> CreateCustomer(Customer customer)
        {
            try
            {
                var customerDetail = await customerRepository.CheckCustomerCreatedAsync(customer.Email, customer.Phone);

                if (customerDetail != null)
                {
                    return new CustomerResponse("Already exist account");
                }

                Guid customerId = Guid.NewGuid();
                customer.CustomerId = customerId;
                customerRepository.CreateCustomer(customer);

                return new CustomerResponse(customer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse(ex.Message);
            }
        }

        public async Task<CustomerResponse> GetCustomerDetailById(Guid customerId)
        {
            try
            {
                var customerDetail = await customerRepository.GetCustomerDetailByIdAsync(customerId);

                if (customerDetail == null)
                {
                    return new CustomerResponse("Customer not found");
                }

                return new CustomerResponse(customerDetail);
            }
            catch (Exception ex)
            {
                return new CustomerResponse(ex.Message);
            }
        }
    }
}
