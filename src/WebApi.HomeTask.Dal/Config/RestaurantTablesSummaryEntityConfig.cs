using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.HomeTask.Dal.Entities;

namespace WebApi.HomeTask.Dal.Config;

public class RestaurantTablesSummaryEntityConfig  : IEntityTypeConfiguration<RestaurantTablesSummaryEntity>
{
    public void Configure(EntityTypeBuilder<RestaurantTablesSummaryEntity> builder)
    {
        builder
            .HasOne(g => g.Restaurant)
            .WithMany(gt => gt.TablesSummary)
            .HasForeignKey(b => b.RestaurantId);
        
        builder
            .HasOne(g => g.TableSize)
            .WithMany(gt => gt.RestaurantTablesSummary)
            .HasForeignKey(b => b.TableSizeId);
    }
}