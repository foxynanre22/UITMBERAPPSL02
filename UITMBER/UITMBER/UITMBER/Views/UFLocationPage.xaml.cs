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
    public partial class UFLocationPage : ContentPage
    {
        UFLocationsViewModel _viewModel;

        public UFLocationPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new UFLocationsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}