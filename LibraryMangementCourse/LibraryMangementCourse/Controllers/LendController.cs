using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryMangementCourse.Data.Interfaces;
using LibraryMangementCourse.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryMangementCourse.Controllers
{
    public class LendController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public LendController(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        [Route("Lend")]
        public IActionResult List()
        {
            //load available books
            var availableBooks = _bookRepository.FindWhithAuthor(x => x.BorrowerId == 0);
            
            //checjk collection
            if (availableBooks.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(availableBooks);
            }
        }

        public IActionResult LendBook(int bookId)
        {
            //load current book and all customer
            var lendVM = new LendViewModel()
            {
                Book = _bookRepository.GetById(bookId),
                Customers = _customerRepository.GetAll()
            };
            //send data to the lend view
            return View(lendVM);
        }

        [HttpPost]
        public IActionResult LendBook(LendViewModel lendViewModel)
        {
            //update the database 
            var book = _bookRepository.GetById(lendViewModel.Book.BookId);
            var customer = _customerRepository.GetById(lendViewModel.Book.BorrowerId);

            book.Borrower = customer;
            _bookRepository.Update(book);

            //redirect to the list view
            return RedirectToAction("List");
        }
    }
}
