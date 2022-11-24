namespace TicketsApi.DTOs.ApiResult
{
    public class ApiResult<T>
    {
        public T Result { get; }
        public string ErrorMessage { get; set; }

        public ApiResult(T result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
        }
    }
}
