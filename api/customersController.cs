using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using myvidly.Models;
using System.Data.Entity;
using myvidly.Dto;
using AutoMapper;
using AutoMapper.QueryableExtensions.Impl;
using myvidly.App_Start;

namespace myvidly.api
{
    public class customersController : ApiController
    {
        private myVidlyContext _context;
        public customersController()
        {
            _context = new myVidlyContext();
        }
        public IEnumerable<customer> getCustomerList()
        {
            return _context.Customers.ToList();
        }
        public customer getCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(w => w.id == id);
            if (customer == null)
            throw new HttpResponseException(HttpStatusCode.NotFound); 
            
            return customer;
        }
        [HttpPost]
        public customer cretaeCustomer(customer customerObj)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Add(customerObj);
            _context.SaveChanges();
            return customerObj;
        }
        [HttpPut]
        public void updateCustomer(int id ,customer customerObj)
        {
            if (!ModelState.IsValid || id == 0) throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customer.BirthData = customerObj.BirthData;
            customer.customerName = customerObj.customerName;
            customer.isSubscibedToNewsLetter = customerObj.isSubscibedToNewsLetter;
            customer.membershipTypeId = customerObj.membershipTypeId;
            _context.SaveChanges();
  
        }
        [HttpDelete]
        public IHttpActionResult deleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok();
        }

    }
}
