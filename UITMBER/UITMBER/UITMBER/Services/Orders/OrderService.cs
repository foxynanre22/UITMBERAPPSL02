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

        public async Task<List<OrderResult>> GetClientOrderDetails()
        {
            var uri = $"{Settings.SERVER_ENDPOINT}/Orders/GetClientOrderDetails";


            return await _requestService.GetAsync<List<OrderResult>>(uri);
    
        }

        public async Task<List<string>> GetLuggageTypes()
        {
            var uri = $"{Settings.SERVER_ENDPOINT}/Orders/GetLuggageTypes";


            return await _requestService.GetAsync<List<string>>(uri);

        }

        public async Task<double> GetCost(DateTime date, double distance)
        {
            var uri = $"{Settings.SERVER_ENDPOINT}/Orders/GetCost?date={date}&distance={distance}";


            return await _requestService.GetAsync<double>(uri);

        }


    }
}
