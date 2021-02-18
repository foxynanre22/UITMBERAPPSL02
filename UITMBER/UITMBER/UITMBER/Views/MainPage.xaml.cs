using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITMBER.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITMBER.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            (BindingContext as MainViewModel).GetCurrentLocationCommand.Execute(true);

            base.OnAppearing();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void originEntry_Focused(object sender, FocusEventArgs e)
        {
            (BindingContext as MainViewModel).OrderStateEnum = Enums.OrderStateEnum.StartPicker;
        }

        private void destinationEntry_Focused(object sender, FocusEventArgs e)
        {
            (BindingContext as MainViewModel).OrderStateEnum = Enums.OrderStateEnum.DestinationPicker;
        }
    }
}