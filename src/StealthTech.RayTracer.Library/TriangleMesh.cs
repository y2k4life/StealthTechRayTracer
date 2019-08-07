using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StealthTech.RayTracer.Library
{
    public class TriangleMesh : Shape
    {

        private readonly List<TriangleGeometry> _triangles = new List<TriangleGeometry>();

        private readonly List<RtPoint> _vertices = new List<RtPoint>();

        private readonly List<RtVector> _normals = new List<RtVector>();

        public TriangleMesh()
        {
        }

        private TriangleMesh(List<TriangleGeometry> triangles, List<RtVector> normals)
        {
            _triangles = triangles;
            _normals = normals;
        }

        public override IntersectionList LocalIntersect(Ray ray)
        {
            var intersections = new IntersectionList();

            foreach (var triangle in _triangles)
            {
                IntersectTrianle(triangle, intersections, ray);
            }

            return intersections;
        }

        public override RtVector LocalNormalAt(RtPoint point, Intersection hit)
        {
            throw new System.NotImplementedException();
        }

        public void AddVertex(double x, double y, double z)
        {
            _vertices.Add(new RtPoint(x, y, z));
        }

        public void AddVertex(RtPoint rtPoint)
        {
            _vertices.Add(rtPoint);
        }

        public void AddTriangle(int v1, int v2, int v3, string group = "Default")
        {
            _triangles.Add(new TriangleGeometry()
            {
                Vertex1 = v1,
                Vertex2 = v2,
                Vertex3 = v3,
                Group = group
            });
        }

        public void AddTriangle(TriangleGeometry vertexIndex)
        {
            _triangles.Add(vertexIndex);
        }

        public IEnumerable<RtPoint> GetTriangleVertices(int indexOfTriangle)
        {
            var triangle = _triangles[indexOfTriangle];
            return new RtPoint[] { _vertices[triangle.Vertex1 - 1], _vertices[triangle.Vertex2 - 1], _vertices[triangle.Vertex3 - 1] };
        }

        public IEnumerable<TriangleGeometry> Triangles => _triangles;

        public IEnumerable<RtPoint> Vertices => _vertices;

        public IEnumerable<RtVector> Normals => _normals;

        public RtPoint GetVertex(int indexOfVertex)
        {
            return _vertices[indexOfVertex - 1];
        }

        public RtVector GetNormal(int indexOfNormal)
        {
            return _normals[indexOfNormal - 1];
        }

        public int VertexCount => _vertices.Count;

        public int TriangleCount => _triangles.Count;

        private void IntersectTrianle(TriangleGeometry triangleGeometry, IntersectionList intersections, Ray ray)
        {
            var vertex1 = _vertices[triangleGeometry.Vertex1 - 1];
            var vertex2 = _vertices[triangleGeometry.Vertex2 - 1];
            var vertex3 = _vertices[triangleGeometry.Vertex3 - 1];

            var edge1 = vertex2 - vertex1;
            var edge2 = vertex3 - vertex1;

            var directionCrossEdge2 = ray.Direction.Cross(edge2);
            var determinant = edge1.Dot(directionCrossEdge2);

            if (Math.Abs(determinant) < DoubleExtensions.EPSILON)
            {
                return;
            }

            var f = 1.0 / determinant;
            var point1ToOrigin = ray.Origin - vertex1;
            var u = f * point1ToOrigin.Dot(directionCrossEdge2);
            if (u < 0 || u > 1)
            {
                return;
            }

            var originCrossEdge1 = point1ToOrigin.Cross(edge1);
            var v = f * ray.Direction.Dot(originCrossEdge1);
            if (v < 0 || (u + v) > 1)
            {
                return;
            }


            var t = f * edge2.Dot(originCrossEdge1);

            Triangle triangle;
            if (_normals.Count > 0)
            {
                var normal1 = _normals[triangleGeometry.Normal1 - 1];
                var normal2 = _normals[triangleGeometry.Normal2 - 1];
                var normal3 = _normals[triangleGeometry.Normal3 - 1];

                triangle = new Triangle(vertex1, vertex2, vertex3, normal1, normal2, normal3);
            }
            else
            {
                triangle = new Triangle(vertex1, vertex2, vertex3);
            }

            triangle.Parent = this;
            triangle.InheritMaterial = true;

            var intersection = new Intersection
            {
                Shape = triangle,
                Time = t,
                U = u,
                V = v
            };

            intersections.Add(intersection);
        }

        public Triangle GetTriangle(int indexOfTraingle)
        {
            var traingleVertices = _triangles[indexOfTraingle - 1];
            var vertex1 = _vertices[traingleVertices.Vertex1 - 1];
            var vertex2 = _vertices[traingleVertices.Vertex2 - 1];
            var vertex3 = _vertices[traingleVertices.Vertex3 - 1];

            var triangle = new Triangle(vertex1, vertex2, vertex3)
            {
                Parent = this,
                InheritMaterial = true
            };

            return triangle;
        }

        public IEnumerable<Triangle> GetTrianglesForGroup(string groupName)
        {
            var triangles = new List<Triangle>();

            foreach (var triangleGeometry in _triangles.Where(g => g.Group == groupName).ToList())
            {
                var vertex1 = _vertices[triangleGeometry.Vertex1 - 1];
                var vertex2 = _vertices[triangleGeometry.Vertex2 - 1];
                var vertex3 = _vertices[triangleGeometry.Vertex3 - 1];

                var triangle = new Triangle(vertex1, vertex2, vertex3)
                {
                    Parent = this,
                    InheritMaterial = true
                };

                triangles.Add(triangle);
            }

            return triangles;
        }

        public void AddNormal(double x, double y, double z)
        {
            _normals.Add(new RtVector(x, y, z));
        }

        public TriangleMesh Scale(int multiplier = 1)
        {
            var maxX = _vertices.Max(v => v.X);
            var maxY = _vertices.Max(v => v.Y);
            var maxZ = _vertices.Max(v => v.Z);

            var minX = _vertices.Min(v => v.X);
            var minY = _vertices.Min(v => v.Y);
            var minZ = _vertices.Min(v => v.Z);

            var sx = maxX - minX;
            var sy = maxY - minY;
            var sz = maxZ - minZ;

            var scale = (new double[] { sx, sy, sz }).Max() / 2;

            var scaledMesh = new TriangleMesh(_triangles, _normals);

            for (int i = 0; i < _vertices.Count; i++)
            {
                var vertex = _vertices[i];
                vertex.X = (vertex.X - (minX + sx / 2)) / scale * multiplier;
                vertex.Y = (vertex.Y - (minY + sy / 2)) / scale * multiplier;
                vertex.Z = (vertex.Z - (minZ + sy / 2)) / scale * multiplier;

                scaledMesh.AddVertex(vertex);
            }

            return scaledMesh;
        }
    }
}