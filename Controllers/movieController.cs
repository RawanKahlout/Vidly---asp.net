using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myvidly.Models;
using myvidly.ViewModel;
using System.Data.Entity;
using System.Linq.Expressions;

namespace myvidly.Controllers
{
    public class movieController : Controller
    {
        private myVidlyContext _context;
        public movieController()
        { _context = new myVidlyContext(); }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpPost]
        public ActionResult save(byte genre, movieGenre movieObj)
        {
            if (movieObj.movie.id == 0) {
                movieObj.movie.genreId = genre;
                movieObj.movie.AddTime = DateTime.Now;
                _context.Movies.Add(movieObj.movie);
            }
            else
            {
                var movie = _context.Movies.SingleOrDefault(c => c.id == movieObj.movie.id);
                movie.MovieName = movieObj.movie.MovieName;
                movie.RealeseDate = movieObj.movie.RealeseDate;
                movie.Stock = movieObj.movie.Stock;
                movie.genreId = genre;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {

            var movie = _context.Movies.SingleOrDefault(c => c.id == id);
            if (movie == null) return HttpNotFound();
            else
            {
                var viewModel = new movieGenre()
                {
                    movie = movie,
                    genre = _context.Genres.ToList()
                };
                return View("newMovie", viewModel);
            }
        }
        public ActionResult Index()
        {
            var movieList = _context.Movies.Include(c => c.genre).ToList();
            return View(movieList);
        }
        public ActionResult details(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var movieDetails = _context.Movies.SingleOrDefault(c =>
               c.id == id);
            if (movieDetails != null)
                return View(movieDetails);
            else
                return HttpNotFound();
        }
        public ActionResult random()
        {
            var movie = new movie() { id = 94, MovieName = "friends" };
            var customersList = new List<customer>
            { new customer {customerName = "rawan", id = 1 },
              new customer { customerName = "Mohammed", id = 2 }
            };
            var viewModel = new RandomMovieViewModel()
            {
                movies = movie,
                customers = customersList
            };
            return View(viewModel);
        }
        //[Route("movie/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)// it should be id or redefine in routing, or we need to use this route as 
                                                               //key value pair
        {

            return Content(year + "/" + month);
        }
        public ActionResult directToNewMovie()
        {
            var genresList = _context.Genres;
            var viewModel = new movieGenre()
            {
                genre = genresList
            };
            return View("newMovie", viewModel);
        }



    }
}