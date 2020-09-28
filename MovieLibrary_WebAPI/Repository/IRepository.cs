using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary_WebAPI.Models;
using MovieLibrary_WebAPI.Repository;

namespace MovieLibrary_WebAPI.Repository
{
   public  interface IRepository:IDisposable
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieById(int? id);
        void CreateMovie(Movie movie);
        void UpdateMovie(int? id, Movie movie);
        void DeleteMovie(int? id);
    }
}
