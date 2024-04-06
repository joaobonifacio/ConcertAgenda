namespace API.Errors
{
    public class ApiResponse
    {
        public int? StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(){}

        public ApiResponse(int? statusCode, string? message = null)
        {
            if(statusCode != null)
            {
                StatusCode = (int)statusCode;
            }
            
            if(message != null && statusCode != null)
            {
                Message = message ?? GetDeafultMessageForStatusCode((int)statusCode);
            }
            else
            {
                Message = "Something went wrong";
            }
        }

        private string GetDeafultMessageForStatusCode(int statusCode)
        {
            return statusCode switch 
            {
                400 => "A bad request you have made",
                401 => "Authorized, you are not",
                404 => "Reesource found, it was not",
                500 => "Error 500",
                _ => "null"
            };
        }
    }
}