using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace PORTAPP
{
    public class InitController
    {

        public InitController()
        {
            SimpleIoc.Default.Register<WineDataDomain.IUserRepository, ServiceDataLib.SqlUserRepository>();
            SimpleIoc.Default.Register<UserSystem.IUserState, UserSystem.UserState>();

            SimpleIoc.Default.Register<LogWindowVM>();
        }



        /// <summary>
        /// Gets the LogWindow property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public LogWindowVM LogWindow
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogWindowVM>();
            }
        }

        public void Cleanup()
        {
            SimpleIoc.Default.Unregister<LogWindowVM>();
        }
    }
}
