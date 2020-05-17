using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.Runtime.Caching;
using AutoMapper;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    // [Authorize] everything in the controller will be authorized
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //  [Authorize] this action will be authorized
        public ViewResult Index()
        {
            // //caching genres
            // if (MemoryCache.Default["Genres"]==null)
            // {
            //     MemoryCache.Default["Genres"] = _context.Genres.ToList();
            // }
            // var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;//as is for Casting you old ass

            //you won't need to return the list of customers if you used datatables ajax to get it from the Api
            //but I'm just gonna keep that code here
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //deferred execution
            return View(customers);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),//initialize all to zero (default values) solve the hidden field problem
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer) // model binding
        {
            //if not valid return user to previous page
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb,"",new string[]{"Name","Email"});//will be updated .=>security holes
                //TryUpdateModel(customerInDb)
                //use auto-mapper better
                Mapper.Map(customer, customerInDb);

                //customerInDb.Name = customer.Name;
                //customerInDb.BirthDate = customer.BirthDate;
                //customerInDb.MembershipTypeId = customer.MembershipTypeId; //customer MembershipType is always null
                //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                //customerInDb.Delinquent = customer.Delinquent;
                //customerInDb.DiscountRate = customer.DiscountRate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}