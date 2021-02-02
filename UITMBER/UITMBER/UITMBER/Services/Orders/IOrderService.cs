using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Orders;

namespace UITMBER.Services.Orders
{
    public interface IOrderService
    {
         Task<List<OrderResult>> GetMyOrders();
         Task<List<OrderResult>> GetCarTypes();
    }
}
