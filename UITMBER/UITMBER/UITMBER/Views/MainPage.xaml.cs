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
    }
}