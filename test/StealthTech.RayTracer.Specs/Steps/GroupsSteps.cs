//-----------------------------------------------------------------------
// <copyright file="GroupsSteps.cs" company="StealthTech">
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
    public class ShapeGroupsSteps
    {
        readonly ShapeGroupsContext _shapeGroupsContext;
        readonly ShapesContext _shapesContext;
        readonly RayContext _rayContext;
        readonly IntersectionsContext _intersectionsContext;
        readonly SphereContext _sphereContext;

        public ShapeGroupsSteps(ShapeGroupsContext shapeGroupsContext, 
            ShapesContext shapesContext, 
            RayContext rayContext,
            IntersectionsContext intersectionsContext,
            SphereContext sphereContext)
        {
            _sphereContext = sphereContext;
            _intersectionsContext = intersectionsContext;
            _rayContext = rayContext;
            _shapesContext = shapesContext;
            _shapeGroupsContext = shapeGroupsContext;
        }

        [Given(@"shapeGroup ← ShapeGroup\(\)")]
        public void Given_shapeGroup_Is_ShapeGroup()
        {
            _shapeGroupsContext.ShapeGroup = new ShapeGroup();
        }

        [Given(@"shapeGroup(.*) ← Group\(\)")]
        public void Given_shapeGroupN_is_Group(int groupIndex)
        {
            _shapeGroupsContext.ShapeGroups[groupIndex] = new ShapeGroup();
        }

        [Given(@"shapeGroup\.AddChild\(sphere(.*)\)")]
        public void Given_AddChild_Of_shapeGroup_With_sphereN(int sphereIndex)
        {
            _shapeGroupsContext.ShapeGroup.AddChild(_sphereContext.Spheres[sphereIndex]);
        }

        [Given(@"shapeGroup\.AddChild\(sphere\)")]
        public void Given_AddChild_Of_shapeGroup_With_sphere()
        {
            _shapeGroupsContext.ShapeGroup.AddChild(_sphereContext.Sphere);
        }

        [Given(@"shapeGroup\.Transform ← scaling\((.*), (.*), (.*)\)")]
        public void Given_Transform_Of_shapeGroup_Is_Scaling(double x, double y, double z)
        {
            _shapeGroupsContext.ShapeGroup.Transform = new Transform()
                .Scaling(x, y, z);
        }

        [Given(@"shapeGroup(.*)\.Transform ← RotationY\(π/2\)")]
        public void Given_Transform_Of_shapeGroupN_Is_RotationY(int groupIndex)
        {
            _shapeGroupsContext.ShapeGroups[groupIndex].Transform = new Transform()
                .RotateY(Math.PI / 2);
        }

        [Given(@"shapeGroup(.*)\.Transform ← Scaling\((.*), (.*), (.*)\)")]
        public void Given_Transform_Of_shapeGroupN_Is_Scaling(int groupIndex, double x, double y, double z)
        {
            _shapeGroupsContext.ShapeGroups[groupIndex].Transform = new Transform()
                .Scaling(x, y, z);
        }

        [Given(@"shapeGroup(.*)\.AddChild\(shapeGroup(.*)\)")]
        public void Given_AddChild_Of_shapeGroupN_With_shapeGroupN(int fristGroupIndex, int secondGroupIndex)
        {
            _shapeGroupsContext.ShapeGroups[fristGroupIndex].AddChild(_shapeGroupsContext.ShapeGroups[secondGroupIndex]);
        }

        [Given(@"shapeGroup(.*)\.AddChild\(sphere\)")]
        public void GivenShapeGroup_AddChildSphere(int groupIndex)
        {
            _shapeGroupsContext.ShapeGroups[groupIndex].AddChild(_sphereContext.Sphere);
        }


        [When(@"intersections ← shapeGroup\.Intersect\(ray\)")]
        public void WhenIntersectionsShapeGroup_IntersectRay()
        {
            _intersectionsContext.Intersections = _shapeGroupsContext.ShapeGroup.Intersect(_rayContext.Ray);
        }

        [When(@"shapeGroup\.AddChild\(testShape\)")]
        public void WhenShapeGroup_AddChildShape()
        {
            _shapeGroupsContext.ShapeGroup.AddChild(_shapesContext.TestShape);
        }

        [When(@"intersections ← shapeGroup\.LocalIntersect\(ray\)")]
        public void When_intersections_LocalIntersect_Of_ShapeGroup_For_Ray()
        {
            _intersectionsContext.Intersections = _shapeGroupsContext.ShapeGroup.LocalIntersect(_rayContext.Ray);
        }

        [Then(@"shapeGroup\.Transform = IdentityMatrix")]
        public void Then_Transform_of_shapeGroup_Should_Be_IdentityMatrix()
        {
            Assert.True(_shapeGroupsContext.ShapeGroup.Transform.Equals(RtMatrix.Identity));
        }
        
        [Then(@"shapeGroup is empty")]
        public void Then_shapeGroup_Is_Empty()
        {
            Assert.Empty(_shapeGroupsContext.ShapeGroup.Shapes);
        }

        [Then(@"shapeGroup is not empty")]
        public void Then_ShapeGroup_Is_Not_Empty()
        {
            Assert.NotEmpty(_shapeGroupsContext.ShapeGroup.Shapes);
        }

        [Then(@"shapeGroup includes testShape")]
        public void Then_shapeGroup_Includes_shape()
        {
            Assert.Contains(_shapesContext.TestShape, _shapeGroupsContext.ShapeGroup.Shapes);
        }

        [Then(@"testShape\.Parent = shapeGroup")]
        public void Then_Parent_Of_shape_Is_shapeGroup()
        {
            Assert.Equal(_shapeGroupsContext.ShapeGroup, _shapesContext.TestShape.Parent);
        }


    }
}
