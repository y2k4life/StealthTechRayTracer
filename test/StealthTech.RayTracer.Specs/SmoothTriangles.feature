Feature: SmoothTriangles

Background:
	Given point1 ← Point(0, 1, 0)
	And point2 ← Point(-1, 0, 0)
	And point3 ← Point(1, 0, 0)
	And normal1 ← Vector(0, 1, 0)
	And normal2 ← Vector(-1, 0, 0)
	And normal3 ← Vector(1, 0, 0)
	When triangle ← Triangle(point1, point2, point3, normal1, normal2, normal3)

Scenario: Constructing a smooth triangle
	Then triangle.Point1 = point1
	And triangle.Point2 = point2
	And triangle.Point3 = point3
	And triangle.Normal1 = normal1
	And triangle.Normal2 = normal2
	And triangle.Normal3 = normal3

Scenario: An intersection with a smooth triangle stores u/v
	Given ray ← Ray(Point(-0.2, 0.3, -2), Vector(0, 0, 1))
	When intersections ← triangle.LocalIntersect(ray)
	Then intersections[0].U = 0.45
	And intersections[0].V = 0.25

Scenario: A smooth triangle uses u/v to interpolate the normal
	When intersection ← intersection(1, triangle, 0.45, 0.25)
	And normal ← triangle.NormalAt(Point(0, 0, 0), intersection)
	Then normal = Vector(-0.5547, 0.83205, 0)

Scenario: Preparing the normal on a smooth triangle
	Given ray ← Ray(Point(-0.2, 0.3, -2), Vector(0, 0, 1))
	When intersection ← intersection(1, triangle, 0.45, 0.25)
	And computations ← intersection.PrepareComputations(ray)
	Then computations.NormalVector = Vector(-0.5547, 0.83205, 0)