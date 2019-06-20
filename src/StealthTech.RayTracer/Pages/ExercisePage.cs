//-----------------------------------------------------------------------
// <copyright file="ExercisePage.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.EasyConsole;
using StealthTech.RayTracer.Exercises;

namespace StealthTech.RayTracer.Pages
{
    public class ExercisePage : MenuPage
    {
        public ExercisePage(ConsoleProgram program)
            : base("Exercises", program)
        {
            AddOption(new Option("Chapter One", () =>
            {
                var chapter = new ChapterOne();
                chapter.Run();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateHome();
            }));

            AddOption(new Option("Chapter Two", () =>
            {
                var chapter = new ChapterTwo();
                chapter.Run();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateHome();
            }));
        }
    }
}
