using AutoMapper;
using MedicineCard.DTO;
using MedicineCard.Exceptions;
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

        public async Task<long> Add(VisitFullDto entity)
        {
            var mapResult = _mapper.Map<Visit>(entity);
            var result = await _visitRepository.Add(mapResult);
            return result;
        }

        public void Delete(long id)
        {
            var visit = _visitRepository.GetById(id);

            if (visit == null)
            {
                throw new NotFoundException($"User with id({id}) does not exist");
            }
            _visitRepository.Delete(visit);
        }

        public IEnumerable<VisitShortDto> GetAll() 
        {
            var visits = _visitRepository.GetAll();
            if (visits == null)
            {
                throw new NotFoundException($"No visits has found");
            }
            var mapResult = _mapper.Map<IEnumerable<VisitShortDto>>(visits);
            return mapResult;
        }

        public VisitFullDto GetById(long id) 
        {
            var visit = _visitRepository.GetByIdQ(id);
            if (visit == null)
            {
                throw new NotFoundException($"User with id({id}) does not exist");
            }
            var mapResult = _mapper.Map<VisitFullDto>(visit);
            return mapResult;
        }
    }
}
