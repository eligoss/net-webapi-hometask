using WebApi.HomeTask.Shared.Exceptions;

namespace WebApi.HomeTask.Bll.Exceptions;

public class NoAvailableTableException : AppException
{
    public NoAvailableTableException(string message) : base(message)
    {
    }
}