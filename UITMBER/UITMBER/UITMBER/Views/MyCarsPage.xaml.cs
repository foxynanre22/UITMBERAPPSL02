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
    
    public partial class MyCarsPage : ContentPage
    {
        MyCarsViewModel _viewModel;
        public MyCarsPage()
        {
            InitializeComponent();
            

            BindingContext = _viewModel = new MyCarsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
        
    }
}