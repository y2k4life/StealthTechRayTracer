//-----------------------------------------------------------------------
// <copyright file="ChapterSixPage.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.EasyConsole;
using StealthTech.RayTracer.Exercises;

namespace StealthTech.RayTracer.Pages
{
    class ChapterSixPage : MenuPage
    {
        public ChapterSixPage(ConsoleProgram program)
            : base("Chapter Six", program)
        {
            AddOption(new Option("Regular", () =>
            {
                var chapter = new ChapterSix();
                chapter.NormalSphere();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<ChapterSixPage>();
            }));

            AddOption(new Option("Custom", () =>
            {
                var chapter = new ChapterSix();
                chapter.Custom();
                Program.NavigateTo<ChapterSixPage>();
            }));

            AddOption(new Option("Shrink it along the y axis", () =>
            {
                var chapter = new ChapterSix();
                chapter.ShrinkAlongYAxis();
                Program.NavigateTo<ChapterSixPage>();
            }));

            AddOption(new Option("Shrink it along the x axis", () =>
            {
                var chapter = new ChapterSix();
                chapter.ShrinkAlongXAxis();
                Program.NavigateTo<ChapterSixPage>();
            }));

            AddOption(new Option("Shrink and Rotate", () =>
            {
                var chapter = new ChapterSix();
                chapter.ShrinkAndRotate();
                Program.NavigateTo<ChapterSixPage>();
            }));

            AddOption(new Option("Shrink and skew", () =>
            {
                var chapter = new ChapterSix();
                chapter.ShrinkAndSkew();
                Program.NavigateTo<ChapterSixPage>();
            }));
        }
    }
}
