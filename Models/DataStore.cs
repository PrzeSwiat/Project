using Aspose.Pdf.Drawing;
using Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Model
{
    public class DataStore
    {
        private readonly List<Ellipse> ellipses;
        private int AmountOfSpheres = 0;
        SpheresLogic spheresLogic = new SpheresLogic();

        public DataStore()
        {
            ellipses = new List<Ellipse>();
        }

        public void CreateOneSphere()
        {
            spheresLogic.InitializeSphere();
            double radius = spheresLogic.GetRad(AmountOfSpheres);
            double x = spheresLogic.GetXPos(AmountOfSpheres);
            double y = spheresLogic.GetXPos(AmountOfSpheres);

            Ellipse newEllipse = new Ellipse(x, y, radius * 2, radius * 2);
            ellipses.Add(newEllipse);

            AmountOfSpheres++;
        }


    }
}