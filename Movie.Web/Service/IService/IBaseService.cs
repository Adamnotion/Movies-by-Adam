using Movie.Web.Models;

namespace Movie.Web.Service.IService
{
        public interface IBaseService
        {
            Task<ResponseDto?> SendAsync(RequestDto requestDto , bool withBearer=true);
        }
}