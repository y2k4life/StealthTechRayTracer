//-----------------------------------------------------------------------
// <copyright file="CylindersSteps.cs" company="StealthTech">
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
    public class CylindersSteps
    {
        readonly CylindersContext _cylindersContext;
        readonly IntersectionsContext _intersectionsContext;
        readonly RayContext _rayContext;
        readonly VectorsContext _vectorsContext;

        public CylindersSteps(CylindersContext cylindersContext,
            IntersectionsContext intersectionsContext,
            RayContext rayContext,
            VectorsContext vectorsContext)
        {
            _vectorsContext = vectorsContext;
            _rayContext = rayContext;
            _intersectionsContext = intersectionsContext;
            _cylindersContext = cylindersContext;
        }

        [Given(@"cylinder ← cylinder\(\)")]
        public void Given_cylinder_Is_Cylinder()
        {
            _cylindersContext.Cylinder = new Cylinder();
        }

        [Given(@"cylinder\.Minimum ← (.*)")]
        public void Given_Minimum_Of_Cylinder_Is(double minimum)
        {
            _cylindersContext.Cylinder.Minimum = minimum;
        }

        [Given(@"cylinder\.Maximum ← (.*)")]
        public void Given_Maximum_Of_Cylinder_Is(double maximum)
        {
            _cylindersContext.Cylinder.Maximum = maximum;
        }

        [Given(@"cylinder\.IsClosed ← true")]
        public void Given_IsClosed_Of_Cylinder_Is_True()
        {
            _cylindersContext.Cylinder.IsClosed = true;
        }

        [When(@"normalVector ← cylinder\.LocalNormalAt\(Point\((.*), (.*), (.*)\)\)")]
        public void When_normalVector_Is_LocalNormalAt_Of_Cylinder(double x, double y, double z)
        {
            _vectorsContext.Normal = _cylindersContext.Cylinder.LocalNormalAt(new RtPoint(x, y, z), null);
        }

        [When(@"intersections ← cylinder\.LocalIntersect\(ray\)")]
        public void When_intersections_Is_LocalIntersect_Of_Cylinder_With_Given_Ray()
        {
            _intersectionsContext.Intersections = _cylindersContext.Cylinder.LocalIntersect(_rayContext.Ray);
        }

        [Then(@"cylinder\.Minimum = -infinity")]
        public void ThenCylinder_Minimum_Infinity()
        {
            AssertDouble.Equals(double.NegativeInfinity, _cylindersContext.Cylinder.Minimum);
        }

        [Then(@"cylinder\.Maximum = infinity")]
        public void ThenCylinder_MaximumInfinity()
        {
            AssertDouble.Equals(double.PositiveInfinity, _cylindersContext.Cylinder.Maximum);
        }

        [Then(@"cylinder\.IsClosed = false")]
        public void Then_Closed_Of_Cylinder_Is_false()
        {
            Assert.False(_cylindersContext.Cylinder.IsClosed);
        }
    }
}
