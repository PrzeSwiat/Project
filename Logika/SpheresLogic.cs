
using Dane;

namespace Logika
{
    internal class SpheresLogic : ShapesDataApi
    {
        internal readonly int _windowWidth;
        internal readonly int _windowHeight;
        internal readonly int _Radius;
        internal readonly List<SpheresAPI> _sphereStorage = new();
        private DataAbstractApi _dataAbstractApi;
        public SpheresLogic(int windowWidth, int windowHeight)
        {
            _windowHeight = windowHeight;
            _windowWidth = windowWidth;
            _Radius = Math.Min(windowHeight, windowWidth) / 30;
        }

        private void CreateSphere()
        {
            Random rnd = new Random();
            int xVelocity, yVelocity;
            int speed = 6;
            do
            {
                xVelocity = rnd.Next(-speed, speed);
                yVelocity = rnd.Next(-speed, speed);
            }
            while (xVelocity == 0 || yVelocity == 0);

            int xPos = rnd.Next(_Radius, _windowWidth - _Radius);
            int yPos = rnd.Next(_Radius, _windowHeight - _Radius);

            Spheres newSphere = new(xPos, yPos, _Radius, xVelocity, yVelocity);
            _sphereStorage.Add(newSphere);
        }

        override public void CreateSpheres(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                CreateSphere();
            }
        }


        override public void TickSpheres()
        {
            foreach (Spheres sphere in _sphereStorage)
            {
                sphere.MoveSphereWithinBox(_windowWidth, _windowHeight);
            }
        }


        override public List<SpheresAPI> GetAllSpheres()
        {
            return _sphereStorage;
        }

    }
}
