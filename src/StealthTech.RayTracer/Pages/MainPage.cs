//-----------------------------------------------------------------------
// <copyright file="MainPage.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.EasyConsole;
using System;

namespace StealthTech.RayTracer.Pages
{
    class MainPage : MenuPage
    {
        public MainPage(ConsoleProgram program)
            : base("Main Page", program)
        {
            AddOption(new Option("Exercises", () => program.NavigateTo<ExercisePage>()));
            AddOption(new Option("Tuning", () => program.NavigateTo<TuningPage>()));
            AddOption(new Option("Exit", () => Environment.Exit(0)));
        }
    }
}
