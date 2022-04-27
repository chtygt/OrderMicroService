namespace Services.Shared.Models
{
    public class ServiceResult
    {
        public bool Status { get; set; }  = false;
        public string Data { get; set; }
        public int Total { get; set; }
        public string Message { get; set; }
    }

    public class ServiceResult<T>
    {
        public bool Status { get; set; } = false;
        public T Data { get; set; }
        public int Total { get; set; }
        public string Message { get; set; }

    }

    public class ServiceListResult<T>
    {
        public List<T> Data { get; set; }
        public int Total { get; set; }
        public string Message { get; set; }
    }
}
