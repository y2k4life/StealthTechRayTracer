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

            test.Render(true);
        }

        public void RunChapterNine()
        {
            var tuning = new ChapterNine(null);
            var canvas = tuning.Render();
            PpmOutput.WriteToFile($"world1.ppm", canvas.GetPPMContent());

            //var animation = new Animation()
            //{
            //    FrameCount = 300,
            //    StartFrame = 1
            //};
                        
            //var tuning = new ChapterNine(animation);


            //for (int x = animation.StartFrame; x < animation.FrameCount + 1; x++)
            //{
            //    animation.CurrentFrame = x;
            //    var canvas = tuning.Render();

            //    PpmOutput.WriteToFile($"world{x}.ppm", canvas.GetPPMContent(), false);
            //}

            //var canvas = tuning.Reference(-Math.PI / 2);
            //PpmOutput.WriteToFile($"world1.ppm", canvas.GetPPMContent());

        }

        public void AnimateAreaLight(int start, int end)
        {
            
            var animation = new Animation()
            {
                FrameCount = 400,
            };

            start = start == 0 ? 1 : start;
            end = end == 0 ? animation.FrameCount : end;

            var tuning = new BonusAreaLight(animation);

            for (int x = start; x < end + 1; x++)
            {
                animation.CurrentFrame = x;
                var canvas = tuning.Animate();

                PpmOutput.WriteToFile($"world{x}.ppm", canvas.GetPPMContent(), false);
            }
        }

        public void RunChapterTwelve()
        {
            var animation = new Animation()
            {
                FrameCount = 13,
                StartFrame = 1
            };

            var tuning = new ChapterTwelve(animation);

            for (int x = animation.StartFrame; x < animation.FrameCount + 1; x++)
            {
                animation.CurrentFrame = x;
                var canvas = tuning.Render();

                PpmOutput.WriteToFile($"world-twelve{x}.ppm", canvas.GetPPMContent(), true);
            }

            //var canvas = tuning.Reference(-Math.PI / 2);
            //PpmOutput.WriteToFile($"world1.ppm", canvas.GetPPMContent());

        }
    }
}
