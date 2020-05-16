﻿using Northwind.BusinessLogic.Interfaces;
using Northwind.Models;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.BusinessLogic.Implementations
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerList> CustomerPageList(int page, int rows)
        {
            return _unitOfWork.Customer.CustomerPageList(page, rows);
        }

        public bool Delete(Customer customer)
        {
            return _unitOfWork.Customer.Delete(customer);
        }

        public Customer GetById(int id)
        {
            return _unitOfWork.Customer.GetById(id);
        }

        public IEnumerable<Customer> GetList()
        {
            return _unitOfWork.Customer.GetList();
        }

        public int Insert(Customer customer)
        {
            return _unitOfWork.Customer.Insert(customer);
        }

        public bool Update(Customer customer)
        {
            return _unitOfWork.Customer.Update(customer);
        }
    }
}
