using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.HomeTask.Dal.Entities;

namespace WebApi.HomeTask.Dal.Config;

public class ReservationEntityConfig : IEntityTypeConfiguration<ReservationEntity>
{
    public void Configure(EntityTypeBuilder<ReservationEntity> builder)
    {
        builder
            .HasOne(g => g.Restaurant)
            .WithMany(gt => gt.Reservations)
            .HasForeignKey(b => b.RestaurantId);

        builder
            .HasOne(g => g.Table)
            .WithMany(gt => gt.Reservations)
            .HasForeignKey(b => b.TableId);

        builder
            .HasOne(g => g.TableSize)
            .WithMany(gt => gt.Reservations)
            .HasForeignKey(b => b.TableSizeId);
    }
}