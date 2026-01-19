using System.Text.Json.Serialization;

namespace LIBRARY_MANAGEMENT_SYSTEM.Utilities
{
    public class ApiResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

   

public class ApiResponse<T> : ApiResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T Data { get; set; }

        public static ApiResponse<T> Success(T data, string message)
            => new()
            {
                Code = ApiResponseMessages.SuccessCode,
                Message = message,
                Data = data
            };

        public static ApiResponse<T> Success(string message)
            => new()
            {
                Code = ApiResponseMessages.SuccessCode,
                Message = message          
            };

        public static ApiResponse<T> Fail(string message, string code)
            => new()
            {
                Code = code,
                Message = message
            };
    }
}
