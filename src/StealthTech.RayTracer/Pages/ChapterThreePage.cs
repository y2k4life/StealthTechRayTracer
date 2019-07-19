using StealthTech.RayTracer.EasyConsole;
using StealthTech.RayTracer.Exercises;

namespace StealthTech.RayTracer.Pages
{
    public class ChapterThreePage : MenuPage
    {
        public ChapterThreePage(ConsoleProgram program)
            : base("Chapter Three", program)
        {
            //AddOption(new Option("Invert Identity Matrix", () =>
            //{
            //    var chapter = new ChapterThree();
            //    chapter.InverseIdentity();
            //    Input.ReadString("Press [Enter] to navigate home");
            //    Program.NavigateTo<ChapterThreePage>();
            //}));

            //AddOption(new Option("Multiple By the Inverse", () =>
            //{
            //    var chapter = new ChapterThree();
            //    chapter.MultipliedByInverse();
            //    Input.ReadString("Press [Enter] to navigate home");
            //    Program.NavigateTo<ChapterThreePage>();
            //}));

            //AddOption(new Option("Compare Inverse/Transpose vs Transpose/Inverse", () =>
            //{
            //    var chapter = new ChapterThree();
            //    chapter.CompareInverseTranspose();
            //    Input.ReadString("Press [Enter] to navigate home");
            //    Program.NavigateTo<ChapterThreePage>();
            //}));
        }
    }
}
