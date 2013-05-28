namespace Telerik.Windows.Examples.Map.USA
{
    using System;
    using Telerik.Windows.Controls;

    public class ExampleViewModel : ViewModelBase
    {
        private Uri _mapSource = new Uri(string.Format("/Map;component/Resources/{0}.xml", "UsaSimplified"), UriKind.Relative);
        protected const string ShapeRelativeUriFormat = "/Map;component/Resources/{0}.xml";

        public Uri MapSource
        {
            get
            {
                return this._mapSource;
            }
        }
    }
}

