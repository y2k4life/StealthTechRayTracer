//-----------------------------------------------------------------------
// <copyright file="ShapesSteps.cs" company="StealthTech">
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
    public class ShapesSteps
    {
        readonly IntersectionsContext _intersectionsContext;
        readonly MaterialsContext _materialsContext;
        readonly RayContext _rayContext;
        readonly ShapesContext _shapesContext;
        readonly VectorsContext _vectorsContext;
        readonly TransformationsContext _transformationsContext;

        public ShapesSteps(ShapesContext shapesContext, 
            MaterialsContext materialsContext, 
            RayContext rayContext, 
            IntersectionsContext intersectionsContext,
            VectorsContext vectorsContext,
            TransformationsContext transformationsContext)
        {
            _transformationsContext = transformationsContext;
            _vectorsContext = vectorsContext;
            _intersectionsContext = intersectionsContext;
            _rayContext = rayContext;
            _materialsContext = materialsContext;
            _shapesContext = shapesContext;
        }

        [Given(@"testShape ← TestShape\(\)")]
        public void Given_shape_Is_Test_Shape()
        {
            _shapesContext.TestShape = new TestShape();
        }

        [When(@"material ← testShape\.material")]
        public void When_material_Is_Material_Of_TestShape()
        {
            _materialsContext.Material = _shapesContext.TestShape.Material;
        }

        [When(@"shape\.Material ← m")]
        public void When_s_Material_Is_m()
        {
            _shapesContext.TestShape.Material = _materialsContext.Material;
        }

        [When(@"set_transform\(s, scaling\((.*), (.*), (.*)\)\)")]
        public void When_Set_Transform_s_To_Scaling(double x, double y, double z)
        {
            _shapesContext.TestShape.Transform = new Transform().Scaling(x, y, z);
        }

        [When(@"testShape\.Transform ← Translation\((.*), (.*), (.*)\)")]
        public void When_Transform_Of_testShape_Is_Translation(double x, double y, double z)
        {
            _shapesContext.TestShape.Transform = new Transform().Translation(x, y, z);
        }

        [When(@"testShape\.Transform ← transformation")]
        public void When_Transform_Of_testShape_Is_transformation()
        {
            _shapesContext.TestShape.Transform = _transformationsContext.Transform;
        }

        [When(@"xs ← intersect\(s, r\)")]
        public void When_xs_Intersect_r()
        {
            var intersections = _shapesContext.TestShape.Intersect(_rayContext.Ray);
            if (intersections != null && intersections.HasHit())
            {
                _intersectionsContext.Intersections.AddRange(intersections);
            }
        }   
                
        [When(@"normalVector ← normal_at\(s, point\((.*), √2/2, -√2/2\)")]
        public void When_normalVector_Is_Normal_At(double x)
        {
            _vectorsContext.Normal = _shapesContext.TestShape.NormalAt(new RtPoint(x, Math.Sqrt(2) / 2 , Math.Sqrt(2) / 2), null);
        }

        [When(@"normalVector ← testShape.NormalAt\(Point\((.*), (.*), (.*)\)\)")]
        public void When_normalVector_Is_NormalAt_Of_testShape(string x, string y, string z)
        {
            _vectorsContext.Normal = _shapesContext.TestShape.NormalAt(new RtPoint(x.EvaluateExpression(),
                                                                                 y.EvaluateExpression(),
                                                                                 z.EvaluateExpression()), null);
        }

        [Then(@"shape\.Material = m")]
        public void Then_Material_Of_Shape_Should_Equal_material()
        {
            var expectedMaterial = _materialsContext.Material;

            var actualMaterial = _shapesContext.TestShape.Material;

            Assert.Equal(expectedMaterial, actualMaterial);
        }

        [Then(@"shape\.SavedRay\.Direction = Vector\((.*), (.*), (.*)\)")]
        public void Then_Direction_Of_SavedRay_Of_shape_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedOrigin = new RtVector(x, y, z);

            var actualOrigin = _shapesContext.TestShape.SavedRay.Direction;

            Assert.Equal(expectedOrigin, actualOrigin);
        }

        [Then(@"shape\.SavedRay\.Origin = Point\((.*), (.*), (.*)\)")]
        public void Then_Origin_Of_SavedRay_Of_shape_Should_Equal_Point(double x, double y, double z)
        {
            var expectedOrigin = new RtPoint(x, y, z);

            var actualOrigin = _shapesContext.TestShape.SavedRay.Origin;

            Assert.Equal(expectedOrigin, actualOrigin);
        }

        [Then(@"testShape\.Transform = identityMatrix")]
        public void Then_Transform_Of_testShape_Equals_Identity_Matrix()
        {
            Assert.True(_shapesContext.TestShape.Transform.Equals(RtMatrix.Identity));
        }

        [Then(@"testShape\.Transform = Translation\((.*), (.*), (.*)\)")]
        public void Then_Transform_Of_testShape_Should_Equals_Translation(double x, double y, double z)
        {
            var expectedTransform = new Transform().Translation(x, y, z);

            var acutalTransform = _shapesContext.TestShape.Transform;

            Assert.Equal(expectedTransform, acutalTransform);
        }

        [Then(@"shape\.Parent is nothing")]
        public void Then_Parent_shape_Is_Nothing()
        {
            Assert.Null(_shapesContext.TestShape.Parent);
        }


    }
}
