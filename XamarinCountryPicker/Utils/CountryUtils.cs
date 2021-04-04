using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PhoneNumbers;
using XamarinCountryPicker.Models;

namespace XamarinCountryPicker.Utils
{
    public static class CountryUtils
    {
        /// <summary>
        /// Gets the list of countries based on ISO 3166-1
        /// </summary>
        /// <returns>Returns the list of countries based on ISO 3166-1</returns>
        public static List<RegionInfo> GetCountriesByIso3166()
        {
            var countries = new List<RegionInfo>();
            foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                var info = new RegionInfo(culture.LCID);
                if (countries.All(p => p.Name != info.Name))
                    countries.Add(info);
            }
            return countries.OrderBy(p => p.EnglishName).ToList();
        }

        /// <summary>
        /// Get Country Model by Country Name
        /// </summary>
        /// <param name="countryName">English Name of Country</param>
        /// <returns>Complete Country Model with Region, Flag, Name and Code</returns>
        public static CountryModel GetCountryModelByName(string countryName)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var isoCountries = GetCountriesByIso3166();
            var regionInfo = isoCountries.FirstOrDefault(c => c.EnglishName == countryName);
            return regionInfo != null
                ? new CountryModel
                {
                    CountryCode = phoneNumberUtil.GetCountryCodeForRegion(regionInfo.TwoLetterISORegionName).ToString(),
                    CountryName = regionInfo.EnglishName,
                    FlagUrl = $"https://hatscripts.github.io/circle-flags/flags/{regionInfo.TwoLetterISORegionName.ToLower()}.svg",
                }
                : new CountryModel
                {
                    CountryName = countryName
                };
        }
    }
}
