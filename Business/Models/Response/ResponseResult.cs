using Business.Models.Response;

namespace Business.Models.Response
{
    public class ResponseResult
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public object? Result { get; set; }

        public static ResponseResult Exists(string? message = default) => new()
        {
            Success = false,
            StatusCode = 409,
            Message = message
        };

        public static ResponseResult InvalidModel(string? message = default) => new()
        {
            Success = false,
            StatusCode = 400,
            Message = message
        };

        public static ResponseResult Failed(string? message = default) => new()
        {
            Success = false,
            StatusCode = 500,
            Message = message
        };

        public static ResponseResult Created(string? message = default) => new()
        {
            Success = false,
            StatusCode = 201,
            Message = message
        };
    }
}


public class ResponseResult<T> : ResponseResult
{
    public T? Result { get; set; }

    public static ResponseResult Ok(string? message = default, T? result = default) => new()
    {
        Success = true,
        StatusCode = 200,
        Message = message,
        Result = result
    };

    public static ResponseResult NotFound(string? message = default) => new()
    {
        Success = false,
        StatusCode = 404,
        Message = message,
    };
}