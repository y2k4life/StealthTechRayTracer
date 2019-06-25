//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.PerformanceTuning;

namespace StealthTech.RayTracer
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0 && args[0] == "-t")
            {
                var tuning = new RenderingTuning();
                tuning.Run();
            }

            var consoleApp = new RayTracerProgram();
            consoleApp.Run();
        }
    }
}
