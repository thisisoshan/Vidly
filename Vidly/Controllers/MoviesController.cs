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
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Avengers" };

            var customers = new List<Customer>
            {
                new Customer { Name= "Customer1"},
                new Customer { Name= "Customer2"},
                new Customer { Name= "Customer3"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
        public ActionResult Edit(int id)
        {
            var idText = "id: " + id;
            return Content(idText);
        }

        public ActionResult Index(int? pageIndex, String sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleasedDate(int year, int month)
        {
            var text = year + "/" + month;
            return Content(text);
        }
    }
}