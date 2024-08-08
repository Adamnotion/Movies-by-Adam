using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Movies.Services.TicketAPI.Models
{

    [AutoMap(typeof(Ticket))]
    public class Ticket
    {
        [Key]
        public int TicketId {  get; set; }
        [Required]
        public string? TicketCode { get ; set; }
        public  double TicketPrice { get; set; }



    }
}
