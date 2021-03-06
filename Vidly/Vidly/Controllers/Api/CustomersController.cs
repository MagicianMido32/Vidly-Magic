﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity; // to use the include method to eager load the membership class (hierarchical data)
using System.Net.Http;
using System.Web.Http;
using Antlr.Runtime;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            //if there's no query , means we are getting all customers,
            //if there's a query means we are getting only customers that contains that query

            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!string.IsNullOrEmpty(query))
            {
                //customer's name contains query ,, such joh => john,johnny ....
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }
            var customerDtos = customersQuery
            .ToList()
            .Select(Mapper.Map<Customer, CustomerDto>/*!!*/);
            // remove the parentheses () because you don't need to invoke the method, you only need to delegate it (get a reference to it)
            return Ok(customerDtos);
        }

        //GET api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            //mosh didn't eager load the MembershipType object , so it will be null in the returned object
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));//Dest - source (Dest Data)
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {//Name it PostCustomer , convention will put HTTPPost for you,but it's poor approach
            /*
             * check the model,
             * map customerDto to a customer object
             * Add the customer object to the context and save the changes
             * the Id will be autogenerated by EF so we need to return it to the user
             * The RESTful convention says you should return the Created Uri '/api/customer/1',and the object
             */

            if (!ModelState.IsValid)
            {
                return BadRequest(); //new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            //  put a customerDto inside a Customer
            // destination , source , (thing that has the data)
            // we didn't pass a destination object (like in update so it created a new object and passed it in customer)

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;  // the Id will be autogenerated by EF so we need to return it to the user

            //The RESTful convention says you should return the Uri '/api/customer/1',and the object
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customerDto/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        { //{you can return customerDto or void} you get id from URL and customerDto from body
            /*
             * check the model => throw badRequest (it's not httpresult it's void)
             * get customerInDb by id
             * if customer don't exist in Db throw not found
             * map customerDto to customerInDbb
             * save changes
             */
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)//User might pass a non existing Id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //here we pass a second object , the destination , so auto mapper is gonna fill that object for us
            //so out db_context can track changes in that object
            Mapper.Map(customerDto, customerInDb);
            /*
            without using auto mapper
            customerInDb.Name = customerDto.Name;
            customerInDb.BirthDate = customerDto.BirthDate;
            customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
            */
            _context.SaveChanges();
        }

        //DELETE /api/customerDto/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            /*
             * get CustomerInDb by id
             * if it doesn't exist throw httpResponseException notfound
             * remove the customer
             * save changes
             */
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)//User might pass a non existing Id
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}