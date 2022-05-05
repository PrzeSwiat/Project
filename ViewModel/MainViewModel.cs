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
using Dane;

namespace ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand _add { get; }
        public RelayCommand _confirm { get; }
        DataStore dataStore { get; }
        private string _changeOfText = "Set amount of Spheres";
        private int AmountOfShperes=0;
       

        public MainViewModel()
        {
           
            _add = new RelayCommand(() => AddSphereHandler());
            _confirm = new RelayCommand(() => ConfirmButtonHandler());
            dataStore = new DataStore();

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

        public Sphere[]? Items { get => dataStore.GetAllSpheres().ToArray(); }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string popertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(popertyName));
        }


    }
}
