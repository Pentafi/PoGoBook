
﻿using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

﻿using ASI.Basecode.Services.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using PogoAdmin.Services;
using Services.ServiceModels;


namespace ASI.Basecode.WebApp.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            // Using GetAllBooks method to fetch all books
            var books = _bookRepository.GetAllBooks().ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {

        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;
        private readonly ILogger<BookController> _logger;

        public BookController(IMapper mapper, IBookService bookService, IAuthorService authorService, IGenreService genreService, ILogger<BookController> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
            _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IActionResult Index(string searchQuery)
        {
            var bookViewModels = _bookService.GetAllBooks();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                bookViewModels = bookViewModels.Where(b => b.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(bookViewModels);
        }


        public IActionResult Details(int id)
        {
            var viewModel = _bookService.GetBookById(id);
            if (viewModel is null)
            {
                _logger.LogWarning("Book with ID {BookId} not found.", id);
                return NotFound();
            }

            return View(viewModel);
        }
// CARL
        [HttpGet]
        public IActionResult Create()
        {
            var authors = _authorService.GetAllAuthors()
                                   .Select(a => new
                                   {
                                       Id = a.Id,
                                       FullName = a.FirstName + " " + a.LastName
                                   })
                                   .ToList();
            var genres = _genreService.GetAllGenres()
                                   .Select(g => new
                                   {
                                       Id = g.Id,
                                       Name = g.Name
                                   })
                                   .ToList();

            ViewBag.AuthorList = new SelectList(authors, "Id", "FullName");
            ViewBag.GenreList = new SelectList(genres, "Id", "Name");

            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.AddBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);

        public IActionResult Create(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(model);
                _logger.LogInformation("Book created: {BookTitle}", model.AuthorNames); // Log information
                return RedirectToAction(nameof(Index));
            }
            _logger.LogWarning("Invalid model state for creating book."); // Log warning
            return View(model);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (ModelState.IsValid)
            {
                if (!_bookRepository.BookExists(book.Id))
                {
                    return NotFound();
                }
                _bookRepository.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);

            var viewModel = _bookService.GetBookById(id);
            if (viewModel is null)
            {
                _logger.LogWarning("Edit attempted for non-existent book with ID {BookId}.", id);
                return NotFound();
            }

            var authors = _authorService.GetAllAuthors()
                                   .ToList()
                                   .Select(a => new
                                   {
                                       Id = a.Id,
                                       FullName = a.FirstName + " " + a.LastName
                                   })
                                   .ToList();
            var genres = _genreService.GetAllGenres()
                                   .Select(g => new
                                   {
                                       Id = g.Id,
                                       Name = g.Name
                                   })
                                   .ToList();

            ViewBag.AuthorList = new SelectList(authors, "Id", "FullName");
            ViewBag.GenreList = new SelectList(genres, "Id", "Name");

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(model);
                _logger.LogInformation("Book updated: {BookId}", model.Id); 
                return RedirectToAction(nameof(Index));
            }
            _logger.LogWarning("Invalid model state for editing book with ID {BookId}.", model.Id);
            return View(model);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            if (_bookRepository.BookExists(id))
            {
                _bookRepository.DeleteBook(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

// OLD

//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using PogoAdmin.Services;
//using Services.ServiceModels;

//namespace ASI.Basecode.WebApp.Controllers
//{
//    public class BookController : Controller
//    {
//        private readonly IMapper _mapper;
//        private readonly IBookService _bookService;
//        private readonly IAuthorService _authorService;

//        public BookController(IMapper mapper, IBookService bookService, IAuthorService authorService)
//        {
//            _mapper = mapper;
//            _bookService = bookService;
//            _authorService = authorService;
//        }

//        public IActionResult Index()
//        {
//            var bookViewModels = _bookService.GetAllBooks();
//            return View(bookViewModels);
//        }

//        public IActionResult Details(int id)
//        {
//            var viewModel = _bookService.GetBookById(id);
//            if (viewModel == null)
//            {
//                return NotFound();
//            }

//            return View(viewModel);
//        }



//        [HttpGet]
//        public IActionResult Create()
//        {
//            var authors = _authorService.GetAllAuthors()
//                                   .Select(a => new
//                                   {
//                                       ID = a.authorID,
//                                       FullName = a.firstName + " " + a.lastName
//                                   })
//                                   .ToList();
//            ViewBag.AuthorList = new SelectList(authors, "Id", "FullName");
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(BookViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                _bookService.AddBook(model);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(model);
//        }

//        [HttpGet]
//        public IActionResult Edit(int id)
//        {
//            var viewModel = _bookService.GetBookById(id);
//            var authors = _authorService.GetAllAuthors()
//                                   .ToList()
//                                   .Select(a => new
//                                   {
//                                       ID = a.authorID,
//                                       FullName = a.firstName + " " + a.lastName
//                                   })
//                                   .ToList();
//            if (viewModel == null)
//            {
//                return NotFound();
//            }
//            ViewBag.AuthorList = new SelectList(authors, "Id", "FullName");

//            return View(viewModel);
//        }

//        [HttpPost]
//        public IActionResult Edit(BookViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                _bookService.UpdateBook(model);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult Delete(int id)
//        {
//            _bookService.DeleteBook(id);
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}

            _bookService.DeleteBook(id);
            _logger.LogInformation("Book deleted: {BookId}", id);
            return RedirectToAction(nameof(Index));
        }
    }
}

