using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Api.Data;
using Users.Api.DTO;
using Users.Api.Models;

namespace Users.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(ApiDbContext contextoBD) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers(CancellationToken ct)
        {
            List<User> users = await contextoBD.Users.AsNoTracking().ToListAsync(ct);
            IEnumerable<UserDTO> dtos = users.Select(u => new UserDTO(u.Id, u.UserName, u.Name, u.Email));
            return Ok(dtos);
        }

        [HttpGet("ByProfile/{idProfile}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByProfile(Guid idProfile, CancellationToken ct)
        {
            List<User> users = await contextoBD.Users.AsNoTracking().Where(u => u.ProfileId == idProfile).ToListAsync(ct);
            IEnumerable<UserDTO> dtos = users.Select(u => new UserDTO(u.Id, u.UserName, u.Name, u.Email));
            return Ok(dtos);
        }
    }
}
