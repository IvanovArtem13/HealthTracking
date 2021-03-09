using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineCard.Services
{
    public interface IEfRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(long id);
        Task<long> Add(T entity);
        long Update(T entity);
        void Delete(long id);
    }
}
