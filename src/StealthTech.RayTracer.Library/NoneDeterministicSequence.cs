//-----------------------------------------------------------------------
// <copyright file="NoneDeterministicSequence.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public class NoneDeterministicSequence : ISequence
    {
        private Random _random = new Random();

        public double Next()
        {
            var number = _random.NextDouble();
            return number;
        }
    }
}
