using System.Runtime.CompilerServices;

namespace ResultModelsDotNet.ApiResponseModels;

/// <summary>
/// Domain Status represents the status of an api response
/// </summary>
/// <param name="Code">A number for a specific status. (e.g 404 For NotFound)</param>
/// <param name="Text">The name of the status in text. (e.g. NotFound)</param>
public record DomainStatus(byte Code, string Text)
{
    private const byte _okMaxValueInDefaultCodes = 100;

    /// <summary>
    /// A dictionary that maps the name of the status to the DomainStatus instance.
    /// This is used when casting a <see cref="ResultModels.Result"/> to <see cref="ApiResponseModels.ApiResponse"/>"/>
    /// it looks up the Error.Code in this dictionary to find the corresponding DomainStatus.
    /// </summary>
    public static Dictionary<string, DomainStatus> Map { get; } = [];

    public Dictionary<string, List<string>>? Errors { get; init; }

    /// <summary>
    /// A function that determines if a DomainStatus is considered "Ok". and sets the Ok property in <see cref="ApiResponseModels.ApiResponse"/>
    /// You can customize this function to change the criteria for what is considered "Ok".
    /// </summary>
    public static Func<DomainStatus, bool> IsOkFunction { get; set; } = (DomainStatus domainStatus) => domainStatus.Code <= _okMaxValueInDefaultCodes;

    /// <summary>
    /// A function that checks if the given DomainStatus is considered "Ok" based on the IsOkFunction.
    /// </summary>
    /// <param name="domainStatus"></param>
    /// <returns>True if the DomainStatus is considered to be Ok</returns>
    public static bool IsOk(DomainStatus domainStatus) => IsOkFunction(domainStatus);

    public static readonly DomainStatus OK = InternalCreate(DomainStatusDefaults.Codes.OK);
    public static readonly DomainStatus NO_CONTENT = InternalCreate(DomainStatusDefaults.Codes.NO_CONTENT);

    public static readonly DomainStatus BAD_REQUEST = InternalCreate(DomainStatusDefaults.Codes.BAD_REQUEST);
    public static readonly DomainStatus INVALID_INPUT = BAD_REQUEST;
    public static readonly DomainStatus INVALID_MODEL_STATE = BAD_REQUEST;
    public static readonly DomainStatus UNAUTHORIZED = InternalCreate(DomainStatusDefaults.Codes.UNAUTHORIZED);

    public static readonly DomainStatus INVALID_CREDENTIALS = InternalCreate(DomainStatusDefaults.Codes.INVALID_CREDENTIALS);
    public static readonly DomainStatus USER_IS_LOCKED = InternalCreate(DomainStatusDefaults.Codes.USER_IS_LOCKED);
    public static readonly DomainStatus USERNAME_ALREADY_TAKEN = InternalCreate(DomainStatusDefaults.Codes.USERNAME_ALREADY_TAKEN);
    public static readonly DomainStatus EMAIL_ALREADY_TAKEN = InternalCreate(DomainStatusDefaults.Codes.EMAIL_ALREADY_TAKEN);
    public static readonly DomainStatus USER_IS_NOT_ACTIVE = InternalCreate(DomainStatusDefaults.Codes.USER_IS_NOT_ACTIVE);

    public static readonly DomainStatus FORBIDDEN = InternalCreate(DomainStatusDefaults.Codes.FORBIDDEN);
    public static readonly DomainStatus NOT_FOUND = InternalCreate(DomainStatusDefaults.Codes.NOT_FOUND);
    public static readonly DomainStatus NOT_ACCEPTABLE = InternalCreate(DomainStatusDefaults.Codes.NOT_ACCEPTABLE);
    public static readonly DomainStatus NOT_SUPPORTED = InternalCreate(DomainStatusDefaults.Codes.NOT_SUPPORTED);
    public static readonly DomainStatus ALREADY_EXISTS = InternalCreate(DomainStatusDefaults.Codes.ALREADY_EXISTS);
    public static readonly DomainStatus ENTITY_HAS_BEEN_CHANGED_SINCE_THEN = InternalCreate(DomainStatusDefaults.Codes.ENTITY_HAS_BEEN_CHANGED_SINCE_THEN);

    public static readonly DomainStatus SERVER_ERROR = InternalCreate(DomainStatusDefaults.Codes.SERVER_ERROR);
    public static readonly DomainStatus SERVER_CONFIGURATION_ERROR = InternalCreate(DomainStatusDefaults.Codes.SERVER_CONFIGURATION_ERROR);

    public static readonly DomainStatus DB_ERROR = InternalCreate(DomainStatusDefaults.Codes.DB_ERROR);
    public static readonly DomainStatus DB_DUPLICATE_ENTITY = InternalCreate(DomainStatusDefaults.Codes.DB_DUPLICATE_ENTITY);
    public static readonly DomainStatus DB_CONSTRAINT_VIOLATION = InternalCreate(DomainStatusDefaults.Codes.DB_CONSTRAINT_VIOLATION);
    public static readonly DomainStatus DB_DEPENDECY_CONSTRAINT_VIOLATED = InternalCreate(DomainStatusDefaults.Codes.DB_DEPENDECY_CONSTRAINT_VIOLATED);

    public static DomainStatus Create(byte value, [CallerMemberName] string? name = null)
    {
        var domainStatus = name == null ?
            throw new ArgumentNullException(nameof(name)) :
            new DomainStatus(value, name);

        return domainStatus;
    }

    private static DomainStatus InternalCreate(byte value, [CallerMemberName] string? name = null)
    {
        var domainStatus = name == null ?
            throw new ArgumentNullException(nameof(name)) :
            new DomainStatus(value, name);

        Map[name] = domainStatus;

        return domainStatus;
    }
}
