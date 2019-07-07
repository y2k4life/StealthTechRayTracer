//-----------------------------------------------------------------------
// <copyright file="Animation.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    public class Animation
    {
        public double CurrentFrame { get; set; }

        public int FrameCount { get; set; }

        public int StartFrame { get; set; } = 1;

        public double Offset(int key1, int key2, double initialValue, double endValue)
        {
            if (CurrentFrame < key1)
            {
                return initialValue;
            }
            else if (CurrentFrame > key2)
            {
                return endValue;
            }

            var percent = (CurrentFrame - key1) / (key2 - key1);
            return (endValue - initialValue) * percent + initialValue;
        }
    }
}
