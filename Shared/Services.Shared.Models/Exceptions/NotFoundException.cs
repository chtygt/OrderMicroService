namespace Services.Shared.Models.Exceptions;

[Serializable]
public class NotFoundException : Exception
{
    public NotFoundException(string exception) : base(exception)
    {

    }
}