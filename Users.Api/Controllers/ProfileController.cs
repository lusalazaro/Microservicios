using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Api.Data;
using Users.Api.DTO;
using Users.Api.Models;

namespace Users.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController(ApiDbContext contextoBD) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ProfileDTO>> GetProfile(Guid id, CancellationToken ct)
        {
            Profile? profile = await contextoBD.Profiles.FindAsync([id], cancellationToken: ct);
            if (profile is null)
            {
                return NotFound();
            }
            return new ProfileDTO(profile.Id, profile.Name);
        }

        [HttpPost]
        public async Task<ActionResult<ProfileDTO>> CreateProfile(ProfileRequest request, CancellationToken ct)
        {
            bool profileExistWithSameName = await contextoBD.Profiles
                .Where(x => x.Name == request.Name).AnyAsync(ct);
            if (profileExistWithSameName)
            {
                return NotFound();
            }

            Profile profile = new(request.Name);
            await contextoBD.Profiles.AddAsync(profile, ct);
            await contextoBD.SaveChangesAsync(ct);

            return new ProfileDTO(profile.Id, profile.Name);
        }

        [HttpPut]
        public async Task<ActionResult<ProfileDTO>> UpdateProfile(Guid id, ProfileRequest request, CancellationToken ct)
        {
            Profile? profile = await contextoBD.Profiles.FindAsync([id], cancellationToken: ct);
            if (profile is null)
            {
                return NotFound();
            }

            profile.Name = request.Name;
            await contextoBD.SaveChangesAsync(ct);

            return new ProfileDTO(profile.Id, profile.Name);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProfile(Guid id, CancellationToken ct)
        {
            Profile? profile = await contextoBD.Profiles.FindAsync([id], cancellationToken: ct);
            if (profile is null)
            {
                return NotFound();
            }

            contextoBD.Profiles.Remove(profile);
            await contextoBD.SaveChangesAsync(ct);

            return NoContent();
        }
    }
}
