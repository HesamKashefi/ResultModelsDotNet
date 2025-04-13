using ResultModelsDotNet.ApiResponseModels;

namespace ResultModelsDotNet.ResultModels;

public class PagedResult<T> : Result<T[]>
{
    public int Page { get; private init; }
    public int PageSize { get; private init; }
    public int TotalItems { get; private init; }
    private protected PagedResult() { }
    private protected PagedResult(T[] data) : base(data)
    {
    }
    private protected PagedResult(Error error) : base(error)
    {
    }

    public static PagedResult<T> Success(T[] data, int page, int pageSize, int totalItems)
    {
        return new PagedResult<T>(data)
        {
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems
        };
    }

    public static new PagedResult<T> Fail(Error error)
    {
        return new PagedResult<T>(error);
    }

    public bool HasNextPage()
    {
        if (IsFailed || TotalItems == 0) return false;
        return Math.Floor((double)TotalItems / PageSize) > Page;
    }

    public bool HasPreviousPage()
    {
        if (IsFailed || TotalItems == 0) return false;
        return Page > 1;
    }

    public static implicit operator PagedApiResponse<T>(PagedResult<T> result)
    {
        if (result.IsSuccess)
        {
            return PagedApiResponse<T>.Success(result.Data!, result.Page, result.PageSize, result.TotalItems);
        }

        return PagedApiResponse<T>.Fail(result.Error ?? throw new ArgumentNullException("Error", "Error property cannot be null on a Result object when IsSuccess=False"));
    }
}