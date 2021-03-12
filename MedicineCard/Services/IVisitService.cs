using MedicineCard.DTO;
using MedicineCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineCard.Services
{
    public interface IVisitService
    {
        IEnumerable<VisitDto> GetAll();
        VisitDto GetById(long id);
        void Delete(long id);
        //long Update(UserDto entity);
        //Task<long> Add(UserDto entity);
    }
}
