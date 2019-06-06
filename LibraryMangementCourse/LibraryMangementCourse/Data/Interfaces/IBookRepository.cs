using LibraryMangementCourse.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMangementCourse.Data.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetAllWhitAuthor();

        IEnumerable<Book> FindWhithAuthor(Func<Book, bool> predicate);

        IEnumerable<Book> FindWhithAuthorAndBorrower(Func<Book, bool> predicate);


    }
}
