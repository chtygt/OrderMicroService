using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Customer.Api.Controllers;
using Services.Customer.Data;
using Services.Customer.Model;
using Services.Customer.Repositories.Repositories;
using Services.Shared.Models;
using Xunit;

namespace CustomerService.Tests
{
    public class CustomerControllerTest
    {
        private readonly DbContextOptions<CustomerDbContext> _dbOptions;

        public CustomerControllerTest()
        {
            _dbOptions = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: "customer-db")
                .Options;

            using (var dbContext = new CustomerDbContext(_dbOptions))
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                dbContext.AddRange(CustomerServiceTestBase.GetFakeContacts());
                dbContext.SaveChanges();
            }
        }

        [Fact]
        public async Task Get_Customer_Success()
        {
            var dbContext = new CustomerDbContext(_dbOptions);
            var contactRepository = new CustomerRepository(dbContext);
            var contactService = new Services.Customer.Api.Services.CustomerService(contactRepository);
            var contactController = new CustomerController(contactService);

            var actionResult =   contactController.Get(CustomerServiceTestBase.GetFakeContacts().FirstOrDefault().Id) as ObjectResult;
            var val = Assert.IsAssignableFrom<ApiResult>(actionResult.Value);
            Assert.IsType<Customer>(val.Data);
            Assert.Equal(HttpStatusCode.OK,val.StatusCode);
        }

        [Fact]
        public async Task Add_Customer_Success()
        {
            var dbContext = new CustomerDbContext(_dbOptions);
            var contactRepository = new CustomerRepository(dbContext);
            var contactService = new Services.Customer.Api.Services.CustomerService(contactRepository);
            var contactController = new CustomerController(contactService);

            var contact = new Customer()
            {
                Id = Guid.Parse("b5333d0a-cb34-46b1-ad17-9ec50f25ea92"),
                CustomerName = "Test 1 customer",
                TaxOffice = "Vergi dairesi 1",
                TaxNumber = 1,
                Adress = "Adres 1"
            };

            var actionResult = contactController.Add(contact) as ObjectResult;
            Assert.Equal((int)HttpStatusCode.OK, actionResult.StatusCode);
        }
        
        [Fact]
        public async Task Update_Customer_Success()
        {
            var dbContext = new CustomerDbContext(_dbOptions);
            var customerRepository = new CustomerRepository(dbContext);
            var customerService = new Services.Customer.Api.Services.CustomerService(customerRepository);
            var customerController = new CustomerController(customerService);
            var oldCustomer =
                dbContext.Customers.FirstOrDefault(x => x.Id == Guid.Parse("87c94155-e37e-4769-bc95-0b9d847a2da9"));
            oldCustomer.CustomerName = "test Customer update";

            var actionResult = customerController.Update(oldCustomer) as ObjectResult;
            Assert.Equal((int)HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Fact]
        public async Task Update_Customer_BadRequest()
        {
            var dbContext = new CustomerDbContext(_dbOptions);
            var customerRepository = new CustomerRepository(dbContext);
            var customerService = new Services.Customer.Api.Services.CustomerService(customerRepository);
            var customerController = new CustomerController(customerService);
           var oldCustomer = new Customer()
            {
                Id = Guid.Parse("87c94155-e37e-4769-bc95-0b9d847a2da9"),
                CustomerName = "Test 55 customer",
                TaxOffice= "Vergi dairesi 55",
                TaxNumber = 55,
                Adress = "Adres 55",
               ConcurrencyStamp = Guid.NewGuid()
            };
            var actionResult = customerController.Update(oldCustomer) as ObjectResult;
            Assert.Equal((int)HttpStatusCode.BadRequest, actionResult.StatusCode);
        }

        [Fact]
        public async Task Delete_Customer_Success()
        {
            var dbContext = new CustomerDbContext(_dbOptions);
            var customerRepository = new CustomerRepository(dbContext);
            var customerService = new Services.Customer.Api.Services.CustomerService(customerRepository);
            var customerController = new CustomerController(customerService);
           
            var actionResult = customerController.Delete(Guid.Parse("7d40faba-ee2f-45bd-a0fe-e180543ab8c4")) as ObjectResult;
            Assert.Equal((int)HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Fact]
        public async Task List_Customer_Success()
        {
            var dbContext = new CustomerDbContext(_dbOptions);
            var customerRepository = new CustomerRepository(dbContext);
            var customerService = new Services.Customer.Api.Services.CustomerService(customerRepository);
            var customerController = new CustomerController(customerService);

            var actionResult = customerController.List(0,100) as ObjectResult;
            Assert.Equal((int)HttpStatusCode.OK, actionResult.StatusCode);
        }
       
        [Fact]
        public async Task Count_Customer_Success()
        {
            var dbContext = new CustomerDbContext(_dbOptions);
            var customerRepository = new CustomerRepository(dbContext);
            var customerService = new Services.Customer.Api.Services.CustomerService(customerRepository);
            var customerController = new CustomerController(customerService);

            var actionResult = customerController.Count() as ObjectResult;
            Assert.Equal((int)HttpStatusCode.OK, actionResult.StatusCode);
        }
         
    }
}