namespace ResultModelsDotNet.ApiResponseModels;

public sealed class PagedApiResponse<T>(DomainStatus status, T[] data) : ApiResponse<T[]>(status, data)
{
    public int Page { get; private init; }
    public int PageSize { get; private init; }
    public int TotalItems { get; private init; }

    public static PagedApiResponse<T> Success(T[] data, int page, int pageSize, int totalItems)
    {
        return new PagedApiResponse<T>(DomainStatus.OK, data)
        {
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems
        };
    }

    public static new PagedApiResponse<T> Fail(DomainStatus status)
    {
        return new PagedApiResponse<T>(status, []);
    }

    public static new PagedApiResponse<T> Fail(DomainStatus status, Dictionary<string, object> error)
    {
        return new PagedApiResponse<T>(status, []) { Error = error };
    }

    public static new PagedApiResponse<T> Fail(DomainStatus status, string message)
    {
        return new PagedApiResponse<T>(status, [])
        {
            Message = message
        };
    }
}