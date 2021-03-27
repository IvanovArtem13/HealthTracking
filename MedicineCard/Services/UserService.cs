using MedicineCard.DTO;
using MedicineCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedicineCard.Exceptions;
using MedicineCard.Logger;

namespace MedicineCard.Services
{
    public class UserService : IUserService
    {
        private readonly IEfRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IEfRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public AuthResponse Auth(AuthRequest authRequest)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.UserName == authRequest.UserName && x.Password == authRequest.Password);

            if (user == null)
            {
                throw new NotFoundException("User does not exist");
            }

            return _mapper.Map<AuthResponse>(user);
        }

        public void Delete(long id)
        {
            var result = _userRepository.GetById(id);
            if (result == null)
            {
                throw new NotFoundException($"User with id({id}) does not exist");
            }

            _userRepository.Delete(result);
        }

        public async Task<long> Add(UserDto entity)
        {
            var mapResult = _mapper.Map<User>(entity);
            var result = await _userRepository.Add(mapResult);
            return result;
        }

        public long Update(UserDto entity)
        {
            var mapResult = _mapper.Map<User>(entity);
            var result = _userRepository.Update(mapResult);
            return result;
        }

        public IEnumerable<UserDto> GetAll()
        {
            IEnumerable<User> users = _userRepository.GetAll();
            if (users == null) throw new NotFoundException($"Users list empty");
            var mapResult = _mapper.Map<IEnumerable<UserDto>>(users);
            return mapResult;
        }

        public UserDto GetById(long id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new NotFoundException($"User with id({id}) does not exist");
            }
            var mapResult = _mapper.Map<UserDto>(user);
            return mapResult;
        }      
    }
}
