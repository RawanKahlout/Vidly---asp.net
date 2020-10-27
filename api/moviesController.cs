using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using myvidly.Models;
namespace myvidly.api
{

    public class moviesController : ApiController
    {
        private myVidlyContext _context;
        public moviesController()
        {
            _context = new myVidlyContext();
        }
        public IEnumerable<movie> getMovieList()
        {
            return _context.Movies.ToList();
        }
        public movie getMovie(int id)
        {
            var customer = _context.Movies.SingleOrDefault(w => w.id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }
        [HttpPost]
        public movie createMovie(movie movieObj)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Movies.Add(movieObj);
            _context.SaveChanges();
            return movieObj;
        }
        [HttpPut]
        public void updaateMovie(int id, movie movieObj)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.id == id);
            if (!ModelState.IsValid ) throw new HttpResponseException(HttpStatusCode.BadRequest);
              if (movie == null)
                  throw new HttpResponseException(HttpStatusCode.NotFound);
            movie.MovieName = movieObj.MovieName;
            movie.RealeseDate = movieObj.RealeseDate;
            movie.Stock = movieObj.Stock;
            movie.genreId = movieObj.genreId;
            _context.SaveChanges();

        }
        [HttpDelete]
        public void delteMovie(movie movieObj, int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movie);
            _context.SaveChanges();

        }

    }
}
