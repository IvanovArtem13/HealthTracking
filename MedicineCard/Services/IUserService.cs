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
        IEnumerable<User> GetAll();
        User GetById(long id);
        long Update(User entity);
        void Delete(long id);
        Task<long> Add(UserDto entity);

        //OTHER
        UserDto Auth(AuthRequest authRequest);
    }
}
