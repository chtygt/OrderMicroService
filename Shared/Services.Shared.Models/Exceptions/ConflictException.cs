namespace Services.Shared.Models.Exceptions;
[Serializable]
public class ConflictException : Exception
{
    public ConflictException(string exception) : base(exception)
    {
            
    } 
}