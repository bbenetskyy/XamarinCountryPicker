using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FFImageLoading;
using PhoneNumbers;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinCountryPicker.Controls;
using XamarinCountryPicker.Models;
using XamarinCountryPicker.Utils;

namespace XamarinCountryPicker.Popups
{
    public partial class ChooseCountryPopup : PopupPage
    {
        #region Fields

        private static List<CountryModel> _countries;
        private CountryModel _selectedCountry;

        #endregion Fields

        #region Constructors

        public ChooseCountryPopup(CountryModel selectedCountry)
        {
            InitializeComponent();
            if (_countries == null || !_countries.Any())
            {
                LoadCountries();
            }
            VisibleCountries = new ObservableCollection<CountryModel>(_countries);

            SelectedCountry = selectedCountry;
            CommonCountriesList.SetBinding(ListView.ItemsSourceProperty, new Binding(nameof(VisibleCountries), source: this));
            CurrentCountryControl.SetBinding(CountryControl.CountryProperty, new Binding(nameof(SelectedCountry), source: this));
        }

        #endregion Constructors

        #region Properties

        public ICommand SelectCountryCommand { get; set; }

        public ObservableCollection<CountryModel> VisibleCountries { get; }

        public CountryModel SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                OnPropertyChanged(nameof(SelectedCountry));
            }
        }

        #endregion Properties

        #region Private Methods

        private void CloseBtn_Clicked(object sender, EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private void ConfirmBtn_Clicked(object sender, EventArgs e)
        {
            SelectCountryCommand?.Execute(SelectedCountry);
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private void LoadCountries()
        {
            //this is not Task, because it's really fast
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            _countries = new List<CountryModel>();
            var isoCountries = CountryUtils.GetCountriesByIso3166();
            _countries.AddRange(isoCountries.Select(c => new CountryModel
            {
                CountryCode = phoneNumberUtil.GetCountryCodeForRegion(c.TwoLetterISORegionName).ToString(),
                CountryName = c.EnglishName,
                FlagUrl = $"https://hatscripts.github.io/circle-flags/flags/{c.TwoLetterISORegionName.ToLower()}.svg",
                RegionName = c.TwoLetterISORegionName
            }));
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            VisibleCountries.Clear();
            var filteredCountries = string.IsNullOrWhiteSpace(SearchBar.Text)
                ? _countries
                : _countries.Where(country => country.CountryName.Contains(SearchBar.Text, StringComparison.InvariantCultureIgnoreCase));
            filteredCountries.ForEach(сountry => VisibleCountries.Add(сountry));
        }

        private void CommonCountriesList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedCountry = e.SelectedItem as CountryModel;
        }

        #endregion Private Methods
    }
}
