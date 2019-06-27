//-----------------------------------------------------------------------
// <copyright file="IntersectionsSteps.cs" company="StealthTech">
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
    public class IntersectionsSteps
    {
        private readonly SphereContext _sphereContext;
        readonly IntersectionsContext _intersectionsContext;
        readonly WorldContext _worldContext;
        readonly RayContext _rayContext;

        public IntersectionsSteps(IntersectionsContext intersectionsContext, 
            SphereContext sphereContext, 
            WorldContext worldContext,
            RayContext rayContext)
        {
            _rayContext = rayContext;
            _worldContext = worldContext;
            _intersectionsContext = intersectionsContext;
            _sphereContext = sphereContext;
        }

        [When(@"i ← intersection\((.*), s\)")]
        public void When_i_Is_Intersection_of_Sphere(double time)
        {
            _intersectionsContext.Intersection = new Intersection(time, _sphereContext.Sphere);
        }

        [Given(@"i ← intersection\((.*), s2\)")]
        public void Given_i_Is_Intersection_of_Sphere2(double time)
        {
            _intersectionsContext.Intersection1 = new Intersection(time, _sphereContext.Sphere2);
        }

        [Then(@"i\.Time = (.*)")]
        public void Then_i_Time_Equals(Double expectedTime)
        {
            AssertDouble.ApproximateEquals(expectedTime, _intersectionsContext.Intersection.Time);
        }

        [Then(@"i\.Item = s")]
        public void Then_i_Item_Equals_s()
        {
            Assert.Equal(_sphereContext.Sphere, _intersectionsContext.Intersection.Shape);
        }

        [Given(@"i1 ← intersection\((.*), s\)")]
        public void Given_i1_Is_Intersection_Of_s(double time)
        {
            _intersectionsContext.Intersection1 = new Intersection(time, _sphereContext.Sphere);
        }

        [Given(@"i2 ← intersection\((.*), s\)")]
        public void Given_i2_Is_Intersection_Of_s(double time)
        {
            _intersectionsContext.Intersection2 = new Intersection(time, _sphereContext.Sphere);
        }

        [Given(@"i3 ← intersection\((.*), s\)")]
        public void Given_i3_Is_Intersection_Of_s(double time)
        {
            _intersectionsContext.Intersection3 = new Intersection(time, _sphereContext.Sphere);
        }

        [Given(@"i4 ← intersection\((.*), s\)")]
        public void Given_i4_Is_Intersection_Of_s(double time)
        {
            _intersectionsContext.Intersection4 = new Intersection(time, _sphereContext.Sphere);
        }

        [When(@"xs ← intersections\(i1, i2\)")]
        public void When_xs_Is_Intersections_i1_and_i2()
        {
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection1);
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection2);
        }

        [Given(@"xs ← intersections\(i1, i2\)")]
        public void Given_xs_Is_Intersections_i1_and_i2()
        {
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection1);
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection2);
        }

        [Given(@"xs ← intersections\(i1, i2, i3\)")]
        public void Given_xs_Is_Intersections_i1_and_i2_and_i3()
        {
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection1);
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection2);
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection3);
        }

        [Given(@"xs ← intersections\(i1, i2, i3, i4\)")]
        public void Given_xs_Is_Intersections_i1_and_i2_and_i3_and_i4()
        {
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection1);
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection2);
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection3);
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection4);
        }

        [Then(@"xs\[(.*)]\.Time = (.*)")]
        public void Then_xs_Time(int index, double expectedTime)
        {
            Assert.Equal(_intersectionsContext.Intersections[index].Time, expectedTime);
        }

        [Then(@"xs\.count = (.*)")]
        public void Then_xs_Count_Equals(int expectedCount)
        {
            Assert.Equal(expectedCount, _intersectionsContext.Intersections.Count);
        }

        [Then(@"xs\[(.*)]\.Item = s")]
        public void Then_xs_Item_Equals_s(int index)
        {
            Assert.Equal(_sphereContext.Sphere, _intersectionsContext.Intersections[index].Shape);
        }

        [When(@"i ← hit\(xs\)")]
        public void When_i_Is_Hit_Of_xs()
        {
            _intersectionsContext.Hit = _intersectionsContext.Intersections.Hit();
        }

        [Then(@"i = i1")]
        public void Then_i_Equals_i1()
        {
            Assert.Equal(_intersectionsContext.Intersection1, _intersectionsContext.Hit);
        }

        [Then(@"i = i2")]
        public void Then_i_Equals_i2()
        {
            Assert.Equal(_intersectionsContext.Intersection2, _intersectionsContext.Hit);
        }

        [Then(@"i = i4")]
        public void Then_i_Equals_i4()
        {
            Assert.Equal(_intersectionsContext.Intersection4, _intersectionsContext.Hit);
        }

        [Then(@"i is nothing")]
        public void Then_i_Equals_Nothing()
        {
            Assert.Null(_intersectionsContext.Hit);
        }

        [When(@"xs ← intersect_world\(w, r\)")]
        public void When_xs_Intersect_World_w_With_R()
        {
            _intersectionsContext.Intersections = _worldContext.World.Intersect(_rayContext.Ray);
        }

        [When(@"comps ← prepare_computations\(i, r\)")]
        public void When_Comps_Is_Intersections_Prepare_Computations_For_r()
        {
            _intersectionsContext.Computations = _intersectionsContext.Intersection1.PrepareComputations(_rayContext.Ray);
        }

        [Then(@"comps\.Time = i\.Time")]
        public void Then_comps_Time_Equals_i_Time()
        {
            var expectedTime = _intersectionsContext.Intersection1.Time;

            var actualTime = _intersectionsContext.Computations.Time;

            Assert.Equal(expectedTime, actualTime);
        }

        [Then(@"comps\.Shape = i\.Shape")]
        public void Then_comps_Shape_Equals_i_Shape()
        {
            var expectedTime = _intersectionsContext.Intersection1.Shape;

            var actualTime = _intersectionsContext.Computations.Shape;

            Assert.Equal(expectedTime, actualTime);
        }

        [Then(@"comps\.point = point\((.*), (.*), (.*)\)")]
        public void ThenComps_PointPoint(double x, double y, double z)
        {
            var expectedPoint = new RtPoint(x, y, z);

            var actualPoint = _intersectionsContext.Computations.Point;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"comps\.eyev = vector\((.*), (.*), (.*)\)")]
        public void Then_comps_EyeVector_Equals_Vector(double x, double y, double z)
        {
            var expectedPoint = new RtVector(x, y, z);

            var actualPoint = _intersectionsContext.Computations.EyeVector;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"comps\.normalv = vector\((.*), (.*), (.*)\)")]
        public void Then_comps_NormalVector_Equals_Vector(double x, double y, double z)
        {
            var expectedPoint = new RtVector(x, y, z);

            var actualPoint = _intersectionsContext.Computations.NormalVector;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"comps\.inside = false")]
        public void Then_comps_Inside_Equals_False()
        {
            var actualInside = _intersectionsContext.Computations.Inside;

            Assert.False(actualInside);
        }

        [Then(@"comps\.inside = true")]
        public void Then_comps_Inside_Equals_True()
        {
            var actualInside = _intersectionsContext.Computations.Inside;

            Assert.True(actualInside);
        }

        [Then(@"comps\.over_point\.z < -EPSILON/2")]
        public void Then_Comps_Over_Point_Z_Less_Than_EPSILON()
        {
            Assert.True(_intersectionsContext.Computations.OverPoint.Z < (-DoubleExtensions.EPSILON / 2.0));
        }

        [Then(@"comps\.point\.z > comps\.over_point\.z")]
        public void Then_Comps_Point_ZComps_Over_Point_Z()
        {
            Assert.True(_intersectionsContext.Computations.Point.Z > _intersectionsContext.Computations.OverPoint.Z);
        }

    }
}
