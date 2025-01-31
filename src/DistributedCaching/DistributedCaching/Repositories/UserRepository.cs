using DistributedCaching.Abstraction;
using DistributedCaching.Data;
using DistributedCaching.DTOs;
using DistributedCaching.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;


using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;

namespace DistributedCaching.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDistributedCache _cache;
    private readonly AppDbContext _context;

    public UserRepository(IDistributedCache cache, AppDbContext context)
    {
        _cache = cache;
        _context = context;
    }

    public async Task<User> Create(UserDto userDto)
    {
        if (userDto == null) 
        {
            return null;
        }

        var user = new User
        {
            Name = userDto.Name,
            Email = userDto.Email,
        };

        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<ICollection<User>> GetAllUsers()
    {
        var user = await _context.User.ToListAsync();
        return user;
    }

    public async Task<ICollection<User>> GetAllUsersUsingCache()
    {
        var cacheKey = "users";
        string serializedUserList;
        var userList = new List<User>();

        var redisUserList = await _cache.GetAsync(cacheKey);

        if (redisUserList != null)
        {
            serializedUserList = Encoding.UTF8.GetString(redisUserList);
            userList = JsonSerializer.Deserialize<List<User>>(serializedUserList);
        }

        userList = await _context.User.ToListAsync();
        serializedUserList = JsonSerializer.Serialize(userList);
        redisUserList = Encoding.UTF8.GetBytes(serializedUserList);
        var options = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
            .SetSlidingExpiration(TimeSpan.FromMinutes(2));

        await _cache.SetAsync(cacheKey, redisUserList, options);
        return userList;

    }

    public async Task<User> GetById(Guid id)
    {
        var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            return null;
        }

        return user;

    }

    public async Task<User> GetByIdUsingCache(Guid id)
    {
        string cacheKey = $"{id}";

        var cachedUser = await _cache.GetStringAsync(cacheKey);
        if(cachedUser != null)
        {
            return JsonSerializer.Deserialize<User>(cachedUser);
        }

        var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);

        await _cache.SetStringAsync(
            cacheKey,
            JsonSerializer.Serialize(user)
            );

        return user;
    }
}
