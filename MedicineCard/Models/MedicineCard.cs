using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineCard.Models
{
    public class MedicineCard : BaseEntity
    {
        public DateTime LastDateTime { get; set; }
        public string Recommendations { get; set; }

        public Doctor Doctor { get; set; }
    }
}
