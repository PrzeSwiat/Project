
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    public class Ball : INotifyPropertyChanged
    {
        public Ball(double x, double y, double radius, double mass, int id)
        {
            _id = id;
            _x = x;
            _y = y;
            _r = radius;
            _m = mass;

            Random r = new Random();

            if (r.Next(2) == 0)
            {
                _xStep = r.NextDouble() * -1;
            }
            else
            {
                _xStep = r.NextDouble() * 1;
            }


            if (r.Next(2) == 0)
                _yStep = Math.Sqrt(1 - (_xStep * _xStep));
            else
                _yStep = Math.Sqrt(1 - (_xStep * _xStep)) * -1;

        }

        private int _id;
        private double _x;
        private double _y;
        private double _r;
        private double _m;
        private double _xStep;
        private double _yStep;

        public void Move()
        {
            X += XStep;
            Y += YStep;
            RaisePropertyChanged("Position");
        }

        public int ID
        {
            get { return _id; }
        }
        public double X
        {
            get => _x;
            set
            {
                _x = value;
                RaisePropertyChanged("X");
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                RaisePropertyChanged("Y");
            }

        }
       
        public double R
        {
            get => _r;
            set
            {
                if (value > 0)
                {
                    _r = value;
                }

                else
                {
                    throw new ArgumentException();
                }

            }
        }
      
        public double M
        {
            get => _m;
            set
            {
                _m = value;
            }
        }

        public double XStep
        {
            get => _xStep;
            set
            {
                _xStep = value;
            }
        }

        public double YStep
        {
            get => _yStep;
            set
            {
                _yStep = value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}