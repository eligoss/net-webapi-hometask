using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using WebApi.HomeTask.Dal.Infrastructure;

namespace WebApi.HomeTask.Dal.Entities;

[ExcludeFromCodeCoverage]
[Table("Tables")]
public class TableEntity : NameableEntity
{
    [StringLength(1024)] public string Description { get; set; }

    public int TableSizeId { get; set; }

    public int LocationId { get; set; }

    public int RestaurantId { get; set; }

    #region Relationships

    public virtual RestaurantEntity Restaurant { get; set; }

    public virtual LocationEntity Location { get; set; }

    public virtual TableSizeEntity TableSize { get; set; }

    public virtual ICollection<ReservationEntity> Reservations { get; set; }

    public virtual ICollection<TableEntity> Tables { get; set; }

    #endregion
}