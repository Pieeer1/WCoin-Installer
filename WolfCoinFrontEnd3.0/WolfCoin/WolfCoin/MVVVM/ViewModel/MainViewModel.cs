using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfCoin.Core;

namespace WolfCoin.MVVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public HomeViewModel HomeVM{ get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }




        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set {
                _currentView = value;
                OnPropertyChanged();
            }
        }



        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            SettingsVM = new SettingsViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => {
                CurrentView = HomeVM;
            });
            SettingsViewCommand = new RelayCommand(o => {
                CurrentView = SettingsVM;
            });

        }
    }
}
