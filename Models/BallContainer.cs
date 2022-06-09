using Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Circle : INotifyPropertyChanged
    {
        public Circle(BallConnector ball)
        {
            ball.PropertyChanged += BallPropertyChanged;
            X_Center = ball.X;
            Y_Center = ball.Y;
            Radius = ball.R;
        }

        private double x_center;
        private double y_center;
        private double radius;

        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                RaisePropertyChanged("Radius");
            }

        }
        public double X_Center
        {
            get => x_center;
            set
            {
                x_center = value;
                RaisePropertyChanged("X_Center");
            }
        }
        public double Y_Center
        {
            get => y_center;
            set
            {
                y_center = value;
                RaisePropertyChanged("Y_Center");
            }
        }
        public double CenterTransform { get => -1 * Radius; }
        public double Diameter { get => 2 * Radius; }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void BallPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            BallConnector b = (BallConnector)sender;

            X_Center = b.X;
            Y_Center = b.Y;
        }
    }
}
