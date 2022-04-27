namespace Services.Shared.Models.Exceptions;
[Serializable]
public class UnauthorizedException : Exception
{
    public UnauthorizedException(string exception) : base(exception)
    {
    }
}