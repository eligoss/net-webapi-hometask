using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using WebApi.HomeTask.Dal.Infrastructure;

namespace WebApi.HomeTask.Dal.Entities;

[Table("Restaurants")]
[ExcludeFromCodeCoverage]
public class RestaurantEntity : NameableEntity
{
    [StringLength(512)] [Required] public override string Name { get; set; }

    public long OpenTime { get; set; }

    public long CloseTime { get; set; }

    [NotMapped]
    public TimeSpan OpenTimeSpan
    {
        get => TimeSpan.FromTicks(OpenTime);
        set => OpenTime = value.Ticks;
    }

    [NotMapped]
    public TimeSpan CloseTimeSpan
    {
        get => TimeSpan.FromTicks(CloseTime);
        set => CloseTime = value.Ticks;
    }

    #region Relationships

    public virtual ICollection<RestaurantTablesSummaryEntity> TablesSummary { get; set; }

    public virtual ICollection<LocationEntity> Locations { get; set; }

    public virtual ICollection<ReservationEntity> Reservations { get; set; }
    
    public virtual ICollection<TableEntity> Tables { get; set; }

    #endregion
}