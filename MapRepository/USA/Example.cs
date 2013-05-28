namespace Telerik.Windows.Examples.Map.USA
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using Telerik.Windows.Controls;
    using Telerik.Windows.Controls.Map;

    public class Example : UserControl, IComponentConnector
    {
        private bool _contentLoaded;
        internal InformationLayer informationLayer;
        internal Grid LayoutRoot;
        internal RadMap radMap;

        public Example()
        {
            this.InitializeComponent();
        }

        [DebuggerNonUserCode, GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
                Uri resourceLocator = new Uri("/Map;component/usa/example.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
            }
        }

        [GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        void IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.LayoutRoot = (Grid) target;
                    return;

                case 2:
                    this.radMap = (RadMap) target;
                    return;

                case 3:
                    this.informationLayer = (InformationLayer) target;
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

