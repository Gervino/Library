﻿using LibraryMangementCourse.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMangementCourse.ViewModel
{
    public class LendViewModel
    {
        public Book Book { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}
