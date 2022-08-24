using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using WebApi.HomeTask.Dal.Infrastructure;

namespace WebApi.HomeTask.Dal.Entities;

[ExcludeFromCodeCoverage]
[Table("TablesSize")]
public class TableSizeEntity : NameableEntity
{
    [StringLength(512)] [Required] public override string Name { get; set; }

    [Required] public int PeopleCount { get; set; }

    #region Relationships

    public virtual ICollection<RestaurantTablesSummaryEntity> RestaurantTablesSummary { get; set; }

    public virtual ICollection<TableEntity> Tables { get; set; }

    public virtual ICollection<ReservationEntity> Reservations { get; set; }

    #endregion
}