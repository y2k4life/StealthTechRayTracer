//-----------------------------------------------------------------------
// <copyright file="Page.cs" company="">
//     Author: splttingatms
//     WebSite: www.sunnyrodriguez.com
//     GitHub: https://github.com/splttingatms/EasyConsole
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;

namespace StealthTech.RayTracer.EasyConsole
{
    public abstract class Page
    {
        public string Title { get; private set; }

        public ConsoleProgram Program { get; set; }

        public Page(string title, ConsoleProgram program)
        {
            Title = title;
            Program = program;
        }

        public virtual void Display()
        {
            if (Program.History.Count > 1 && Program.BreadCrumbHeader)
            {
                string breadCrumb = null;
                foreach (var title in Program.History.Select((page) => page.Title).Reverse())
                    breadCrumb += title + " > ";
                breadCrumb = breadCrumb.Remove(breadCrumb.Length - 3);
                Console.WriteLine(breadCrumb);
            }
            else
            {
                Console.WriteLine(Title);
            }
            Console.WriteLine("---");
        }
    }
}
