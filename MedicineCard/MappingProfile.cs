using AutoMapper;
using MedicineCard.DTO;
using MedicineCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineCard
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Visit, VisitFullDto>().ReverseMap();
            CreateMap<Visit, VisitShortDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>();
        }
    }
}
