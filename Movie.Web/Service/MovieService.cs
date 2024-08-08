using Movie.Web.Models;
using Movie.Web.Service.IService;
using Movie.Web.Utility;

namespace Movie.Web.Service
{
    public class MovieService : IMovieService
    {
        private readonly IBaseService _baseService;
        public MovieService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateMoviesAsync(MovieDto movieDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data=movieDto,
                Url = SD.MovieAPIBase + "/api/Movie"
            });
        }

        public async Task<ResponseDto?> DeleteMoviesAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.MovieAPIBase + "/api/Movie/" + id
            });
        }

        public async Task<ResponseDto?> GetAllMoviesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.MovieAPIBase + "/api/Movie"
            });
        }

        public async Task<ResponseDto?> GetMovieAsync(string MovieCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.MovieAPIBase + "/api/Movie/GetByCode/"+MovieCode
            });
        }

        public async Task<ResponseDto?> GetMovieByIdAsync(int id)
        {

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.MovieAPIBase + "/api/Movie/" + id
            }); 
        }

        public async Task<ResponseDto?> UpdateMoviesAsync(MovieDto movieDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = movieDto,
                Url = SD.MovieAPIBase + "/api/Movie"
            });
        }
    }
}
