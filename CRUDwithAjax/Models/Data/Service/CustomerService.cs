using CRUDwithAjax.Models.Data.BootShopContext;
using CRUDwithAjax.Models.Data.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace CRUDwithAjax.Models.Data.Service
{
    public class CustomerService
    {
        private BootShopContext.BootShopContext _Ctx;

        public CustomerService(BootShopContext.BootShopContext ctx)
        {
            _Ctx = ctx;
        }

        //Get Customers
        public List<CustomerViewModel> GetCustomers()
        {
            List<Customer> customers = _Ctx.Customer.ToList();
            List<CustomerViewModel> model = customers.Select(x => new CustomerViewModel
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                CustomerAge = x.CustomerAge,
                CustomerContact = x.CustomerContact,
                CustomerLocation = x.CustomerLocation
               
            }).ToList();

            return model;
        }

        //Get customer
        public CustomerViewModel GetCustomer(int customerId)
        {
            Customer customer = _Ctx.Customer.Where(x => x.CustomerId==customerId).FirstOrDefault();
            CustomerViewModel model = new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                CustomerAge = customer.CustomerAge,
                CustomerContact = customer.CustomerContact,
                CustomerLocation = customer.CustomerLocation

            };
            return model;
        }

        //Add new Customer
        public bool AddCustomer(CustomerViewModel model)
        {
            Customer customer = new Customer
            {
                CustomerName = model.CustomerName,
                CustomerAge = model.CustomerAge,
                CustomerContact = model.CustomerContact,
                CustomerLocation = model.CustomerLocation

            };
            _Ctx.Customer.Add(customer);
            _Ctx.SaveChanges();
            return true;
        }

        //update customer
        public bool UpdateCustomer(CustomerViewModel model)
        {
            Customer customer = _Ctx.Customer.Where(x => x.CustomerId == model.CustomerId).FirstOrDefault();
            customer.CustomerContact = model.CustomerContact;
            customer.CustomerLocation = model.CustomerLocation;
            customer.CustomerName = model.CustomerName;
            customer.CustomerAge = model.CustomerAge;
            _Ctx.Customer.Update(customer);
            _Ctx.SaveChanges();

            return true;
        }

        //delete customer
        public bool DeleteCustomer(int customerId)
        {
            Customer customer = _Ctx.Customer.Where(x => x.CustomerId == customerId).FirstOrDefault();
            _Ctx.Customer.Remove(customer);
            _Ctx.SaveChanges();

            return true;
        }



    }
}
