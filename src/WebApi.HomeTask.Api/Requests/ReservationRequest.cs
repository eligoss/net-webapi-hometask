namespace WebApi.HomeTask.Api.Requests;

public class ReservationRequest
{
    public string RestaurantName { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan Time { get; set; }

    public int NumPeople { get; set; }
}