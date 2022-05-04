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

namespace ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _buttonClick;
        private string _changeOfText;



        public MainViewModel()
        {
            ChangeOfText = "Set amount of Spheres";
            ConfirmButtomCommand = new RelayCommand(ConfirmButton);
            AddSphereCommand = new RelayCommand(AddSphere);



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

        private void AddSphere(object obj)
        {
           
        }

        private void ConfirmButton(object obj)
        {
            
        }

        public ICommand ConfirmButtomCommand
        {
            get;
            set;
        }
        public ICommand AddSphereCommand
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
