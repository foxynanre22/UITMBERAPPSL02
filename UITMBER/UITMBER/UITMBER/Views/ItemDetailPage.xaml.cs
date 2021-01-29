using System.ComponentModel;
using Xamarin.Forms;
using UITMBER.ViewModels;

namespace UITMBER.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}