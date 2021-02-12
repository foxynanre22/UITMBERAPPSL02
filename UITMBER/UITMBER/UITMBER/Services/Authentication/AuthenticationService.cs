using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Authentication;
using UITMBER.Services.Request;
using Xamarin.Forms;

namespace UITMBER.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {

        public IRequestService _requestService => DependencyService.Get<IRequestService>();


        //private readonly IRequestService _requestService;

        //public AuthenticationService(IRequestService requestService)
        //{
        //    _requestService = requestService;
        //}

        public async Task<bool> Authenticate(AuthenticationRequest input)
        {
            var uri = $"{Settings.SERVER_ENDPOINT}/Authentication/Authenticate";


            var result = await _requestService.PostAsync<AuthenticationRequest, AuthenticationReponse>(uri, input);
            Settings.AccessToken = result.AccessToken;
            Settings.Name = result.Name;
            Settings.Roles = result.Roles;
            Settings.Photo = result.Photo;
            Settings.TokenExpire = DateTime.Now.AddSeconds(result.ExpireInSeconds);

            return true;
        }
    }
}
