﻿using Northwind.BusinessLogic.Interfaces;
using Northwind.Models;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.BusinessLogic.Implementations
{
    public class SupplierLogic : ISupplierLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool Delete(Supplier supplier) => _unitOfWork.Supplier.Delete(supplier);

        public Supplier GetById(int id) => _unitOfWork.Supplier.GetById(id);

        public int Insert(Supplier supplier) => _unitOfWork.Supplier.Insert(supplier);

        public IEnumerable<Supplier> SupplierPageList(int Page, int Rows, string SearchTerm) => _unitOfWork.Supplier.SupplierPageList(Page, Rows, SearchTerm);

        public bool Update(Supplier supplier) => _unitOfWork.Supplier.Update(supplier);
    }
}
