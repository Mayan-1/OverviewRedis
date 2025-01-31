using DistributedCaching.DTOs;
using DistributedCaching.Models;

namespace DistributedCaching.Abstraction;

public interface IUserRepository
{
    Task<User> Create(UserDto userDto);
    Task<User> GetById(Guid id);
    Task<User> GetByIdUsingCache(Guid id);
    Task<ICollection<User>> GetAllUsers();
    Task<ICollection<User>> GetAllUsersUsingCache();

}
