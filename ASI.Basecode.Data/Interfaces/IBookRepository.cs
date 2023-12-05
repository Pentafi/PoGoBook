using System;
using ASI.Basecode.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAllBooks();
        Book GetBookById(int Id);
        IQueryable<Book> GetBookByAuthorId(int authorId);
        IQueryable<Genre> GetGenreByBook(int bookId);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        bool BookExists(int id);
        //bool BookExists(string bookID);
    }
}
