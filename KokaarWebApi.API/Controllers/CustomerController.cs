using System;
using System.Text;
using KokaarWebApi.Domain.Entities;
using KokaarWepApi.Service.Abstract;
using KokaarWepApi.Service.Core;
using Microsoft.AspNetCore.Mvc;

namespace KokaarWebApi.API.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }

        [HttpGet("{customerId}", Name = "GetById")]
        public IActionResult GGetById(int customerId)
        {
            var customer = _customerService.Get(customerId);
            return Ok(customer);
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

                validationErrors.Insert(0, "Please take care of the following messages : ");
                return BadRequest(validationErrors.ToString());                
            }
            return BadRequest();
        }
    }
}