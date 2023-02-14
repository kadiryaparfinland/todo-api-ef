using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.DBModel;

namespace ToDo.Infrastructure.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.PasswordHash)
                .IsRequired();
        }
    }
}
