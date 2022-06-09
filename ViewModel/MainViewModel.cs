using System.Windows;
using Model;
using ViewModel;
using Logika;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Models;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public class ViewModelLayer : INotifyPropertyChanged
    {

        public ViewModelLayer()
        {
            MyModel = ModelLayerAbstractAPI.CreateAPI();
            Start = new RelayCommand(() => start());
            Stop = new RelayCommand(() => stop());
            _numberOfBalls = 5;
            _startButton = "Start";
        }

        private ModelLayerAbstractAPI MyModel { get; set; }

        private int _numberOfBalls;
        private int _height = 600;
        private int _width = 900;
        private string _startButton;
        private bool _enabled = true;

        public string StartButton
        {
            get => _startButton;
            set
            {
                _startButton = value;
                RaisePropertyChanged("StartButton");
            }

        }

        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                RaisePropertyChanged("Width");
            }

        }


        public int Height
        {
            get => _height;
            set
            {
                _height = value;
                RaisePropertyChanged("Height");
            }
        }

        public ObservableCollection<Circle> Circles
        {
            get => MyModel.Circles;
            set => MyModel.Circles = value;
        }

        public string NumberOfBalls
        {
            get => _numberOfBalls.ToString();
            set
            {
                if (int.TryParse(value, out int n) && n != 0)
                    _numberOfBalls = Math.Abs(n);
                RaisePropertyChanged(nameof(NumberOfBalls));
            }
        }

        public bool StartEnabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                RaisePropertyChanged(nameof(StartEnabled));
            }
        }

        public ICommand Start { get; set; }
        public ICommand Stop { get; set; }

        private void start()
        {
            MyModel.GenerateBallsRepresentative(Height, Width, _numberOfBalls, 30);
            StartButton = "Restart";
            StartEnabled = false;

        }

        private void stop()
        {
            MyModel.StopSimulation();
            StartEnabled = true;
        }


        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
