using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacja.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _buttonClick;

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
