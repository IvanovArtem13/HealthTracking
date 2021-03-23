using MedicineCard.DTO;
using MedicineCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineCard.Services
{
    public interface IUserService
    {
        //CRUD
        IEnumerable<UserDto> GetAll();
        UserDto GetById(long id);
        long Update(UserDto entity);
        void Delete(long id);
        Task<long> Add(UserDto entity);

        //OTHER
        AuthResponse Auth(AuthRequest authRequest);
    }
}
