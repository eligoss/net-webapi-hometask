namespace WebApi.HomeTask.Bll.Exceptions;

public class NoAvailableTableException : Exception
{
    public NoAvailableTableException(string message) : base(message)
    {
    }
}