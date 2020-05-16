using Northwind.BusinessLogic.Interfaces;
using Northwind.Models;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.BusinessLogic.Implementations
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool Delete(Order entity) => _unitOfWork.Order.Delete(entity);

        public OrderList GetOrderById(int orderId) => _unitOfWork.Order.GetOrderById(orderId);

        public IEnumerable<OrderList> getPaginatedOrder(int page, int rows) => _unitOfWork.Order.getPaginatedOrder(page, rows);

        public string GetOrderNumber(int orderId)
        {
            var list = _unitOfWork.Order.GetList();

            var record = list.First(x => x.Id == orderId);

            return record.OrderNumber;
        }

    }
}
