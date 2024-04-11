using Costumer_Manager.Data;
using Costumer_Manager.Data.DataModels;
using Costumer_Manager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Costumer_Manager.Controllers
{
    public class CustomerController : Controller
    {
        private AppDBContext _context;
        public CustomerController(AppDBContext context) {
            _context = context;
        }
        // GET: CustomerController/ViewCustomerProfile/5
        public ActionResult ViewCustomerProfile(int id)
        {
            CustomerModel customer = _context.Customers.Where(e =>e.ID==id).FirstOrDefault();
            CustomerViewModel viewModel = new CustomerViewModel();
            
            if (customer != null)
            {
                viewModel.Name =  customer.Name;
                viewModel.Email = customer.Email;
                viewModel.Phone = customer.Phone;
                viewModel.Address = customer.Address;
                viewModel.JobTitle = customer.JobTitle;
                viewModel.ID = customer.ID;
                viewModel.CreatedDate = customer.CreatedDate;
                viewModel.IsAdmin = customer.IsAdmin;
                viewModel.IsActive = customer.IsActive;
            }
            else
            {
                viewModel = new CustomerViewModel()
                {
                    Name = "Tom Cruise",
                    Email = "tom.cruise@cruise.com",
                    Phone = "+1 111 111 111",
                    Address = "NYC, US",
                    IsActive = true,
                    IsAdmin = false,
                    Birthday = new DateTime(1975, 05, 29, 00, 30, 45),
                    ID = id,
                    JobTitle = "Actor"
                };
            }
            return View(viewModel);
        }

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
                // access the database
                CustomerModel customer = new CustomerModel();
                customer = newCustomer;

                _context.Customers.Add(customer);
                _context.SaveChanges();

                return Redirect("/");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;  
                return View();
            }
        }

        // GET: CustomerController/UpdateCustomer/5
        public ActionResult UpdateCustomer(int id)
        {

            CustomerModel customer = _context.Customers.FirstOrDefault(x => x.ID == id);
            return View(customer);
        }

        // POST: CustomerController/UpdateCustomer/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCustomer(CustomerModel customer)
        {
            try
            {
                CustomerModel customerToUpdate = _context.Customers.FirstOrDefault(y => y.ID == customer.ID);
                if (customerToUpdate != null) 
                {
                    if (customerToUpdate.Name != customer.Name)
                    {
                        customerToUpdate.Name = customer.Name;
                    }
                    if (customerToUpdate.Email != customer.Email)
                    {
                        customerToUpdate.Email = customer.Email;
                    }
                    if (customerToUpdate.Address != customer.Address)
                    {
                        customerToUpdate.Address = customer.Address;
                    }
                    if (customerToUpdate.Phone != customer.Phone)
                    {
                        customerToUpdate.Phone = customer.Phone;
                    }
                    if (customerToUpdate.JobTitle != customer.JobTitle)
                    {
                        customerToUpdate.JobTitle = customer.JobTitle;
                    }
                    if (customerToUpdate.Password != customer.Password)
                    {
                        customerToUpdate.Password = customer.Password;
                    }
                    if (customerToUpdate.IsActive != customer.IsActive)
                    {
                        customerToUpdate.IsActive = customer.IsActive;
                    }
                    if (customerToUpdate.IsAdmin != customer.IsAdmin)
                    {
                        customerToUpdate.IsAdmin = customer.IsAdmin;
                    }
                    if (customerToUpdate.Birthday != customer.Birthday)
                    {
                        customerToUpdate.Birthday = customer.Birthday;
                    }

                    customerToUpdate.Name = customer.Name;
                    customerToUpdate.ModifiedDate = DateTime.Now;
                    _context.SaveChanges();
                }
                return Redirect("/");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: CustomerController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            try
            {
                CustomerModel customer = _context.Customers.FirstOrDefault(x=> x.ID == id);
                if (customer != null)
                {
                    //_context.Customers.Remove(customer);
                    customer.IsDeleted = true;
                    _context.SaveChanges();
                }

                RequestMsg requestMsg = new RequestMsg();
                requestMsg.Message = "Deleted Successfully";
                return Json(requestMsg);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                RequestMsg requestMsg = new RequestMsg();
                requestMsg.Message = "Could not delete the item";
                return Json(requestMsg);
            }
        }
    }
}
