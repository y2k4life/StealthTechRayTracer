using StealthTech.RayTracer.Exercises;
using StealthTech.RayTracer.Library;
using System.Threading.Tasks;

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
    }
}
