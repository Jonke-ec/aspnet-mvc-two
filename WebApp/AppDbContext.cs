using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp {
    public class AppDbContext : IdentityDbContext {

        public AppDbContext() {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        public virtual DbSet<ProfileEntity> Profiles { get; set; }

    }
}
