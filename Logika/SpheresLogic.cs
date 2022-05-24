
using Dane;

namespace Logika
{
    internal class SpheresLogic : ShapesDataApi
    {
        internal readonly int _Radius = 15;
        internal readonly List<DataAbstractApi> _SphereStorage = new();

        internal readonly int _windowWidth;
        internal readonly int _windowHeight;

        public SpheresLogic(int windowWidth, int windowHeight)
        {
            _windowHeight = windowHeight;
            _windowWidth = windowWidth;
        }


        override public void CreateSpheres(int amount)
        {
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                int xPos = rnd.Next(_Radius, _windowWidth - _Radius);
                int yPos = rnd.Next(_Radius, _windowHeight - _Radius);
                _SphereStorage.Add(DataAbstractApi.getSphere(xPos, yPos));
            }
        }


        public override void BounceIfOnEdge(DataAbstractApi sphere)
        {
            throw new NotImplementedException();
        }

        public override List<DataAbstractApi> GetAllSpheres()
        {
            return _SphereStorage;
        }
    }
}
