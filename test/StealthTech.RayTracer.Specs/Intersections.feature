Feature: Intersections

Scenario: An intersection encapsulates t and object
	Given sphere ← Sphere()
	When intersection ← Intersection(3.5, s)
	Then intersection.Time = 3.5
	And intersection.Shape = s

Scenario: Aggregating intersections
	Given sphere ← Sphere()
	And intersection1 ← Intersection(1, sphere)
	And intersection2 ← Intersection(2, sphere)
	When intersections ← IntersectionList(i1, i2)
	Then intersections.Count = 2
	And intersections[0].Time = 1
	And intersections[1].Time = 2

Scenario: The hit, when all intersections have positive t
	Given sphere ← Sphere()
	And intersection1 ← Intersection(1, sphere)
	And intersection2 ← Intersection(2, sphere)
	And intersections ← IntersectionList(i1, i2)
	When intersection ← hit(intersections)
	Then intersection = intersection1

Scenario: The hit, when some intersections have negative t
	Given sphere ← Sphere()
	And intersection1 ← Intersection(-1, sphere)
	And intersection2 ← Intersection(1, sphere)
	And intersections ← IntersectionList(i1, i2)
	When intersection ← hit(intersections)
	Then intersection = intersection2

Scenario: The hit, when all intersections have negative t
	Given sphere ← Sphere()
	And intersection1 ← Intersection(-2, sphere)
	And intersection2 ← Intersection(-1, sphere)
	And intersections ← IntersectionList(i1, i2)
	When intersection ← hit(intersections)
	Then intersection is nothing

Scenario: The hit is always the lowest nonnegative intersection
	Given sphere ← Sphere()
	And intersection1 ← Intersection(5, sphere)
	And intersection2 ← Intersection(7, sphere)
	And intersection3 ← Intersection(-3, sphere)
	And intersection4 ← Intersection(2, s)
	And intersections ← IntersectionList(i1, i2, i3, i4)
	When intersection ← hit(intersections)
	Then intersection = i4

Scenario: Precomputing the state of an intersection
	Given ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	And sphere ← Sphere()
	And intersection ← Intersection(4, sphere)
	When computations ← prepare_computations(i, r)
	Then computations.Time = intersection.Time
	And computations.Shape = intersection.Shape
	And computations.Point = Point(0, 0, -1)
	And computations.EyeVector = Vector(0, 0, -1)
	And computations.NormalVector = Vector(0, 0, -1)

Scenario: The hit, when an intersection occurs on the outside
	Given ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	And sphere ← Sphere()
	And intersection ← Intersection(4, sphere)
	When computations ← prepare_computations(i, r)
	Then computations.Inside = false

Scenario: The hit, when an intersection occurs on the inside
	Given ray ← Ray(Point(0, 0, 0), Vector(0, 0, 1))
	And sphere ← Sphere()
	And intersection ← Intersection(1, sphere)
	When computations ← prepare_computations(i, r)
	Then computations.Point = Point(0, 0, 1)
	And computations.EyeVector = Vector(0, 0, -1)
	And computations.Inside = true
	# normal would have been (0, 0, 1), but is inverted!
	And computations.NormalVector = Vector(0, 0, -1)

Scenario: The hit should offset the point
	Given ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	And sphere ← Sphere() with:
		| transform | translation(0, 0, 1) |
	And intersection ← Intersection(5, sphere)
	When computations ← prepare_computations(i, r)
	Then computations.OverPoint.Z < -EPSILON/2
	And computations.Point.Z > computations.OverPoint.Z