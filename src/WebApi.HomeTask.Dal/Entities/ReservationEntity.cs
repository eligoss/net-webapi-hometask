using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using WebApi.HomeTask.Dal.Infrastructure;

namespace WebApi.HomeTask.Dal.Entities;

[ExcludeFromCodeCoverage]
[Table("Reservations")]
public class ReservationEntity : BaseAuditableEntity
{
    public ReservationEntity()
    {
    }

    public ReservationEntity(int restaurantId, int tableId, int tableSizeId, DateTimeOffset startDateTime,
        string ownerFullName, string ownerPhone)
    {
        OwnerFullName = ownerFullName;
        OwnerPhone = ownerPhone;
        RestaurantId = restaurantId;
        TableId = tableId;
        TableSizeId = tableSizeId;
        StartDateTime = startDateTime;
        EndDateTime = startDateTime.AddHours(1);
    }

    public int RestaurantId { get; set; }

    public int TableId { get; set; }

    public int TableSizeId { get; set; }

    public long StartTimeEpoch { get; set; }

    public long EndTimeEpoch { get; set; }

    [NotMapped]
    private DateTimeOffset StartDateTime
    {
        get => DateTimeOffset.FromUnixTimeSeconds(StartTimeEpoch);
        set => StartTimeEpoch = value.ToUnixTimeMilliseconds();
    }

    [NotMapped]
    private DateTimeOffset EndDateTime
    {
        get => DateTimeOffset.FromUnixTimeSeconds(EndTimeEpoch);
        set => EndTimeEpoch = value.ToUnixTimeMilliseconds();
    }

    [StringLength(512)] [Required] public string OwnerFullName { get; set; }
    [StringLength(512)] [Required] public string OwnerPhone { get; set; }

    #region Relationships

    public virtual RestaurantEntity Restaurant { get; set; }

    public virtual TableEntity Table { get; set; }

    public virtual TableSizeEntity TableSize { get; set; }

    #endregion
}