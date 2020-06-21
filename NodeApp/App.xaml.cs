using NodeApp.Core;
using System.Windows;

namespace NodeApp
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom startup so we load IoC immediately
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IoC.Setup();

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
