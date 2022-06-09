using Logika;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;


namespace Model
{
    public abstract class ModelLayerAbstractAPI
    {
        public static ModelLayerAbstractAPI CreateAPI(LogicLayerAbstractAPI logicLayer = default)
        {
            return new ModelLayer(logicLayer ?? LogicLayerAbstractAPI.CreateAPI());
        }

        public abstract void GenerateBallsRepresentative(int height, int width, int numberOfBalls, int radiusOfBalls);
        public abstract void StartSimulation();
        public abstract void StopSimulation();

        public ObservableCollection<Circle> Circles
        {
            get => circles;
            set => circles = value;
        }

        private ObservableCollection<Circle> circles = new ObservableCollection<Circle>();



        internal class ModelLayer : ModelLayerAbstractAPI
        {
            public ModelLayer(LogicLayerAbstractAPI logicLayer)
            {
                MyLogicLayer = logicLayer;
            }


            public override void GenerateBallsRepresentative(int height, int width, int numberOfBalls, int radiusOfBalls)
            {
                MyLogicLayer.DestroyThreads();
                MyLogicLayer.CreateBox(height, width, numberOfBalls, radiusOfBalls);

                circles.Clear();

                foreach (BallConnector bc in MyLogicLayer.GetBalls())
                {
                    circles.Add(new Circle(bc));
                }

                StartSimulation();
            }
            public override void StartSimulation()
            {
                MyLogicLayer.StartMovingBalls();
            }

            public override void StopSimulation()
            {
                MyLogicLayer.DestroyThreads();
            }


            private readonly LogicLayerAbstractAPI MyLogicLayer;

        }

    }
}