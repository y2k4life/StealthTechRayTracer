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
using TechTalk.SpecFlow.Assist;

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
            var intersections = _sphereContext.Sphere.Intersect(_rayContext.Ray);
            if (intersections.HasHit)
            {
                _intersectionsContext.Intersections.AddRange(intersections);
            }
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
            var point = new RtPoint(ConvertCoordinate(x), ConvertCoordinate(y), ConvertCoordinate(z));
            _sphereContext.Normal = _sphereContext.Sphere.NormalAt(point);
        }

        [Then(@"n = vector\((.*), (.*), (.*)\)")]
        public void Then_n_Equals_Vector(string x, string y, string z)
        {
            var expectedVector = new RtVector(ConvertCoordinate(x), ConvertCoordinate(y), ConvertCoordinate(z));

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

        [Given(@"s1 ← sphere\(\) with:")]
        public void GivenSSphereWith(Table table)
        {
            _sphereContext.Sphere1 = CreateSphereFromTableWith(table);
        }

        [Given(@"s2 ← sphere\(\) with:")]
        public void Given_s2_Is_A_Sphere_With(Table table)
        {
            _sphereContext.Sphere2 = CreateSphereFromTableWith(table);
        }

        public Sphere CreateSphereFromTableWith(Table table)
        {
            var sphere = new Sphere();

            var properties = table.ToDictionary();
            foreach (var kv in properties)
            {
                var property = kv.Key;
                var subproperty = "";
                if (kv.Key.Contains('.'))
                {
                    property = kv.Key.Split('.')[0];
                    subproperty = kv.Key.Split('.')[1];
                }

                switch (property)
                {
                    case "material":
                        switch (subproperty)
                        {
                            case "color":
                                string[] colorValues = kv.Value
                                    .Replace('(', ' ')
                                    .Replace(')', ' ')
                                    .Split(',');
                                sphere.Material.Color = new RtColor(Convert.ToDouble(colorValues[0]), Convert.ToDouble(colorValues[1]), Convert.ToDouble(colorValues[2]));
                                break;
                            case "diffuse":
                                sphere.Material.Diffuse = Convert.ToDouble(kv.Value);
                                break;
                            case "specular":
                                sphere.Material.Specular = Convert.ToDouble(kv.Value);
                                break;
                        }
                        break;
                    case "transform":
                        string transform = kv.Value.Substring(0, kv.Value.IndexOf('('));
                        string[] values = kv.Value.Substring(kv.Value.IndexOf('(') + 1, kv.Value.Length - kv.Value.IndexOf('(') - 2).Split(',');
                        switch (transform)
                        {
                            case "scaling":
                                sphere.Transform *= new Transform().Scaling(Convert.ToDouble(values[0]), Convert.ToDouble(values[1]), Convert.ToDouble(values[2]));
                                break;
                            case "translation":
                                sphere.Transform *= new Transform().Translation(Convert.ToDouble(values[0]), Convert.ToDouble(values[1]), Convert.ToDouble(values[2]));
                                break;
                        }
                        break;
                }
            }

            return sphere;
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
