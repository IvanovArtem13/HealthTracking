using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineCard.Models
{
    public class Visit : BaseEntity
    {
        public DateTime VisitDate { get; set; }
        public string Recommendations { get; set; }
        public string Therapy { get; set; }
        public string Diagnosis { get; set; }
        public Doctor Doctor { get; set; }
    }
}
