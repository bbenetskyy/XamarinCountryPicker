using System.ComponentModel;
using Xamarin.Forms;
using XamarinCountryPicker.ViewModels;

namespace XamarinCountryPicker.Views
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