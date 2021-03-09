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
        IEnumerable<User> GetAll();
        User GetById(long id);
        UserDto Auth(AuthRequest authRequest);
        //todo methods from repository
    }
}
