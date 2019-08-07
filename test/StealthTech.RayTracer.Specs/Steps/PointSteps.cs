//-----------------------------------------------------------------------
// <copyright file="PointSteps.cs" company="StealthTech">
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
    public class PointSteps
    {
        readonly PointsContext _pointsContext;
        readonly VectorsContext _vectorContext;

        public PointSteps(PointsContext pointContext, VectorsContext vectorContext)
        {
            _vectorContext = vectorContext;
            _pointsContext = pointContext;
        }

        [Given(@"point ← Point\((.*), (.*), (.*)\)")]
        public void Given_p_Is_Point(float x, float y, float z)
        {
            _pointsContext.Point = new RtPoint(x, y, z);
        }

        [Given(@"point(.*) ← Point\((.*), (.*), (.*)\)")]
        public void Given_pointN_Is_Point(int pointIndex, float x, float y, float z)
        {
            _pointsContext.Points[pointIndex] = new RtPoint(x, y, z);
        }

        [Given(@"position ← Point\((.*), (.*), (.*)\)")]
        public void Given_Position_Point(float x, float y, float z)
        {
            _pointsContext.Position = new RtPoint(x, y, z);
        }

        [Given(@"origin ← Point\((.*), (.*), (.*)\)")]
        public void Given_Origin_As_Point(float x, float y, float z)
        {
            _pointsContext.Origin = new RtPoint(x, y, z);
        }

        [Given(@"from ← Point\((.*), (.*), (.*)\)")]
        public void Given_from_Is_Point(float x, float y, float z)
        {
            _pointsContext.From = new RtPoint(x, y, z);
        }

        [Given(@"to ← Point\((.*), (.*), (.*)\)")]
        public void Given_to_Is_Point(float x, float y, float z)
        {
            _pointsContext.To = new RtPoint(x, y, z);
        }

        [Given(@"light_position ← Point\((.*), (.*), (.*)\)")]
        public void Given_light_position_Is_Point(float x, float y, float z)
        {
            _pointsContext.LightPosition = new RtPoint(x, y, z);
        }

        [Given(@"corner ← Point\((.*), (.*), (.*)\)")]
        public void Given_corner_Is_Point(float x, float y, float z)
        {
            _pointsContext.Corner = new RtPoint(x, y, z);
        }

        [Given(@"eye ← Point\((.*), (.*), (.*)\)")]
        public void Given_Eye_Is_Point(double x, double y, double z)
        {
            _pointsContext.Eye = new RtPoint(x, y, z);
        }

        [Then(@"point(.*) - point(.*) = Vector\((.*), (.*), (.*)\)")]
        public void Then_point1_Minus_point2_Should_Equal_Vector(int firstPointIndex, int secondPointIndex, float x, float y, float z)
        {
            var expectedVector = new RtVector(x, y, z);

            var actualVector = _pointsContext.Points[firstPointIndex] - _pointsContext.Points[secondPointIndex];

            Assert.Equal(expectedVector, actualVector);
        }

        [Then(@"point = tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_point_Should_Equal_Tuple(float x, float y, float z, float w)
        {
            var expectedTuple = new RtTuple(x, y, z, w);
            var actualTuple = _pointsContext.Point;

            var resutls = expectedTuple.Equals(actualTuple);

            Assert.True(resutls);
        }

        [Then(@"point - vector = Point\((.*), (.*), (.*)\)")]
        public void Then_point_Minus_vector_Should_Equal_Point(float x, float y, float z)
        {
            var expectedTuple = new RtPoint(x, y, z);

            RtPoint actualPoint = _pointsContext.Point - _vectorContext.Vector;

            Assert.Equal(expectedTuple, actualPoint);
        }

        [Then(@"point(.*) = Point\((.*), (.*), (.*)\)")]
        public void Then_pointN_Equals_Point(int pointIndex, string x, string y, string z)
        {
            var expectedPoint = new RtPoint(x.EvaluateExpression(), y.EvaluateExpression(), z.EvaluateExpression());

            Assert.Equal(expectedPoint, _pointsContext.Points[pointIndex]);
        }

        [Then(@"point = Point\((.*), (.*), (.*)\)")]
        public void Then_point_Equals_Point(float x, float y, float z)
        {
            var expectedPoint = new RtPoint(x, y, z);

            Assert.Equal(expectedPoint, _pointsContext.Point);
        }

    }
}
