using Classfy.Users.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Classfy.Users.Infra.Persistence.EF.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(
                x => x.Email, 
                email => 
                    email.Property(email => email.Address)
                        .IsRequired()
                        .HasColumnName("Email"));
        }
    }
}
