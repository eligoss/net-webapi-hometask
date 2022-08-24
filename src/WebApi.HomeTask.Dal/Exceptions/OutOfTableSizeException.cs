namespace WebApi.HomeTask.Dal.Exceptions;

public class OutOfTableSizeException : Exception
{
    public OutOfTableSizeException(string message) : base(message)
    {
    }
}