
namespace Logika
{
    public abstract class ShapesDataApi
    {
        public abstract class SpheresAPI
        {
            public int XPosition { get; set; }
            public int YPosition { get; set; }
            public int Radius { get; set; }
        };

        public static ShapesDataApi Initialize(int windowWidth, int windowHeight)
        {
            return new SpheresLogic(windowWidth, windowHeight);
        }

        public abstract void CreateSpheres(int amount);

        public abstract void TickSpheres();

        public abstract List<SpheresAPI> GetAllSpheres();

    }
}

