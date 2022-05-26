
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    internal class DataApi : DataAbstractApi
    {
        public DataApi(double x, double y) 
        { 
            XPosition = x;
            YPosition = y;
            Radius = 15;
            Mass = 10;

            Random rnd = new Random();
            do
            {
                Vx = rnd.Next(-3, 3);
                Vy = rnd.Next(-3, 3);
            } while (Vx == 0 || Vy == 0);
        }

        public override event PropertyChangedEventHandler? PropertyChanged;

        public override void move()
        {
            XPosition += Vx;
            YPosition += Vy;

            RaisePropertyChanged();
        }

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}