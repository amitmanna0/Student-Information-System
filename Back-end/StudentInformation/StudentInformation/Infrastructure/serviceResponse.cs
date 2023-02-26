namespace StudentInformation.Infrastructure
{
    public class serviceResponse<T>
    {
        public T? data { get; set; } 
        public string message { get; set; } = string.Empty;
    }
}
