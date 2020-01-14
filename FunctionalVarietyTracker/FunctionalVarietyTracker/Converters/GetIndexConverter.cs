using System;
using System.Globalization;
using System.Windows.Data;

namespace FunctionalVarietyTracker.Converters
{
  internal class GetIndexConverter : IMultiValueConverter
  {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      var collection = (ListCollectionView)values[1];
      var itemIndex = collection.IndexOf(values[0]);

      return itemIndex;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}