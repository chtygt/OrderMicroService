namespace Services.Shared.Models.Exceptions;

public class BadRequestException : Exception
{
   

    public BadRequestException(string exception) : base(exception)
    {
    }
}