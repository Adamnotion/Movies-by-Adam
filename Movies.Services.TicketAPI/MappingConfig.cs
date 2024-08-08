using AutoMapper;
using Movies.Services.TicketAPI.Models;
using Movies.Services.TicketAPI.Models.Dto;

namespace Movies.Services.TicketAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TicketDto, Ticket>();
                config.CreateMap<Ticket, TicketDto>();
            });
            return mappingConfig;
        }
    }
}
