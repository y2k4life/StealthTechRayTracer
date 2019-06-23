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
        private RtMatrix _matrix3;
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

        [Then(@"The identity of A is:")]
        public void ThenTheIdentityOfAIs(Table table)
        {
            var expectedMatrix = new RtMatrix(table.RowCount, table.Rows[0].Count);
            FillMatrix(table, expectedMatrix);

            var identity = _matrix1.Identity();
            Assert.Equal(expectedMatrix, identity);
        }

        [Then(@"A \* identity_matrix = A")]
        public void ThenAIdentity_MatrixA()
        {
            var identity = _matrix1.Identity();

            var actual = _matrix1 * identity;

            Assert.Equal(_matrix1, actual);
        }

        [Then(@"identity_matrix \* a = a")]
        public void Then_Identity_Matrix_A_Multiplied_By_Tuple_a_equals_a()
        {
            var actual = _matrix1 * _tupleContext.Tuple;

            Assert.Equal(_tupleContext.Tuple, actual);
        }

        [Then(@"transpose\(A\) is the following matrix:")]
        public void Then_Transpose_A_Is_The_Following_Matrix(Table table)
        {
            var expectedMatrix = new RtMatrix(table.RowCount, table.Rows[0].Count);
            FillMatrix(table, expectedMatrix);

            var actual = _matrix1.Transpose();

            Assert.Equal(expectedMatrix, actual);
        }

        [Then(@"determinant\(A\) = (.*)")]
        public void Then_Determinant_Of_A(int expectedDeterminant)
        {
            var actualDeterminant = _matrix1.Determinant();

            Assert.Equal(expectedDeterminant, actualDeterminant);
        }

        [Then(@"submatrix\(A, (.*), (.*)\) is the following matrix:")]
        public void Then_The_Submatrix_Of_A_Is_The_Following_Matrix(int row, int column, Table table)
        {
            RtMatrix expectedMatrix = GetExpected(table);

            RtMatrix actual = _matrix1.Remove(row, column);

            Assert.Equal(expectedMatrix, actual);
        }

        [Given(@"B ← submatrix\(A, (.*), (.*)\)")]
        public void GivenB_SubmatrixA(int row, int column)
        {
            _matrix2 = _matrix1.Remove(row, column);
        }

        [Then(@"determinant\(B\) = (.*)")]
        public void Then_The_Determinant_Of_B(int expectedDeterminant)
        {
            var actualDeterminante = _matrix2.Determinant();

            Assert.Equal(expectedDeterminant, actualDeterminante);
        }

        [Then(@"minor\(A, (.*), (.*)\) = (.*)")]
        public void Then_The_Minor_Of_A(int row, int column, int expectedMinor)
        {
            var actualMinor = _matrix1.Minor(row, column);

            Assert.Equal(expectedMinor, actualMinor);
        }

        [Then(@"cofactor\(A, (.*), (.*)\) = (.*)")]
        public void Then_The_Cofactor_Of_A_Row_Column_Is(int row, int column, int expectedCofactor)
        {
            var actualCofactor = _matrix1.Cofactor(row, column);

            Assert.Equal(expectedCofactor, actualCofactor);
        }

        [Then(@"A is invertible")]
        public void Then_A_IsInvertible()
        {
            var actualIsInvertible = _matrix1.IsInvertible();

            Assert.True(actualIsInvertible);
        }

        [Then(@"A is not invertible")]
        public void Then_A_Is_Not_Invertible()
        {
            var actualIsInvertible = _matrix1.IsInvertible();

            Assert.False(actualIsInvertible);
        }

        [Given(@"B ← inverse\(A\)")]
        public void Given_B_Inverse_A()
        {
            _matrix2 = _matrix1.Inverse();
        }

        [Then(@"B\[(.*),(.*)] = (.*)/(.*)")]
        public void ThenB(int row, int column, double numerator, double denominator)
        {
            var expectedValue = numerator / denominator;

            var actualValue = _matrix2[row, column];

            AssertDouble.ApproximateEquals(expectedValue, actualValue);
        }

        [Then(@"B is the following matrix:")]
        public void ThenBIsTheFollowingMatrix(Table table)
        {
            var expectedMatrix = GetExpected(table);

            Assert.Equal(expectedMatrix, _matrix2);
        }

        [Then(@"inverse\(A\) is the following matrix:")]
        public void Then_The_Inverse_A_Is_The_Following_Matrix(Table table)
        {
            var expectedMatrix = GetExpected(table);

            var actualMatrix = _matrix1.Inverse();

            Assert.Equal(expectedMatrix, actualMatrix);

        }

        [Given(@"C ← A \* B")]
        public void Given_C_Equals_A_Multiplied_By_B()
        {
            _matrix3 = _matrix1 * _matrix2;
        }

        [Then(@"C \* inverse\(B\) = A")]
        public void Then_C_Equals_Inverse_Of_B_Multiplied_By_A()
        {
            var inverseOfB = _matrix2.Inverse();

            var actualResults = _matrix3 * inverseOfB;

            Assert.Equal(_matrix1, actualResults);
        }

        private static RtMatrix GetExpected(Table table)
        {
            var expectedMatrix = new RtMatrix(table.RowCount, table.Rows[0].Count);
            FillMatrix(table, expectedMatrix);
            return expectedMatrix;
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
