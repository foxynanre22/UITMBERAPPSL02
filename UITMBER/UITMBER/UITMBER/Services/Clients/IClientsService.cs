using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Clients;

namespace UITMBER.Services.Clients
{
    interface IClientsService
    {
        Task<ClientsDto> GetMyProfile(int clientsId);
        Task<string> UpdatePhoto(ClientsDto photo);
    }
}
