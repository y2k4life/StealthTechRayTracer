//-----------------------------------------------------------------------
// <copyright file="Canvas.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System.Text;
using System.IO;

namespace StealthTech.RayTracer.Library
{
    public class Canvas
    {
        private readonly RtColor[,] canvas;

        public Canvas(int width, int height) 
            : this(width, height, RtColor.Black)
        {
        }

        public Canvas(int width, int height, RtColor background)
        {
            Width = width;
            Height = height;
            canvas = new RtColor[width, height];

            Clear(background);
        }

        public int Width { get; set; }
        
        public int Height { get; set; }

        public RtColor this[int x, int y]
        {
            get
            {
                return canvas[x, y];
            }

            set
            {
                canvas[x, y] = value;
            }
        }

        public string GetPPMContent()
        {
            var builder = new StringBuilder();
            builder.AppendLine("P3");
            builder.AppendLine($"{Width} {Height}");
            builder.AppendLine("255");
            for (int y = 0; y < Height; y++)
            {
                int lineLength = 0;
                for (int x = 0; x < Width; x++)
                {
                    string[] colorA = canvas[x, y].ToRGBA();
                    foreach (var color in colorA)
                    {
                        if (lineLength + 1 + color.Length > 70)
                        {
                            builder.AppendLine();
                            lineLength = 0;
                        }

                        if(lineLength != 0)
                        {
                            builder.Append(" ");
                            lineLength++;
                        }

                        builder.Append(color);
                        lineLength += color.Length;
                    }
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }

        private void Clear(RtColor RtColor)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    canvas[x, y] = RtColor;
                }
            }
        }
    }
}