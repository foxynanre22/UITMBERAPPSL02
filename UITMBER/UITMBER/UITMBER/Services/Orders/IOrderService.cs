using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Orders;

namespace UITMBER.Services.Orders
{
    public interface IOrderService
    {
       Task<OrderPaymentResponse> OrderPayment(long orderid);
       Task<OrderAcceptResponse> OrderAccept(OrderModel input);
       Task<ClientRateResponse> ClientRate(long idOrder, double driverRate, string info);
    }
}
