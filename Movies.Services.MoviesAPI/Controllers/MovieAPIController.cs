using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Services.MovieAPI.Data;
using Movies.Services.MovieAPI.Models;
using Movies.Services.MovieAPI.Models.Dto;
using static Azure.Core.HttpHeader;

namespace Movies.Services.MovieAPI.Controllers
{
    [Route("api/movie")]
    [ApiController]
  
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
                IEnumerable<Movie> objList = _db.Movies.ToList();
                _response.Result = _mapper.Map<IEnumerable<MovieDto>>(objList);
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
                Movie obj = _db.Movies.First(u => u.MovieId == id);
                _response.Result = _mapper.Map<MovieDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

       

        [HttpPost]

        public ResponseDto Post([FromBody] MovieDto ticketDto)
        {
            try
            {
                Movie obj = _mapper.Map<Movie>(ticketDto);
                _db.Movies.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<MovieDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPut]

        public ResponseDto Put([FromBody] MovieDto ticketDto)
        {
            try
            {
                Movie obj = _mapper.Map<Movie>(ticketDto);
                _db.Movies.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<MovieDto>(obj);
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

        public ResponseDto Delete(int id)
        {
            try
            {
                Movie obj = _db.Movies.First(u => u.MovieId == id);
                _db.Movies.Remove(obj);
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