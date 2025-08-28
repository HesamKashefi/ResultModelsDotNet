namespace ResultModelsDotNet.ApiResponseModels;

/// <summary>
/// Api response with data
/// </summary>
/// <typeparam name="T">Type of the Data</typeparam>
/// <param name="status">Status of the response</param>
/// <param name="data">The response Data</param>
public class ApiResponse<T>(DomainStatus status, T? data) : ApiResponse(status)
{
    /// <summary>
    /// Data of the response
    /// </summary>
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
