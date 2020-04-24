using System;
using System.ComponentModel.DataAnnotations;

namespace KokaarWebApi.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        
    }
}
