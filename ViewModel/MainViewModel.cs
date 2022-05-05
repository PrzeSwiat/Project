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

namespace ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _buttonClick;
        private string _changeOfText;
        private DataStore DataStore = new DataStore();

        public MainViewModel()
        {
            ChangeOfText = "Set amount of Spheres";
            AddSphereCommand = new RelayCommand(DataStore.CreateOneSphere);


        }

        public string ChangeOfText
        {
            get { return _changeOfText; }
            set
            {
                _changeOfText = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ConfirmButtomCommand
        {
            get;
            set;
        }
        public RelayCommand AddSphereCommand
        {
            get;
            set;
        }

        public string ButtonClick
        {
            get { return _buttonClick; }
            set
            {
                _buttonClick = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string popertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(popertyName));
        }


    }
}
