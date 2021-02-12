﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UITMBER.Services;
using UITMBER.Views;
using UITMBER.Services.Request;
using UITMBER.Services.Authentication;

using UITMBER.Services.Clients;

using UITMBER.Services.UFLocations;

using UITMBER.Services.Car;

using UITMBER.Services.Orders;

using UITMBER.Services.Register;
using UITMBER.Services.Location;

using UITMBER.Services.Application;
using UITMBER.Services.Client.Drivers;


namespace UITMBER
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            RegisterServices();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void RegisterServices()
        {
            DependencyService.Register<MockDataStore>();

            DependencyService.Register<IRequestService, RequestService>();
            DependencyService.Register<IAuthenticationService, AuthenticationService>();

            DependencyService.Register<IClientsService, ClientsService>();

            DependencyService.Register<IUFLocationsService, UFLocationsService>();


            DependencyService.Register<ICarService, CarService>();

            DependencyService.Register<IRegisterService, RegisterService>();
            DependencyService.Register<ILocationService, LocationService>();

            

            DependencyService.Register<IOrderService, OrderService>();

            DependencyService.Register<IApplicationService, ApplicationService>();
            DependencyService.Register<IDriversService, DriverService>();


        }

    }
}
