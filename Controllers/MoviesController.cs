using System.Collections.Generic;
using DapperTest.Models;
using DapperTest.Services;
using Microsoft.AspNetCore.Mvc;

//TODO: Improve validation checks; Implement asynchronous technique
namespace DapperTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepo _movieRepo;

        public MoviesController(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            var movies = _movieRepo.GetMovies();
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpGet("{id}", Name="GetMovieById")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            var movie = _movieRepo.GetMovieById(id);
            if (movie != null)
            {
                return Ok(movie);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Movie> AddMovie(Movie movie)
        {
            _movieRepo.AddMovie(movie);
            //TODO: find a way to recall the new MovieId and attach it to object response of ActionResult
            return Ok(movie);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, Movie movie)
        {
            if (movie != null)
            {
                _movieRepo.UpdateMovie(id, movie);
                return NoContent();
            }

            return NotFound();      
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            _movieRepo.DeleteMovie(id);
            return NoContent();
        } 
    }
}