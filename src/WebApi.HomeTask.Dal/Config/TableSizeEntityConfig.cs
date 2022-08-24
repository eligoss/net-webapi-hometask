using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.HomeTask.Dal.Entities;

namespace WebApi.HomeTask.Dal.Config;

public class TableSizeEntityConfig : IEntityTypeConfiguration<TableSizeEntity>
{
    public void Configure(EntityTypeBuilder<TableSizeEntity> builder)
    {
        //Add size index.
        builder
            .HasIndex(p => p.Name).IncludeProperties(q => q.PeopleCount);

        //TODO: Think later what actual index I will need.
        
        //Add people  index.
        builder
            .HasIndex(p => p.PeopleCount).IncludeProperties(q => q.Name);
    }
}