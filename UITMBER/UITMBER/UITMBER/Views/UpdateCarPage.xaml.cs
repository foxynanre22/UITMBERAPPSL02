using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITMBER.Models.Car;
using UITMBER.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITMBER.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateCarPage : ContentPage
    {
        public CarDto Item { get; set; }
        public UpdateCarPage()
        {
            InitializeComponent();
            BindingContext = new UpdateCarViewModel();
        }
    }
}