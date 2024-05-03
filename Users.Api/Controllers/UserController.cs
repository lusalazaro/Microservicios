using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Api.Data;
using Users.Api.DTO;
using Users.Api.Models;

namespace Users.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(ApiDbContext contextoBD) : ControllerBase
    {
        [HttpGet]
        public ActionResult<UserDTO> GetUser(Guid id)
        {
            var user = contextoBD.Users.Find(id);
            if (user is null)
            {
                return NotFound();
            }
            return new UserDTO(user.Id, user.UserName, user.Name, user.Email);
        }

        [HttpPost]
        public ActionResult<UserDTO> CreateUser(CreateUserRequest request)
        {
            Profile? profile = contextoBD.Profiles.Find(request.ProfileId);
            if (profile is null)
            {
                return NotFound();
            }

            User user = new(request.UserName, request.Name, request.LastName, request.Email, request.ProfileId);
            contextoBD.Users.Add(user);
            contextoBD.SaveChanges();

            return new UserDTO(user.Id, user.UserName, user.Name, user.Email);
        }
    }
}
