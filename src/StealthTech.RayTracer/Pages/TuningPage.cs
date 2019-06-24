//-----------------------------------------------------------------------
// <copyright file="TuningPage.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.EasyConsole;
using StealthTech.RayTracer.Exercises;
using StealthTech.RayTracer.PerformanceTuning;

namespace StealthTech.RayTracer.Pages
{
    public class TuningPage : MenuPage
    {
        public TuningPage(ConsoleProgram program)
            : base("Tuning", program)
        {
            AddOption(new Option("Matrix Multiplication", () =>
            {
                var tuning = new MatricesTuning();
                tuning.Multiplication();
            }));

            AddOption(new Option("Build Image from Chapter Five", () =>
            {
                var tuning = new MatricesTuning();
                tuning.BuildImageFromChapterFix();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<ExercisePage>();
            }));
        }
    }
}
