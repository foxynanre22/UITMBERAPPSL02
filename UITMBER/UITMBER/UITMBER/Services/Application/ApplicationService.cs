using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Application;
using UITMBER.Services.Request;
using Xamarin.Forms;

namespace UITMBER.Services.Application
{
    public class ApplicationService : IApplicationService
    {
        public IRequestService _requestService => DependencyService.Get<IRequestService>();

        public async Task<bool> SendApplication(SendApplicationRequest input)
        {
            var uri = $"{Settings.SERVER_ENDPOINT}/Application/SendApplication";

            await _requestService.PostAsync<SendApplicationRequest>(uri, input);

            return true;
        }
    }
}
