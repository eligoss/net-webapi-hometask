using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using WebApi.HomeTask.Dal.Infrastructure;

namespace WebApi.HomeTask.Dal.Entities;

[ExcludeFromCodeCoverage]
[Table("Locations")]
public class LocationEntity : NameableEntity
{
    [StringLength(512)] [Required] public override string Name { get; set; }

    [Required] public int RestaurantId { get; set; }


    #region Relationships

    public virtual RestaurantEntity? Restaurant { get; set; }

    public virtual ICollection<TableEntity>? Tables { get; set; }

    #endregion
}