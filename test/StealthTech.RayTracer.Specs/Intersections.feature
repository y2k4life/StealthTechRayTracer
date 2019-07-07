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
	When computations ← intersection.PrepareComputations(ray)
	Then computations.Time = intersection.Time
	And computations.Shape = intersection.Shape
	And computations.Position = Point(0, 0, -1)
	And computations.EyeVector = Vector(0, 0, -1)
	And computations.NormalVector = Vector(0, 0, -1)

Scenario: The hit, when an intersection occurs on the outside
	Given ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	And sphere ← Sphere()
	And intersection ← Intersection(4, sphere)
	When computations ← intersection.PrepareComputations(ray)
	Then computations.Inside = false

Scenario: The hit, when an intersection occurs on the inside
	Given ray ← Ray(Point(0, 0, 0), Vector(0, 0, 1))
	And sphere ← Sphere()
	And intersection ← Intersection(1, sphere)
	When computations ← intersection.PrepareComputations(ray)
	Then computations.Position = Point(0, 0, 1)
	And computations.EyeVector = Vector(0, 0, -1)
	And computations.Inside = true
	# normal would have been (0, 0, 1), but is inverted!
	And computations.NormalVector = Vector(0, 0, -1)

Scenario: The hit should offset the point
	Given ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	And sphere ← Sphere() with:
		| transform | translation(0, 0, 1) |
	And intersection ← Intersection(5, sphere)
	When computations ← intersection.PrepareComputations(ray)
	Then computations.OverPoint.Z < -EPSILON/2
	And computations.Point.Z > computations.OverPoint.Z

Scenario: Precomputing the reflection vector
	Given plane ← Plane()
	And ray ← Ray(Point(0, 1, -1), Vector(0, -√2/2, √2/2))
	And intersection ← Intersection(√2, plane)
	When computations ← intersection.PrepareComputations(ray)
	Then computations.ReflectVector = Vector(0, √2/2, √2/2)

Scenario Outline: Finding n1 and n2 at various intersections
	Given sphere1 ← GlassSphere() with:
		| transform                | scaling(2, 2, 2) |
		| material.RefractiveIndex | 1.5              |
	And sphere2 ← GlassSphere() with:
		| transform                | translation(0, 0, -0.25) |
		| material.RefractiveIndex | 2.0                      |
	And sphere3 ← GlassSphere() with:
		| transform                | translation(0, 0, 0.25) |
		| material.RefractiveIndex | 2.5                     |
	And ray ← Ray(Point(0, 0, -4), Vector(0, 0, 1))
	And intersections ← Add(2, sphere1)
	And intersections ← Add(2.75, sphere2)
	And intersections ← Add(3.25, sphere3)
	And intersections ← Add(4.75, sphere2)
	And intersections ← Add(5.25, sphere3)
	And intersections ← Add(6, sphere1)
	When computations ← intersections[<index>].PrepareComputations(ray, intersections)
	Then computations.n1 = <n1>
	And computations.n2 = <n2>

	Examples:
		| index | n1  | n2  |
		| 0     | 1.0 | 1.5 |
		| 1     | 1.5 | 2.0 |
		| 2     | 2.0 | 2.5 |
		| 3     | 2.5 | 2.5 |
		| 4     | 2.5 | 1.5 |
		| 5     | 1.5 | 1.0 |

Scenario: The under point is offset below the surface
	Given ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	And sphere ← GlassSphere() with:
		| transform | translation(0, 0, 1) |
	And intersection ← Intersection(5, sphere)
	And intersections ← Add(intersection)
	When computations ← intersections.PrepareComputations(ray, intersections)
	Then computations.UnderPoint.Z > EPSILON/2
	And computations.Position.Z < computations.UnderPoint.Z

Scenario: The Schlick approximation under total internal reflection
	Given sphere1 ← GlassSphere()
	And ray ← Ray(Point(0, 0, √2/2), Vector(0, 1, 0))
	And intersections ← Add(-√2/2, sphere1)
	And intersections ← Add(√2/2, sphere1)
	When computations ← intersections[1].PrepareComputations(ray, intersections)
	And reflectance ← computations.Schlick()
	Then reflectance = 1.0

Scenario: The Schlick approximation with a perpendicular viewing angle
	Given sphere1 ← GlassSphere()
	And ray ← Ray(Point(0, 0, 0), Vector(0, 1, 0))
	And intersections ← Add(-1, sphere1)
	And intersections ← Add(1, sphere1)
	When computations ← intersections[1].PrepareComputations(ray, intersections)
	And reflectance ← computations.Schlick()
	Then reflectance = 0.04

Scenario: The Schlick approximation with small angle and n2 > n1
	Given sphere1 ← GlassSphere()
	And ray ← Ray(Point(0, 0.99, -2), Vector(0, 0, 1))
	And intersections ← Add(1.8589, sphere1)
	When computations ← intersections[0].PrepareComputations(ray, intersections)
	And reflectance ← computations.Schlick()
	Then reflectance = 0.48873