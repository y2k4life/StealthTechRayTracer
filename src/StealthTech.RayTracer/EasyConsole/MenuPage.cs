//-----------------------------------------------------------------------
// <copyright file="MenuPage.cs" company="">
//     Author: splttingatms
//     WebSite: www.sunnyrodriguez.com
//     GitHub: https://github.com/splttingatms/EasyConsole
// </copyright>
//-----------------------------------------------------------------------
namespace StealthTech.RayTracer.EasyConsole
{
    public abstract class MenuPage : Page
    {
        protected Menu Menu { get; } = new Menu();

        public MenuPage(string title, ConsoleProgram program)
            : base(title, program)
        {
        }

        public void AddOption(Option option)
        {
            Menu.Add(option);
        }

        public override void Display()
        {
            base.Display();

            if (Program.NavigationEnabled && !Menu.Contains("Go back"))
                Menu.Add("Go back", () => { Program.NavigateBack(); });

            Menu.Display();
        }
    }
}
