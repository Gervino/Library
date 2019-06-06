using LibraryMangementCourse.Data;
using LibraryMangementCourse.Data.Interfaces;
using LibraryMangementCourse.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMangementCourse.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LibraryDbContext context) : base(context)
        {

        }
    }
}
