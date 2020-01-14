using System.Windows.Controls;

using FunctionalVarietyTracker.WPF.Contracts.Services;
using FunctionalVarietyTracker.WPF.Contracts.Views;
using FunctionalVarietyTracker.WPF.Core.Contracts.Services;
using FunctionalVarietyTracker.WPF.Core.Services;
using FunctionalVarietyTracker.WPF.Models;
using FunctionalVarietyTracker.WPF.Services;
using FunctionalVarietyTracker.WPF.Views;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

using Microsoft.Extensions.Configuration;

namespace FunctionalVarietyTracker.WPF.ViewModels
{
    public class ViewModelLocator
    {
        private IPageService PageService
            => SimpleIoc.Default.GetInstance<IPageService>();

        public ShellViewModel ShellViewModel
            => SimpleIoc.Default.GetInstance<ShellViewModel>();

        public MainViewModel MainViewModel
            => SimpleIoc.Default.GetInstance<MainViewModel>();

        public DetailsViewModel DetailsViewModel
            => SimpleIoc.Default.GetInstance<DetailsViewModel>();

        public SettingsViewModel SettingsViewModel
            => SimpleIoc.Default.GetInstance<SettingsViewModel>();

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IWindowManagerService, WindowManagerService>();
            SimpleIoc.Default.Register<IPersistAndRestoreService, PersistAndRestoreService>();
            SimpleIoc.Default.Register<IThemeSelectorService, ThemeSelectorService>();
            SimpleIoc.Default.Register<ISampleDataService, SampleDataService>();
            SimpleIoc.Default.Register<IFilesService, FilesService>();
            SimpleIoc.Default.Register<IPageService, PageService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IShellWindow, ShellWindow>();
            SimpleIoc.Default.Register<ShellViewModel>();
            SimpleIoc.Default.Register<IApplicationHostService, ApplicationHostService>();
            Register<MainViewModel, MainPage>();
            Register<DetailsViewModel, DetailsPage>();
            Register<SettingsViewModel, SettingsPage>();
        }

        private void Register<VM, V>()
            where VM : ViewModelBase
            where V : Page
        {
            SimpleIoc.Default.Register<VM>();
            SimpleIoc.Default.Register<V>();
            PageService.Configure<VM, V>();
        }

        public void AddConfiguration(IConfiguration configuration)
        {
            var appConfig = configuration
                .GetSection(nameof(AppConfig))
                .Get<AppConfig>();

            // Register configurations to IoC
            SimpleIoc.Default.Register(() => configuration);
            SimpleIoc.Default.Register(() => appConfig);
        }
    }
}
