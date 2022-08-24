using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.HomeTask.Dal.Entities;

namespace WebApi.HomeTask.Dal.Config;

public class TableSizeEntityConfig : IEntityTypeConfiguration<TableSizeEntity>
{
    public void Configure(EntityTypeBuilder<TableSizeEntity> builder)
    {
     
    }
}