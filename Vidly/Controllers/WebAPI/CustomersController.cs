using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.WebAPI
{
    public class CustomersController : ApiController
    {

        ApplicationDbContext _context;

            public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/Customers
        public IHttpActionResult  GetCustomers(string query=null)
        {
            var customersQuery = _context.Customers.
                Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
          customersQuery=      customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos=customersQuery
                .ToList().
                Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET api/Customers/1
        public  IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(cust => cust.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id.ToString()),customerDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var customerInContext=   _context.Customers.SingleOrDefault(cust => cust.Id == id);
            if (customerInContext == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, customerInContext);
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        // DELETE api/Customers/1
        public IHttpActionResult DeleteCustomer(int id)
        {

            var customerInContext = _context.Customers.SingleOrDefault(cust => cust.Id ==id);
            if (customerInContext == null)
                return NotFound();

            _context.Customers.Remove(customerInContext);
            _context.SaveChanges();
            return Ok();
        }

    }
}