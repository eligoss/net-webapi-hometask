using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.HomeTask.Dal.Entities;

namespace WebApi.HomeTask.Dal.Config;

public class RestaurantEntityConfig : IEntityTypeConfiguration<RestaurantEntity>

{
    public void Configure(EntityTypeBuilder<RestaurantEntity> builder)
    {
    }
}