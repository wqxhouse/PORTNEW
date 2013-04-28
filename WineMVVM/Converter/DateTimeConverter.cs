using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;


namespace WineMVVM.Converter
{
    [ValueConversion(typeof(string), typeof(DateTime))]
    public class DateTimeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, 
            object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, 
            object parameter, System.Globalization.CultureInfo culture)
        {
            var dateStr = value as string;
            try
            {
                DateTime date = DateTime.Parse(dateStr);
                return date;
            }
            catch { }

            return null;
           
        }
    }
}
