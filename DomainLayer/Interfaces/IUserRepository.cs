using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDTO> GetByIdAsync(int id);

        Task<UserDTO> GetByUsernameAsync(string username);

        Task<UserDTO> GetByEmailAsync(string email);

        Task AddUser(UserDTO userDTO);
    }
}
