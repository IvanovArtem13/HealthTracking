using MedicineCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineCard.DTO
{
    public class VisitFullDto
    {
        public DateTime VisitDate { get; set; }
        public string Recommendations { get; set; }
        public string Therapy { get; set; }
        public string Diagnosis { get; set; }
        public DoctorDto Doctor { get; set; }
    }
}
