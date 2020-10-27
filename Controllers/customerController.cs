using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using myvidly.Models;
using myvidly.ViewModel;

namespace myvidly.Controllers
{
    public class customerController : Controller
    {
        //Eager loading when we load related object with query object
        private myVidlyContext _context;
        // GET: customer
        public customerController()
        { _context = new myVidlyContext(); }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult newCustomer(){
            var membership = _context.MembershipTypes;
            var viewModel = new customerMemberShip()
            {
                membershipTypes = membership
            };
            return View(viewModel);  
        }
        public ActionResult Index()
        {
            Console.WriteLine("HERE IAM");
            var customers = _context.Customers.Include(c=>c.membershipType).ToList();
            if (customers == null)
            {
                return HttpNotFound();
            }

            Console.WriteLine(customers);
            return View(customers);
        }
        public ActionResult details(int id)
        {
            var customer = _context.Customers.Include(c=>c.membershipType).SingleOrDefault(c => c.id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost]
        public ActionResult save(customerMemberShip customerObj)
        {
           if (! ModelState.IsValid)
            {
                var viewModel = new customerMemberShip()
                {
                    customers = customerObj.customers,
                    membershipTypes = _context.MembershipTypes.ToList()
                };
                return View("newCustomer",viewModel);
            }
            //if all the keys of model are exist in model it will be binding automaticly
            if (customerObj.customers.id == 0)
            {
                _context.Customers.Add(customerObj.customers);
              
            }
            else
            {
             var customer = _context.Customers.SingleOrDefault(c => c.id == customerObj.customers.id);
                if (customer == null) return HttpNotFound();
                customer.BirthData = customerObj.customers.BirthData;
                customer.customerName = customerObj.customers.customerName;
                customer.isSubscibedToNewsLetter = customerObj.customers.isSubscibedToNewsLetter;
                customer.membershipTypeId = customerObj.customers.membershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
         }
            
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);
            if (customer == null) return HttpNotFound();
            var viewModel = new customerMemberShip()
            {
                customers = customer,
                membershipTypes = _context.MembershipTypes.ToList()
            };
            return View("newCustomer",viewModel);
        }
    }
}