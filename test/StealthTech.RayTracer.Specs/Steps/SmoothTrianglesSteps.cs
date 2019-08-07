//-----------------------------------------------------------------------
// <copyright file="SmoothTrianglesSteps.cs" company="StealthTech">
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
    public class SmoothTrianglesSteps
    {
        readonly TrianglesContext _trianglesContext;
        readonly VectorsContext _vectorsContext;
        readonly PointsContext _pointsContext;
        readonly IntersectionsContext _intersectionsContext;

        public SmoothTrianglesSteps(TrianglesContext trianglesContext, 
            VectorsContext vectorsContext, 
            PointsContext pointsContext, 
            IntersectionsContext intersectionsContext)
        {
            _intersectionsContext = intersectionsContext;
            _pointsContext = pointsContext;
            _vectorsContext = vectorsContext;
            _trianglesContext = trianglesContext;
        }

        [When(@"triangle ← Triangle\(point1, point2, point3, normal1, normal2, normal3\)")]
        public void When_triangle_Is_Triangle()
        {
            _trianglesContext.Triangle = new Triangle(
                _pointsContext.Points[1],
                _pointsContext.Points[2],
                _pointsContext.Points[3],
                _vectorsContext.Normals[1],
                _vectorsContext.Normals[2],
                _vectorsContext.Normals[3]);
        }

        [When(@"intersection ← intersection\((.*), triangle, (.*), (.*)\)")]
        public void When_intersection_Is_Intersection(double time, double u, double v)
        {
            _intersectionsContext.Intersection = new Intersection(time, _trianglesContext.Triangle, u, v);
        }

        [When(@"normal ← triangle\.NormalAt\(Point\((.*), (.*), (.*)\), intersection\)")]
        public void When_normal_Is_NormalAt_Of_triangle(double x, double y, double z)
        {
            _vectorsContext.Normal = _trianglesContext.Triangle.NormalAt(new RtPoint(x, y, z), _intersectionsContext.Intersection);
        }

        [Then(@"triangle\.Normal1 = normal(.*)")]
        public void Then_Normal1_Of_Triangle_Should_Equal_normalN(int indexOfNormal)
        {
            Assert.Equal(_vectorsContext.Normals[indexOfNormal], _trianglesContext.Triangle.Normal1);
        }

        [Then(@"triangle\.Normal2 = normal(.*)")]
        public void Then_Normal2_Of_Triangle_Should_Equal_normalN(int indexOfNormal)
        {
            Assert.Equal(_vectorsContext.Normals[indexOfNormal], _trianglesContext.Triangle.Normal2);
        }

        [Then(@"triangle\.Normal3 = normal(.*)")]
        public void Then_Normal3_Of_Triangle_Should_Equal_normalN(int indexOfNormal)
        {
            Assert.Equal(_vectorsContext.Normals[indexOfNormal], _trianglesContext.Triangle.Normal3);
        }
    }
}
