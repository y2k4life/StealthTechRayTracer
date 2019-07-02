//-----------------------------------------------------------------------
// <copyright file="IntersectionsSteps.cs" company="StealthTech">
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
    public class IntersectionsSteps
    {
        readonly IntersectionsContext _intersectionsContext;
        readonly RayContext _rayContext;
        private readonly SphereContext _sphereContext;
        readonly WorldContext _worldContext;
        readonly PlanesContext _planesContext;

        public IntersectionsSteps(IntersectionsContext intersectionsContext,
            SphereContext sphereContext,
            WorldContext worldContext,
            RayContext rayContext,
            PlanesContext planesContext)
        {
            _planesContext = planesContext;
            _rayContext = rayContext;
            _worldContext = worldContext;
            _intersectionsContext = intersectionsContext;
            _sphereContext = sphereContext;
        }

        [Given(@"intersection ← Intersection\((.*), sphere2\)")]
        public void Given_i_Is_Intersection_of_Sphere2(double time)
        {
            _intersectionsContext.Intersection = new Intersection(time, _sphereContext.Sphere2);
        }

        [Given(@"intersection1 ← Intersection\((.*), sphere\)")]
        public void Given_intersection1_Is_Intersection(double time)
        {
            _intersectionsContext.Intersection1 = new Intersection(time, _sphereContext.Sphere);
        }

        [Given(@"intersection2 ← Intersection\((.*), sphere\)")]
        public void Given_intersection2_Is_Intersection(double time)
        {
            _intersectionsContext.Intersection2 = new Intersection(time, _sphereContext.Sphere);
        }

        [Given(@"intersection3 ← Intersection\((.*), sphere\)")]
        public void Given_intersection3_Is_Intersection(double time)
        {
            _intersectionsContext.Intersection3 = new Intersection(time, _sphereContext.Sphere);
        }

        [Given(@"intersection4 ← Intersection\((.*), s\)")]
        public void Given_intersection4_Is_Intersection(double time)
        {
            _intersectionsContext.Intersection4 = new Intersection(time, _sphereContext.Sphere);
        }

        [Given(@"intersection ← Intersection\((.*), sphere\)")]
        public void Given_intersections_Is_IntersectionList(double time)
        {
            _intersectionsContext.Intersection = new Intersection(time, _sphereContext.Sphere);
        }

        [Given(@"intersections ← IntersectionList\(i1, i2\)")]
        public void Given_intersections_Is_IntersectionList_With_i1_i2()
        {
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection1);
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection2);
        }

        [Given(@"intersections ← IntersectionList\(i1, i2, i3, i4\)")]
        public void Given_intersections_Is_IntersectionList_With_i1_i2_i3_i4()
        {
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection1);
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection2);
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection3);
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection4);
        }

        [Then(@"computations\.EyeVector = Vector\((.*), (.*), (.*)\)")]
        public void Then_EyeVector_Of_computations_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedPoint = new RtVector(x, y, z);

            var actualPoint = _intersectionsContext.Computations.EyeVector;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"intersection = intersection1")]
        public void Then_i_Equals_i1()
        {
            Assert.Equal(_intersectionsContext.Intersection1, _intersectionsContext.Hit);
        }

        [Then(@"intersection = intersection2")]
        public void Then_i_Equals_i2()
        {
            Assert.Equal(_intersectionsContext.Intersection2, _intersectionsContext.Hit);
        }

        [Then(@"intersection = i4")]
        public void Then_i_Equals_i4()
        {
            Assert.Equal(_intersectionsContext.Intersection4, _intersectionsContext.Hit);
        }

        [Then(@"intersection is nothing")]
        public void Then_i_Equals_Nothing()
        {
            Assert.Null(_intersectionsContext.Hit);
        }

        [Then(@"computations\.Inside = false")]
        public void Then_Inside_computations_Should_Equal_False()
        {
            var actualInside = _intersectionsContext.Computations.Inside;

            Assert.False(actualInside);
        }

        [Then(@"computations\.Inside = true")]
        public void Then_Inside_Of_computations_Should_Equal_True()
        {
            var actualInside = _intersectionsContext.Computations.Inside;

            Assert.True(actualInside);
        }

        [Then(@"computations\.NormalVector = Vector\((.*), (.*), (.*)\)")]
        public void Then_NormalVector_Of_computations_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedPoint = new RtVector(x, y, z);

            var actualPoint = _intersectionsContext.Computations.NormalVector;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"computations\.Point = Point\((.*), (.*), (.*)\)")]
        public void Then_Point_of_computations_Should_Equal_Point(double x, double y, double z)
        {
            var expectedPoint = new RtPoint(x, y, z);

            var actualPoint = _intersectionsContext.Computations.Point;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"computations\.Shape = intersection\.Shape")]
        public void Then_Shape_Of_computations_Should_Equal()
        {
            var expectedTime = _intersectionsContext.Intersection.Shape;

            var actualTime = _intersectionsContext.Computations.Shape;

            Assert.Equal(expectedTime, actualTime);
        }

        [Then(@"intersection\.Shape = s")]
        public void Then_Shape_Of_intersection_Equals_s()
        {
            Assert.Equal(_sphereContext.Sphere, _intersectionsContext.Intersection.Shape);
        }

        [Then(@"computations\.Time = intersection\.Time")]
        public void Then_Time_Of_computations_Should_Equal()
        {
            var expectedTime = _intersectionsContext.Intersection.Time;

            var actualTime = _intersectionsContext.Computations.Time;

            Assert.Equal(expectedTime, actualTime);
        }

        [Then(@"intersection\.Time = (.*)")]
        public void Then_Time_Of_intersection_Equals(Double expectedTime)
        {
            AssertDouble.ApproximateEquals(expectedTime, _intersectionsContext.Intersection.Time);
        }

        [Then(@"intersections\.Count = (.*)")]
        public void Then_xs_Count_Equals(int expectedCount)
        {
            Assert.Equal(expectedCount, _intersectionsContext.Intersections.Count);
        }

        [Then(@"intersections\[(.*)]\.Item = s")]
        public void Then_xs_Item_Equals_s(int index)
        {
            Assert.Equal(_sphereContext.Sphere, _intersectionsContext.Intersections[index].Shape);
        }

        [Then(@"intersections\[(.*)]\.Shape = plane")]
        public void Then_The_Shape_Of_intersections_At_index_Should_Equal_plane(int index)
        {
            var expectedPlane = _planesContext.Plane;

            var actualPlane = _intersectionsContext.Intersections[index].Shape;

            Assert.Equal(expectedPlane, actualPlane);
        }

        [Then(@"intersections\[(.*)]\.Time = (.*)")]
        public void Then_xs_Time(int index, double expectedTime)
        {
            Assert.Equal(_intersectionsContext.Intersections[index].Time, expectedTime);
        }

        [Then(@"computations\.OverPoint\.Z < -EPSILON/2")]
        public void Then_Z_Of_OverPoint_Of_computations_Should_Be_Less_Than_EPSILON()
        {
            Assert.True(_intersectionsContext.Computations.OverPoint.Z < (-DoubleExtensions.EPSILON / 2.0));
        }

        [Then(@"computations\.Point\.Z > computations\.OverPoint\.Z")]
        public void Then_Z_Point_Of_computations_Should_Equals_Z_Of_OverPoint_Of_computations()
        {
            Assert.True(_intersectionsContext.Computations.Point.Z > _intersectionsContext.Computations.OverPoint.Z);
        }

        [When(@"computations ← prepare_computations\(i, r\)")]
        public void When_computations_Is_Intersections_prepare_computations()
        {
            _intersectionsContext.Computations = _intersectionsContext.Intersection.PrepareComputations(_rayContext.Ray);
        }

        [When(@"intersection ← hit\(intersections\)")]
        public void When_i_Is_Hit_Of_xs()
        {
            _intersectionsContext.Hit = _intersectionsContext.Intersections.Hit();
        }

        [When(@"intersection ← Intersection\((.*), s\)")]
        public void When_i_Is_Intersection_of_Sphere(double time)
        {
            _intersectionsContext.Intersection = new Intersection(time, _sphereContext.Sphere);
        }

        [When(@"intersections ← intersect_world\(w, r\)")]
        public void When_intersections_Is_intersect_world()
        {
            _intersectionsContext.Intersections = _worldContext.World.Intersect(_rayContext.Ray);
        }

        [When(@"intersections ← IntersectionList\(i1, i2\)")]
        public void When_intersections_Is_IntersectionList()
        {
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection1);
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection2);
        }

        [Then(@"intersections is empty")]
        public void Then_intersections_Is_Empty()
        {
            Assert.True(_intersectionsContext.Intersections.IsEmpty);
        }



    }
}
