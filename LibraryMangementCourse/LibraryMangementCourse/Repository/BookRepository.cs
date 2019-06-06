using LibraryMangementCourse.Data;
using LibraryMangementCourse.Data.Interfaces;
using LibraryMangementCourse.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMangementCourse.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {      
        public BookRepository(LibraryDbContext context) : base(context)
        {

        }

        public IEnumerable<Book> FindWhithAuthor(Func<Book, bool> predicate)
        {
            return _context.Books
                .Include(a => a.Author)
                .Where(predicate);
        }

        public IEnumerable<Book> FindWhithAuthorAndBorrower(Func<Book, bool> predicate)
        {
            return _context.Books
                 .Include(a => a.Author)
                 .Include(a => a.Borrower)
                 .Where(predicate);
        }

        public IEnumerable<Book> GetAllWhitAuthor()
        {
            return _context.Books.Include(a => a.Author);
        }
    }
}
