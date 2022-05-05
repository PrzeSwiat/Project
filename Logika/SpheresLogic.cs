﻿using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class SpheresLogic
    {
        private ShapesDataApi ShapesDataApi;
        private Shapes Shape;
        private double MoveX;
        private double MoveY;
        private int SphereIndex;

        public SpheresLogic()
        {
            ShapesDataApi = ShapesDataApi.CreateShapesList();
        }

        public List<Sphere> GetAllOfSpheres()
        {
            return ShapesDataApi.GetSpheres();
        }

        public Shapes InitializeSphere()
        {
            Random rnd = new Random();
            double rndX = rnd.Next(100, 800);
            double rndY = rnd.Next(100, 500);
            double rndR = 35;
            Shape = ShapesDataApi.CreateSphere(rndX, rndY, rndR);
            ShapesDataApi.Add(Shape);
            SphereIndex = ShapesDataApi.Count();

            return Shape;
        }

        public List<double> OrderPositionChange()
        {
            Random rnd = new Random();
            double rndPosX = rnd.Next(150, 750);
            double rndPosY = rnd.Next(150, 450);

            List<double> orderPositions = new List<double>();
            orderPositions.Add(rndPosX);
            orderPositions.Add(rndPosY);

            return orderPositions;
        }

        public int DatasCounter()
        {
            int counter = 0;
            for (int i = 0; i < ShapesDataApi.Count(); i++)
            {
                counter++;
            }

            return counter;
        }

        public Sphere GetSphere(int index)
        {
            return (Sphere)ShapesDataApi.Get(index);
        }

        public double GetXPos(int index)
        {
            return ShapesDataApi.GetX(index);
        }
        public double GetYPos(int index)
        {
            return ShapesDataApi.GetY(index);
        }
        public double GetRad(int index)
        {
            return ShapesDataApi.GetRad(index);
        }

        public void MoveToNextPos()
        {
            var lista = OrderPositionChange();
            MoveX = lista[0];
            MoveY = lista[1];
            ShapesDataApi.MoveNext(MoveX, MoveY, SphereIndex);
        }

    }
}
