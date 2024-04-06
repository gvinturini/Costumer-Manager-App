﻿using Costumer_Manager.Data;
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
                    customerToUpdate = customer;
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
