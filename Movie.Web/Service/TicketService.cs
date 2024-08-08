using Movie.Web.Models;
using Movie.Web.Service.IService;
using Movie.Web.Utility;

namespace Movie.Web.Service
{
    public class TicketService : ITicketService
    {
        private readonly IBaseService _baseService;
        public TicketService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> CreateTicketsAsync(TicketDto ticketDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data=ticketDto,
                Url = SD.TicketAPIBase + "/api/Ticket"
            });
        }

        public async Task<ResponseDto?> DeleteTicketsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.TicketAPIBase + "/api/Ticket/" + id
            });
        }

        public async Task<ResponseDto?> GetAllTicketsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TicketAPIBase + "/api/Ticket"
            });
        }

        public async Task<ResponseDto?> GetTicketAsync(string TicketCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TicketAPIBase + "/api/Ticket/GetByCode/"+TicketCode
            });
        }

        public async Task<ResponseDto?> GetTicketByIdAsync(int id)
        {

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TicketAPIBase + "/api/Ticket/" + id
            }); 
        }

        public async Task<ResponseDto?> UpdateTicketsAsync(TicketDto ticketDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = ticketDto,
                Url = SD.TicketAPIBase + "/api/Ticket"
            });
        }
    }
}
