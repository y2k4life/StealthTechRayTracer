//-----------------------------------------------------------------------
// <copyright file="SpheresSteps.cs" company="StealthTech">
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
    public class SpheresSteps
    {
        private readonly RayContext _rayContext;
        readonly SphereContext _sphereContext;
        readonly IntersectionsContext _intersectionsContext;
        readonly MaterialsContext _materialsContext;
        readonly VectorsContext _vectorsContext;
        readonly ComputationsContext _computationsContext;
        readonly WorldContext _worldContext;

        public SpheresSteps(SphereContext sphereContext,
            RayContext rayContext,
            IntersectionsContext intersectionsContext,
            MaterialsContext materialsContext,
            VectorsContext vectorsContext,
            ComputationsContext computationsContext,
            WorldContext worldContext)
        {
            _worldContext = worldContext;
            _computationsContext = computationsContext;
            _vectorsContext = vectorsContext;
            _materialsContext = materialsContext;
            _intersectionsContext = intersectionsContext;
            _sphereContext = sphereContext;
            _rayContext = rayContext;
        }

        [Given(@"sphere ← Sphere\(\)")]
        public void Given_sphere_Is_A_Sphere()
        {
            _sphereContext.Sphere = new Sphere();
        }

        [Given(@"sphere1 ← sphere\(\) with:")]
        public void GivenSSphereWith(Table table)
        {
            _sphereContext.Sphere1 = new Sphere();
            table.SetShapePropertiesFromTable(_sphereContext.Sphere1);
        }

        [Given(@"sphere2 ← sphere\(\) with:")]
        public void Given_s2_Is_A_Sphere_With(Table table)
        {
            _sphereContext.Sphere2 = new Sphere();
            table.SetShapePropertiesFromTable(_sphereContext.Sphere2);
        }

        [Given(@"sphere ← Sphere\(\) with:")]
        public void Given_sphere_Is_A_Sphere_With(Table table)
        {
            _sphereContext.Sphere = new Sphere();
            table.SetShapePropertiesFromTable(_sphereContext.Sphere);
        }

        [Given(@"sphere\.Transform ← scaling\((.*), (.*), (.*)\)")]
        public void Given_Transform_Of_sphere_Is_Scaling(double x, double y, double z)
        {
            _sphereContext.Sphere.Transform = new Transform().Scaling(x, y, z);
        }

        [Given(@"sphere\.Material\.Ambient ← (.*)")]
        public void Given_Ambient_Of_Material_Of_sphere_Is(double ambient)
        {
            _sphereContext.Sphere.Material.Ambient = ambient;
        }


        [Given(@"sphere ← GlassSphere\(\)")]
        public void Given_sphere_Is_GlassSphere()
        {
            _sphereContext.Sphere = new GlassSphere();
        }

        [Given(@"sphere(.*) ← GlassSphere\(\) with:")]
        public void Given_sphere_Is_GlassSphere_With(int index, Table table)
        {
            var sphere = new GlassSphere();
            sphere.Name = index.ToString();
            table.SetShapePropertiesFromTable(sphere);
            _sphereContext.Spheres[index] = sphere;
        }

        [Given(@"sphere ← GlassSphere\(\) with:")]
        public void Given_sphere_Is_GlassSphere_With(Table table)
        {
            var sphere = new GlassSphere();
            table.SetShapePropertiesFromTable(sphere);
            _sphereContext.Sphere = sphere;
        }


        [Given(@"sphere(.*) has:")]
        public void GivenSphereHas(int index, Table table)
        {
            _sphereContext.Spheres[index].Name = index.ToString();
            table.SetShapePropertiesFromTable(_sphereContext.Spheres[index]);
        }

        [Given(@"sphere(.*) ← GlassSphere\(\)")]
        public void Given_sphere_Is_GlassSphere(int index)
        {
            _sphereContext.Spheres[index] = new GlassSphere();
        }


        [When(@"intersections ← intersect\(sphere, r\)")]
        public void When_xs_Is_Intersect_r()
        {
            _intersectionsContext.Intersections = _sphereContext.Sphere.LocalIntersect(_rayContext.Ray);
        }

        [When(@"normalVector ← normal_at\(sphere, Point\((.*), (.*), (.*)\)\)")]
        public void When_normalVector_Is_Normal_At(string x, string y, string z)
        {
            _vectorsContext.NormalVector = _sphereContext.Sphere.LocalNormalAt(new RtPoint(x.EvaluateExpression(),
                                                                                 y.EvaluateExpression(),
                                                                                 z.EvaluateExpression()));
        }

        [Then(@"sphere\.Transform = identityMatrix")]
        public void Then_Transform_Of_sphere_Should_Equal_identityMatrix()
        {
            var expectedMatrix = new RtMatrix(4, 4).Identity();

            Assert.Equal(expectedMatrix, _sphereContext.Sphere.Transform.Matrix);
        }

        [Then(@"sphere\.Material\.Transparency = (.*)")]
        public void Then_Transparency_Of_Material_Of_Sphere_Should_Equal(double expectedTransparency)
        {
            Assert.Equal(expectedTransparency, _sphereContext.Sphere.Material.Transparency);
        }

        [Then(@"sphere\.Material\.RefractiveIndex = (.*)")]
        public void Then_RefractiveIndex_Of_Material_Of_Sphere_Should_Equal(double expectedRefractiveIndex)
        {
            Assert.Equal(expectedRefractiveIndex, _sphereContext.Sphere.Material.RefractiveIndex);
        }




    }
}
