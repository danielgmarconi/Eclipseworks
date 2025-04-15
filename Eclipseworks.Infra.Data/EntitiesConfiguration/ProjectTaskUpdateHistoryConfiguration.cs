using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipseworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eclipseworks.Infra.Data.EntitiesConfiguration;

public class ProjectTaskUpdateHistoryConfiguration : IEntityTypeConfiguration<ProjectTaskUpdateHistory>
{
    public void Configure(EntityTypeBuilder<ProjectTaskUpdateHistory> builder) 
    { 
    }
}
