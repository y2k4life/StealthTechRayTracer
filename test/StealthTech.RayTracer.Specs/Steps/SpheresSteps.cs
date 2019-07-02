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

        public SpheresSteps(SphereContext sphereContext,
            RayContext rayContext,
            IntersectionsContext intersectionsContext,
            MaterialsContext materialsContext,
            VectorsContext vectorsContext)
        {
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
            _sphereContext.Sphere1 = CreateSphereFromTableWith(table);
        }

        [Given(@"sphere2 ← sphere\(\) with:")]
        public void Given_s2_Is_A_Sphere_With(Table table)
        {
            _sphereContext.Sphere2 = CreateSphereFromTableWith(table);
        }

        [Given(@"sphere ← Sphere\(\) with:")]
        public void Given_sphere_Is_A_Sphere_With(Table table)
        {
            _sphereContext.Sphere = CreateSphereFromTableWith(table);
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
    }
}
