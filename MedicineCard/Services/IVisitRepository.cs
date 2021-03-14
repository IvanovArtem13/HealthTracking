using MedicineCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineCard.Services
{
    public interface IVisitRepository : IEfRepository<Visit> 
    {
        Visit GetByIdQ(long id);
    }
}
