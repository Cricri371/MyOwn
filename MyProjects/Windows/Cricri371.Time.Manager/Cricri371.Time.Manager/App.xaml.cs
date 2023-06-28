using System;
using System.Collections.Generic;
using System.Windows;

using Cricri371.Framework.Configuration.AppSettings;

using GalaSoft.MvvmLight.Threading;

using Microsoft.Shell;

namespace Cricri371.Time.Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, ISingleInstanceApp
    {
        static App()
        {
            DispatcherHelper.Initialize();

            AppSettingsSingleton.Instance.Load();
        }

        // TODO: Make this unique!
        private const string Unique = "Cricri371.Time.Manager";

        #region Main

        [STAThread]
        public static void Main()
        {
            if (SingleInstance<App>.InitializeAsFirstInstance(Unique))
            {
                var application = new App();
                application.InitializeComponent();

                application.Run();

                // Allow single instance code to perform cleanup operations
                SingleInstance<App>.Cleanup();
            }
        }

        #endregion Main

        #region ISingleInstanceApp Members

        public bool SignalExternalCommandLineArgs(IList<string> args)
        {
            // Bring window to foreground
            if (this.MainWindow.WindowState == WindowState.Minimized)
            {
                this.MainWindow.WindowState = WindowState.Normal;
            }

            this.MainWindow.Activate();

            return true;
        }

        #endregion ISingleInstanceApp Members
    }
}