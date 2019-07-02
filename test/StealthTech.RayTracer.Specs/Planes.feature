Feature: Planes

Scenario: The normal of a plane is constant everywhere
	Given plane ← Plane()
	When normalVector1 ← plane.LocalNormalAt(point(0, 0, 0))
	And normalVector2 ← plane.LocalNormalAt(point(10, 0, -10))
	And normalVector3 ← plane.LocalNormalAt(point(-5, 0, 150))
	Then normal1 = Vector(0, 1, 0)
	And normal2 = Vector(0, 1, 0)
	And normal3 = Vector(0, 1, 0)

Scenario: Intersect with a ray parallel to the plane
	Given plane ← Plane()
	And ray ← Ray(Point(0, 10, 0), Vector(0, 0, 1))
	When intersections ← plane.LocalIntersect(ray)
	Then intersections is empty

Scenario: Intersect with a coplanar ray
	Given plane ← Plane()
	And ray ← Ray(Point(0, 0, 0), Vector(0, 0, 1))
	When intersections ← plane.LocalIntersect(ray)
	Then intersections is empty

Scenario: A ray intersecting a plane from above
	Given plane ← Plane()
	And ray ← Ray(Point(0, 1, 0), Vector(0, -1, 0))
	When intersections ← plane.LocalIntersect(ray)
	Then intersections.Count = 1
	And intersections[0].Time = 1
	And intersections[0].Shape = plane

Scenario: A ray intersecting a plane from below
	Given plane ← Plane()
	And ray ← Ray(Point(0, -1, 0), Vector(0, 1, 0))
	When intersections ← plane.LocalIntersect(ray)
	Then intersections.Count = 1
	And intersections[0].Time = 1
	And intersections[0].Shape = plane