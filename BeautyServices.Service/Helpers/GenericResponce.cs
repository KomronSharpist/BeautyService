namespace BeautyServices.Service.Helpers;

public class GenericResponce<TValue>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public TValue Value { get; set; }
}
