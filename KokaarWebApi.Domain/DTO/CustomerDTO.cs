using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarWebApi.Domain.DTO
{
    public class CustomerDTO : BaseDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
