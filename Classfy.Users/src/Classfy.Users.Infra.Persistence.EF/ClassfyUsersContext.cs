using Classfy.Users.Domain.User;
using Classfy.Users.Infra.Persistence.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Classfy.Users.Infra.Persistence.EF
{
    public class ClassfyUsersContext : DbContext
    {
        public ClassfyUsersContext(DbContextOptions<ClassfyUsersContext> options): 
            base(options)
        {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfiguration(new UserConfiguration());
    }
}
