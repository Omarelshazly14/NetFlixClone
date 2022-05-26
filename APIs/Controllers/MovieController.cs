using APIs.DTO;
using APIs.Models;
using APIs.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepo movieRepo;

        public MovieController(IMovieRepo movieRepo)
        {
            this.movieRepo = movieRepo;
        }
        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Movie> movies = movieRepo.GetAll();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest("Error Getting Actors");
            }
        }

        // GET api/<MovieController>/5
        [HttpGet("{id:int}", Name ="GetOneMovie")]
        public IActionResult Get(int id)
        {
            try
            {
                Movie? movie = movieRepo.GetById(id);
                if (movie == null) return BadRequest("Movie Not Found");

                MovieWithActorsDTO movieDTO = new MovieWithActorsDTO();
                movieDTO.Id = movie.Id;
                movieDTO.Movie_Name = movie.Name;
                foreach (var item in movie.MovieActors)
                {
                    movieDTO.Movie_Actors.Add(item.Actor);
                }
                return Ok(movieDTO);
            }
            catch (Exception ex)
            {
                return BadRequest("Error Getting Genre");
            }
        }

        // POST api/<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] Movie newMovie)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Movie Not Valid");

                movieRepo.Insert(newMovie);
                string? url = Url.Link("GetOneMovie", new { id = newMovie.Id });
                return Created(url, newMovie);

            }
            catch (Exception ex)
            {
                return BadRequest("Could not Add Movie");
            }
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] Movie newMovie)
        {
            try
            {
                if (movieRepo.Update(newMovie) == 0) return BadRequest("Could not Update Movie");
                return StatusCode(204, newMovie);

            }
            catch (Exception ex)
            {
                return BadRequest("Could not Update Movie");
            }
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (movieRepo.Remove(id) == 0) return BadRequest("Could not Delete Movie");
                return StatusCode(204, "Movie Removed Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Could not Delete Movie");
            }
        }
        //private bool MovieExists(int id)
        //{
        //    return (movieRepo.GetAll()?.Any(m => m.Id == id)).GetValueOrDefault();
        //}
    }
}
