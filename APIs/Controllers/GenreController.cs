using APIs.DTO;
using APIs.Models;
using APIs.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepo genreRepo;

        public GenreController(IGenreRepo genreRepo)
        {
            this.genreRepo = genreRepo;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Genre> genres = genreRepo.GetAll();
                return Ok(genres);
            }catch(Exception ex)
            {
                return BadRequest("Error Getting Genre");
            }
        }

        // GET api/<GenreController>/5
        [HttpGet("{id:int}",Name ="GetOneGenre")]
        public IActionResult Get(int id)
        {
            try
            {
                Genre? genre = genreRepo.GetById(id);
                if (genre == null) return BadRequest("Genre Not Found");

                GenreWithMoviesDTO genreDTO = new GenreWithMoviesDTO();
                genreDTO.Id = genre.Id;
                genreDTO.Genre_Name = genre.Name;
                foreach (var movie in genre.Movies)
                {
                    genreDTO.Genre_Movies.Add(movie);
                }
                return Ok(genreDTO);
            }catch(Exception ex)
            {
                return BadRequest("Error Getting Genre");
            }
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult Post([FromBody] Genre newGenre)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Genre Not Valid");

                genreRepo.Insert(newGenre);
                string? url = Url.Link("GetOneGenre", new { id = newGenre.Id });
                return Created(url, newGenre);

            }catch(Exception ex)
            {
                return BadRequest("Could not Add Genre");
            }
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] Genre newGenre)
        {
            try
            {
                if (genreRepo.Update(newGenre) == 0) return BadRequest("Could not Update Genre");
                return StatusCode(204, newGenre);

            }catch(Exception ex)
            {
                return BadRequest("Could not Update Genre");
            }
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (genreRepo.Remove(id) == 0) return BadRequest("Could not Delete Genre");
                return StatusCode(204, "Genre Removed Successfully");
            }catch(Exception ex)
            {
                return BadRequest("Could not Delete Genre");
            }
        }
        //private bool ActorExists(int id)
        //{
        //    return (genreRepo.GetAll()?.Any(g => g.Id == id)).GetValueOrDefault();
        //}
    }
}
