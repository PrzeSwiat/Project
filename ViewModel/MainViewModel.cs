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
        DataStore dataStore = new DataStore();
        private string _changeOfText = "Set amount of Spheres";
        private int AmountOfShperes=0;

        public MainViewModel()
        {
           
            AddSphereCommand = new RelayCommand(() => AddSphereHandler());
            ConfirmButtonCommand = new RelayCommand(() => ConfirmButtonHandler());

        }
        private void AddSphereHandler()
        {
            dataStore.CreateOneSphere();
            OnPropertyChanged("Items");

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

            for (int i = 0; i < AmountOfShperes; i++)
            {
                dataStore.CreateOneSphere();
                OnPropertyChanged("Items");
            }
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

        public RelayCommand ConfirmButtonCommand
        {
            get;
            set;
        }
        public RelayCommand AddSphereCommand
        {
            get;
            set;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string popertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(popertyName));
        }


    }
}
