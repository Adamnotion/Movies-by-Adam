
using AutoMapper;
using Movies.Services.TicketAPI.Data;
using Movies.Services.TicketAPI.Models;
using Movies.Services.TicketAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Movie.Services.TicketAPI.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    [Authorize]
    public class TicketAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public TicketAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Ticket> objList = _db.Tickets.ToList();
                _response.Result = _mapper.Map<IEnumerable<TicketDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Ticket obj = _db.Tickets.First(u => u.TicketId == id);
                _response.Result = _mapper.Map<TicketDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Ticket obj = _db.Tickets.First(u => u.TicketCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<TicketDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] TicketDto ticketDto)
        {
            try
            {
                Ticket obj = _mapper.Map<Ticket>(ticketDto);
                _db.Tickets.Add(obj);
                _db.SaveChanges();


                _response.Result = _mapper.Map<TicketDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] TicketDto ticketDto)
        {
            try
            {
                Ticket obj = _mapper.Map<Ticket>(ticketDto);
                _db.Tickets.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<TicketDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Ticket obj = _db.Tickets.First(u => u.TicketId == id);
                _db.Tickets.Remove(obj);
                _db.SaveChanges();


     

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
