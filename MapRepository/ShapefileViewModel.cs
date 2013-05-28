namespace Telerik.Windows.Examples.Map.Shapefile
{
    using System;
    using System.ComponentModel;
    using Telerik.Windows.Controls;

    public class ShapefileViewModel : ViewModelBase
    {
        private string _region;
        private Uri _shapefileDataSourceUri;
        private Uri _shapefileSourceUri;
        protected const string DbfExtension = "dbf";
        protected const string ShapeExtension = "shp";
        protected const string ShapeRelativeUriFormat = "/Map;component/Resources/{0}.{1}";

        public ShapefileViewModel()
        {
            base.PropertyChanged += new PropertyChangedEventHandler(this.ShapefileViewModelPropertyChanged);
        }

        private void ShapefileViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Region")
            {
                this.ShapefileSourceUri = new Uri(string.Format("/Map;component/Resources/{0}.{1}", this.Region, "shp"), UriKind.Relative);
                this.ShapefileDataSourceUri = new Uri(string.Format("/Map;component/Resources/{0}.{1}", this.Region, "dbf"), UriKind.Relative);
            }
        }

        public string Region
        {
            get
            {
                return this._region;
            }
            set
            {
                if (this._region != value)
                {
                    this._region = value;
                    this.OnPropertyChanged("Region");
                }
            }
        }

        public Uri ShapefileDataSourceUri
        {
            get
            {
                return this._shapefileDataSourceUri;
            }
            set
            {
                if (this._shapefileDataSourceUri != value)
                {
                    this._shapefileDataSourceUri = value;
                    this.OnPropertyChanged("ShapefileDataSourceUri");
                }
            }
        }

        public Uri ShapefileSourceUri
        {
            get
            {
                return this._shapefileSourceUri;
            }
            set
            {
                if (this._shapefileSourceUri != value)
                {
                    this._shapefileSourceUri = value;
                    this.OnPropertyChanged("ShapefileSourceUri");
                }
            }
        }
    }
}

