using PROJECT.UI.providers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Windows;

namespace PROJECT.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomProvider, CustomProvider>();
            services.AddScoped<MainWindow>();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //To wait for the API start
            Thread.Sleep(3000);
            Window mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
