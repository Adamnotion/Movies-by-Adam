using Microsoft.AspNetCore.Mvc;
using Movie.Web.Models;
using Movie.Web.Service.IService;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Movie.Web.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public async Task<IActionResult> TicketIndex()
        {


            List<TicketDto>? list = new();

            ResponseDto? response= await _ticketService.GetAllTicketsAsync();


            if (response != null && response.IsSuccess) 
            {
                list = JsonConvert.DeserializeObject<List<TicketDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
        public async Task<IActionResult> TicketCreate()
        {
            return View();
        }
		[HttpPost]
		
		public async Task<IActionResult> TicketCreate(TicketDto model)
		{
			if (ModelState.IsValid)
			{
				ResponseDto? response = await _ticketService.CreateTicketsAsync(model);

				if (response != null && response.IsSuccess)
				{
                    TempData["success"] = "Ticket Added successfully";
                    return RedirectToAction(nameof(TicketIndex));
				}
				else
				{
					TempData["error"] = response?.Message;
				}
			}
			return View(model);
		}
        public async Task <IActionResult> TicketDelete(int TicketId)
        {
			ResponseDto? response = await _ticketService.GetTicketByIdAsync(TicketId);
			if (response != null && response.IsSuccess)
			{
				TicketDto? model = JsonConvert.DeserializeObject<TicketDto>(Convert.ToString(response.Result));
				return View(model);
			}
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> TicketDelete(TicketDto ticketDto)
        {
            ResponseDto? response = await _ticketService.DeleteTicketsAsync(ticketDto.TicketId);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(TicketIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(ticketDto);
        }
    }
}