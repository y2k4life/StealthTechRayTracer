Feature: Spheres

Scenario: A ray intersects a sphere at two points
	Given ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	And sphere ← Sphere()
	When intersections ← intersect(sphere, r)
	Then intersections.Count = 2
	And intersections[0].Time = 4.0
	And intersections[1].Time = 6.0

Scenario: A ray intersects a sphere at a tangent
	Given ray ← Ray(Point(0, 1, -5), Vector(0, 0, 1))
	And sphere ← Sphere()
	When intersections ← intersect(sphere, r)
	Then intersections.Count = 2
	And intersections[0].Time = 5.0
	And intersections[1].Time = 5.0

Scenario: A ray misses a sphere
	Given ray ← Ray(Point(0, 2, -5), Vector(0, 0, 1))
	And sphere ← Sphere()
	When intersections ← intersect(sphere, r)
	Then intersections.Count = 0

Scenario: A ray originates inside a sphere
	Given ray ← Ray(Point(0, 0, 0), Vector(0, 0, 1))
	And sphere ← Sphere()
	When intersections ← intersect(sphere, r)
	Then intersections.Count = 2
	And intersections[0].Time = -1.0
	And intersections[1].Time = 1.0

Scenario: A sphere is behind a ray
	Given ray ← Ray(Point(0, 0, 5), Vector(0, 0, 1))
	And sphere ← Sphere()
	When intersections ← intersect(sphere, r)
	Then intersections.Count = 2
	And intersections[0].Time = -6.0
	And intersections[1].Time = -4.0

Scenario: Intersect sets the object on the intersection
	Given ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	And sphere ← Sphere()
	When intersections ← intersect(sphere, r)
	Then intersections.Count = 2
	And intersections[0].Item = s
	And intersections[1].Item = s

Scenario: The normal on a sphere at a point on the x axis
	Given sphere ← Sphere()
	When normalVector ← normal_at(sphere, Point(1, 0, 0))
	Then normalVector = Vector(1, 0, 0)

Scenario: The normal on a sphere at a point on the y axis
	Given sphere ← Sphere()
	When normalVector ← normal_at(sphere, Point(0, 1, 0))
	Then normalVector = Vector(0, 1, 0)

Scenario: The normal on a sphere at a point on the z axis
	Given sphere ← Sphere()
	When normalVector ← normal_at(sphere, Point(0, 0, 1))
	Then normalVector = Vector(0, 0, 1)

Scenario: The normal on a sphere at a nonaxial point
	Given sphere ← Sphere()
	When normalVector ← normal_at(sphere, Point(√3/3, √3/3, √3/3))
	Then normalVector = Vector(√3/3, √3/3, √3/3)

Scenario: The normal is a normalized vector
	Given sphere ← Sphere()
	When normalVector ← normal_at(sphere, Point(√3/3, √3/3, √3/3))
	Then normalVector = normalize(normalVector)

Scenario: A helper for producing a sphere with a glassy material
	Given sphere ← GlassSphere()
	Then sphere.Transform = identityMatrix
	And sphere.Material.Transparency = 1.0
	And sphere.Material.RefractiveIndex = 1.5