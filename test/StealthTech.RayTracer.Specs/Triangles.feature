Feature: Triangles

Scenario: Constructing a triangle
	Given point1 ← Point(0, 1, 0)
	And point2 ← Point(-1, 0, 0)
	And point3 ← Point(1, 0, 0)
	And triangle ← Triangle(point1, point2, point3)
	Then triangle.Point1 = point1
	And triangle.Point2 = point2
	And triangle.Point3 = point3
	And triangle.Edge1 = Vector(-1, -1, 0)
	And triangle.Edge2 = Vector(1, -1, 0)
	And triangle.Normal = Vector(0, 0, -1)

Scenario: Finding the normal on a triangle
	Given triangle ← Triangle(Point(0, 1, 0), Point(-1, 0, 0), Point(1, 0, 0))
	When normal1 ← triangle.LocalNormalAt(Point(0, 0.5, 0))
	And normal2 ← triangle.LocalNormalAt(Point(-0.5, 0.75, 0))
	And normal3 ← triangle.LocalNormalAt(Point(0.5, 0.25, 0))
	Then normal1 = triangle.Normal
	And normal2 = triangle.Normal
	And normal3 = triangle.Normal

Scenario: Intersecting a ray parallel to the triangle
	Given triangle ← Triangle(Point(0, 1, 0), Point(-1, 0, 0), Point(1, 0, 0))
	And ray ← Ray(Point(0, -1, -2), Vector(0, 1, 0))
	When intersections ← triangle.LocalIntersect(ray)
	Then intersections is empty

Scenario: A ray misses the p1-p3 edge
	Given triangle ← Triangle(Point(0, 1, 0), Point(-1, 0, 0), Point(1, 0, 0))
	And ray ← Ray(Point(1, 1, -2), Vector(0, 0, 1))
	When intersections ← triangle.LocalIntersect(ray)
	Then intersections is empty

Scenario: A ray misses the p1-p2 edge
	Given triangle ← Triangle(Point(0, 1, 0), Point(-1, 0, 0), Point(1, 0, 0))
	And ray ← Ray(Point(-1, 1, -2), Vector(0, 0, 1))
	When intersections ← triangle.LocalIntersect(ray)
	Then intersections is empty

Scenario: A ray misses the p2-p3 edge
	Given triangle ← Triangle(Point(0, 1, 0), Point(-1, 0, 0), Point(1, 0, 0))
	And ray ← Ray(Point(0, -1, -2), Vector(0, 0, 1))
	When intersections ← triangle.LocalIntersect(ray)
	Then intersections is empty

Scenario: A ray strikes a triangle
	Given triangle ← Triangle(Point(0, 1, 0), Point(-1, 0, 0), Point(1, 0, 0))
	And ray ← Ray(Point(0, 0.5, -2), Vector(0, 0, 1))
	When intersections ← triangle.LocalIntersect(ray)
	Then intersections.Count = 1
	And intersections[0].Time = 2