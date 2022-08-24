using WebApi.HomeTask.Shared.Exceptions;

namespace WebApi.HomeTask.Bll.Exceptions;

public class NotFoundException : AppException
{
    public NotFoundException(string message) : base(message)
    {
    }
}