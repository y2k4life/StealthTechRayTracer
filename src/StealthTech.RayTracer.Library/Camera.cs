//-----------------------------------------------------------------------
// <copyright file="Camera.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace StealthTech.RayTracer.Library
{
    public class Camera
    {
        public Camera(int horizontalSize, int verticalSize, double fieldOfView)
        {
            HorizontalSize = horizontalSize;
            VerticalSize = verticalSize;
            FieldOfView = fieldOfView;

            var halfView = Math.Tan(fieldOfView / 2);
            var aspect = horizontalSize * 1.0 / verticalSize;
            if (aspect >= 1)
            {
                HalfWidth = halfView;
                HalfHeight = halfView / aspect;
            }
            else
            {
                HalfWidth = halfView * aspect;
                HalfHeight = halfView;
            }

            PixelSize = (HalfWidth * 2) / horizontalSize;
        }

        public int HorizontalSize { get; set; }

        public int VerticalSize { get; set; }

        public double FieldOfView { get; set; }

        public Transform ViewTransform { get; set; } = new ViewTransform();

        public double HalfWidth { get; }

        public double HalfHeight { get; }

        public double PixelSize { get; }

        public Ray RayForPixel(double px, double py)
        {
            var offsetX = (px + 0.5) * PixelSize;
            var offsetY = (py + 0.5) * PixelSize;

            var worldX = HalfWidth - offsetX;
            var worldY = HalfHeight - offsetY;

            var pixel = ViewTransform.Matrix.Inverse() * new RtPoint(worldX, worldY, -1);
            var origin = ViewTransform.Matrix.Inverse().MultipliedByPointOrigin();
            var direction = (pixel - origin).Normalize();

            return new Ray(origin, direction);
        }

        public Canvas Render(World world, int topX, int topY, int width, int heigth)
        {
            var image = new Canvas(HorizontalSize, VerticalSize);

            for (int y = topY; y < topY + heigth; y++)
            {
                for (int x = topX; x < topX + width; x++)
                {
                    var ray = RayForPixel(x, y);
                    var color = world.ColorAt(ray, 4);

                    image[x, y] = color;
                }
            }

            return image;
        }

        public Canvas Render(World world, bool parallel = true)
        {
            var image = new Canvas(HorizontalSize, VerticalSize);
            if (parallel)
            {
                Parallel.For(0, VerticalSize, y =>
                {
                    Parallel.For(0, HorizontalSize, x =>
                    {
                        var ray = RayForPixel(x, y);
                        var color = world.ColorAt(ray, 4);
                        image[x, y] = color;
                    });
                });
            }
            else
            {
                for (int y = 0; y < VerticalSize; y++)
                {
                    for (int x = 0; x < HorizontalSize; x++)
                    {
                        var ray = RayForPixel(x, y);
                        var color = world.ColorAt(ray, 4);
                        image[x, y] = color;
                        //output?.Invoke(x, y, color.ToARGB());
                    }
                }
            }

            return image;
        }
    }
}
