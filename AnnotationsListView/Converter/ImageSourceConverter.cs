using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AnnotationsListView
{
    /// <summary> 
    /// Represents the image conversion methods to change the expand and collapse images displayed in the list view's page grouped header
    /// </summary> 
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return ImageSource.FromResource("AnnotationsListView.Assets.Expand.png");
            else
                return ImageSource.FromResource("AnnotationsListView.Assets.Collapse.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
