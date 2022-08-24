using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.HomeTask.Dal.Entities;

namespace WebApi.HomeTask.Dal.Config;

public class TableEntityConfig : IEntityTypeConfiguration<TableEntity>
{
    public void Configure(EntityTypeBuilder<TableEntity> builder)
    {
        builder
            .HasOne(g => g.Restaurant)
            .WithMany(gt => gt.Tables)
            .HasForeignKey(b => b.RestaurantId);

        builder
            .HasOne(g => g.Location)
            .WithMany(gt => gt.Tables)
            .HasForeignKey(b => b.LocationId);

        builder
            .HasOne(g => g.TableSize)
            .WithMany(gt => gt.Tables)
            .HasForeignKey(b => b.RestaurantId);
    }
}