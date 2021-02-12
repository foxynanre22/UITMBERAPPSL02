using System;
using System.Collections.Generic;
using UITMBER.ViewModels;
using UITMBER.Views;
using Xamarin.Forms;

namespace UITMBER
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(NewLocationPage), typeof(NewLocationPage));
            Routing.RegisterRoute(nameof(LocationDetailPage), typeof(LocationDetailPage));



            Routing.RegisterRoute(nameof(SendApplicationPage), typeof(SendApplicationPage));


            Routing.RegisterRoute(nameof(MyCarPage), typeof(MyCarPage));
            Routing.RegisterRoute(nameof(NewCarPage), typeof(NewCarPage));
            Routing.RegisterRoute(nameof(UpdateCarPage), typeof(UpdateCarPage));
            Routing.RegisterRoute(nameof(MyCarsPage), typeof(MyCarsPage));
            Routing.RegisterRoute(nameof(MyApplicationPage), typeof(MyApplicationPage));

        }
    }
}
