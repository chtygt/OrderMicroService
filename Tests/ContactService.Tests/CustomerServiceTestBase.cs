using System;
using System.Collections.Generic;
using System.Linq;
using Services.Customer.Model;

namespace CustomerService.Tests
{
    public  static class CustomerServiceTestBase
    {
        public static List<Customer> GetFakeContacts()
        {
            return new List<Customer>()
            {
                new Customer()
                {
                    Id = Guid.Parse("1d5ec52a-f91b-49cd-88c2-f7901926ed93"),
                    CustomerName = "Test 1 customer",
                    TaxOffice = "Vergi dairesi 1",
                    TaxNumber = 1,
                    Adress = "Adres 1"
                },
                new Customer()
                {
                    Id = Guid.Parse("87c94155-e37e-4769-bc95-0b9d847a2da9"),
                    CustomerName = "Test 2 customer",
                    TaxOffice = "Vergi dairesi 2",
                    TaxNumber = 2,
                    Adress = "Adres 2"
                },
                new Customer()
                {
                    Id = Guid.Parse("fdbe1d64-b98c-486d-9635-0ecda7e692b6"),
                    CustomerName = "Test 3 customer",
                    TaxOffice = "Vergi dairesi 3",
                    TaxNumber = 3,
                    Adress = "Adres 3"
                },
                new Customer()
                {
                    Id = Guid.Parse("7d40faba-ee2f-45bd-a0fe-e180543ab8c4"),
                    CustomerName = "Test 4 customer",
                    TaxOffice = "Vergi dairesi 4",
                    TaxNumber = 4,
                    Adress = "Adres 4"
                },
                new Customer()
                {
                    CustomerName = "Test 5 customer",
                    TaxOffice = "Vergi dairesi 5",
                    TaxNumber = 5,
                    Adress = "Adres 5"
                },
                new Customer()
                {
                    Id = Guid.Parse("047fadb5-b903-4d18-a5bf-ae8f57692bba"),
                    CustomerName = "Test 6 customer",
                    TaxOffice = "Vergi dairesi 6",
                    TaxNumber = 6,
                    Adress = "Adres 6"
                }
            };
        }
    }
}
