namespace WebApi.HomeTask.Bll.Dto;

public class ReservationResponseDto
{
    public int ReservationId { get; set; }

    public int TableId { get; set; }

    public int RestaurantId { get; set; }

    public DateTimeOffset StartTime { get; set; }

    public DateTimeOffset EndTime { get; set; }
}