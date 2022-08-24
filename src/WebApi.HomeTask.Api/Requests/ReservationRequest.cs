using System.ComponentModel.DataAnnotations;

namespace WebApi.HomeTask.Api.Requests;

public class ReservationRequest
{
    [Required]
    [StringLength(512, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
    public string RestaurantName { get; set; }

    [Required]
    [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
    public string Date { get; set; }

    [Required]
    [StringLength(8, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 7)]
    public string Time { get; set; }

    [Required] [Range(1, 100)] public int NumPeople { get; set; }
}