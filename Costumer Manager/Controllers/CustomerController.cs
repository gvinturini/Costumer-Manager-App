using Costumer_Manager.Data.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Costumer_Manager.Controllers
{
    public class CustomerController : Controller
    {

        // GET: CustomerController/ViewCustomerProfile/5
        public ActionResult ViewCustomerProfile(int id)
        {
            return View();
        }

        // GET: CustomerController/NewCustomer
        public ActionResult NewCustomer()
        {
            return View();
        }

        // POST: CustomerController/NewCustomer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCustomer(CustomerModel newCustomer)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/UpdateCustomer/5
        public ActionResult UpdateCustomer(int id)
        {
            return View();
        }

        // POST: CustomerController/UpdateCustomer/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCustomer(CustomerModel customer)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
