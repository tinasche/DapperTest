using System;
using System.Collections.Generic;
using System.Linq;
using DapperTest.Data;
using DapperTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DapperTest.Services
{
    public class EFMovieRepo : IMovieRepo
    {
        private readonly DapperDbContext _context;

        public EFMovieRepo(DapperDbContext context)
        {
            _context = context;
        }

        public void AddMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.MovieId == id);
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.MovieId == id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public void UpdateMovie(int id, Movie movie)
        {
            
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}