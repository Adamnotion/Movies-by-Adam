using Movie.Web.Models;

namespace Movie.Web.Service.IService
{
    public interface ITicketService
    {
        Task<ResponseDto?> GetTicketAsync(string TicketCode);
        Task<ResponseDto?> GetAllTicketsAsync();
        Task<ResponseDto?> GetTicketByIdAsync(int id);
        Task<ResponseDto?> CreateTicketsAsync(TicketDto ticketDto);
        Task<ResponseDto?> UpdateTicketsAsync(TicketDto ticketDto);
        Task<ResponseDto?> DeleteTicketsAsync(int id);
    }
}
