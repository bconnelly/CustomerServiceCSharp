namespace CustomersService.ExceptionManagment
{
    public class ErrorResponse
    {
        public int statusCode { get; set; }
        public string? message { get; set; }
        public string? title { get; set; }

    }
}
