Feature: Shapes

Scenario: The default transformation
	Given shape ← test_shape()
	Then shape.Transform = identityMatrix

Scenario: Assigning a transformation
	Given shape ← test_shape()
	When set_transform(s, translation(2, 3, 4))
	Then shape.Transform = Translation(2, 3, 4)

Scenario: The default material
	Given shape ← test_shape()
	When material ← shape.material
	Then material = Material()

Scenario: Assigning a material
	Given shape ← test_shape()
	And material ← Material()
	And material.Ambient ← 1
	When shape.Material ← m
	Then shape.Material = m

Scenario: Intersecting a scaled shape with a ray
	Given ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	And shape ← test_shape()
	When set_transform(s, scaling(2, 2, 2))
	And xs ← intersect(s, r)
	Then shape.SavedRay.Origin = Point(0, 0, -2.5)
	And shape.SavedRay.Direction = Vector(0, 0, 0.5)

Scenario: Intersecting a translated shape with a ray
	Given ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	And shape ← test_shape()
	When set_transform(s, translation(5, 0, 0))
	And xs ← intersect(s, r)
	Then shape.SavedRay.Origin = Point(-5, 0, -5)
	And shape.SavedRay.Direction = Vector(0, 0, 1)

Scenario: Computing the normal on a transformed shape
	Given shape ← test_shape()
	And transform ← rotation_z(π / 5).scaling(1, 0.5, 1)
	When set_transform(shape, transformation)
	And normalVector ← normal_at(s, Point(0, √2/2, -√2/2))
	Then normalVector = Vector(0, 0.97014, -0.24254)

Scenario: Computing the normal on a translated shape
	Given shape ← test_shape()
	When set_transform(s, translation(0, 1, 0))
	And normalVector ← normal_at(s, Point(0, 1.70711, -0.70711))
	Then normalVector = Vector(0, 0.70711, -0.70711)