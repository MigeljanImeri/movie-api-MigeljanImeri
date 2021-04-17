using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApi.Models;
using MovieApi.Services;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly ILogger<MovieController> _logger;
        private IMovieSerivce _service;


        public MovieController(ILogger<MovieController> logger, IMovieSerivce service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            IEnumerable<Movie> list = _service.GetMovies();
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("{name}", Name = "GetMovie")]
        public IActionResult GetMovieByName(string name)
        {
            Movie m = _service.GetMovieByName(name);

            if (m != null) return Ok(m);
            return BadRequest();

        }
        
        [HttpGet("year/")]
        public IActionResult GetMovieByYear(int year)
        {
            Movie m = _service.GetMovieByYear(year);

            if (m != null) return Ok(m);
            return BadRequest();
        }
        [HttpPost]
        public IActionResult CreateMovie(Movie m)
        {
            _service.CreateMovie(m);
            //add code to determine if succesful
            return CreatedAtRoute("GetMovie", new { name = m.Name }, m);
        }
        [HttpPut("{name}")]
        public IActionResult UpdateMovie(string name, Movie movieIn)
        {
            _service.UpdateMovie(name,movieIn);
            return NoContent();
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteMovie(string name)
        {
            _service.DeleteMovie(name);
            return NoContent();
        }
    }
}
