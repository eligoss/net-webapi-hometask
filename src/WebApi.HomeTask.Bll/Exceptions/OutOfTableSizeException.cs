using WebApi.HomeTask.Shared.Exceptions;

namespace WebApi.HomeTask.Bll.Exceptions;

public class OutOfTableSizeException : AppException
{
    public OutOfTableSizeException(string message) : base(message)
    {
    }
}