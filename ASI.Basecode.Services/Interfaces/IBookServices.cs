using ASI.Basecode.Data.Models;
using System.Collections.Generic;
﻿using System.Collections.Generic;

using Services.ServiceModels;
namespace PogoAdmin.Services
{
    public interface IBookService
    {
        IEnumerable<BookViewModel> GetAllBooks();
        BookViewModel GetBookById(int bookID);
        void AddBook(BookViewModel model);
        void UpdateBook(BookViewModel model);
        void DeleteBook(int bookID);
    }
}