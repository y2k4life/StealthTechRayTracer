//-----------------------------------------------------------------------
// <copyright file="ExercisePage.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.EasyConsole;
using StealthTech.RayTracer.Exercises;
using StealthTech.RayTracer.Library;

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
                Program.NavigateTo<ExercisePage>();
            }));

            AddOption(new Option("Chapter Two", () =>
            {
                var chapter = new ChapterTwo();
                chapter.Run();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<ExercisePage>();
            }));

            AddOption(new Option("Chapter Three", () => program.NavigateTo<ChapterThreePage>()));

            AddOption(new Option("Chapter Four", () =>
            {
                var chapter = new ChapterFour();
                chapter.Run();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<ExercisePage>();
            }));

            AddOption(new Option("Chapter Five", () => Program.NavigateTo<ChapterFivePage>()));

            AddOption(new Option("Chapter Six", () => Program.NavigateTo<ChapterSixPage>()));

            AddOption(new Option("Chapter Seven and Eight", () =>
            {
                var chapter = new ChapterSeven();
                chapter.Run();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<ExercisePage>();
            }));

            AddOption(new Option("Chapter Nine", () =>
            {
                var animation = new Animation()
                {
                    FrameCount = 13,
                    StartFrame = 1
                };
                
                var chapter = new ChapterNine(animation);
                chapter.Run();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<ExercisePage>();
            }));

            AddOption(new Option("Chapter Thirteen", () =>
            {
                var chapter = new ChapterThirteen();
                chapter.Run();
                Input.ReadString("Press [Enter] to navigate home");
                Program.NavigateTo<ExercisePage>();
            }));

            AddOption(new Option("Bonus - Area Light", () =>
            {
                var bonus = new BonusAreaLight();

                var canvas = bonus.Run();
                PpmOutput.WriteToFile("world.ppm", canvas.GetPPMContent());

                Program.NavigateTo<ExercisePage>();
            }));
        }
    }
}
