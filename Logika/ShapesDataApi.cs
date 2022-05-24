using Dane;
namespace Logika
{
    public abstract class ShapesDataApi
    {
        public object _lock = new object();
        public bool isMoving { get; set; }
        public List<Thread> threads;


        public static ShapesDataApi Initialize(int windowWidth, int windowHeight)
        {
            return new SpheresLogic(windowWidth, windowHeight);
        }

        public abstract void CreateSpheres(int amount);
        public abstract List<DataAbstractApi> GetAllSpheres();

        public abstract void BounceIfOnEdge(DataAbstractApi sphere);
    }
}

