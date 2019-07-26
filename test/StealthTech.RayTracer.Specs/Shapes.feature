Feature: Shapes

Scenario: The default transformation
	Given testShape ← TestShape()
	Then testShape.Transform = identityMatrix

Scenario: Assigning a transformation
	Given testShape ← TestShape()
	When testShape.Transform ← Translation(2, 3, 4)
	Then testShape.Transform = Translation(2, 3, 4)

Scenario: The default material
	Given testShape ← TestShape()
	When material ← testShape.material
	Then material = Material()

Scenario: Assigning a material
	Given testShape ← TestShape()
	And material ← Material()
	And material.Ambient ← 1
	When shape.Material ← m
	Then shape.Material = m

Scenario: Intersecting a scaled shape with a ray
	Given ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	Given testShape ← TestShape()
	When set_transform(s, scaling(2, 2, 2))
	And xs ← intersect(s, r)
	Then shape.SavedRay.Origin = Point(0, 0, -2.5)
	And shape.SavedRay.Direction = Vector(0, 0, 0.5)

Scenario: Intersecting a translated shape with a ray
	Given ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	Given testShape ← TestShape()
	When testShape.Transform ← Translation(5, 0, 0)
	And xs ← intersect(s, r)
	Then shape.SavedRay.Origin = Point(-5, 0, -5)
	And shape.SavedRay.Direction = Vector(0, 0, 1)

Scenario: Computing the normal on a transformed shape
	Given testShape ← TestShape()
	And transform ← rotation_z(π / 5).scaling(1, 0.5, 1)
	When testShape.Transform ← transformation
	And normalVector ← testShape.NormalAt(Point(0, √2/2, -√2/2))
	Then normalVector = Vector(0, 0.97014, -0.24254)

Scenario: Computing the normal on a translated shape
	Given testShape ← TestShape()
	When testShape.Transform ← Translation(0, 1, 0)
	And normalVector ← testShape.NormalAt(Point(0, 1.70711, -0.70711))
	Then normalVector = Vector(0, 0.70711, -0.70711)

Scenario: A shape has a parent attribute
	Given testShape ← TestShape()
	Then shape.Parent is nothing

Scenario: Converting a point from world to object space
	Given shapeGroup1 ← Group()
	And shapeGroup1.Transform ← RotationY(π/2)
	And shapeGroup2 ← Group()
	And shapeGroup2.Transform ← Scaling(2, 2, 2)
	And shapeGroup1.AddChild(shapeGroup2)
	And sphere ← Sphere()
	And sphere.Transform ← translation(5, 0, 0)
	And shapeGroup2.AddChild(sphere)
	When point ← sphere.WorldToShape(Point(-2, 0, -10))
	Then point = Point(0, 0, -1)

Scenario: Converting a normal from object space to world space
	Given shapeGroup1 ← Group()
	And shapeGroup1.Transform ← RotationY(π/2)
	And shapeGroup2 ← Group()
	And shapeGroup2.Transform ← Scaling(1, 2, 3)
	And shapeGroup1.AddChild(shapeGroup2)
	And sphere ← Sphere()
	And sphere.Transform ← translation(5, 0, 0)
	And shapeGroup2.AddChild(sphere)
	When normalVector ← sphere.NormalToWorld(Vector(√3/3, √3/3, √3/3))
	Then normalVector = Vector(0.2857, 0.4286, -0.8571)

Scenario: Finding the normal on a child object
	Given shapeGroup1 ← Group()
	And shapeGroup1.Transform ← RotationY(π/2)
	And shapeGroup2 ← Group()
	And shapeGroup2.Transform ← Scaling(1, 2, 3)
	And shapeGroup1.AddChild(shapeGroup2)
	And sphere ← Sphere()
	And sphere.Transform ← translation(5, 0, 0)
	And shapeGroup2.AddChild(sphere)
	When normalVector ← sphere.NormalAt(Point(1.7321, 1.1547, -5.5774))
	Then normalVector = Vector(0.2857, 0.4286, -0.8571)