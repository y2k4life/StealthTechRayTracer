Feature: world

Scenario: Creating a world
	Given world ← World()
	Then world contains no shapes
	And world has no light source

Scenario: The default world
	Given light ← PointLight(Point(-10, 10, -10), Color(1, 1, 1))
	And sphere1 ← sphere() with:
		| material.color    | (0.8, 1.0, 0.6) |
		| material.diffuse  | 0.7             |
		| material.specular | 0.2             |
	And sphere2 ← sphere() with:
		| transform | scaling(0.5, 0.5, 0.5) |
	When world ← default_world()
	Then world.Light = light
	And world contains sphere1
	And world contains sphere2

Scenario: Intersect a world with a ray
	Given world ← default_world()
	And ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	When intersections ← intersect_world(w, r)
	Then intersections.Count = 4
	And intersections[0].Time = 4
	And intersections[1].Time = 4.5
	And intersections[2].Time = 5.5
	And intersections[3].Time = 6

Scenario: Shading an intersection
	Given world ← default_world()
	And ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	And sphere ← the first shape in world
	And intersection ← Intersection(4, sphere)
	When computations ← prepare_computations(i, r)
	And color ← shade_hit(w, computations)
	Then color = Color(0.38066, 0.47583, 0.2855)

Scenario: Shading an intersection from the inside
	Given world ← default_world()
	And world.Light ← PointLight(Point(0, 0.25, 0), Color(1, 1, 1))
	And ray ← Ray(Point(0, 0, 0), Vector(0, 0, 1))
	And sphere ← the second shape in world
	And intersection ← Intersection(0.5, sphere)
	When computations ← prepare_computations(i, r)
	And color ← shade_hit(w, computations)
	Then color = Color(0.90498, 0.90498, 0.90498)

Scenario: The color when a ray misses
	Given world ← default_world()
	And ray ← Ray(Point(0, 0, -5), Vector(0, 1, 0))
	When color ← color_at(w, r)
	Then color = Color(0, 0, 0)

Scenario: The color when a ray hits
	Given world ← default_world()
	And ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	When color ← color_at(w, r)
	Then color = Color(0.38066, 0.47583, 0.2855)

Scenario: The color with an intersection behind the ray
	Given world ← default_world()
	And outerShape ← the first shape in world
	And outerShape.Material.Ambient ← 1
	And innerShape ← the second shape in world
	And inner.material.ambient ← 1
	And ray ← Ray(Point(0, 0, 0.75), Vector(0, 0, -1))
	When color ← color_at(w, r)
	Then color = inner.Material.Color

Scenario: There is no shadow when nothing is collinear with point and light
	Given world ← default_world()
	And point ← Point(0, 10, 0)
	Then is_shadowed(w, p) is false

Scenario: The shadow when an object is between the point and the light
	Given world ← default_world()
	And point ← Point(10, -10, 10)
	Then is_shadowed(w, p) is true

Scenario: There is no shadow when an object is behind the light
	Given world ← default_world()
	And point ← Point(-20, 20, -20)
	Then is_shadowed(w, p) is false

Scenario: There is no shadow when an object is behind the point
	Given world ← default_world()
	And point ← Point(-2, 2, -2)
	Then is_shadowed(w, p) is false

Scenario: shade_hit() is given an intersection in shadow
	Given world ← World()
	And world.Light ← PointLight(Point(0, 0, -10), Color(1, 1, 1))
	And sphere ← Sphere()
	And sphere is added to world
	And sphere2 ← sphere() with:
		| transform | translation(0, 0, 10) |
	And sphere2 is added to world
	And ray ← Ray(Point(0, 0, 5), Vector(0, 0, 1))
	And intersection ← Intersection(4, sphere2)
	When computations ← prepare_computations(i, r)
	And color ← shade_hit(w, computations)
	Then color = Color(0.1, 0.1, 0.1)