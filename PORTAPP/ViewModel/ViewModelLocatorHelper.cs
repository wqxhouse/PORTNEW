using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PORTAPP.ViewModel
{
    public class ViewModelLocatorHelper
    {
        public static void CreateStaticViewModelLocatorForDesigner(FrameworkElement control, object ViewModelLocator)
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Blend 4"))
                control.Resources.Add("Locator", ViewModelLocator);
        }
    }
}
