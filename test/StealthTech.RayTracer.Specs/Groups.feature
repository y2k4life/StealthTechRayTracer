Feature: Groups

Scenario: Creating a new group
	Given shapeGroup ← ShapeGroup()
	Then shapeGroup.Transform = IdentityMatrix
	And shapeGroup is empty

Scenario: Adding a child to a group
	Given shapeGroup ← ShapeGroup()
	And testShape ← TestShape()
	When shapeGroup.AddChild(testShape)
	Then shapeGroup is not empty
	And shapeGroup includes testShape
	And testShape.Parent = shapeGroup

Scenario: Intersecting a ray with an empty group
	Given shapeGroup ← ShapeGroup()
	And ray ← Ray(Point(0, 0, 0), Vector(0, 0, 1))
	When intersections ← shapeGroup.LocalIntersect(ray)
	Then intersections is empty

Scenario: Intersecting a ray with a nonempty group
	Given shapeGroup ← ShapeGroup()
	And sphere1 ← Sphere()
	And sphere2 ← Sphere()
	And sphere2.Transform ← translation(0, 0, -3)
	And sphere3 ← Sphere()
	And sphere3.Transform ← translation(5, 0, 0)
	And shapeGroup.AddChild(sphere1)
	And shapeGroup.AddChild(sphere2)
	And shapeGroup.AddChild(sphere3)
	And ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	When intersections ← shapeGroup.LocalIntersect(ray)
	Then intersections.Count = 4
	And intersections[0].Shape = sphere2
	And intersections[1].Shape = sphere2
	And intersections[2].Shape = sphere1
	And intersections[3].Shape = sphere1

Scenario: Intersecting a transformed group
	Given shapeGroup ← ShapeGroup()
	And shapeGroup.Transform ← scaling(2, 2, 2)
	And sphere ← Sphere()
	And sphere.Transform ← translation(5, 0, 0)
	And shapeGroup.AddChild(sphere)
	And ray ← Ray(Point(10, 0, -10), Vector(0, 0, 1))
	When intersections ← shapeGroup.Intersect(ray)
	Then intersections.Count = 2