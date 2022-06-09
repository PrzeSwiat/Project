using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Box
    {
        private readonly int _width;
        private readonly int _height;

        private readonly List<Ball> _balls;


        public Box(int height, int width)
        {
            _balls = new List<Ball>();
            if (height <= 0 || width <= 0)
                throw new ArgumentException();

            _width = width;
            _height = height;

        }

        public int Width { get => _width; }
        public int Height { get => _height; }

        public void AddBall(Ball ball)
        {
            _balls.Add(ball);
        }

        public List<Ball> GetBalls()
        {
            return _balls;
        }

    }
}
