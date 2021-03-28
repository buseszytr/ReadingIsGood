using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ReadingIsGood.API.Resources;
using ReadingIsGood.Domain.Models;
using ReadingIsGood.Domain.ResponseModels;
using ReadingIsGood.Domain.Services;

namespace ReadingIsGood.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerResource customerResource)
        {
            Customer customer = mapper.Map<CustomerResource, Customer>(customerResource);

            CustomerResponse customerResponse = await customerService.CreateCustomer(customer);

            if (customerResponse.Success)
            {
                return Ok(customerResponse.customer);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerDetail(Guid customerId)
        {
            CustomerResponse customerResponse = await customerService.GetCustomerDetailById(customerId);

            if (customerResponse.Success)
            {
                return Ok(customerResponse.customer);
            }

            return BadRequest(customerResponse.Message);
        }
    }
}
