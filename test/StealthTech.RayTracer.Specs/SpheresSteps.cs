//-----------------------------------------------------------------------
// <copyright file="SpheresSteps.cs" company="StealthTech">
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
    public class SpheresSteps
    {
        private readonly RayContext _rayContext;
        readonly SphereContext _sphereContext;
        readonly IntersectionsContext _intersectionsContext;
        readonly MaterialsContext _materialsContext;

        public SpheresSteps(SphereContext sphereContext, 
            RayContext rayContext, 
            IntersectionsContext intersectionsContext, 
            MaterialsContext materialsContext)
        {
            _materialsContext = materialsContext;
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

        [When(@"n ← normal_at\(s, point\((.*), (.*), (.*)\)\)")]
        public void When_n_Normal_At_Point(string x, string y, string z)
        {
            var point = RtTuple.Point(ConvertCoordinate(x), ConvertCoordinate(y), ConvertCoordinate(z));
            _sphereContext.Normal = _sphereContext.Sphere.NormalAt(point);
        }

        [Then(@"n = vector\((.*), (.*), (.*)\)")]
        public void Then_n_Equals_Vector(string x, string y, string z)
        {
            var expectedVector = RtTuple.Vector(ConvertCoordinate(x), ConvertCoordinate(y), ConvertCoordinate(z));

            Assert.Equal(expectedVector, _sphereContext.Normal);
        }

        [Then(@"n = normalize\(n\)")]
        public void Then_n_Equals_Normalize_n()
        {
            Assert.Equal(_sphereContext.Normal, _sphereContext.Normal.Normalized());
        }
               
        [Given(@"t ← scaling\((.*), (.*), (.*)\) and rotation_z\(π/(.*)\)")]
        public void GivenMScaling(double x, double y, double z, double r)
        {
            _sphereContext.Transform = new Transform()
                .Scaling(x, y, z)
                .RotateZ(r);

        }

        [Given(@"set_transform\(s, translation\((.*), (.*), (.*)\)\)")]
        public void GivenSet_TransformSTranslation(double x, double y, double z)
        {
            _sphereContext.Sphere.Transform = new Transform().Translation(x, y, z);
        }

        [Given(@"set_transform\(s, t\)")]
        public void GivenSet_TransformST()
        {
            _sphereContext.Sphere.Transform = _sphereContext.Transform;
        }

        [When(@"m ← s\.material")]
        public void WhenMS_Material()
        {
            _materialsContext.Material = _sphereContext.Sphere.Material;
        }

        [Then(@"m = material\(\)")]
        public void Then_m_Equals_Material()
        {
            var expectedMaterial = new Material();

            Assert.Equal(expectedMaterial, _materialsContext.Material);
        }

        [Given(@"m\.ambient ← (.*)")]
        public void Given_m_Ambient(double ambient)
        {
            _materialsContext.Material.Ambient = ambient;
        }

        [When(@"s\.material ← m")]
        public void When_s_Material_Is_m()
        {
            _sphereContext.Sphere.Material = _materialsContext.Material;
        }

        [Then(@"s\.material = m")]
        public void Then_s_Material_Equals_m()
        {
            Assert.Equal(_materialsContext.Material, _sphereContext.Sphere.Material);
        }



        private double ConvertCoordinate(string coordiante)
        {
            if (coordiante.Length == 5)
            {
                return (Math.Sqrt(3) / 3) * -1;
            }
            else if (coordiante.Length == 4)
            {
                return (Math.Sqrt(3) / 3);
            }

            return Convert.ToDouble(coordiante);
        }

    }
}
