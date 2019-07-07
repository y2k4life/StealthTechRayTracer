//-----------------------------------------------------------------------
// <copyright file="VectorsSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.Specs.Contexts;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs.Steps
{
    [Binding]
    public class VectorsSteps
    {
        readonly VectorsContext _vectorsContext;
        readonly ComputationsContext _computationsContext;

        public VectorsSteps(VectorsContext vectorContext, ComputationsContext computationsContext)
        {
            _computationsContext = computationsContext;
            _vectorsContext = vectorContext;
        }

        [Given(@"direction ← Vector\((.*), (.*), (.*)\)")]
        public void Given_direction_As_Vector(double x, double y, double z)
        {
            _vectorsContext.Director = new RtVector(x, y, z);
        }

        [Given(@"normalVector ← Vector\((.*), (.*), (.*)\)")]
        public void Given_normalVector_Is_Vector(double x, double y, double z)
        {
            _vectorsContext.NormalVector = new RtVector(x, y, z);
        }

        [Given(@"up ← Vector\((.*), (.*), (.*)\)")]
        public void Given_up_Is_A_Vector(double x, double y, double z)
        {
            _vectorsContext.Up = new RtVector(x, y, z);
        }

        [Given(@"vector ← Vector\((.*), (.*), (.*)\)")]
        public void Given_vector_Is_A_Vector(double x, double y, double z)
        {
            _vectorsContext.Vector = new RtVector(x, y, z);
        }

        [Given(@"vector1 ← Vector\((.*), (.*), (.*)\)")]
        public void Given_vector1_Is_A_Vector(double x, double y, double z)
        {
            _vectorsContext.Vector1 = new RtVector(x, y, z);
        }

        [Given(@"vector2 ← Vector\((.*), (.*), (.*)\)")]
        public void Given_vector2_Is_A_Vector(double x, double y, double z)
        {
            _vectorsContext.Vector2 = new RtVector(x, y, z);
        }

        [Given(@"zeroVector ← Vector\(0, 0, 0\)")]
        public void Given_zeroVector_Is_A_Vector()
        {
            _vectorsContext.ZeroVector = RtVector.ZeroVector;
        }

        [When(@"normalizedVector ← normalize\(v\)")]
        public void When_normalizedVector_Is_Normalize_Of_vector()
        {
            _vectorsContext.NormalizedVector = _vectorsContext.Vector.Normalize();
        }

        [When(@"reflect ← reflect\(v, n\)")]
        public void When_reflect_Is_Reflect_Of_normal()
        {
            _vectorsContext.Reflect = _vectorsContext.Vector.Reflect(_vectorsContext.NormalVector);
        }

        [Then(@"cross\(vector1, vector2\) = Vector\((.*), (.*), (.*)\)")]
        public void Then_Cross_vector1_With_vector2_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            var actualVector = _vectorsContext.Vector1.Cross(_vectorsContext.Vector2);

            Assert.Equal(expectedVector, actualVector);
        }

        [Then(@"cross\(vector2, vector1\) = Vector\((.*) (.*), (.*)\)")]
        public void Then_Cross_vector2_With_vector1_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            var actualVector = _vectorsContext.Vector2.Cross(_vectorsContext.Vector1);

            Assert.Equal(expectedVector, actualVector);
        }

        [Then(@"dot\(vector1, vector2\) = (.*)")]
        public void Then_Dot_vector1_with_vector2_Should_Equal(double expectedDot)
        {
            Assert.Equal(expectedDot, _vectorsContext.Vector1.Dot(_vectorsContext.Vector2));
        }

        [Then(@"magnitude\(normalizedVector\) = (.*)")]
        public void Then_Magnitude_Of_normalVector_Should_Equal(double expectedMagnitude)
        {
            var actualMagnitude = _vectorsContext.NormalizedVector.Magnitude();

            Assert.Equal(expectedMagnitude, actualMagnitude);
        }

        [Then(@"magnitude\(vector\) = (.*)")]
        public void Then_Magnitude_v_Should_Equal(double expectedMagnitude)
        {
            var actualMagnitude = _vectorsContext.Vector.Magnitude();
            AssertDouble.ApproximateEquals(expectedMagnitude, actualMagnitude);
        }

        [Then(@"normalize\(vector\) = approximately Vector\((.*), (.*), (.*)\)")]
        public void Then_Normalize_vector_Should_Approximately_Equal_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            var actual = _vectorsContext.Vector.Normalize();

            Assert.Equal(expectedVector, actual);
        }

        [Then(@"normalize\(vector\) = Vector\((.*), (.*), (.*)\)")]
        public void Then_Normalize_vector_Should_Equals_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            var actual = _vectorsContext.Vector.Normalize();

            Assert.Equal(expectedVector, actual);
        }

        [Then(@"reflect = Vector\((.*), (.*), (.*)\)")]
        public void Then_reflect_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            Assert.Equal(expectedVector, _vectorsContext.Reflect);
        }

        [Then(@"vector = Tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_vector_Should_Equal_Tuple(double x, double y, double z, double w)
        {
            var expectedTuple = new RtTuple(x, y, z, w);

            var actualeVector = _vectorsContext.Vector;

            var results = expectedTuple.Equals(actualeVector);

            Assert.True(results);
        }

        [Then(@"vector1 - vector2 = Vector\((.*), (.*), (.*)\)")]
        public void Then_vector1_minus_vector2_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            RtVector actualVector = _vectorsContext.Vector1 - _vectorsContext.Vector2;

            Assert.Equal(expectedVector, actualVector);
        }

        [Then(@"zeroVector - vector = Vector\((.*), (.*), (.*)\)")]
        public void Then_zeroVector_Minus_vector_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            var actualVector = _vectorsContext.ZeroVector - _vectorsContext.Vector;

            Assert.Equal(expectedVector, actualVector);
        }

        [Then(@"normalVector = Vector\((.*), (.*), (.*)\)")]
        public void Then_normalVector_Should_Equal_Vector(string x, string y, string z)
        {
            var expectedVector = new RtVector(x.EvaluateExpression(), y.EvaluateExpression(), z.EvaluateExpression());

            Assert.Equal(expectedVector, _vectorsContext.NormalVector);
        }

        [Then(@"normalVector = normalize\(normalVector\)")]
        public void Then_normalVector_Should_Equal_normalVector_Normalize()
        {
            var expectedVector = _vectorsContext.NormalVector.Normalize();

            Assert.Equal(expectedVector, _vectorsContext.NormalVector);
        }

        [Then(@"normal1 = Vector\((.*), (.*), (.*)\)")]
        public void Then_normaVector1_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            Assert.Equal(expectedVector, _vectorsContext.NormalVector1);
        }

        [Then(@"normal2 = Vector\((.*), (.*), (.*)\)")]
        public void Then_normaVector2_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            Assert.Equal(expectedVector, _vectorsContext.NormalVector2);
        }

        [Then(@"normal3 = Vector\((.*), (.*), (.*)\)")]
        public void Then_normaVector3_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            Assert.Equal(expectedVector, _vectorsContext.NormalVector3);
        }
    }
}
