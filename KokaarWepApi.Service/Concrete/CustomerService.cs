using KokaarWebApi.DataAccess.Repository.Abstract;
using KokaarWebApi.Domain.Entities;
using KokaarWepApi.Service.Abstract;
using KokaarWepApi.Service.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarWepApi.Service.Concrete
{
    [Serializable()]
    public class CustomerService : ICustomerService
    {
        #region Overrides

        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Customer Get(int id)
        {
            return _unitOfWork.CustomerRepository.Get(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _unitOfWork.CustomerRepository.GetAll();
        }

        private bool IsValidForSave(ref StringBuilder validationErrors, Customer customer)
        {
            string separator = "; ";

            if (string.IsNullOrWhiteSpace(customer.Name))
                validationErrors.Append($"Name is required{separator}");    
            
            if (string.IsNullOrWhiteSpace(customer.Email))
                validationErrors.Append($"Email is required{separator}");
            
            return validationErrors.Length == 0;
        }

        private bool IsNewRecord(Customer customer)
        {
            return customer.Id == 0;
        }

        public bool Save(ref StringBuilder validationErrors, Customer customer, string user)
        {
            if (IsValidForSave(ref validationErrors, customer))
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
                catch (Exception ex)
                {
                    validationErrors.Append(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool IsValidForDelete(ref StringBuilder validationErrors, Customer customer)
        {
            return validationErrors.Length == 0;
        }

        public bool Delete(ref StringBuilder validationErrors, Customer customer)
        {
            if (IsValidForDelete(ref validationErrors, customer))
            {
                _unitOfWork.CustomerRepository.Remove(customer.Id);
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
