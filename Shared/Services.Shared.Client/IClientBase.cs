using RestSharp;

namespace Services.Shared.Client;

public interface IClientBase
{
    RestClient CreateClient(string url);
    RestClient CreateClientAnonymous(string url);
    RestRequest CreateRequest(object model, Method method);
}