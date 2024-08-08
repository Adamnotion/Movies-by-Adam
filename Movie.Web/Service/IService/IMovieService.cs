using Movie.Web.Models;

namespace Movie.Web.Service.IService
{
    public interface IMovieService
    {
        Task<ResponseDto?> GetMovieAsync(string TicketCode);
        Task<ResponseDto?> GetAllMoviesAsync();
        Task<ResponseDto?> GetMovieByIdAsync(int id);
        Task<ResponseDto?> CreateMoviesAsync(MovieDto movieDto);
        Task<ResponseDto?> UpdateMoviesAsync(MovieDto movieDto);
        Task<ResponseDto?> DeleteMoviesAsync(int id);
    }
}
