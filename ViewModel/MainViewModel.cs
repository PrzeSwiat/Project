using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModel;
using Model;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        DataStore dataStore;
        private string _buttonClick;
        private string _changeOfText = "Set amount of Spheres";
        private int AmountOfShperes=0;
        private ObservableCollection<DataStore> _items;
        private static System.Timers.Timer? Timer;

        public MainViewModel()
        {
           
            AddSphereCommand = new RelayCommand(() => AddSphereHandler());
            ConfirmButtonCommand = new RelayCommand(() => ConfirmButtonHandler());

        }
        private void AddSphereHandler()
        {
            Items = new ObservableCollection<DataStore>();
            DataStore dataStore= new DataStore();
            dataStore.CreateOneSphere();
            Items.Add(dataStore);

        }
        private void ConfirmButtonHandler()
        {
            if(String.IsNullOrEmpty(ChangeOfText))
            {
                AmountOfShperes = 0;
            }
            else
            {
                AmountOfShperes++;
            }

            ChangeOfText = _changeOfText.ToString();
        }


        public string ChangeOfText
        {
            get { return _changeOfText; }
            set
            {
                _changeOfText = value;
                AmountOfShperes = int.Parse(_changeOfText);
                RaisePropertyChanged("ChangeOfText");
            }
        }

        public ICommand ConfirmButtonCommand
        {
            get;
            set;
        }
        public ICommand AddSphereCommand
        {
            get;
            set;
        }


        public ObservableCollection<DataStore> Items 
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                RaisePropertyChanged("Items");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string popertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(popertyName));
        }


    }
}
