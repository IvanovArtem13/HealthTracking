using MedicineCard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineCard
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Models.MedicineCard> MedicineCards { get; set; } //конфликт с похожим именем проекта 
        public DbSet<Doctor> Doctors { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }


    }
}
