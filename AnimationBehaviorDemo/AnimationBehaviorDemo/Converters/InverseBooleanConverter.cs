using System;
using System.Globalization;
using Xamarin.Forms;

namespace AnimationBehaviorDemo.Converters
{
  /// <summary>
  /// Taken from https://forums.xamarin.com/discussion/22476/how-to-databind-with-a-converter-in-code
  /// </summary>
  public class InverseBooleanConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
    {
      if (targetType != typeof(bool))
        throw new InvalidOperationException("The target must be a boolean");

      return !(bool)value;
    }

    public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
    {
      throw new NotSupportedException();
    }
  }
}
