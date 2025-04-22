using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipseworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclipseworks.Infra.Data.EntitiesConfiguration;

public class ProjectTaskCommentConfiguration : IEntityTypeConfiguration<ProjectTaskComment>
{
    public void Configure(EntityTypeBuilder<ProjectTaskComment> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.UserId).IsRequired();
        builder.Property(t => t.ProjectTaskId).IsRequired();
        builder.Property(t => t.Comment).HasMaxLength(1000).IsRequired();
        builder.Property(t => t.DateCreated).IsRequired();
        builder.HasOne(e => e.User).WithMany(e => e.ProjectTaskComments)
            .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.ProjectTask).WithMany(e => e.ProjectTaskComments)
            .HasForeignKey(e => e.ProjectTaskId).OnDelete(DeleteBehavior.Restrict);
    }
}
