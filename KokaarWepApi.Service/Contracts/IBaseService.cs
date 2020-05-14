using System.Collections.Generic;
using System.Text;

namespace KokaarWepApi.Service.Contracts
{
    public interface IBaseService<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        bool Save(ref StringBuilder validationErrors, T entity, string user);
        bool Delete(ref StringBuilder validationErrors, int id);
    }
}
