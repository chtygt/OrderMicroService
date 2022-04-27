using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using Services.Shared.Models;
using Services.Shared.Models.Exceptions;

namespace Services.Shared.Client;

public abstract class ClientBase
{
    private readonly string _apiUrl;
    private readonly string _accessToken;

    protected ClientBase(string accessToken, ClientBaseOptions options)
    {
        _accessToken = accessToken;
        _apiUrl = options.BaseUrl + options.ApiPath;
        if (_apiUrl.LastIndexOf("/", StringComparison.Ordinal) == 0)
            _apiUrl += "/";

    }

    protected RestClient CreateClient(string url)
    {
        var restClientOptions = new RestClientOptions(_apiUrl + url)
        {
            ThrowOnAnyError = false,
            Timeout = 60 * 1000
        };
        var client = new RestClient(restClientOptions)
        {
            Authenticator = new JwtAuthenticator(_accessToken),
        };
        return client;
    } 

    private RestClient CreateClientAnonymous(string url)
    {
        var restClientOptions = new RestClientOptions(_apiUrl + url)
        {
            ThrowOnAnyError = false,
            Timeout = 60 * 1000
        };
        var client = new RestClient(restClientOptions);
        return client;
    }

 
    protected  Task<RestResponse<T>> CreateRequest<T>(string url, object model, Method method, params UrlSegmentParam[] urlSegments)
    {
        var client = CreateClient(url);
        var request = new RestRequest
        {
            Method = method,
            Timeout = 60 * 1000
        };
        if (model != null && method == Method.Post)
            request.AddJsonBody(model);

        if (model == null && urlSegments.Length > 0)
        {
            foreach (var s in urlSegments)
            {
                if (s.Name != null) request.AddUrlSegment(s.Name, s.Value.ToString() ?? "");
            }
        }

        var task = client.ExecuteAsync<T>(request);
        return task;
    }

    protected  Task<RestResponse<T>> CreateRequestAnonymous<T>(string url, object model, Method method)
    {
        var client = CreateClientAnonymous(url);
        var request = new RestRequest
        {
            Method = method,
            Timeout = 60 * 1000
        };
        if (model != null)
            request.AddJsonBody(model);

        var task = client.ExecuteAsync<T>(request);
        return task;
    }

    protected static ServiceResult HandleResponse(Task<RestResponse<ServiceResult>> task)
    {
        task.Wait();
        var response = task.Result;
        var result = new ServiceResult();
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                result.Data = response.Data?.Message;
                result.Total = response.Data?.Total ?? 0;
                result.Status = true;
                break;
            case HttpStatusCode.NotFound:
                throw new NotFoundException(response.Data?.Message);
            case HttpStatusCode.Conflict:
                throw new ConflictException(response.Data?.Message);
            case HttpStatusCode.BadRequest:
                throw new BadRequestException(response.Data?.Message);
            case HttpStatusCode.Unauthorized:
                throw new UnauthorizedException(response.Data?.Message);
            default:
                throw new Exception(response.Content);
        }
        return result;
    }

    protected static ServiceResult<T> HandleResponse<T>(Task<RestResponse<ServiceResult<T>>> task)
    {
        task.Wait();
        var response = task.Result;
        var result = new ServiceResult<T>();
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                result.Status = true;
                if (response.Data != null)
                {
                    result.Data = response.Data.Data;
                    result.Total = response.Data.Total;
                }
                break;
            case HttpStatusCode.NotFound:
                throw new NotFoundException(response.Data?.Message);
            case HttpStatusCode.Conflict:
                throw new ConflictException(response.Data?.Message);
            case HttpStatusCode.BadRequest:
                throw new BadRequestException(response.Data?.Message);
            case HttpStatusCode.Unauthorized:
                throw new UnauthorizedException(response.Data?.Message);
            default:
                throw new Exception(response.Content);
        }
        return result;
    }

    protected static ServiceResult<List<T>> HandleResponse<T>(Task<RestResponse<ServiceListResult<T>>> task)
    {
        task.Wait();
        var response = task.Result;
        var result = new ServiceResult<List<T>>();
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                result.Status = true;
                if (response.Data != null)
                {
                    result.Data = response.Data.Data;
                    result.Total = response.Data.Total;
                }
                break;
            case HttpStatusCode.NotFound:
                throw new NotFoundException(response.Data?.Message);
            case HttpStatusCode.Conflict:
                throw new ConflictException(response.Data?.Message);
            case HttpStatusCode.BadRequest:
                throw new BadRequestException(response.Data?.Message);
            case HttpStatusCode.Unauthorized:
                throw new UnauthorizedException(response.Data?.Message);
            default:
                throw new Exception(response.Content);
        }
        return result;
    }

}