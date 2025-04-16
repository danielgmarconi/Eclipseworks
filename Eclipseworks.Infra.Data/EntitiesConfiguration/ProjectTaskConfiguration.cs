using Eclipseworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclipseworks.Infra.Data.EntitiesConfiguration;

public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
{
    public void Configure(EntityTypeBuilder<ProjectTask> builder)
    {
        //builder.HasKey(t => t.Id);
        //builder.Property(t => t.Name).HasMaxLength(200).IsRequired();
        //builder.Property(t => t.Description).HasMaxLength(1000).IsRequired();
        //builder.Property(t => t.Priority).HasConversion<Byte>();
        //builder.Property(t => t.Status).HasConversion<Byte>();
        //builder.Property(t => t.DateCreated).IsRequired();
        //builder.HasOne(e => e.User).WithMany(e => e.ProjectTasks)
        //    .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
        //builder.HasOne(e => e.Project).WithMany(e => e.ProjectTasks)
        //    .HasForeignKey(e => e.ProjectId).OnDelete(DeleteBehavior.Restrict);
    }
}
