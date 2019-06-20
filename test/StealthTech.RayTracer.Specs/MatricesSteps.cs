//-----------------------------------------------------------------------
// <copyright file="MatricesSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs
{

    [Binding]
    public class MatricesSteps
    {
        private RtMatrix _matrix1;
        private RtMatrix _matrix2;
        readonly TuplesContext _tupleContext;

        public MatricesSteps(TuplesContext tupleContext)
        {
            _tupleContext = tupleContext;
        }

        [Given(@"the following (.*)x(.*) matrix M:")]
        public void GivenTheFollowingMatrixM(int rows, int columns, Table table)
        {
            _matrix1 = new RtMatrix(rows, columns);
            FillMatrix(table, _matrix1);
        }

        [Then(@"M\[(.*),(.*)] = (.*)")]
        public void ThenM(int row, int column, int expectedValue)
        {
            Assert.Equal(expectedValue, _matrix1[row, column]);
        }

        [Given(@"the following matrix A:")]
        public void GivenTheFollowingMatrixA(Table table)
        {
            _matrix1 = new RtMatrix(table.RowCount, table.Rows[0].Count);
            FillMatrix(table, _matrix1);
        }

        [Given(@"the following matrix B:")]
        public void GivenTheFollowingMatrixB(Table table)
        {
            _matrix2 = new RtMatrix(table.RowCount, table.Rows[0].Count);
            FillMatrix(table, _matrix2);
        }

        [Then(@"A = B")]
        public void Then_A_Equals_B()
        {
            Assert.Equal(_matrix1, _matrix2);
        }

        [Then(@"A != B")]
        public void Then_A_Not_Equal_B()
        {
            Assert.NotEqual(_matrix1, _matrix2);
        }

        [Then(@"A \* B is the following matrix:")]
        public void ThenABIsTheFollowingMatrix(Table table)
        {
            var expectedMatrix = new RtMatrix(table.RowCount, table.Rows[0].Count);
            FillMatrix(table, expectedMatrix);
            
            var actual = _matrix1 * _matrix2;

            Assert.Equal(expectedMatrix, actual);
        }

        [Then(@"A \* b = tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_A_multiplied_by_b_Equals_Tuple(double x, double y, double z, double w)
        {
            var expectedTuple = new RtTuple(x, y, z, w);
            var actual = _matrix1 * _tupleContext.Tuple2;

            Assert.Equal(expectedTuple, actual);
        }

        [Then(@"b \* A = tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_b_multiplied_by_A_Equals_Tuple(double x, double y, double z, double w)
        {
            var expectedTuple = new RtTuple(x, y, z, w);
            var actual = _tupleContext.Tuple2 * _matrix1;

            Assert.Equal(expectedTuple, actual);
        }

        private static void FillMatrix(Table table, RtMatrix matrix)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Rows[i].Count; j++)
                {
                    matrix[i, j] = Convert.ToDouble(table.Rows[i][j]);
                }
            }
        }
    }


}
