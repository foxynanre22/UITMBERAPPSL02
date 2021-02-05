using System;
using System.Threading.Tasks;
using System.Windows.Input;
using UITMBER.Services.Authentication;
using UITMBER.Services.Location;
using UITMBER.Services.Register;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UITMBER.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public IAuthenticationService _authService => DependencyService.Get<IAuthenticationService>();
        public IRegisterService _regService => DependencyService.Get<IRegisterService>();
        public ILocationService _locatService => DependencyService.Get<ILocationService>();

        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Test());
        }

        private async Task Test()
        {
            try
            {
                var result = await _authService.Authenticate(new Models.Authentication.AuthenticationRequest()
                {
                     Login = "test2@test.pl",
                     Password = "Sm1shn3"
                });
               
            }
            catch (Exception e)
            {

            }
        }

        public ICommand OpenWebCommand { get; }
    }
}