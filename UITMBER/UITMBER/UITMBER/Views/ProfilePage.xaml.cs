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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        ProfileViewModel _viewModel;

        public ProfilePage()
        {
            BindingContext = _viewModel = new ProfileViewModel();
            if(_viewModel != null && _viewModel.InitUserCommand.CanExecute(null))
            {
                _viewModel.InitUserCommand.Execute(null);
            }
            InitializeComponent();
        }
    }
}