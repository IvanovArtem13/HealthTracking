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
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName)).ReverseMap(); //если имена полей ==, то в этом нет необходимости
            CreateMap<Visit, VisitDto>()
                .ForMember(dest => dest.Diagnosis, opt => opt.MapFrom(src => src.Diagnosis)).ReverseMap();
        }
    }
}
