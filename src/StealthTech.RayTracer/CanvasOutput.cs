using System.Diagnostics;
using System.IO;

namespace StealthTech.RayTracer
{
    public class PpmOutput
    {
        public static void WriteToFile(string fileName, string ppmContent)
        {
            File.WriteAllText(fileName, ppmContent);
            new Process
            {
                StartInfo = new ProcessStartInfo(fileName)
                {
                    UseShellExecute = true
                }
            }.Start();
        }
    }
}
