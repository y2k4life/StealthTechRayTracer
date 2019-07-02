//-----------------------------------------------------------------------
// <copyright file="CameraContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs.Contexts
{
    public class CameraContext
    {
        public int HorizontalSize { get; set; }

        public int VerticalSize { get; set; }

        public double FieldOfView { get; set; }

        public Camera Camera { get; set; }

        public Canvas Image { get; set; }
    }
}
