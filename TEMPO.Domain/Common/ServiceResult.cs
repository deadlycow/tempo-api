namespace TEMPO.Domain.Common;

public class ServiceResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }

    public static ServiceResult SuccessResult() => new() { Success = true };
    public static ServiceResult Failure(string errorMessage) => new() { Success = false, ErrorMessage = errorMessage };
}

public class ServiceResult<T>
{
    public bool Success { get; }
    public T? Data { get; }
    public string? ErrorMessage { get; }

    private ServiceResult(bool success, T? data, string? errorMessage)
    {
        Success = success;
        Data = data;
        ErrorMessage = errorMessage;
    }

    public static ServiceResult<T> SuccessResult(T data)
        => new(true, data, null);

    public static ServiceResult<T> Failure(string errorMessage)
        => new(false, default, errorMessage);
}