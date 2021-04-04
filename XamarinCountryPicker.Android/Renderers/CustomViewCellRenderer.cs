using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinCountryPicker.Droid.Renderers;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]

namespace XamarinCountryPicker.Droid.Renderers
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        private Android.Views.View _cell;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _cell = base.GetCellCore(item, convertView, parent, context);
            return _cell;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);

            if (e.PropertyName == "IsSelected")
            {
                try
                {
                    _cell.SetBackgroundColor(Color.White.ToAndroid());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    Debug.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}
