namespace WebApi.HomeTask.Api.ViewModels;

public class ReservationViewModel
{
    public int ReservationId { get; set; }

    public int TableId { get; set; }

    public int RestaurantId  { get; set; }

    public int StartTime { get; set; }

    public int EndTime { get; set; }
}