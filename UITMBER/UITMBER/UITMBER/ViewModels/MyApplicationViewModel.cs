using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Application;
using UITMBER.Services.Application;
using UITMBER.Views;
using Xamarin.Forms;

namespace UITMBER.ViewModels
{
    class MyApplicationViewModel :BaseViewModel
    {
        

       
        public IApplicationService _ApplicationService => DependencyService.Get<IApplicationService>();

        public Command LoadItemCommand { get; }
        public ObservableCollection<GetApplicationResponse> _GetApplicationResponses { get; }
        public Command MyCarsCommand { get; }
        public Command SendApplicationCommand { get; }

        public long id;

        public long userId;

        public DateTime date;
        public bool accepted;
        public string driverLicenceNo;
        public string driverLicencePhoto;
        public long carId;

        public bool SendApplicationVisible { get; set; }


        public MyApplicationViewModel()
        {
            LoadItemCommand = new Command(async () => await ExecuteLoadItemsCommand());

            _GetApplicationResponses = new ObservableCollection<GetApplicationResponse>();
            MyCarsCommand = new Command(OnMyCars);
            //DeleteItemCommand = new Command<long>(OnDeleteItem);
            //UpdateItemCommand = new Command<long>(OnUpdateItem);
            CanSendApplication();
            SendApplicationCommand = new Command(OnSendApplication);
        }

        public DateTime Date
        {

            get => date;
            set => SetProperty(ref date, value);
        }

        public long Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public string DriverLicenceNo
        {
            get => driverLicenceNo;
            set => SetProperty(ref driverLicenceNo, value);
        }
        public bool Accepted
        {
            get => accepted;
            set => SetProperty(ref accepted, value);
        }


        public string DriverLicencePhoto
        {
            get => driverLicencePhoto;
            set => SetProperty(ref driverLicencePhoto, value);
        }
        
        public long UserId
        {
            get => userId;
            set => SetProperty(ref userId, value);
        }

        public long CarId
        {
            get => carId;
            set => SetProperty(ref carId, value);
        }

        public void OnAppearing()
        {
            IsBusy = true;
           
        }


        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {

                

                _GetApplicationResponses.Clear();
                var items = await _ApplicationService.GetMyApplications();
                var item = items.Last();
                Id = item.Id;
                Date = item.Date;
                DriverLicencePhoto = !string.IsNullOrEmpty(item.DriverLicencePhoto) ? item.DriverLicencePhoto : "ic_user";
                DriverLicenceNo = item.DriverLicenceNo;
                Accepted = item.Accepted;
                UserId = item.UserId;





                _GetApplicationResponses.Add(item);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void OnMyCars(object obj)
        {
            await Shell.Current.GoToAsync(nameof(MyCarsPage));
        }


        private void CanSendApplication()
        {
            if (Settings.Roles == "Client" && Settings.TokenExpire >= DateTime.Now)
            {
                SendApplicationVisible = true;
            }
            else
            {
                SendApplicationVisible = false;
            }
        }

        private async void OnSendApplication(object obj)
        {
            await Shell.Current.GoToAsync(nameof(SendApplicationPage));
        }




    }
}
