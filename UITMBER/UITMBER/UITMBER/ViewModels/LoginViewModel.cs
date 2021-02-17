using UITMBER.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using UITMBER.Services.Authentication;

namespace UITMBER.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private string email;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        AuthenticationService authenticationService => new AuthenticationService();

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public Command RecoverCommand { get; }

        public LoginViewModel()
        {

            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
            RecoverCommand = new Command(OnRecoverClicked);

            Email = "test2@test.pl";
            Password = "Sm1shn3";

        }

        private async void OnRecoverClicked(object obj)
        {
            await Shell.Current.GoToAsync("//RecoverAccountPage");

        }

        private async void OnRegisterClicked(object obj)
        {
            await Shell.Current.GoToAsync("//RegisterPage");
        }

        private async void OnLoginClicked(object obj)
        {
            if (IsBusy)
                return;


            IsBusy = true;

            try
            {


                await authenticationService.Authenticate(new Models.Authentication.AuthenticationRequest
                {
                    Login = email,
                    Password = password
                });
                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            catch (Exception ex)
            {

                //Error handlig
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
