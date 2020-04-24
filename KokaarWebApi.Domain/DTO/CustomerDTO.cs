using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarWebApi.Domain.DTO
{
    class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
