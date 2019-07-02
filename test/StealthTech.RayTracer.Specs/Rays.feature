Feature: Rays

Scenario: Creating and querying a ray
	Given origin ← Point(1, 2, 3)
	And direction ← Vector(4, 5, 6)
	When ray ← Ray(origin, direction)
	Then ray.Origin = origin
	And ray.Direction = direction

Scenario: Computing a point from a distance
	Given ray ← Ray(Point(2, 3, 4), Vector(1, 0, 0))
	Then position(0) = Point(2, 3, 4)
	And position(1) = Point(3, 3, 4)
	And position(-1) = Point(1, 3, 4)
	And position(2.5) = Point(4.5, 3, 4)

Scenario: Translating a ray
	Given ray ← Ray(Point(1, 2, 3), Vector(0, 1, 0))
	And transform ← translation(3, 4, 5)
	When ray2 ← transform(r, transform)
	Then ray2.Origin = Point(4, 6, 8)
	And ray2.Direction = Vector(0, 1, 0)

Scenario: Scaling a ray
	Given ray ← Ray(Point(1, 2, 3), Vector(0, 1, 0))
	And transform ← scaling(2, 3, 4)
	When ray2 ← transform(r, transform)
	Then ray2.Origin = Point(2, 6, 12)
	And ray2.Direction = Vector(0, 3, 0)
