//-----------------------------------------------------------------------
// <copyright file="CubesSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.Specs.Contexts;
using System;
using TechTalk.SpecFlow;

namespace StealthTech.RayTracer.Specs.Steps
{
    [Binding]
    public class CubesSteps
    {
        readonly CubesContext _cubesContext;
        readonly IntersectionsContext _intersectionsContext;
        readonly RayContext _rayContext;
        readonly VectorsContext _vectorsContext;
        readonly PointsContext _pointsContext;

        public CubesSteps(CubesContext cubesContext, 
            IntersectionsContext intersectionsContext, 
            RayContext rayContext, 
            VectorsContext vectorsContext,
            PointsContext pointsContext)
        {
            _pointsContext = pointsContext;
            _vectorsContext = vectorsContext;
            _rayContext = rayContext;
            _intersectionsContext = intersectionsContext;
            _cubesContext = cubesContext;
        }

        [Given(@"cube ← Cube\(\)")]
        public void Given_cube_Is_Cube()
        {
            _cubesContext.Cubes[0] = new Cube();
        }

        [When(@"intersections ← cube\.LocalIntersect\(ray\)")]
        public void When_intersections_Is_The_Results_Of_Cube_LocalIntersect_ray()
        {
            _intersectionsContext.Intersections = _cubesContext.Cubes[0].LocalIntersect(_rayContext.Ray);
        }

        [When(@"normalVector ← cube\.LocalNormalAt\(point\)")]
        public void When_normal_Is_The_Results_Of_Cube_LocalNormalAt_point()
        {
            _vectorsContext.NormalVector = _cubesContext.Cubes[0].LocalNormalAt(_pointsContext.Point);
        }

    }
}
