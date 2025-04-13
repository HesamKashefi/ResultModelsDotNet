using System.Text.Json.Serialization;

namespace ResultModelsDotNet.ApiResponseModels;

public class ApiResponse
{
    /// <summary>
    /// Is an ok response
    /// </summary>
    [JsonInclude]
    public bool Ok => DomainStatus.IsOk(Status);

    /// <summary>
    /// The status of the response
    /// </summary>
    [JsonInclude]
    public DomainStatus Status { get; private set; }

    /// <summary>
    /// A displayable message
    /// </summary>
    public string? Message { get; internal protected set; }

    /// <summary>
    /// Errors
    /// </summary>
    public Dictionary<string, object>? Error { get; internal protected set; }

    /// <summary>
    /// Request Identifier
    /// </summary>
    public string? TraceId => System.Diagnostics.Activity.Current?.TraceId.ToString();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [JsonConstructor]
    private ApiResponse() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected ApiResponse(DomainStatus status)
    {
        Status = status;
    }

    public static ApiResponse Success()
    {
        return new ApiResponse(DomainStatus.OK);
    }

    public static ApiResponse<T> Success<T>(T data)
    {
        return new ApiResponse<T>(DomainStatus.OK, data);
    }

    public static ApiResponse Fail(DomainStatus status)
    {
        return new ApiResponse(status);
    }

    public static ApiResponse<T> Fail<T>(DomainStatus status, T? data)
    {
        return new ApiResponse<T>(status, data);
    }

    public static ApiResponse Fail(DomainStatus status, Dictionary<string, object> error)
    {
        return new ApiResponse(status) { Error = error };
    }

    public static ApiResponse Fail(DomainStatus status, string message)
    {
        return new ApiResponse(status)
        {
            Message = message
        };
    }
}
