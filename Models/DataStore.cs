﻿using Dane;
using Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Model
{
    public class DataStore
    {
        private int AmountOfSpheres = 0;
        SpheresLogic spheresLogic = new SpheresLogic();
        private double _elipseX = 0;
        private double _elipseY = 0;

        public DataStore()
        {
            Sphere newShape = (Sphere)spheresLogic.InitializeSphere();

        }

        public double ElipseX 
        {
            get { return spheresLogic.GetXPos(AmountOfSpheres);}
            set { spheresLogic.MoveToNextPos(value,0,AmountOfSpheres); }
        }
        public double ElipseY
        {
            get { return spheresLogic.GetYPos(AmountOfSpheres); }
            set { spheresLogic.MoveToNextPos(0, value, AmountOfSpheres); }
        }

        public DataStore CreateOneSphere()
        {
            spheresLogic.InitializeSphere();
            _elipseX = spheresLogic.GetXPos(AmountOfSpheres);
            _elipseY = spheresLogic.GetXPos(AmountOfSpheres);

            AmountOfSpheres++;

            return this;
        }

        public void CreateAmountOfShperes(int amount)
        {
            for(int i = 0; i < amount; i++)
            {
                CreateOneSphere();
            }
        }


    }
}