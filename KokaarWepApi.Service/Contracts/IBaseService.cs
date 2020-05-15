using KokaarWebApi.Domain.Entities;
using KokaarWepApi.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KokaarWepApi.Business.Contracts
{
    public interface IBaseService<TBusinessObject> where TBusinessObject : BaseDTO
    {
        TBusinessObject Get(int id);
        IEnumerable<TBusinessObject> GetAll();
        int Add(ref StringBuilder validationErrors, TBusinessObject businessObject);
        bool Update(ref StringBuilder validationErrors, TBusinessObject businessObject);
        bool Delete(ref StringBuilder validationErrors, int businessObjectId);
    }
}