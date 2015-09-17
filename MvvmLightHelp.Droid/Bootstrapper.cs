using System;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MvvmLightHelp.Core;
using MvvmLightHelp.Core.ViewModel;

namespace MvvmLightHelp.Droid
{
    public class Bootstrapper
    {

        public static bool Initialized { get { return ServiceLocator.IsLocationProviderSet; } }

        NavigationService _nav;

        public void Run()
        {
            if (Initialized)
                return;


            var container = SimpleIoc.Default;


            // Navigation
            _nav = new NavigationService();
            _nav.Configure("main", typeof(MainActivity));
            _nav.Configure(NavigationKey.DetailsPage, typeof(DetailsActivity));

            container.Register<INavigationService>( () => _nav);


            // Repositories
            container.Register<IProductRepository, MockProductRepository>();
            container.Register<ILoggingService, LoggingService>();


            // ViewModels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DetailsViewModel>();

            ServiceLocator.SetLocatorProvider( () => container);

        }
    }
}

