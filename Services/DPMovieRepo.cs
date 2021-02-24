using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DapperTest.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DapperTest.Services
{
    public class DPMovieRepo : IMovieRepo
    {
        private readonly SqlConnection _dapperConn;
        

        public DPMovieRepo(IConfiguration configuration)
        {
            _dapperConn = new SqlConnection(configuration.GetConnectionString("DapperTestConn"));
        }


        public void AddMovie(Movie movie)
        {
            var addMovieSql = "INSERT INTO Movies (Title, Director, Genre, ReleaseYear) VALUES (@Title, @Director, @Genre, @ReleaseYear)";
            _dapperConn.Execute(addMovieSql, movie);
        }

        public void DeleteMovie(int id)
        {
            var theMovie = GetMovieById(id);
            var deleteMovieSql = "DELETE FROM Movies WHERE MovieId = @MovieId";
            _dapperConn.Execute(deleteMovieSql, new { @MovieId = theMovie.MovieId } );
        }

        public Movie GetMovieById(int id)
        {
            var getMovieSql = "SELECT * FROM Movies WHERE MovieId = @MovieId";
            var theMovie = _dapperConn.Query<Movie>(getMovieSql, new { @MovieId = id}).Single();
            //FIXME: Resolve content issues for non-existent results.
            if (theMovie != null)
            {
                return theMovie;
            }
            return null;

        }

        public IEnumerable<Movie> GetMovies()
        {

            var getAllMoviesSql = "SELECT * FROM Movies";
            return _dapperConn.Query<Movie>(getAllMoviesSql).ToList();
        }

        public void UpdateMovie(int id, Movie movie)
        {
            var updateMovieSql = "UPDATE Movies SET Title=@Title, Director=@Director, Genre=@Genre, ReleaseYear=@ReleaseYear " +
            "WHERE MovieId=@MovieId";
            movie.MovieId = id;
            _dapperConn.Execute(updateMovieSql, movie);
        }
    }
}