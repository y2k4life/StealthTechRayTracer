//-----------------------------------------------------------------------
// <copyright file="SpheresSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs
{
    [Binding]
    public class SpheresSteps
    {
        private readonly RayContext _rayContext;
        readonly SphereContext _sphereContext;
        readonly IntersectionsContext _intersectionsContext;

        public SpheresSteps(SphereContext sphereContext, RayContext rayContext, IntersectionsContext intersectionsContext)
        {
            _intersectionsContext = intersectionsContext;
            _sphereContext = sphereContext;
            _rayContext = rayContext;
        }

        [Given(@"s ← sphere\(\)")]
        public void Given_s_Sphere()
        {
            _sphereContext.Sphere = new Sphere();
        }

        [When(@"xs ← intersect\(s, r\)")]
        public void When_xs_Intersect_r()
        {
            _intersectionsContext.Intersections.AddRange(_sphereContext.Sphere.Intersect(_rayContext.Ray));
        }

        [Then(@"s\.transform = identity_matrix")]
        public void Then_s_Transform_Equals_Identity_Matrix()
        {
            Assert.Equal(new RtMatrix(4, 4).Identity(), _sphereContext.Sphere.Transform.Matrix);
        }

        [Given(@"t ← translation\((.*), (.*), (.*)\)")]
        public void GivenTTranslation(double x, double y, double z)
        {
            _sphereContext.Transform = new Transform().Translation(x, y, z);
        }

        [When(@"set_transform\(s, t\)")]
        public void When_Set_Transform_t()
        {
            _sphereContext.Sphere.Transform = _sphereContext.Transform;
        }

        [Then(@"s\.transform = t")]
        public void Then_s_Transform_Equals_t()
        {
            Assert.Equal(_sphereContext.Transform, _sphereContext.Sphere.Transform);
        }

        [When(@"set_transform\(s, scaling\((.*), (.*), (.*)\)\)")]
        public void When_Set_Transform_s_To_Scaling(double x, double y, double z)
        {
            _sphereContext.Sphere.Transform = new Transform().Scaling(x, y, z);
        }

        [When(@"set_transform\(s, translation\((.*), (.*), (.*)\)\)")]
        public void When_Set_Transform_s_To_Translation(double x, double y, double z)
        {
            _sphereContext.Sphere.Transform = new Transform().Translation(x, y, z);
        }
    }
}
