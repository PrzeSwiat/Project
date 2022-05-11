
namespace Dane
{
    internal class DataApi : DataAbstractApi
    {

        private double _x;
        private double _y;

        public DataApi() 
        { 
        }


        public override double getX()
        {
            return _x;
        }

        public override double getY()
        {
            return _y;
        }

        public override void setX(double x)
        {
            _x = x;
        }

        public override void setY(double y)
        {
            _y = y;
        }
    }
}