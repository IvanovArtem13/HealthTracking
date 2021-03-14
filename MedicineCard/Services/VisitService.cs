using AutoMapper;
using MedicineCard.DTO;
using MedicineCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineCard.Services
{
    public class VisitService : IVisitService
    {
        private readonly IMapper _mapper;
        private readonly IVisitRepository _visitRepository;

        public VisitService(IMapper mapper, IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
            _mapper = mapper;
        }

        public void Delete(long id)
        {
            var visit = _visitRepository.GetById(id);

            if (visit == null)
            {
                //add valid and logger
                return;
            }
            _visitRepository.Delete(visit);
        }

        public IEnumerable<VisitShortDto> GetAll() 
        {
            var visits = _visitRepository.GetAll();
            if (visits == null)
            {
                return new List<VisitShortDto>();
            }
            var mapResult = _mapper.Map<IEnumerable<VisitShortDto>>(visits);
            return mapResult;
        }

        public VisitFullDto GetById(long id) 
        {
            var visit = _visitRepository.GetByIdQ(id);
            if (visit == null)
            {
                //todo logger and validation
                return null;
            }
            var mapResult = _mapper.Map<VisitFullDto>(visit);
            return mapResult;
        }
    }
}
