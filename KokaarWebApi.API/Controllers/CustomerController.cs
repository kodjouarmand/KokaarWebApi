using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using KokaarWepApi.Business.Contracts;
using KokaarWepApi.Business.Implementations;
using KokaarWepApi.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace KokaarWebApi.API.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerBO)
        {
            _customerService = customerBO ?? throw new ArgumentNullException(nameof(customerBO));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerService.GetAll();
            if (customers.Count() == 0)
                return NotFound();
            else
                return Ok(customers);
        }

        [HttpGet("{customerId}", Name = "GetCustomerById")]
        public IActionResult Get(int customerId)
        {
            var customer = _customerService.Get(customerId);
            if (customer == null)
                return NotFound();
            else
                return Ok(customer);
        }

        [HttpPost(Name = "Add")]
        public IActionResult Add([FromBody]CustomerDTO customerToAdd)
        {
            if (customerToAdd == null)
            {
                return BadRequest("Object is null");
            }

            if (ModelState.IsValid)
            {
                customerToAdd.CurrentUser = CurrentUser;

                StringBuilder validationErrors = new StringBuilder();
                customerToAdd.Id = _customerService.Add(ref validationErrors, customerToAdd);

                if (customerToAdd.Id == 0)
                {
                    validationErrors.Insert(0, "Please take care of the following messages : ");
                    return BadRequest(validationErrors.ToString());
                }

                var customerToReturn = _customerService.Get(customerToAdd.Id);
                return CreatedAtRoute("GetCustomerById", new { customerId = customerToReturn.Id }, customerToReturn);
            }
            return BadRequest();
        }

        [HttpPut(Name = "Update")]
        public IActionResult Update([FromBody]CustomerDTO customerToUpdate)
        {
            if (customerToUpdate == null || customerToUpdate.Id == 0)
            {
                return BadRequest("Object is null");
            }

            if (ModelState.IsValid)
            {
                customerToUpdate.CurrentUser = CurrentUser;

                StringBuilder validationErrors = new StringBuilder();
                if (!_customerService.Update(ref validationErrors, customerToUpdate))
                {
                    validationErrors.Insert(0, "Please take care of the following messages : ");
                    return BadRequest(validationErrors.ToString());
                }

                var customerToReturn = _customerService.Get(customerToUpdate.Id);
                return CreatedAtRoute("GetCustomerById", new { customerId = customerToReturn.Id }, customerToReturn);
            }
            return BadRequest();
        }

        [HttpDelete("{customerId}")]
        public IActionResult Delete(int customerId)
        {
            StringBuilder validationErrors = new StringBuilder();

            if (_customerService.Delete(ref validationErrors, customerId))
            {
                return NoContent();
            }

            validationErrors.Insert(0, "Please take care of the following messages : ");
            return BadRequest(validationErrors.ToString());
        }
    }
}