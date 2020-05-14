using FluentValidation.Results;
using KokaarWebApi.DataAccess.Repository.Contracts;
using KokaarWebApi.Domain.Entities;
using KokaarWepApi.Service.Contracts;
using KokaarWepApi.Service.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarWepApi.Service.Implementations
{
    [Serializable()]
    public class CustomerService : ICustomerService
    {
        #region Overrides

        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));            
        }

        public Customer Get(int customerId) => _unitOfWork.CustomerRepository.Get(customerId);
        
        public IEnumerable<Customer> GetAll() =>  _unitOfWork.CustomerRepository.GetAll();            
        

        private bool IsNewRecord(Customer customer) =>  customer.Id == 0;        

        private bool IsValidForSave(ref ValidationResult validationResult, Customer customer)
        {
            validationResult = new CustomerValidator().Validate(customer);

            return validationResult.IsValid;
        }        

        public bool Save(ref StringBuilder validationErrors, Customer customer, string user)
        {
            ValidationResult validationResult = new ValidationResult();

            if (IsValidForSave(ref validationResult, customer))
            {
                try
                {
                    if (IsNewRecord(customer))
                    {
                        customer.CreationDate = DateTime.Now;
                        customer.CreationUser = user;
                        _unitOfWork.CustomerRepository.Add(customer);
                    }
                    else
                    {
                        customer.UpdateDate = DateTime.Now;
                        customer.UpdateUser = user;
                        _unitOfWork.CustomerRepository.Update(customer);
                    }
                    _unitOfWork.Save();
                    return true;
                }
                catch (DbUpdateException)
                {
                    validationErrors.Append(@"The record you attempted to edit was modified by another user after you got the original value. The edit operation has been canceled");
                }
                catch (Exception ex)
                {
                    validationErrors.Append(ex.Message);                   
                }
                return false;
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    validationErrors.Append(error.ErrorMessage + "; ");
                }
                return false;
            }
        }

        private bool IsValidForDelete(ref StringBuilder validationErrors)
        {
            return validationErrors.Length == 0;
        }

        public bool Delete(ref StringBuilder validationErrors, int customerId)
        {
            if (IsValidForDelete(ref validationErrors))
            {
                _unitOfWork.CustomerRepository.Remove(customerId);
                _unitOfWork.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion Overrides

    }
}
