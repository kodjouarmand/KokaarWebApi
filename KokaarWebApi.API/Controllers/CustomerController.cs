using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using KokaarWebApi.Domain.DataTransfertObjects;
using KokaarWebApi.Domain.Entities;
using KokaarWepApi.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KokaarWebApi.API.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customersFromDb = _customerService.GetAll();
            if (customersFromDb.Count() == 0)
                return NotFound();
            else
            {
                var customersToReturn = _mapper.Map<IEnumerable<CustomerDto>>(customersFromDb);
                return Ok(customersToReturn);
            }
        }

        [HttpGet("{customerId}", Name = "GetCustomerById")]
        public IActionResult Get(int customerId)
        {
            var customerFromDb = _customerService.Get(customerId);
            if (customerFromDb == null)
                return NotFound();
            else
            {
                var customerToReturn = _mapper.Map<CustomerDto>(customerFromDb);
                return Ok(customerToReturn);
            }
        }

        [HttpPost(Name = "Upsert")]        
        public IActionResult Upsert(Customer customerToAdd)
        {
            if (customerToAdd == null)
            {
                return BadRequest("Object is null");
            }

            if (ModelState.IsValid)
            {
                StringBuilder validationErrors = new StringBuilder();
                if(!_customerService.Save(ref validationErrors, customerToAdd, User.Identity.Name))
                {
                    validationErrors.Insert(0, "Please take care of the following messages : " + Environment.NewLine);
                    return BadRequest(validationErrors.ToString());
                }
                var customerToReturn = _mapper.Map<CustomerDto>(customerToAdd);
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

            validationErrors.Insert(0, "Please take care of the following messages : " + Environment.NewLine);
            return BadRequest(validationErrors.ToString());           
        }
    }
}