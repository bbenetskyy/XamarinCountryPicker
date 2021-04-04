using System;
using System.Diagnostics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinCountryPicker.iOS.Renderers;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]

namespace XamarinCountryPicker.iOS.Renderers
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell =  base.GetCell(item, reusableCell, tv);

            try
            {
                cell.SelectedBackgroundView = new UIView(cell.SelectedBackgroundView.Bounds);
                cell.SelectedBackgroundView.BackgroundColor = Color.Transparent.ToUIColor();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }

            return cell;
        }
    }
}
