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

        public IntersectionsSteps(IntersectionsContext intersectionsContext, SphereContext sphereContext)
        {
            _intersectionsContext = intersectionsContext;
            _sphereContext = sphereContext;
        }

        [When(@"i ← intersection\((.*), s\)")]
        public void When_i_Is_Intersection_of_Sphere(double time)
        {
            _intersectionsContext.Intersection = new Intersection(time, _sphereContext.Sphere);
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


    }
}
