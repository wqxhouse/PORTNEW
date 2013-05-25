namespace WineSearchBar
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class ControlToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string name = string.Empty;
            if (value is IControlInfo)
            {
                name = ((IControlInfo) value).Name;
            }
            else if (value != null)
            {
                name = value.ToString();
            }
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            string str2 = "24x24";
            if (!string.IsNullOrEmpty(parameter.ToString()))
            {
                str2 = parameter.ToString();
            }
            return new Uri(string.Format("/Application;component/Resources/Icons/{0}/Rad{1}_WPF.png", str2, name), UriKind.Relative);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

