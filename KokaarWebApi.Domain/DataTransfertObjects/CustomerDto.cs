namespace KokaarWebApi.Domain.DataTransfertObjects
{
    public class CustomerDto : BaseDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
