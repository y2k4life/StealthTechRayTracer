//-----------------------------------------------------------------------
// <copyright file="RtMatrix.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public class RtMatrix : IEquatable<RtMatrix>
    {
        private readonly double[,] _matrix;

        public int RowCount { get; }

        public int ColumnCount { get; }

        public RtMatrix(int rows, int columns)
        {
            RowCount = rows;
            ColumnCount = columns;

            _matrix = new double[rows, columns];
        }

        public double this[int row, int column]
        {
            get
            {
                return _matrix[row, column];
            }
            set
            {
                _matrix[row, column] = value;
            }
        }

        public static RtMatrix operator *(RtMatrix left, RtMatrix right)
        {
            int leftRowCount = left.RowCount;
            int leftColumnCount = left.ColumnCount;

            int rightColumnCount = right.ColumnCount;

            var results = new RtMatrix(leftRowCount, rightColumnCount);

            double accumulator = 0;

            for (int li = 0; li < leftRowCount; li++)
            {
                for (int rj = 0; rj < rightColumnCount; rj++)
                {
                    for (int i1 = 0; i1 < leftColumnCount; i1++)
                    {
                        accumulator += left[li, i1] * right[i1, rj];
                    }

                    results[li, rj] = accumulator;
                    accumulator = 0;
                }
            }

            return results;
        }

        public static RtTuple operator *(RtMatrix left, RtTuple right)
        {
            var results = new double[4];

            double[] column = { right.X, right.Y, right.Z, right.W };

            for (int r = 0; r < left.RowCount; r++)
            {
                double accumulator = 0;
                for (int c = 0; c < 4; c++)
                {
                    accumulator += left[r, c] * column[c];
                }

                results[r] = accumulator;
            }

            return new RtTuple(results[0], results[1], results[2], results[3]);
        }

        public static RtTuple operator *(RtTuple left, RtMatrix right)
        {
            return right * left;
        }

        public override int GetHashCode()
        {
            return _matrix.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return Equals(obj as RtMatrix);
        }

        public bool Equals(RtMatrix other)
        {
            if (other is null)
            {
                return false;
            }

            if (_matrix.GetLength(0) != other._matrix.GetLength(0) || _matrix.GetLength(1) != other._matrix.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[i, j] != other[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
