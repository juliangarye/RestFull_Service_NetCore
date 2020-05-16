using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<CustomerList> CustomerPageList(int page, int rows);

    }
}
