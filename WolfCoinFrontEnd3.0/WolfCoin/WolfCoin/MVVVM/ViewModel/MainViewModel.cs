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
        public SendViewModel SendVM { get; set; }
        public SellViewModel SellVM { get; set; }
        public BuyViewModel BuyVM { get; set; }
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand SendViewCommand { get; set; }
        public RelayCommand SellViewCommand { get; set; }
        public RelayCommand BuyViewCommand { get; set; }

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
            SendVM = new SendViewModel();
            SellVM = new SellViewModel();
            BuyVM = new BuyViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => {
                CurrentView = HomeVM;
            });
            SendViewCommand = new RelayCommand(o => {
                CurrentView = SendVM;
            });
            SellViewCommand = new RelayCommand(o => {
                CurrentView = SellVM;
            });
            BuyViewCommand = new RelayCommand(o => {
                CurrentView = BuyVM;
            });
        }
    }
}
