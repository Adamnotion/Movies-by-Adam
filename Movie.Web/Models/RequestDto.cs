using static Movie.Web.Utility.SD;
using System.Security.AccessControl;


namespace Movie.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object  Data { get; set; }
        public string AccessToken  { get; set; }
    }
}
