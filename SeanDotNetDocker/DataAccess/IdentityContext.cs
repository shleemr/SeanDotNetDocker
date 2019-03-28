using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SeanDotNetDocker.Models;
using Microsoft.AspNetCore.Identity;

namespace SeanDotNetDocker.DataAccess
{
    public class ApplicationUser : IdentityUser
    {
        public int Uid { get; set; }
        public string Role { get; set; } = "";
    }

    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<UserModel> Users { get; set; }

    }
}
