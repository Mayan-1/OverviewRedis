using DistributedCaching.Abstraction;
using DistributedCaching.DTOs;
using DistributedCaching.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DistributedCaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(UserDto userDto)
        {
            var user = await _userRepository.Create(userDto);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        [HttpGet("normal")]
        public async Task<ActionResult<User>> GetById([FromQuery]Guid id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("redis")]
        public async Task<ActionResult<User>> GetByIdUsingCache([FromQuery]Guid id)
        {
            var user = await _userRepository.GetByIdUsingCache(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("normal-get-all")]
        public async Task<ActionResult<ICollection<User>>> GetAllUsers()
        {
            var user = await _userRepository.GetAllUsers();
            return Ok(user);
        }

        [HttpGet("redis-get-all")]
        public async Task<ActionResult<ICollection<User>>> GetAllUsersUsingCache()
        {
            var user = await _userRepository.GetAllUsersUsingCache();
            return Ok(user);
        }


    }
}
