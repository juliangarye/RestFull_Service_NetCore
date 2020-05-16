using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.BusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        IEnumerable<OrderList> getPaginatedOrder(int page, int rows);
        OrderList GetOrderById(int orderId);
        bool Delete(Order entity);

        string GetOrderNumber(int orderId);

    }
}
