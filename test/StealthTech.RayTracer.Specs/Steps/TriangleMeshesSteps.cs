//-----------------------------------------------------------------------
// <copyright file="TriangleMeshesSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.Specs.Contexts;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs.Steps
{
    [Binding]
    public class TriangleMeshesSteps
    {
        readonly TriangleMeshesContext _meshesContext;
        readonly PointsContext _pointsContext;
        readonly IntersectionsContext _intersectionsContext;
        readonly RayContext _rayContext;

        public TriangleMeshesSteps(TriangleMeshesContext meshesContext, 
            PointsContext pointsContext, 
            IntersectionsContext intersectionsContext,
            RayContext rayContext)
        {
            _rayContext = rayContext;
            _intersectionsContext = intersectionsContext;
            _pointsContext = pointsContext;
            _meshesContext = meshesContext;
        }

        [Given(@"triangleMesh ← TriangleMesh\(\)")]
        public void GivenTriangleMeshTriangleMesh()
        {
            _meshesContext.Mesh = new TriangleMesh();
        }

        [Given(@"triangleMesh\.AddVertex\(Point\((.*), (.*), (.*)\)\)")]
        public void Given_AddVertex_Of_TriangleMesh_With(double x, double y, double z)
        {
            _meshesContext.Mesh.AddVertex(new RtPoint(x, y, z));
        }

        [Given(@"triangleMesh\.AddVertex\(point(.*)\)")]
        public void Given_AddVertex_Of_TriangleMesh_With_PointN(int indexOfPoint)
        {
            _meshesContext.Mesh.AddVertex(_pointsContext.Points[indexOfPoint]);
        }

        [Given(@"triangleMesh\.AddTriangle\((.*), (.*), (.*)\)")]
        public void Given_TriangleMesh_AddTriangle(int v1, int v2, int v3)
        {
            _meshesContext.Mesh.AddTriangle(new TriangleGeometry() { Vertex1 = v1, Vertex2 = v2, Vertex3 = v3 });
        }

        [When(@"triangleMesh\.AddVertex\(point\)")]
        public void When_AddVertex_Of_triangleMesh()
        {
            _meshesContext.Mesh.AddVertex(_pointsContext.Point);
        }

        [When(@"triangleMesh\.AddTriangle\((.*), (.*), (.*)\)")]
        public void WhenTriangleMesh_AddTriangle(int v1, int v2, int v3)
        {
            _meshesContext.Mesh.AddTriangle(new TriangleGeometry() { Vertex1 = v1, Vertex2 = v2, Vertex3 = v3 });
        }

        [When(@"intersections ← triangleMesh\.LocalIntersect\(ray\)")]
        public void When_intersections_Is_LocalIntersect_Of_TriangleMesh()
        {
            _intersectionsContext.Intersections = _meshesContext.Mesh.LocalIntersect(_rayContext.Ray);
        }


        [Then(@"triangleMesh\.Transform = IdentityMatrix")]
        public void ThenTriangleMesh_TransformIdentityMatrix()
        {
            Assert.True(_meshesContext.Mesh.Transform.Equals(RtMatrix.Identity));
        }

        [Then(@"triangleMesh\.Vertices is empty")]
        public void Then_Vertices_Of_triangleMesh_Is_Empty()
        {
            Assert.Empty(_meshesContext.Mesh.Vertices);
        }

        [Then(@"triangleMesh\.Triangles is empty")]
        public void Then_Triangles_Of_triangleMesh_Is_Empty()
        {
            Assert.Empty(_meshesContext.Mesh.Triangles);
        }

        [Then(@"triangleMesh\.VertexCount = (.*)")]
        public void Then_VerticesCount_Of_TriangleMesh_Should_Equal(int verticesCount)
        {
            Assert.Equal(verticesCount, _meshesContext.Mesh.VertexCount);
        }

        [Then(@"triangleMesh includes point")]
        public void Then_triangleMesh_Should_Include_point()
        {
            Assert.Contains(_pointsContext.Point, _meshesContext.Mesh.Vertices);
        }

        [Then(@"triangleMesh\.TriangleCount = (.*)")]
        public void Then_TriangleCount_Of_TriangleMesh_Should_Equal(int triangleCount)
        {
            Assert.Equal(triangleCount, _meshesContext.Mesh.TriangleCount);
        }

        [Then(@"triangleMesh\.Triangle\[(.*)] should include point(.*)")]
        public void Then_Triangle_Of_TriangleMesh_Should_Include_Point(int indexOfTriangle, int indexOfPoint)
        {
            Assert.Contains(_pointsContext.Points[indexOfPoint], _meshesContext.Mesh.GetTriangleVertices(indexOfTriangle));
        }

    }
}
