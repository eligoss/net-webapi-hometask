using WebApi.HomeTask.Shared.Exceptions;

namespace WebApi.HomeTask.Bll.Exceptions;

public class OutOfWorkingHoursException : AppException
{
    public OutOfWorkingHoursException(string message) : base(message)
    {
    }
}