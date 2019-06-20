//-----------------------------------------------------------------------
// <copyright file="MatricesTunning.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace StealthTech.RayTracer.PerformanceTuning
{
    public class MatricesTuning
    {
        public RtMatrix Multiplication()
        {
            var results = new RtMatrix(0, 0);
            for (int c = 0; c < 1000; c++)
            {
                var matrix1 = CreateMatrix(256);
                var matrix2 = CreateMatrix(256);
                results = matrix1 * matrix2;
            }

            return results;
        }

        private static RtMatrix CreateMatrix(int size)
        {
            var matrix = new RtMatrix(size, size);
            var rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    matrix[x, y] = rnd.NextDouble() * 10;
                }
            }

            return matrix;
        }
    }
}
