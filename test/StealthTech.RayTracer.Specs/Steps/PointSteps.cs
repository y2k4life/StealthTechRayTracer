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

        [Given(@"point1 ← Point\((.*), (.*), (.*)\)")]
        public void Given_point1_Is_Point(float x, float y, float z)
        {
            _pointsContext.Point1 = new RtPoint(x, y, z);
        }

        [Given(@"point2 ← Point\((.*), (.*), (.*)\)")]
        public void Given_point2_Is_Point(float x, float y, float z)
        {
            _pointsContext.Point2 = new RtPoint(x, y, z);
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

        [Then(@"point1 - point2 = Vector\((.*), (.*), (.*)\)")]
        public void Then_point1_Minus_point2_Should_Equal_Vector(float x, float y, float z)
        {
            var expectedVector = new RtVector(x, y, z);

            var actualVector = _pointsContext.Point1 - _pointsContext.Point2;

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

        [Then(@"point2 = Point\((.*), (.*), (.*)\)")]
        public void Then_point2_Equals_Point(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(x.EvaluateExpression(), y.EvaluateExpression(), z.EvaluateExpression());

            Assert.Equal(expectedPoint, _pointsContext.Point2);
        }

        [Then(@"point3 = Point\((.*), (.*), (.*)\)")]
        public void Then_point3_Equals_Point(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(x.EvaluateExpression(), y.EvaluateExpression(), z.EvaluateExpression());

            Assert.Equal(expectedPoint, _pointsContext.Point3);
        }

        [Then(@"point4 = Point\((.*), (.*), (.*)\)")]
        public void Then_point4_Equals_Point(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(x.EvaluateExpression(), y.EvaluateExpression(), z.EvaluateExpression());

            Assert.Equal(expectedPoint, _pointsContext.Point4);
        }

        [Then(@"point = Point\((.*), (.*), (.*)\)")]
        public void Then_point_Equals_Point(float x, float y, float z)
        {
            var expectedPoint = new RtPoint(x, y, z);

            Assert.Equal(expectedPoint, _pointsContext.Point);
        }

    }
}
