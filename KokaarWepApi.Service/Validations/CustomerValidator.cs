using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using KokaarWebApi.Domain.Entities;

namespace KokaarWepApi.Service.Validations
{   
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name).NotNull().NotEmpty().WithMessage("The name should not be null or empty");
            RuleFor(customer => customer.DateOfBirth).NotNull().GreaterThan(DateTime.Now.AddYears(-18)).WithMessage($"Date of birth should be greater than {DateTime.Now.AddYears(-18)}");
            RuleFor(customer => customer.Email).Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").WithMessage("The Email format is not valid");
        }
    }
}
