namespace WebApi.HomeTask.Shared.Messages;

public static class ExceptionMessages
{
    public static string NoAvailableTables => "No Available tables left within this restaurant and size.";

    private const string RestaurantNotFound = "Restaurant with name:{0} not found";

    private const string OutOfWorkingHours = "Restaurant is out of working hours Open:{0} Close:{1}";

    public static string BuildRestaurantNotFoundMessage(string restaurantName)
    {
        return string.Format(RestaurantNotFound, restaurantName);
    }

    public static string BuildOutOfWorkingHoursMessage(long restaurantOpenTime, long restaurantCloseTime)
    {
        return string.Format(OutOfWorkingHours, new TimeSpan(restaurantOpenTime), new TimeSpan(restaurantCloseTime));
    }
}