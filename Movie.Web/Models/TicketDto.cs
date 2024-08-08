namespace Movie.Web.Models
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public required string TicketCode { get; set; }
        public required double TicketPrice { get; set; }
    }
}
