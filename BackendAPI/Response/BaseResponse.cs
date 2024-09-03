using BackendAPI.Data;

namespace BackendAPI.Response
{
    public class BaseResponse<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public T? data { get; set; }
    }
}
