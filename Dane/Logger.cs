using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dane
{
    internal class Logger
    {
        private static List<Ball> balls;
        private bool isLogging = true;
        private Stopwatch sw;
        internal Logger(List<Ball> BallList)
        {
            balls = BallList;

            Thread thread = new Thread(() => StartLogging(10));

            thread.IsBackground = true;
            thread.Start();

        }

        private void StartLogging(int ms)
        {
            sw = Stopwatch.StartNew();

            while (isLogging)
            {
                if (sw.ElapsedMilliseconds >= ms)
                {
                    sw.Restart();
                    string time = ($"{ DateTime.Now:o}");
                    StringWriter wr = new StringWriter();

                    foreach (Ball ball in balls)
                    {
                        wr.WriteLine(time + " - " + JsonSerializer.Serialize(ball));
                    }

                }


            }

        }

        internal void StopLogging()
        {
            isLogging = false;
        }

    }
}
