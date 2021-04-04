using System;
using System.Diagnostics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinCountryPicker.iOS.Renderers;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]

namespace XamarinCountryPicker.iOS.Renderers
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;
            try
            {
                if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
                {
                    Control.SearchTextField.BackgroundColor = Color.Transparent.ToUIColor();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}
