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
        private readonly IEfRepository<Visit> _visitRepository;
        private readonly IMapper _mapper;

        public VisitService(IEfRepository<Visit> visitRepository, IMapper mapper)
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

        public IEnumerable<VisitDto> GetAll()
        {
            var visits = _visitRepository.GetAll();
            var mapResult = _mapper.Map<IEnumerable<VisitDto>>(visits);
            return mapResult;
        }

        public VisitDto GetById(long id)
        {
            var visit = _visitRepository.GetById(id);
            if (visit == null)
            {
                //todo logger and validation
                return null;
            }
            var mapResult = _mapper.Map<VisitDto>(visit);
            return mapResult;
        }
    }
}
