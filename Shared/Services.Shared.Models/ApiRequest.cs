namespace Services.Shared.Models;

public class ApiRequest
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 1000;
}