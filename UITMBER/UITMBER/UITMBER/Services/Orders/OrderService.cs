using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Orders;
using UITMBER.Services.Request;
using Xamarin.Forms;

namespace UITMBER.Services.Orders
{
    public class OrderService : IOrderService
    {
        public IRequestService _requestService => DependencyService.Get<IRequestService>();

        public async Task<List<OrderResult>> GetMyOrders()
        {
            var uri = $"{Settings.SERVER_ENDPOINT}/Orders/GetMyOrders";


            return await _requestService.GetAsync<List<OrderResult>>(uri);
    
        }

        public async Task<List<OrderResult>> GetCarTypes()
        {
            var uri = $"{Settings.SERVER_ENDPOINT}/Orders/GetCarTypes";


            return await _requestService.GetAsync<List<OrderResult>>(uri);

        }
    }
}
