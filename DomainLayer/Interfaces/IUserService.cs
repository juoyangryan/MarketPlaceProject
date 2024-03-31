using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetByIdAsync(int id);

        Task<UserDTO> GetByUsernameAsync(string username);

        Task<UserDTO> GetByEmailAsync(string email);

        Task AddUser(UserDTO userDTO);
    }
}
