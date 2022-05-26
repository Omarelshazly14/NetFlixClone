using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIs.Models;
using APIs.Repositories;
using APIs.DTO;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepo actorRepo;

        public ActorController(IActorRepo actorRepo)
        {
            this.actorRepo = actorRepo;
        }

        // GET: api/Actor
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Actor> actors = actorRepo.GetAll();
                return Ok(actors);
            }
            catch (Exception ex)
            {
                return BadRequest("Error Getting Actors");
            }
        }

        // GET: api/Actor/5
        [HttpGet("{id:int}", Name = "GetOneActor")]
        public IActionResult GetActor(int id)
        {
            try
            {
                Actor? actor = actorRepo.GetById(id);
                if (actor == null) return BadRequest("Actor Not Found");

                ActorWithMoviesDTO actorDTO = new ActorWithMoviesDTO();
                actorDTO.Id = actor.Id;
                actorDTO.Actor_Name = actor.Name;
                foreach (var item in actor.ActorMovies)
                {
                    actorDTO.Actor_Movies.Add(item.Movie);
                }
                return Ok(actorDTO);
            }
            catch (Exception ex)
            {
                return BadRequest("Error Getting Genre");
            }
        }

        // POST: api/Actor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Post([FromBody]Actor newActor)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Actor Not Valid");

                actorRepo.Insert(newActor);
                string? url = Url.Link("GetOneActor", new { id = newActor.Id });
                return Created(url, newActor);

            }
            catch (Exception ex)
            {
                return BadRequest("Could not Add Actor");
            }
        }

        // PUT: api/Actor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public IActionResult Put([FromBody] Actor newActor)
        {
            try
            {
                if (actorRepo.Update(newActor) == 0) return BadRequest("Could not Update Actor");
                return StatusCode(204, newActor);

            }
            catch (Exception ex)
            {
                return BadRequest("Could not Update Actor");
            }
        }


        // DELETE: api/Actor/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (actorRepo.Remove(id) == 0) return BadRequest("Could not Delete Actor");
                return StatusCode(204, "Actor Removed Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Could not Delete Actor");
            }
        }

        //private bool ActorExists(int id)
        //{
        //    return (actorRepo.GetAll()?.Any(a => a.Id == id)).GetValueOrDefault();
        //}
    }
}
