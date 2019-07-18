//-----------------------------------------------------------------------
// <copyright file="DeterministicSequence.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    public class DeterministicSequence : ISequence
    {
        private int _index;
        private double[] _numbers;
        private object lockObject = new object();
        
        public DeterministicSequence(params double[] numbers)
        {
            _numbers = numbers;
        }

        public double Next()
        {
            lock (lockObject)
            {
                var nextNumber = _numbers[_index++];

                if (_index > _numbers.Length - 1)
                {
                    _index = 0;
                }

                return nextNumber;
            }
        }
    }
}
