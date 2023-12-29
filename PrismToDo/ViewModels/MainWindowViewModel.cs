using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismToDo.Extensions;
using PrismToDo.Model;
using PrismToDo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismToDo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private IRegionNavigationJournal _navigationJournal;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);

            GoForwardCommand = new DelegateCommand(GoForward);
            GoBackCommand = new DelegateCommand(GoBack);

            MenuBars =
            [
                new MenuBar { Icon = "Home", Title = "首页", NameSpace = nameof(HomeView) },
                new MenuBar { Icon = "Custom", Title = "自定义", NameSpace = nameof(CustomView) },
                new MenuBar { Icon = "Setting", Title = "设置", NameSpace = nameof(SettingView) },
            ];
        }

        public ObservableCollection<MenuBar> MenuBars { get; set; }

        public string HomeViewName => nameof(HomeView);

        public DelegateCommand GoForwardCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; private set; }

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }

        private void Navigate(MenuBar menuItem)
        {
            _regionManager.Regions[PrismExtensions.MainViewRegionName].RequestNavigate(menuItem.NameSpace,
                back =>
                {
                    _navigationJournal = back.Context.NavigationService.Journal;
                });
        }

        private void GoForward()
        {
            if (_navigationJournal != null && _navigationJournal.CanGoForward)
            {
                _navigationJournal.GoForward();
            }
        }

        private void GoBack()
        {
            if (_navigationJournal != null && _navigationJournal.CanGoBack)
            {
                _navigationJournal.GoBack();
            }
        }
    }
}
