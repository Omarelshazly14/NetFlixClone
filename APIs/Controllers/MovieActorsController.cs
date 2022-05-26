using APIs.Models;
using APIs.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorsController : ControllerBase
    {
        private readonly IMovieActorRepo movieActorRepo;

        public MovieActorsController(IMovieActorRepo movieActorRepo)
        {
            this.movieActorRepo = movieActorRepo;
        }
        // GET: api/<MovieActorsController>
        //[HttpGet("{id:int}", Name ="GetMovieActors")]
       // public void GetAllMovieActors(int MovieId)
        //{
            //try
            //{
            //    List<MovieActor> movieActors = movieActorRepo.GetByMovieID(MovieId);
            //    if (movieActors == null) return BadRequest("No Actors for This Movie");

            //    GenreWithMoviesDTO genreDTO = new GenreWithMoviesDTO();
            //    genreDTO.Genre_Name = genre.Name;
            //    foreach (var movie in genre.Movies)
            //    {
            //        genreDTO.Genre_Movies.Add(movie);
            //    }
            //    return Ok(genreDTO);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest("Error Getting Genre");
            //}
        //}
        
        // GET api/<MovieActorsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MovieActorsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovieActorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieActorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
