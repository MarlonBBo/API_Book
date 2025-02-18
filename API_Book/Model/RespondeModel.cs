namespace API_Book.Model
{
    public class RespondeModel<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
