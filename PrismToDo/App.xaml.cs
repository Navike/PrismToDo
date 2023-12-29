using Prism.Ioc;
using PrismToDo.ViewModels;
using PrismToDo.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PrismToDo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //dialog

            //nav views
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();

            containerRegistry.RegisterForNavigation<HomeView>();
            containerRegistry.RegisterForNavigation<CustomView>();
            containerRegistry.RegisterForNavigation<SettingView>();
        }
    }
}
