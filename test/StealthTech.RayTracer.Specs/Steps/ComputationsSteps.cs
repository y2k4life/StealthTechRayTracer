﻿//-----------------------------------------------------------------------
// <copyright file="ComputationsSteps.cs" company="StealthTech">
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
    public class ComputationsSteps
    {
        private readonly ComputationsContext _computationsContext;

        private readonly PointsContext _pointsContext;

        public ComputationsSteps(ComputationsContext computationsContext, PointsContext pointsContext)
        {
            _computationsContext = computationsContext;
            _pointsContext = pointsContext;
        }

        [Given(@"computations ← Computations\(\)")]
        public void GivenComputationsComputations()
        {
            _computationsContext.Computations = new Computations();
        }

        [Given(@"computations.NormalVector ← Vector\((.*), (.*), (.*)\)")]
        public void Given_normalVector_Is_A_Vector(float x, float y, float z)
        {
            _computationsContext.Computations.NormalVector = new RtVector(x, y, z);
        }

        [Given(@"computations.NormalVector ← Vector\(computations\.Position\.X, computations\.Position\.Y, computations\.Position\.Z\)")]
        public void Given_normalVector_Is_A_Vector_Of_Position()
        {
            _computationsContext.Computations.NormalVector = new RtVector(
                _computationsContext.Computations.Position.X,
                _computationsContext.Computations.Position.Y,
                _computationsContext.Computations.Position.Z);
        }

        [Given(@"computations.EyeVector ← Vector\((.*), (.*), (.*)\)")]
        public void Given_EyeVector_Of_computations_Is_Vector(string x, string y, string z)
        {
            _computationsContext.Computations.EyeVector = new RtVector(x.EvaluateExpression(), y.EvaluateExpression(), z.EvaluateExpression());
        }

        [Given(@"computations\.Shape = Sphere\(\)")]
        public void Given_Shape_Of_Computations_Is_Sphere()
        {
            _computationsContext.Computations.Shape = new Sphere();
        }

        [Given(@"computations\.Position ← Point\((.*), (.*), (.*)\)")]
        public void Given_Position_Of_Computations_Is_Point(float x, float y, float z)
        {
            _computationsContext.Computations.Position = new RtPoint(x, y, z);
        }

        [Given(@"computations\.EyeVector ← Normalize\(eye - pt\)")]
        public void Given_EyeVector_Of_Computations_Is_Normalize_Position_Subtract_Eye()
        {
            _computationsContext.Computations.EyeVector = (_pointsContext.Eye - _computationsContext.Computations.Position).Normalize();
        }


        [When(@"reflectance ← computations.Schlick\(\)")]
        public void When_reflectance_Is_The_Results_Of_computations_Schlick()
        {
            _computationsContext.Reflectance = _computationsContext.Computations.Schlick();
        }

        [Then(@"computations\.EyeVector = Vector\((.*), (.*), (.*)\)")]
        public void Then_EyeVector_Of_computations_Should_Equal_Vector(float x, float y, float z)
        {
            var expectedPoint = new RtVector(x, y, z);

            var actualPoint = _computationsContext.Computations.EyeVector;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"computations\.NormalVector = Vector\((.*), (.*), (.*)\)")]
        public void Then_NormalVector_Of_computations_Should_Equal_Vector(float x, float y, float z)
        {
            var expectedPoint = new RtVector(x, y, z);

            var actualPoint = _computationsContext.Computations.NormalVector;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"computations\.Position = Point\((.*), (.*), (.*)\)")]
        public void Then_Point_of_computations_Should_Equal_Point(float x, float y, float z)
        {
            var expectedPoint = new RtPoint(x, y, z);

            var actualPoint = _computationsContext.Computations.Position;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"reflectance = (.*)")]
        public void Then_reflectance_Should_Equal(float expectedReflectance)
        {
            AssertDouble.ApproximateEquals(expectedReflectance, _computationsContext.Reflectance);
        }
    }
}
