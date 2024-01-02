using System.Net;

namespace ProjectManagementApi.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public HttpStatusCode Code { get; set; } = HttpStatusCode.OK;
        public string? Message { get; set; } = null;
    }
}
