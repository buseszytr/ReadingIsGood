﻿using ReadingIsGood.Domain.Models;
using ReadingIsGood.Domain.MongoDb;
using ReadingIsGood.Domain.Repositories;
using ReadingIsGood.Infrastructure.MongoDbContext;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingIsGood.Infrastructure.Repositories
{
    public class CustomerRespository : ICustomerRepository
    {
        private readonly IMongoDbContext mongoDbContext;
        public CustomerRespository(IMongoDbContext mongoDbContext)
        {
            this.mongoDbContext = mongoDbContext;
        }
        public void CreateCustomer(Customer customer)
        {
            mongoDbContext.InsertOne(customer, CollectionName.Customer.ToString());
        }

        public async Task<Customer> GetCustomerDetailByIdAsync(Guid customerId)
        {
            var customer = await mongoDbContext.FindAsync<Customer, Customer>(x => x.CustomerId == customerId, null, CollectionName.Customer.ToString());
            return customer.FirstOrDefault();
        }

        public async Task<Customer> CheckCustomerCreatedAsync(string email, string phone)
        {
            var customer = await mongoDbContext.FindAsync<Customer, Customer>(x => x.Email == email || x.Phone == phone, null, CollectionName.Customer.ToString());
            return customer.FirstOrDefault();
        }
    }
}
