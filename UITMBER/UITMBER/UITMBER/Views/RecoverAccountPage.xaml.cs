using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITMBER.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecoverAccountPage : ContentPage
    {
        public RecoverAccountPage()
        {
            InitializeComponent();
        }

        private void OdzyskajButton_Clicked(object sender, EventArgs e)
        {
            EmailLabel.IsVisible = false;
            EmailEntry.IsVisible = false;
            OdzyskajButton.IsVisible = false;
            ResponseLabel.IsVisible = true;
            ResponseLogin.IsVisible = true;
        }

        private async void ResponseLogin_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}