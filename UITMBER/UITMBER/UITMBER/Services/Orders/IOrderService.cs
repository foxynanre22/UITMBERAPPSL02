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


       Task<OrderPaymentResponse> OrderPayment(long orderid);
       Task<OrderAcceptResponse> OrderAccept(OrderModel input);
       Task<ClientRateResponse> ClientRate(long idOrder, double driverRate, string info);

        Task<List<OrderResult>> GetClientOrderDetails();
        Task<List<string>> GetLuggageTypes();
        Task<double> GetCost(DateTime date, double distance);

    }
}
