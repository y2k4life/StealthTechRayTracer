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
        readonly ComputationsContext _computationsContext;

        public IntersectionsSteps(IntersectionsContext intersectionsContext,
            SphereContext sphereContext,
            WorldContext worldContext,
            RayContext rayContext,
            PlanesContext planesContext,
            ComputationsContext computationsContext)
        {
            _computationsContext = computationsContext;
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

        [Given(@"intersections ← Add\((.*), sphere(.*)\)")]
        public void Given_intersections_Add_sphere(string time, int index)
        {
            _intersectionsContext.Intersections.Add(new Intersection(time.EvaluateExpression(), _sphereContext.Spheres[index]));
        }

        [Given(@"intersections ← Add\(intersection\)")]
        public void Given_intersections_Add_sphere()
        {
            _intersectionsContext.Intersections.Add(_intersectionsContext.Intersection);
        }

        [Given(@"intersection ← Intersection\((.*), plane\)")]
        public void Given_Intersection_Is_Intersection_With_time_And_plane(string time)
        {
            _intersectionsContext.Intersection = new Intersection(time.EvaluateExpression(), _planesContext.Plane);
        }

        [Given(@"intersections ← Add\((.*), floor\)")]
        public void GivenIntersectionsAddFloor(string time)
        {
            _intersectionsContext.Intersections.Add(new Intersection(time.EvaluateExpression(), _planesContext.Floor));
        }


        [When(@"computations ← intersection\.PrepareComputations\(ray\)")]
        public void When_computations_Is_PrepareComputations_Of_intersection()
        {
            _computationsContext.Computations = _intersectionsContext.Intersection.PrepareComputations(_rayContext.Ray, null);
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
            var actualInside = _computationsContext.Computations.Inside;

            Assert.False(actualInside);
        }

        [Then(@"computations\.Inside = true")]
        public void Then_Inside_Of_computations_Should_Equal_True()
        {
            var actualInside = _computationsContext.Computations.Inside;

            Assert.True(actualInside);
        }

        [Then(@"computations\.Shape = intersection\.Shape")]
        public void Then_Shape_Of_computations_Should_Equal()
        {
            var expectedTime = _intersectionsContext.Intersection.Shape;

            var actualTime = _computationsContext.Computations.Shape;

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

            var actualTime = _computationsContext.Computations.Time;

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
            AssertDouble.Equals(_intersectionsContext.Intersections[index].Time, expectedTime);
        }

        [Then(@"computations\.OverPoint\.Z < -EPSILON/2")]
        public void Then_Z_Of_OverPoint_Of_computations_Should_Be_Less_Than_EPSILON()
        {
            Assert.True(_computationsContext.Computations.OverPosition.Z < (-DoubleExtensions.EPSILON / 2.0));
        }

        [Then(@"computations\.Point\.Z > computations\.OverPoint\.Z")]
        public void Then_Z_Point_Of_computations_Should_Equals_Z_Of_OverPoint_Of_computations()
        {
            Assert.True(_computationsContext.Computations.Position.Z > _computationsContext.Computations.OverPosition.Z);
        }

        [Then(@"computations\.ReflectVector = Vector\((.*), (.*), (.*)\)")]
        public void Then_ReflectVector_Of_Computations_Should_Equal_Vector(string x, string y, string z)
        {
            var expectedVector = new RtVector(x.EvaluateExpression(), y.EvaluateExpression(), z.EvaluateExpression());

            var actualVector = _computationsContext.Computations.ReflectVector;

            Assert.Equal(expectedVector, actualVector);
        }

        [Then(@"intersections is empty")]
        public void Then_intersections_Is_Empty()
        {
            Assert.True(_intersectionsContext.Intersections.IsEmpty);
        }

        [When(@"computations ← intersections\[(.*)]\.PrepareComputations\(ray, intersections\)")]
        public void When_computations_Is_Results_Of_PrepareComputations_Of_Intersections(int index)
        {
            _computationsContext.Computations = _intersectionsContext.Intersections[index].PrepareComputations(_rayContext.Ray, _intersectionsContext.Intersections);
        }

        [When(@"computations ← intersections\.PrepareComputations\(ray, intersections\)")]
        public void When_computations_Is_Results_Of_PrepareComputations_Of_Intersections()
        {
            _computationsContext.Computations = _intersectionsContext.Intersection.PrepareComputations(_rayContext.Ray, _intersectionsContext.Intersections);
        }

        [Then(@"computations\.n1 = (.*)")]
        public void Then_n1_Of_Computations_Equals(double expectedValue)
        {
            Assert.Equal(expectedValue, _computationsContext.Computations.n1);
        }

        [Then(@"computations\.n2 = (.*)")]
        public void Then_n2_Of_Computations_Equals(double expectedValue)
        {
            Assert.Equal(expectedValue, _computationsContext.Computations.n2);
        }

        [Then(@"computations\.UnderPoint\.Z > EPSILON/2")]
        public void Then_UnderPoint_Z_Of_Computations_Greater_Than_EPSILON()
        {
            var greaterThan = _computationsContext.Computations.UnderPosition.Z > DoubleExtensions.EPSILON / 2;
            Assert.True(greaterThan);
        }

        [Then(@"computations\.Position\.Z < computations\.UnderPoint\.Z")]
        public void Then_Position_Z_Of_Computations_Should_Be_Less_Then_UnderPoint_Z_Computations()
        {
            bool lessThan = _computationsContext.Computations.Position.Z < _computationsContext.Computations.UnderPosition.Z;
            Assert.True(lessThan);
        }

        [Then(@"intersections\[(.*)]\.Shape = sphere(.*)")]
        public void Then_Shape_Of_IntersectionsN_Should_Be_shapeN(int intersectionIndex, int sphereIndex)
        {
            Assert.Equal(_sphereContext.Spheres[sphereIndex], _intersectionsContext.Intersections[intersectionIndex].Shape);
        }
    }
}
