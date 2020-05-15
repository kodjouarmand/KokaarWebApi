using AutoMapper;
using KokaarWebApi.DataAccess.Repository.Contracts;
using KokaarWebApi.Domain.Entities;
using KokaarWepApi.Business.Contracts;
using KokaarWepApi.Business.Validations;
using KokaarWepApi.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarWepApi.Business.Implementations
{
    [Serializable()]
    public class CustomerService : BaseService<CustomerDTO, Customer>, ICustomerService
    {
        #region Overrides

        //public CustomerService() { }

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public override CustomerDTO Get(int customerId)
        {
            var customer = _unitOfWork.CustomerRepository.Get(customerId);
            return MapEntityToBusinesObject(customer);
        }

        public override IEnumerable<CustomerDTO> GetAll()
        {
            var customers = _unitOfWork.CustomerRepository.GetAll();
            return MapEntitiesToBusinesObjects(customers);
        }

        protected override void ValidateAdd(ref StringBuilder validationErrors, CustomerDTO customerBO)
        {
            if (!customerBO.IsNew())
            {
                validationErrors.Append("La ressource que vous souhaitez ajouter existe déjà.");
                return;
            }
            var validationResult = new CustomerValidator().Validate(customerBO);
            validationErrors.Append(validationResult.ToString());
        }

        protected override void ValidateUpdate(ref StringBuilder validationErrors, CustomerDTO customerBO)
        {
            if (customerBO.IsNew())
            {
                validationErrors.Append("La ressource que vous souhaitez mettre à jour n'existe pas.");
                return;
            }

            var validationResult = new CustomerValidator().Validate(customerBO);
            validationErrors.Append(validationResult.ToString());
        }

        protected override bool Validate(ref StringBuilder validationErrors, CustomerDTO customerBO, ref Customer customer)
        {
            if (customerBO.IsNew())
            {
                ValidateAdd(ref validationErrors, customerBO);
            }
            else
            {
                ValidateUpdate(ref validationErrors, customerBO);
            }

            if (validationErrors.Length == 0)
            {
                MapBusinessObjectToEntity(ref customer, customerBO);
            }

            return validationErrors.Length == 0;
        }

        public override int Add(ref StringBuilder validationErrors, CustomerDTO customerBO)
        {
            Customer customer = new Customer();
            if (Validate(ref validationErrors, customerBO, ref customer))
            {
                _unitOfWork.CustomerRepository.Add(customer);
                _unitOfWork.Save();
                return customer.Id;
            }
            return 0;
        }

        public override bool Update(ref StringBuilder validationErrors, CustomerDTO customerBO)
        {
            Customer customer = new Customer();
            if (Validate(ref validationErrors, customerBO, ref customer))
            {
                _unitOfWork.CustomerRepository.Update(customer);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        protected override bool ValidateDelete(ref StringBuilder validationErrors, CustomerDTO customerBO = null)
        {
            return validationErrors.Length == 0;
        }

        public override bool Delete(ref StringBuilder validationErrors, int customerId)
        {
            if (ValidateDelete(ref validationErrors))
            {
                _unitOfWork.CustomerRepository.Remove(customerId);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }
        #endregion Overrides

    }
}
