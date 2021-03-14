using MedicineCard.DTO;
using MedicineCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

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

        public UserDto Auth(AuthRequest authRequest)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.UserName == authRequest.UserName && x.Password == authRequest.Password);

            if (user == null)
            {
                // todo: need to add logger
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }

        public void Delete(long id)
        {
            var result = _userRepository.GetById(id);
            if (result == null)
            {
                Console.WriteLine("Invalid id");//todo logger
                throw new Exception("Error"); //обработка исключений
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
            var mapResult = _mapper.Map<IEnumerable<UserDto>>(users);
            return mapResult;
        }

        public UserDto GetById(long id)
        {
            var user = _userRepository.GetById(id);
            
            var mapResult = _mapper.Map<UserDto>(user);
            return mapResult;
        }      
    }
}
