Feature: TriangleMeshes

Scenario: Creating a new mesh
	Given triangleMesh ← TriangleMesh()
	Then triangleMesh.Transform = IdentityMatrix
	And triangleMesh.Vertices is empty
	And triangleMesh.Triangles is empty

Scenario: Adding a vertex to a mesh
	Given triangleMesh ← TriangleMesh()
	And point ← Point(2, 3, 4)
	When triangleMesh.AddVertex(point)
	Then triangleMesh.VertexCount = 1
	And triangleMesh includes point

Scenario: Adding a triangle to a mesh
	Given triangleMesh ← TriangleMesh()
	And point1 ← Point(0, 1, 0)
	And point2 ← Point(1, 2, 3)
	And point3 ← Point(4, 5, 6)
	And triangleMesh.AddVertex(point1)
	And triangleMesh.AddVertex(point2)
	And triangleMesh.AddVertex(point3)
	When triangleMesh.AddTriangle(1, 2, 3)
	Then triangleMesh.TriangleCount = 1
	And triangleMesh.Triangle[0] should include point1
	And triangleMesh.Triangle[0] should include point2
	And triangleMesh.Triangle[0] should include point3

Scenario: Intersecting a ray parallel to the triangle
	Given triangleMesh ← TriangleMesh()
	And triangleMesh.AddVertex(Point(0, 1, 0))
	And triangleMesh.AddVertex(Point(-1, 0, 0))
	And triangleMesh.AddVertex(Point(1, 0, 0))
	And triangleMesh.AddTriangle(1, 2, 3)
	And ray ← Ray(Point(0, -1, -2), Vector(0, 1, 0))
	When intersections ← triangleMesh.LocalIntersect(ray)
	Then intersections is empty

Scenario: A ray misses the p1-p3 edge
	Given triangleMesh ← TriangleMesh()
	And triangleMesh.AddVertex(Point(0, 1, 0))
	And triangleMesh.AddVertex(Point(-1, 0, 0))
	And triangleMesh.AddVertex(Point(1, 0, 0))
	And triangleMesh.AddTriangle(1, 2, 3)
	And ray ← Ray(Point(1, 1, -2), Vector(0, 0, 1))
	When intersections ← triangleMesh.LocalIntersect(ray)
	Then intersections is empty

Scenario: A ray misses the p1-p2 edge
	Given triangleMesh ← TriangleMesh()
	And triangleMesh.AddVertex(Point(0, 1, 0))
	And triangleMesh.AddVertex(Point(-1, 0, 0))
	And triangleMesh.AddVertex(Point(1, 0, 0))
	And triangleMesh.AddTriangle(1, 2, 3)
	And ray ← Ray(Point(-1, 1, -2), Vector(0, 0, 1))
	When intersections ← triangleMesh.LocalIntersect(ray)
	Then intersections is empty

Scenario: A ray misses the p2-p3 edge
	Given triangleMesh ← TriangleMesh()
	And triangleMesh.AddVertex(Point(0, 1, 0))
	And triangleMesh.AddVertex(Point(-1, 0, 0))
	And triangleMesh.AddVertex(Point(1, 0, 0))
	And triangleMesh.AddTriangle(1, 2, 3)
	And ray ← Ray(Point(0, -1, -2), Vector(0, 0, 1))
	When intersections ← triangleMesh.LocalIntersect(ray)
	Then intersections is empty

Scenario: A ray strikes a triangle
	Given triangleMesh ← TriangleMesh()
	And triangleMesh.AddVertex(Point(0, 1, 0))
	And triangleMesh.AddVertex(Point(-1, 0, 0))
	And triangleMesh.AddVertex(Point(1, 0, 0))
	And triangleMesh.AddTriangle(1, 2, 3)
	And ray ← Ray(Point(0, 0.5, -2), Vector(0, 0, 1))
	When intersections ← triangleMesh.LocalIntersect(ray)
	Then intersections.Count = 1
	And intersections[0].Time = 2