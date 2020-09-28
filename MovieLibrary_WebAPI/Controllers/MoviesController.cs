using MovieLibrary_WebAPI.Models;
using MovieLibrary_WebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MovieLibrary_WebAPI.Controllers
{
    [RoutePrefix("api/Movies")]
    public class MoviesController : ApiController
    {
        private IRepository _repository = null;
        public MoviesController(IRepository repository)
        {
            this._repository = repository;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }


        //api/Movies/GetMovies
        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return _repository.GetMovies();
        }


        ////api/Movies/GetGenres
        //[Route("GetGenres")]
        //[HttpGet]
        //public IEnumerable<Genre> GetGenres()
        //{
        //    return _repository.GetGenres();
        //}

        [Route("GetById/{id?}")]
        [HttpGet]
        public IHttpActionResult GetMovie([FromUri] int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var movie = _repository.GetMovieById(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);

        }
        [HttpPost]
        [Route("CreateMovie")]
        public IHttpActionResult CreateMovie([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _repository.CreateMovie(movie);
            }
            catch (ArgumentNullException)
            {
                return BadRequest(nameof(movie));
            }
            return Created("/api/Movies/GetMovie/{id}", movie);
        }







            //        //To Create a record in movies

            //        [Route("CreateMovie")]
            //        [HttpPost]
            //        public IHttpActionResult CreateMovie([FromBody]Movie movie)
            //        {
            //            if (!ModelState.IsValid)
            //            {
            //                return BadRequest(ModelState);
            //            }
            //            dbContext.Movies.Add(movie);
            //            dbContext.SaveChanges();
            //            return Created("/api/Movies/GetMovie/{id}", movie);
            //        }


            //        //To Update a record in movies

            // [HttpPut]
            //[Route("UpdateMovie/{id?}")]
            //public IHttpActionResult UpdateMovie([FromUri] int? id,[FromBody] Movie movie)
            //        {
            //            if(id==null || movie == null)
            //            {
            //                return BadRequest(nameof(movie));
            //            }

            //            if (!ModelState.IsValid)
            //            {
            //                return BadRequest(ModelState);
            //            }
            //            var movieinDb = dbContext.Movies.SingleOrDefault(m => m.Id == id.Value);
            //            if (movieinDb == null)
            //            {
            //                return NotFound();
            //            }
            //            movieinDb.Name = movie.Name;
            //            movieinDb.DirectorName = movie.DirectorName;
            //            movieinDb.ReleaseDate = movie.ReleaseDate;
            //            movieinDb.GenreId = movie.GenreId;
            //            dbContext.SaveChanges();
            //            return Ok(movieinDb);

            //        }


            //        //To Delete a record from movies
            //[HttpDelete]
            //[Route("DeleteMovieById/{id?}")]
            //public IHttpActionResult DeleteMovie(int? id)
            //        {
            //            if (id == null)
            //            {
            //                return BadRequest(nameof(id));
            //            }
            // var movieinDb=_repository.DeleteMovieById(id.Value);
            //          //  var movieinDb = dbContext.Movies.SingleOrDefault(m => m.Id == id.Value);
            //            if (movieinDb == null)
            //            {
            //                return NotFound();
            //            }

            //            dbContext.Movies.Remove(movieinDb);
            //            dbContext.SaveChanges();
            //            return Ok(movieinDb);
            //        }


            //[HttpDelete]
            //[Route("DeleteMovie/{id?}")]
            //public IHttpActionResult DeleteMovie(int? id)
            //{
            //    if (id == null)
            //    {
            //        return BadRequest(nameof(id));
            //    }
            //    var movieinDb = _repository.DeleteMovie(id.Value);
            //    //  var movieinDb = dbContext.Movies.SingleOrDefault(m => m.Id == id.Value);
            //    if (movieinDb == null)
            //    {
            //        return NotFound();
            //    }


            //    return Ok(movieinDb);
            //}

            [HttpPut]
        [Route("UpdateMovie/{id?}")]

        public IHttpActionResult UpdateMovie([FromUri] int? id, [FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _repository.UpdateMovie(id.Value, movie);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("DeleteMovie/{id?}")]
    

        public IHttpActionResult DeleteMovie(int? id)
        {
            //    if (Id == null)
            //    {
            //        return BadRequest(nameof(Id));
            //    }
            //    _repository.DeleteMovie(Id);

            //    return Ok();
            try
            {
                _repository.DeleteMovie(id.Value);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
    }

}


