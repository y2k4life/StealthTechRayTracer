//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.PerformanceTuning;
using System;
using System.Runtime.Intrinsics.X86;

namespace StealthTech.RayTracer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "-a")
            {
                int start = 0;
                int end = 0;
                if (args.Length > 1)
                {
                    start = Convert.ToInt32(args[1]);
                }

                if (args.Length > 2)
                {
                    end = Convert.ToInt32(args[2]);
                }

                var tuning = new RenderingTuning();
                tuning.AnimateAreaLight(start, end);
                return;
            }

            var consoleApp = new RayTracerProgram();
            consoleApp.Run();
        }
    }
}
