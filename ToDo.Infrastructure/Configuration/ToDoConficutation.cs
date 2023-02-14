using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.DBModel;

namespace ToDo.Infrastructure.Configuration
{
    public class ToDoConficutation : IEntityTypeConfiguration<TODO>
    {
        public void Configure(EntityTypeBuilder<TODO> builder)
        {
            builder.HasIndex(x => x.UserId)
               .IsUnique(false);

            builder.Property(x => x.Status)
                .IsRequired();
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(500);
            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasOne(x=> x.User)
                .WithOne(x=> x.TODOUser)
                .HasForeignKey<TODO>(x=> x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}