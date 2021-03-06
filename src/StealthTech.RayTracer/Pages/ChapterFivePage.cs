﻿//-----------------------------------------------------------------------
// <copyright file="ChapterFivePage.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.EasyConsole;
using StealthTech.RayTracer.Exercises;

namespace StealthTech.RayTracer.Pages
{
    class ChapterFivePage : MenuPage
    {
        public ChapterFivePage(ConsoleProgram program)
            : base("Chapter Five", program)
        {
            AddOption(new Option("Regular", () =>
            {
                var chapter = new ChapterFive();
                chapter.NormalSphere();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<ChapterFivePage>();
            }));

            AddOption(new Option("Shrink it along the y axis", () =>
            {
                var chapter = new ChapterFive();
                chapter.ShrinkAlongYAxis();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<ChapterFivePage>();
            }));

            AddOption(new Option("Shrink it along the x axis", () =>
            {
                var chapter = new ChapterFive();
                chapter.ShrinkAlongXAxis();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<ChapterFivePage>();
            }));

            AddOption(new Option("Shrink and Rotate", () =>
            {
                var chapter = new ChapterFive();
                chapter.ShrinkAndRotate();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<ChapterFivePage>();
            }));

            AddOption(new Option("Shrink and skew", () =>
            {
                var chapter = new ChapterFive();
                chapter.ShrinkAndSkew();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<ChapterFivePage>();
            }));
        }
    }
}
