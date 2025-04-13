using ResultModelsDotNet.ApiResponseModels;

namespace ResultModelsDotNet.ResultModels;

public class Result<T> : Result
{
    public T? Data { get; private init; }

    private protected Result() { }
    private protected Result(T data) : base(true)
    {
        Data = data;
    }
    private protected Result(Error error) : base(error)
    {
    }
    private protected Result(Error error, T data) : base(error)
    {
        Data = data;
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>(data);
    }

    public static new Result<T> Fail(Error error)
    {
        return new Result<T>(error);
    }

    public static Result<T> Fail(Error error, T data)
    {
        return new Result<T>(error, data);
    }

    public static implicit operator ApiResponse<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return ApiResponse.Success(result.Data!);
        }

        return ApiResponse<T>.Fail(result.Error ?? throw new ArgumentNullException("Error", "Error property cannot be null on a Result object when IsSuccess=False"), result.Data);
    }
}
