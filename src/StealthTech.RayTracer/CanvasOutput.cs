﻿using System.Diagnostics;
using System.IO;

namespace StealthTech.RayTracer
{
    public class PpmOutput
    {
        public static void WriteToFile(string fileName, string ppmContent, bool showAfter = true)
        {
            File.WriteAllText(fileName, ppmContent);
            if (showAfter)
            {
                using var process = new Process
                {
                    StartInfo = new ProcessStartInfo(fileName)
                    {
                        UseShellExecute = true
                    }
                };
                process.Start();
            }
        }
    }
}
