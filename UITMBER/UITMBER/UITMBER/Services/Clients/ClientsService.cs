using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Clients;
using UITMBER.Services.Request;
using Xamarin.Forms;

namespace UITMBER.Services.Clients
{
    class ClientsService : IClientsService
    {
        private IRequestService _requestService => DependencyService.Get<IRequestService>();

        public async Task<ClientsDto> GetMyProfile(int clientsId)
        {
            var url = $"{Settings.SERVER_ENDPOINT}/Clients/GetMyProfile?id={clientsId}";
            var data = await _requestService.GetAsync<ClientsDto>(url);

            return data;
        }

        public async Task<string> UpdatePhoto(ClientsDto photo)
        {
            var url = $"{Settings.SERVER_ENDPOINT}/Clients/UpdatePhoto";
            var result = await _requestService.PutAsync<ClientsDto, string>(url, photo);

            return result;
        }
    }
}
