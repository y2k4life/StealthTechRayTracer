using StealthTech.RayTracer.Exercises;
using StealthTech.RayTracer.Library;
using System;

namespace StealthTech.RayTracer.PerformanceTuning
{
    public class RenderingTuning
    {
        public void Run()
        {
            var test = new ChapterSix();

            var shape = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(0.5, 1, 1)
                    .Shearing(1, 0, 0, 0, 0, 0),
                Material = new Material { Color = new RtColor(1, 0.2, 1) }
            };

            test.Run(shape);
        }

        public void RunChapter7()
        {
            var test = new ChapterSeven();

            test.Render(false);
        }

        public void RunChapterNine()
        {
            var tuning = new ChapterNine();

            //for (int x = 0; x < 6; x++)
            //{
            //    var canvas = tuning.Reference(((x + 1) * -1.1) + x);
            //    PpmOutput.WriteToFile($"world{x}.ppm", canvas.GetPPMContent());
            //}

            var canvas = tuning.Reference(-Math.PI / 2);
            PpmOutput.WriteToFile($"world1.ppm", canvas.GetPPMContent());

        }
    }
}
