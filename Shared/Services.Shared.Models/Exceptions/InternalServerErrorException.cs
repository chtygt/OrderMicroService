namespace Services.Shared.Models.Exceptions;
[Serializable]
public class InternalServerErrorException : Exception
{
    public InternalServerErrorException(string exception) : base(exception)
    {
    }
}