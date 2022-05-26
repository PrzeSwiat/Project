using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logika.LogicApi;

namespace Logika
{
    internal class AbstractSphere: IAbstractSphere
    {
        internal AbstractSphere(double xPosition, double yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Radius = 15;
        }
    }
}
