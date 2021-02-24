using System.Collections.Generic;
using DapperTest.Models;

namespace DapperTest.Services
{
    public interface IMovieRepo
    {
         public IEnumerable<Movie> GetMovies();
         public Movie GetMovieById(int id);
         public void AddMovie(Movie movie);
         public void UpdateMovie(int id, Movie movie);
         public void DeleteMovie(int id);
    }
}