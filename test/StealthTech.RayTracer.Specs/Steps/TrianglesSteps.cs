//-----------------------------------------------------------------------
// <copyright file="TrianglesSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.Specs.Contexts;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs.Steps
{
    [Binding]
    public class TrianglesSteps
    {
        readonly TrianglesContext _triangesContext;
        readonly PointsContext _pointsContext;
        readonly VectorsContext _vectorsContext;
        readonly RayContext _rayContext;
        readonly IntersectionsContext _intersectionsContext;

        public TrianglesSteps(TrianglesContext triangesContext,
            PointsContext pointsContext,
            VectorsContext vectorsContext,
            RayContext rayContext,
            IntersectionsContext intersectionsContext)
        {
            _intersectionsContext = intersectionsContext;
            _rayContext = rayContext;
            _vectorsContext = vectorsContext;
            _pointsContext = pointsContext;
            _triangesContext = triangesContext;
        }

        [Given(@"triangle ← Triangle\(point(.*), point(.*), point(.*)\)")]
        public void Given_triangle_Is_Triangle(int firstPointIndex, int secondPointIndex, int thirdPointIndex)
        {
            _triangesContext.Triangle = new Triangle(
                _pointsContext.Points[firstPointIndex],
                _pointsContext.Points[secondPointIndex],
                _pointsContext.Points[thirdPointIndex]);
        }

        [Given(@"triangle ← Triangle\(Point\((.*), (.*), (.*)\), Point\((.*), (.*), (.*)\), Point\((.*), (.*), (.*)\)\)")]
        public void Given_triangle_Is_Triangle(double p1x, double p1y, double p1z, double p2x, double p2y, double p2z, double p3x, double p3y, double p3z)
        {
            _triangesContext.Triangle = new Triangle(
                new RtPoint(p1x, p1y, p1z),
                new RtPoint(p2x, p2y, p2z),
                new RtPoint(p3x, p3y, p3z));
        }

        [When(@"normal(.*) ← triangle\.LocalNormalAt\(Point\((.*), (.*), (.*)\)\)")]
        public void When_normalN_Is_LocalNormalAt_Of_triangle(int indexOfNormal, double x, double y, double z)
        {
            _vectorsContext.Normals[indexOfNormal] = _triangesContext.Triangle.LocalNormalAt(new RtPoint(x, y, z), null);
        }

        [When(@"intersections ← triangle\.LocalIntersect\(ray\)")]
        public void When_intersections_Is_LocalIntersect_Of_triangle()
        {
            _intersectionsContext.Intersections = _triangesContext.Triangle.LocalIntersect(_rayContext.Ray);
        }

        [Then(@"triangle\.Point1 = point(.*)")]
        public void Then_Point1_Of_Triangle_Should_Equal_PointN(int pointIndex)
        {
            Assert.Equal(_pointsContext.Points[pointIndex], _triangesContext.Triangle.Point1);
        }

        [Then(@"triangle\.Point2 = point(.*)")]
        public void Then_Point2_Of_Triangle_Should_Equal_PointN(int pointIndex)
        {
            Assert.Equal(_pointsContext.Points[pointIndex], _triangesContext.Triangle.Point2);
        }

        [Then(@"triangle\.Point3 = point(.*)")]
        public void Then_Point3_Of_Triangle_Should_Equal_PointN(int pointIndex)
        {
            Assert.Equal(_pointsContext.Points[pointIndex], _triangesContext.Triangle.Point3);
        }

        [Then(@"triangle\.Edge1 = Vector\((.*), (.*), (.*)\)")]
        public void Then_Edge1_Of_Triangle_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            Assert.Equal(expectedVector, _triangesContext.Triangle.Edge1);
        }

        [Then(@"triangle\.Edge2 = Vector\((.*), (.*), (.*)\)")]
        public void Then_Edge2_Of_Triangle_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            Assert.Equal(expectedVector, _triangesContext.Triangle.Edge2);
        }

        [Then(@"triangle\.Normal = Vector\((.*), (.*), (.*)\)")]
        public void Then_Normal_Of_Triangle_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            Assert.Equal(expectedVector, _triangesContext.Triangle.Normal);
        }

        [Then(@"normal(.*) = triangle\.Normal")]
        public void Then_normalN_Should_Equal_Normal_Of_Triangle(int indexOfNormal)
        {
            Assert.Equal(_triangesContext.Triangle.Normal, _vectorsContext.Normals[indexOfNormal]);
        }
    }
}
