using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryMangementCourse.Models;
using LibraryMangementCourse.Data.Interfaces;
using LibraryMangementCourse.ViewModel;

namespace LibraryMangementCourse.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICustomerRepository _customerRepository;

        public HomeController(IBookRepository bookRepository,
                              IAuthorRepository authorRepository,
                              ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            // create home view model
            var homeVM = new HomeViewModel()
            {
                AuthorCount = _authorRepository.Count(x => true),
                CustomerCount = _customerRepository.Count(x => true),
                BookCount = _bookRepository.Count(x => true),
                LendBookCount = _bookRepository.Count(x => x.Borrower != null)
            };

            // call view
            return View(homeVM);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
