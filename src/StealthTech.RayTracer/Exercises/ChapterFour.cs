using StealthTech.RayTracer.Library;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace StealthTech.RayTracer.Exercises
{
    public class ChapterFour
    {
        private const int SIZE = 800;
        private readonly Canvas _canvas = new Canvas(SIZE, SIZE);

        public void Run()
        {
            var startingPoint = new RtPoint(0, 0, 1);
            WriteToCanvas(startingPoint.X, startingPoint.Z);

            for (int i = 1; i < 12; i++)
            {
                WriteNumber(i, startingPoint);
            }

            PpmOutput.WriteToFile("file.ppm", _canvas.GetPPMContent());
        }

        public void WriteNumber(int number, RtPoint startingPoint)
        {
            var moveClock = new Transform()
                .RotateY(number * Math.PI / 6);

            var numberPoint = moveClock * startingPoint;
            WriteToCanvas(numberPoint.X, numberPoint.Z);
        }

        public void WriteToCanvas(double x, double y)
        {
            _canvas[Convert.ToInt32(x * (SIZE * 0.375)) + SIZE / 2, Convert.ToInt32(y * (SIZE * 0.375)) + SIZE / 2] = new RtColor(1, 0, 0);
        }
    }
}
