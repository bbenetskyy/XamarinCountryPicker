using System;
using Xamarin.Forms;
using XamarinCountryPicker.Models;

namespace XamarinCountryPicker.Controls
{
    public partial class CountryControl : StackLayout
    {
        public static readonly BindableProperty CountryProperty = BindableProperty.Create(
            nameof(Country),
            typeof(CountryModel),
            typeof(CountryControl),
            default,
            BindingMode.TwoWay,
            propertyChanged: (bindable, value, newValue) => (bindable as CountryControl)?.UpdateCountry(newValue as CountryModel));

        public CountryModel Country
        {
            get => (CountryModel)GetValue(CountryProperty);
            set => SetValue(CountryProperty, value);
        }

        public CountryControl()
        {
            InitializeComponent();
        }

        private void UpdateCountry(CountryModel model)
        {
            CountryCodeLabel.Text = $"(+{model?.CountryCode})";
            CountryNameLabel.Text = model?.CountryName;
            if (!string.IsNullOrEmpty(model?.FlagUrl))
            {
                FlagImage.Source = ImageSource.FromUri(new Uri(model?.FlagUrl));
            }
        }
    }
}
