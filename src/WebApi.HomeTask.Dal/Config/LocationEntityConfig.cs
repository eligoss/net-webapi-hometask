using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.HomeTask.Dal.Entities;

namespace WebApi.HomeTask.Dal.Config;

public class LocationEntityConfig : IEntityTypeConfiguration<LocationEntity>
{
    public void Configure(EntityTypeBuilder<LocationEntity> builder)
    {
        builder
            .HasOne(g => g.Restaurant)
            .WithMany(gt => gt.Locations)
            .HasForeignKey(b => b.RestaurantId);
    }
}