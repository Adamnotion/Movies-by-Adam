using Microsoft.AspNetCore.Mvc;
using Movie.Web.Models;
using Movie.Web.Service.IService;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Movie.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IActionResult> MovieIndex()
        {


            List<MovieDto>? list = new();

            ResponseDto? response= await _movieService.GetAllMoviesAsync();


            if (response != null && response.IsSuccess) 
            {
                list = JsonConvert.DeserializeObject<List<MovieDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"]=response?.Message;
            }

            return View(list);
        }
        public async Task<IActionResult> MovieCreate()
        {
            return View();
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> MovieCreate(MovieDto model)
		{
			if (ModelState.IsValid)
			{
				ResponseDto? response = await _movieService.CreateMoviesAsync(model);

				if (response != null && response.IsSuccess)
				{
                    TempData["success"] = "Movie Added successfully";
					return RedirectToAction(nameof(MovieIndex));
				}
				else
				{
					TempData["error"] = response?.Message;
				}
			}
			return View(model);
		}
        public async Task <IActionResult> MovieDelete(int MovieId)
        {
			ResponseDto? response = await _movieService.GetMovieByIdAsync(MovieId);
			if (response != null && response.IsSuccess)
			{
				MovieDto? model = JsonConvert.DeserializeObject<MovieDto>(Convert.ToString(response.Result));
				return View(model);
			}
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> MovieDelete(MovieDto movieDto)
        {
            ResponseDto? response = await _movieService.DeleteMoviesAsync(movieDto.MovieId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Movie deleted successfully";
                return RedirectToAction(nameof(MovieIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(movieDto);
        }
        public async Task<IActionResult> MovieEdit(int MovieId)
        {
            ResponseDto? response = await _movieService.GetMovieByIdAsync(MovieId);
            if (response != null && response.IsSuccess)
            {
                MovieDto? model = JsonConvert.DeserializeObject<MovieDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> MovieEdit(MovieDto movieDto)
        {
            ResponseDto? response = await _movieService.UpdateMoviesAsync(movieDto);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Movie updated successfully";
                return RedirectToAction(nameof(MovieIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(movieDto);
        }
    }
}