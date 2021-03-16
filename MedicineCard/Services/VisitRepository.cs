
using MedicineCard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineCard.Services
{
    public class VisitRepository : EfRepository<Visit>, IVisitRepository
    {
        public VisitRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public Visit GetByIdQ(long id)
        {
            var visit = _context.Visits.Include(x => x.Doctor).FirstOrDefault(x => x.Id == id);
            return visit;
        }

    }
}
