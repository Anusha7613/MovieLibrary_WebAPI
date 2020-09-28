using MovieLibrary_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLibrary_WebAPI.Repository
{
    public class MovieRepository : IRepository
    {
        private ApplicationDbContext dbContext = null;
        public MovieRepository()
        {
            dbContext = new ApplicationDbContext();
        }
          public void Dispose()
        {if (dbContext != null)
            {
                dbContext.Dispose();
            }
           
        }
        public IEnumerable<Movie> GetMovies()
        {
            return dbContext.Movies.ToList();
        }


        public Movie GetMovieById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var movie = dbContext.Movies.SingleOrDefault(m => m.Id == id.Value);
            if (movie == null)
            {
                throw new NullReferenceException(nameof(movie));

            }
            return movie;
        }


        public void CreateMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();
        }

        public void DeleteMovie(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var movie = dbContext.Movies.SingleOrDefault(m => m.Id == id.Value);
            if (movie == null)
            {
                throw new NullReferenceException();

            }
            dbContext.Movies.Remove(movie);
            dbContext.SaveChanges();
        }

      
        public void UpdateMovie(int? Id, Movie movie)
        {

            if (Id == null || movie == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }

            var movieInDb = dbContext.Movies.SingleOrDefault(m => m.Id == Id.Value);
            if (movieInDb == null)
            {
                throw new NullReferenceException();
            }
            movieInDb.Name = movie.Name;
            movieInDb.DirectorName = movie.DirectorName;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.GenreId = movie.GenreId;

            dbContext.SaveChanges();
        }
    }
}