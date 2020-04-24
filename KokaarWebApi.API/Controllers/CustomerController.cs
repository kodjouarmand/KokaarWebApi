using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using KokaarWebApi.Domain.DTO;
using KokaarWebApi.Domain.Entities;
using KokaarWepApi.Service.Abstract;
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
            var customers = _customerService.GetAll();
            return Ok(_mapper.Map<IEnumerable<CustomerDTO>>(customers));
        }

        [HttpGet("{customerId}", Name = "GetById")]
        public IActionResult GetById(int customerId)
        {
            var customer = _customerService.Get(customerId);
            return Ok(_mapper.Map<CustomerDTO>(customer));
        }

        [HttpPost(Name = "Upsert")]        
        public IActionResult Upsert(Customer customer)
        {
            if (ModelState.IsValid)
            {
                StringBuilder validationErrors = new StringBuilder();
                if(_customerService.Save(ref validationErrors, customer, User.Identity.Name))
                {
                    return Ok(customer);
                }

                validationErrors.Insert(0, "Please take care of the following messages : " + Environment.NewLine);
                return BadRequest(validationErrors.ToString());                
            }
            return BadRequest();
        }

        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
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