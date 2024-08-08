
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Web.Models;
using Movie.Web.Service.IService;
using Movie.Web.Utility;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Movie.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        
        public async Task<IActionResult> Index()
        {

            List<MovieDto>? list = new();

            ResponseDto? response = await _movieService.GetAllMoviesAsync();


            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<MovieDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> MovieDetails(int movieId)
        {

            MovieDto? model = new();

            ResponseDto? response = await _movieService.GetMovieByIdAsync(movieId);


            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<MovieDto>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message ;
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
