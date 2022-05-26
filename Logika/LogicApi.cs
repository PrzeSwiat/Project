using Dane;
namespace Logika
{
    public abstract class LogicApi
    {
        public object _lock = new object();
        public bool isMoving { get; set; }
        public List<Thread> threads;


        public static LogicApi Initialize(int windowWidth, int windowHeight)
        {
            return new SpheresLogic(windowWidth, windowHeight);
        }
        public abstract void SummonSpheres(int amount);
        public abstract void CreateSpheres(int amount);
        public abstract List<DataAbstractApi> GetAllSpheres();

        public abstract void BounceIfOnEdge(DataAbstractApi sphere);

        public abstract void ClearThreads();

    }
      

}

