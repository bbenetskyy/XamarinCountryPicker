using System;
using System.Collections.Generic;
using XamarinCountryPicker.ViewModels;
using XamarinCountryPicker.Views;
using Xamarin.Forms;

namespace XamarinCountryPicker
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
