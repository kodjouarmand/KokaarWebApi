using System;

namespace KokaarWepApi.Domain.DTO
{
    [Serializable()]
    public class CustomerDTO : BaseDTO
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        //Customs properties
        public int Age { get; set; }
    }
}
