//-----------------------------------------------------------------------
// <copyright file="RayTracerProgram.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.EasyConsole;
using StealthTech.RayTracer.Pages;

namespace StealthTech.RayTracer
{
    public class RayTracerProgram : ConsoleProgram
    {
        public RayTracerProgram()
            : base("Ray Tracer Challenge", true)
        {
            AddPage(new ExercisePage(this));
            AddPage(new TuningPage(this));
            AddPage(new MainPage(this));
            AddPage(new ChapterThreePage(this));
            AddPage(new ChapterFivePage(this));

            SetPage<MainPage>();
        }
    }
}
