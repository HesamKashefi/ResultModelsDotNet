namespace ResultModelsDotNet.ApiResponseModels;

public class ApiResponse<T>(DomainStatus status, T? data) : ApiResponse(status)
{
    public T? Data { get; } = data;

    public static new ApiResponse<T> Fail(DomainStatus status)
    {
        return new ApiResponse<T>(status, default);
    }

    public static ApiResponse<T> Fail(DomainStatus status, T? data)
    {
        return new ApiResponse<T>(status, data);
    }

    public static new ApiResponse<T> Fail(DomainStatus status, Dictionary<string, object> error)
    {
        return new ApiResponse<T>(status, default) { Error = error };
    }

    public static new ApiResponse<T> Fail(DomainStatus status, string message)
    {
        return new ApiResponse<T>(status, default)
        {
            Message = message
        };
    }
}
