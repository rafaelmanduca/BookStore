using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class GenresController : Controller
    {
        public IActionResult Index()
        {
            List<Genre> genres = new List<Genre>
            {
                new Genre(1, "Drama"),
                new Genre(2, "Comédia"),
                new Genre(3, "Ação"),
                new Genre(4, "Romance"),
            };

            return View(genres);
        }
    }
}
