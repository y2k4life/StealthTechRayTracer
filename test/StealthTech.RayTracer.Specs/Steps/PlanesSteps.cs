//-----------------------------------------------------------------------
// <copyright file="PlanesSteps.cs" company="StealthTech">
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
    public class PlanesSteps
    {
        private readonly PlanesContext _planesContext;
        readonly IntersectionsContext _intersectionsContext;
        readonly VectorsContext _vectorsContext;
        readonly RayContext _rayContext;

        public PlanesSteps(PlanesContext planesContext, 
            IntersectionsContext intersectionsContext, 
            VectorsContext vectorsContext,
            RayContext rayContext)
        {
            _rayContext = rayContext;
            _vectorsContext = vectorsContext;
            _intersectionsContext = intersectionsContext;
            _planesContext = planesContext;
        }

        [Given(@"plane ← Plane\(\)")]
        public void Given_plane_Is_A_Plane()
        {
            _planesContext.Plane = new Plane();
        }

        [Given(@"plane ← Plane\(\) with:")]
        public void Given_plane_Is_Plane_With(Table table)
        {
            _planesContext.Plane = new Plane();
            table.SetShapePropertiesFromTable(_planesContext.Plane);
        }

        [Given(@"upperPlane ← Plane\(\) with:")]
        public void Given_upperPlane_Is_Plane_With(Table table)
        {
            _planesContext.upperPlane = new Plane();
            table.SetShapePropertiesFromTable(_planesContext.upperPlane);
        }

        [Given(@"lowerPlane ← Plane\(\) with:")]
        public void Given_lowerPlane_Is_Plane_With(Table table)
        {
            _planesContext.lowerPlane = new Plane();
            table.SetShapePropertiesFromTable(_planesContext.lowerPlane);
        }

        [Given(@"floor ← Plane\(\) with:")]
        public void Given_floor_Is_Plane_With(Table table)
        {
            _planesContext.Floor = new Plane();
            table.SetShapePropertiesFromTable(_planesContext.Floor);
        }


        [When(@"normalVector1 ← plane\.LocalNormalAt\(point\((.*), (.*), (.*)\)\)")]
        public void When_normal1_Is_The_Results_Of_plane_LocalNormalAt(double x, double y, double z)
        {
            _vectorsContext.NormalVector1 = _planesContext.Plane.LocalNormalAt(new RtPoint(x, y, z));
        }

        [When(@"normalVector2 ← plane\.LocalNormalAt\(point\((.*), (.*), (.*)\)\)")]
        public void When_normal2_Is_The_Results_Of_plane_LocalNormalAt(double x, double y, double z)
        {
            _vectorsContext.NormalVector2 = _planesContext.Plane.LocalNormalAt(new RtPoint(x, y, z));
        }

        [When(@"normalVector3 ← plane\.LocalNormalAt\(point\((.*), (.*), (.*)\)\)")]
        public void When_normal3_Is_The_Results_Of_plane_LocalNormalAt(double x, double y, double z)
        {
            _vectorsContext.NormalVector3 = _planesContext.Plane.LocalNormalAt(new RtPoint(x, y, z));
        }

        [When(@"intersections ← plane\.LocalIntersect\(ray\)")]
        public void When_intersections_Is_The_Results_Of_plane_LocalIntersect_Of_ray()
        {
            _intersectionsContext.Intersections = _planesContext.Plane.LocalIntersect(_rayContext.Ray);
        }
    }
}
