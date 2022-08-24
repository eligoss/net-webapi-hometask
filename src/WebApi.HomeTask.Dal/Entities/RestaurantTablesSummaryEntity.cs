using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using WebApi.HomeTask.Dal.Infrastructure;

namespace WebApi.HomeTask.Dal.Entities;

[ExcludeFromCodeCoverage]
[Table("RestaurantTablesSummary")]
public class RestaurantTablesSummaryEntity : BaseIdEntity<int>
{
    public int TableSizeId { get; set; }

    public short Amount { get; set; }

    public int RestaurantId { get; set; }

    #region Relationships

    public virtual RestaurantEntity Restaurant { get; set; }

    public virtual TableSizeEntity TableSize { get; set; }

    #endregion
}