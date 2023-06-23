using CRUDwithAjax.Models.Data.BootShopContext;
using CRUDwithAjax.Models.Data.Service;
using CRUDwithAjax.Models.Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDwithAjax.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerService _CustomerService;

        public CustomersController(CustomerService customerService)
        {
            _CustomerService = customerService;
        }

        // GET: CustomersController
        public ActionResult Index()
        {

            return View();
        }


        public JsonResult GetCustomers()
        {
            var model = _CustomerService.GetCustomers();
            return Json(model);
        }

        // GET: CustomersController/Details/5
        public JsonResult GetCustomersDetails(int customerId)
        {
            var model = _CustomerService.GetCustomer(customerId);
            return Json(model);
        }

        // GET: CustomersController/Create
        [HttpPost]
        public JsonResult AddorEditCustomer(CustomerViewModel customer)
        {
            if (customer.CustomerId == 0)
            {
                // add new customer
                bool result = _CustomerService.AddCustomer(customer);

                if (result)
                {
                    return Json(new { success = true, message = "Customer successfully added" });
                }
                return Json(new { success = false, message = "Customer failed to be added!" });
            }
            else
            {
                bool result = _CustomerService.UpdateCustomer(customer);

                if (result)
                {
                    return Json(new { success = true, message = "Customer successfully updated" });
                }
                return Json(new { success = false, message = "Customer failed to be updated!" });
            }
        }


        // POST: CustomersController/Delete/5
        [HttpPost]
        public JsonResult DeleteCustomer(int customerId)
        {
            bool result = _CustomerService.DeleteCustomer(customerId);
            if (result)
            {
                return Json(new { success = true, message = "Customer successfully deleted!" });
            }
            return Json(new { success = false, message = "Customer failed to be deleted!" });
        }
    }
}
