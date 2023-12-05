using ASI.Basecode.Data.Models;
using ASI.Basecode.WebApp.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.WebApp.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : ControllerBase<HomeController>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="mapper"></param>
        public HomeController(IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IMapper mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {

        }


        /// <summary>
        /// Returns Home View.
        /// </summary>
        /// <returns> Home View </returns>
        /// 

        private static List<Book> _books = new List<Book>
    {
        new Book { Id = 1, Title = "Pokemon X and Y", Description = "Lorem ipsum dolor sit amet. Ex galisum expedita quo sunt consequatur et cupiditate vitae vel molestiae nostrum et velit sequi. Ut quae nihil qui officia quasi et aliquam doloribus hic earum impedit et doloribus repellendus.\r\n\r\nEt deleniti praesentium ut quisquam blanditiis et tempora sint ea illum placeat. Et sunt quos et maxime consectetur qui officiis iusto non beatae ipsum ut recusandae facere nam impedit dolorum.\r\n\r\nId optio voluptatem ad minus reiciendis sit iure impedit qui quibusdam totam aut enim illum. Sed temporibus Quis est maiores quae ut placeat tempore 33 maxime molestiae et omnis similique sed internos blanditiis!", ImageUrl = "https://assets.pokemon.com/assets/cms2/img/video-games/_tiles/pokemon-xy/pokemon-xy-launch-169.jpg", LastUpdated = "5 mins ago" },
        new Book { Id = 2, Title = "Pokemon Black and White", Description = "Lorem ipsum dolor sit amet. Ex galisum expedita quo sunt consequatur et cupiditate vitae vel molestiae nostrum et velit sequi. Ut quae nihil qui officia quasi et aliquam doloribus hic earum impedit et doloribus repellendus.\r\n\r\nEt deleniti praesentium ut quisquam blanditiis et tempora sint ea illum placeat. Et sunt quos et maxime consectetur qui officiis iusto non beatae ipsum ut recusandae facere nam impedit dolorum.\r\n\r\nId optio voluptatem ad minus reiciendis sit iure impedit qui quibusdam totam aut enim illum. Sed temporibus Quis est maiores quae ut placeat tempore 33 maxime molestiae et omnis similique sed internos blanditiis!", ImageUrl = "https://www.trustedreviews.com/wp-content/uploads/sites/54/2016/12/pokemon-sun-6-1.jpg", LastUpdated = "3 mins ago" },
        new Book { Id = 3, Title = "Pokemon Red, Blue, and Yellow", Description = "Lorem ipsum dolor sit amet. Ex galisum expedita quo sunt consequatur et cupiditate vitae vel molestiae nostrum et velit sequi. Ut quae nihil qui officia quasi et aliquam doloribus hic earum impedit et doloribus repellendus.\r\n\r\nEt deleniti praesentium ut quisquam blanditiis et tempora sint ea illum placeat. Et sunt quos et maxime consectetur qui officiis iusto non beatae ipsum ut recusandae facere nam impedit dolorum.\r\n\r\nId optio voluptatem ad minus reiciendis sit iure impedit qui quibusdam totam aut enim illum. Sed temporibus Quis est maiores quae ut placeat tempore 33 maxime molestiae et omnis similique sed internos blanditiis!", ImageUrl = "https://ragglefragglereviews.files.wordpress.com/2021/09/maxresdefault-2.jpg?w=1200", LastUpdated = "1 mins ago" },
    };
        public IActionResult Index()
        {
           
            return View(_books);
        }

        public IActionResult List()
        {

            Book b = new() {
                Id = 1,
                Title = "Book1",
                Author = "Author1"
            };
            List<Book> booklist = new();

            booklist.Add(b);    
            return View(booklist);
        }

        public IActionResult Details(int id)
        {
        // Fetch the book from the simulated data store
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }
    }
}
