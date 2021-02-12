using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Clients;
using UITMBER.Services.Clients;
using Xamarin.Forms;

namespace UITMBER.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public IClientsService service => new ClientsService();
        private ClientsDto _user;
        private ClientsDto User
        {
            get => _user;
            set
            {
                SetProperty(ref _user, value);
            }
        }
        public string UserName { get => _user.FirstName; }
        public string UserSurname { get => _user.LastName; }
        public string UserEmail { get => _user.Email; }
        public string UserPhone { get => _user.PhoneNumber; }
        public string UserPhoto { get => _user.Photo; }

        public Command InitUserCommand { get; }

        public ProfileViewModel()
        {
            InitUserCommand = new Command(async()=>await GetUser());
        }

        private async Task GetUser()
        {
            //nie przetestowane bo nie ma połączenia z https://dev.wsiz.edu.pl/
            //GetMyProfile() potrzebuje Id uzytkownika, który otrzymujemy po logowaniu,
            //ale w Settings.cs mamy tylko Name. czyli to jest błąd na poziomie Api, bo nie zwraca nam Id.
            //dla testu wziąłem id = 2, bo chyba taki uzytkownik kiedys byl stworzony ale nie ma szansu teraz
            //to przetestowac
            User = await service.GetMyProfile(2);
        }
    }
}
