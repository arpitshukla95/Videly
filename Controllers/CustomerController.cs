using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videly.Models;
using System.Data.Entity;
using Videly.ViewModels;

namespace Videly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();  
        }
        
    // GET: Customer

            public ActionResult New()
            {
            var membershipType = _context.MembershipType.ToList();
            var newCustomerViewModel = new NewCustomerViewModel()
            {
                Customer  = new Customer(),
                MembershipTypes = membershipType
            };
                    return View("CustomerForm",newCustomerViewModel);
            }
        [HttpPost]   
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
            {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            else { 
            if(customer.Id == 0)
            { 
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(m => m.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;


            }
            _context.SaveChanges();

                return RedirectToAction("Index","Customer");
            }
        }
        public ActionResult Edit(int id)
        {
            var customers = _context.Customers.SingleOrDefault(m => m.Id == id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel()
            {
                Customer = customers,
                MembershipTypes = _context.MembershipType.ToList()
            };
            return View("CustomerForm",viewModel);
        }
        public ActionResult Index()
            {
                    var customers = _context.Customers.Include(c =>c.MembershipType).ToList();
                    return View(customers);
            }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(x => x.Id == id);
            if (customers == null)
            {
                return HttpNotFound();
            }
           
            return View(customers);
        }
    }
}