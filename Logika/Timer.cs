using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    public class Tasker
    {

        private SpheresLogic spheresLogic = new SpheresLogic();
        public void MainOperator()//tutaj bedzie dostawał komunikat ze jest kolejna kula (uzytkowanik klick)
        {
            // a tutaj jezeli bedzie komunikat to musi sie zainicjalizować next kula
            spheresLogic.InitializeSphere();











            ////to musi byc jeden cykl (tutaj będa się aktualizować wszystkie kule jakie będa na planszy)
            //Parallel.For(0, spheresLogic.DatasCounter(), i =>
            //{
            //    ActualizePosition(spheresLogic.GetSphere(i), 0.1, 0.1);//ZMIEN TO !

            //});

            


        }
        

        public void ActualizePosition(Sphere sphere, double nextX, double nextY)
        {
            sphere.Move(nextX, nextY); //małe przesunięcia  
        }

    }

}
