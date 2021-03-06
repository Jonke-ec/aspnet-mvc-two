using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Services {

    public interface IProfileManager {

        Task<ProfileResult> CreateAsync(IdentityUser user, UserProfile profile);
        Task<UserProfile> ReadAsync(string userId);
        Task<string> DisplayNameAsync(string userId);
    }

    public class ProfileManager : IProfileManager {

        private readonly AppDbContext _context;

        public ProfileManager(AppDbContext context) {

            _context = context;
        }

        public async Task<ProfileResult> CreateAsync(IdentityUser user, UserProfile profile) {

            if (await _context.Users.AnyAsync(x => x.Id == user.Id)) {

                var profileEntity = new ProfileEntity {

                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Address = profile.Address,
                    PostalCode = profile.PostalCode,
                    City = profile.City,
                    UserId = user.Id
                };

                _context.Profiles.Add(profileEntity);
                await _context.SaveChangesAsync();

                return new ProfileResult { Succeeded = true };
            }

            return new ProfileResult { Succeeded = false };

        }

        public async Task<UserProfile> ReadAsync(string userId) {

            var profile = new UserProfile();
            var profileEntity = await _context.Profiles.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == userId);
            if (profileEntity != null) {

                profile.FirstName = profileEntity.FirstName;
                profile.LastName = profileEntity.LastName;
                profile.Email = profileEntity.User.Email;
                profile.Address = profileEntity.Address;
                profile.PostalCode = profileEntity.PostalCode;
                profile.City = profileEntity.City;
            }

            return profile;
        }

        public async Task<string> DisplayNameAsync(string userId) {
            var result = await ReadAsync(userId);
            return $"{result.FirstName} {result.LastName}";
        }
    }

    public class ProfileResult {

        public bool Succeeded { get; set; } = false;

    }
}
