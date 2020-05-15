using System;
using FluentValidation;
using KokaarWebApi.Domain.Entities;
using KokaarWepApi.Business.Implementations;
using KokaarWepApi.Domain.DTO;

namespace KokaarWepApi.Business.Validations
{
    public class CustomerValidator : AbstractValidator<CustomerDTO>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name).NotNull().NotEmpty()
                .WithMessage("The name should not be null or empty");
            RuleFor(customer => customer.DateOfBirth.Date).NotNull().LessThanOrEqualTo(DateTime.Now.Date.AddYears(-18))
                .WithMessage($"Date of birth should be greater than {DateTime.Now.Date.AddYears(-18)}");
            RuleFor(customer => customer.Email).Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                .WithMessage("The Email format is not valid");
        }
    }
}
