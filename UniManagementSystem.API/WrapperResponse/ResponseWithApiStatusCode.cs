namespace UniManagementSystem.API.WrapperResponse
{
    public class ResponseWithApiStatusCode<T>
    {
        public int StatusCode { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionError { get; set; }
        public string ExceptionStackTrace { get; set; }
        public string InnerException { get; set; }

        public T Data { get; set; }
    }
}
