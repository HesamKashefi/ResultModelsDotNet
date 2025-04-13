using ResultModelsDotNet.ApiResponseModels;

namespace ResultModelsDotNet.ResultModels;

public class Result
{
    public readonly bool IsSuccess;
    public bool IsFailed => !IsSuccess;
    public Error? Error { get; }

    private protected Result() { }

    private protected Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }
    private protected Result(Error error)
    {
        Error = error;
    }

    public static Result Success()
    {
        return new Result(true);
    }

    public static Result Fail(Error error)
    {
        return new Result(error);
    }

    public static Result<T> Success<T>(T data)
    {
        return Result<T>.Success(data);
    }

    public static Result<T> Fail<T>(Error error)
    {
        return Result<T>.Fail(error);
    }

    public static Result<T> Fail<T>(Error error, T data)
    {
        return Result<T>.Fail(error, data);
    }

    public static implicit operator ApiResponse(Result result)
    {
        if (result.IsSuccess)
        {
            return ApiResponse.Success();
        }

        return ApiResponse.Fail(result.Error ?? throw new ArgumentNullException("Error", "Error property cannot be null on a Result object when IsSuccess=False"));
    }
}
