using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);

            return View(movie);
        }

        public ActionResult Random()
        {
            const string movieName = "Shrek!";
            var movie = new Movie() { Id = 1, Name = movieName };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var movieCustomerViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(movieCustomerViewModel);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
               new Movie{Id = 1, Name = "Shrek"},
               new Movie{Id = 2, Name = "Shrek 2"},
               new Movie{Id = 3, Name = "Shrek 3"},
            };
        }
    }
}