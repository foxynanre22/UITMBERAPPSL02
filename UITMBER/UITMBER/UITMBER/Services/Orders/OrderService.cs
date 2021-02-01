using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Orders;
using UITMBER.Services.Request;
using Xamarin.Forms;

namespace UITMBER.Services.Orders
{
    class OrderService: IOrderService
    {
        public IRequestService _requestService => DependencyService.Get<IRequestService>();

        public async Task<OrderPaymentResponse> OrderPayment(long orderid)
        {
            var uri = $"{Settings.SERVER_ENDPOINT}/Orders/OrderPayment?orderid={orderid}";

            return await _requestService.PostAsync<string, OrderPaymentResponse>(uri, "");
        }

        public async Task<OrderAcceptResponse> OrderAccept(OrderModel input)
        {
            var uri = $"{Settings.SERVER_ENDPOINT}/Orders/OrderAccept";

            return await _requestService.PostAsync<OrderModel, OrderAcceptResponse>(uri, input);
        }

        public async Task<ClientRateResponse> ClientRate(long idOrder, double driverRate, string info)
        {
            var uri = $"{Settings.SERVER_ENDPOINT}/Orders/ClientRate?idOrder={idOrder}&driverRate={driverRate}&info={info}";

            return await _requestService.PutAsync<string, ClientRateResponse>(uri, "");
        }
    }
}
