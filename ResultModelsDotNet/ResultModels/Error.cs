using ResultModelsDotNet.ApiResponseModels;
using System.Runtime.CompilerServices;

namespace ResultModelsDotNet.ResultModels;

public record Error(string Code, Error? InnerError = null)
{
    public Dictionary<string, List<string>>? ModelStateDictionary { get; init; }

    public static readonly Error ERROR = Create();
    public static readonly Error DB_ERROR = Create();

    public static readonly Error NOT_FOUND_ERROR = Create();
    public static readonly Error ENTITY_HAS_BEEN_CHANGED_SINCE_THEN = Create();
    public static readonly Error INVALID_INPUT = Create();
    public static readonly Error INVALID_MODEL_STATE = Create();

    public static readonly Error UNAUTHORIZED = Create();
    public static readonly Error FORBIDDEN = Create();
    public static readonly Error INVALID_CREDENTIALS = Create();
    public static readonly Error USER_IS_NOT_ACTIVE = Create();
    public static readonly Error USER_IS_LOCKED = Create();

    public static readonly Error USERNAME_ALREADY_TAKEN = Create();
    public static readonly Error EMAIL_ALREADY_TAKEN = Create();

    public static readonly Error ENTITY_ALREADY_EXISTS = Create();



    public static implicit operator DomainStatus(Error error)
    {
        if (DomainStatus.Map.TryGetValue(error.Code, out var value))
        {
            return value with { Errors = error.ModelStateDictionary };
        }
        return DomainStatus.Create(byte.MaxValue, error.Code) with { Errors = error.ModelStateDictionary };
    }


    public static Error Create([CallerMemberName] string? name = null)
    {
        return name == null ?
            throw new ArgumentNullException(nameof(name)) :
            new Error(name);
    }

    public static Error Create(Error innerError, [CallerMemberName] string? name = null)
    {
        return name == null ?
            throw new ArgumentNullException(nameof(name)) :
            new Error(name, innerError);
    }
}