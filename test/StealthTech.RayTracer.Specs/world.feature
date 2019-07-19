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
	When computations ← intersection.PrepareComputations(ray)
	And color ← world.ShadeHit(computations, 5)
	Then color = Color(0.38066, 0.47583, 0.2855)

Scenario: Shading an intersection from the inside
	Given world ← default_world()
	And world.Light ← PointLight(Point(0, 0.25, 0), Color(1, 1, 1))
	And ray ← Ray(Point(0, 0, 0), Vector(0, 0, 1))
	And sphere ← the second shape in world
	And intersection ← Intersection(0.5, sphere)
	When computations ← intersection.PrepareComputations(ray)
	And color ← world.ShadeHit(computations, 5)
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

#Scenario: There is no shadow when nothing is collinear with point and light
#	Given world ← default_world()
#	And point ← Point(0, 10, 0)
#	Then is_shadowed(w, p) is false
#
#Scenario: The shadow when an object is between the point and the light
#	Given world ← default_world()
#	And point ← Point(10, -10, 10)
#	Then is_shadowed(w, p) is true
#
#Scenario: There is no shadow when an object is behind the light
#	Given world ← default_world()
#	And point ← Point(-20, 20, -20)
#	Then is_shadowed(w, p) is false
#
#Scenario: There is no shadow when an object is behind the point
#	Given world ← default_world()
#	And point ← Point(-2, 2, -2)
#	Then is_shadowed(w, p) is false

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
	When computations ← intersection.PrepareComputations(ray)
	And color ← world.ShadeHit(computations, 5)
	Then color = Color(0.1, 0.1, 0.1)

Scenario: The reflected color for a nonreflective material
	Given world ← default_world()
	And ray ← Ray(Point(0, 0, 0), Vector(0, 0, 1))
	And sphere ← the second shape in world
	And sphere.Material.Ambient ← 1
	And intersection ← Intersection(1, sphere)
	When computations ← intersection.PrepareComputations(ray)
	And color ← world.ReflectedColor(computations)
	Then color = Color(0, 0, 0)

Scenario: The reflected color for a reflective material
	Given world ← default_world()
	And plane ← Plane() with:
		| material.reflective | 0.5                   |
		| transform           | translation(0, -1, 0) |
	And plane is added to world
	And ray ← Ray(Point(0, 0, -3), Vector(0, -√2/2, √2/2))
	And intersection ← Intersection(√2, plane)
	When computations ← intersection.PrepareComputations(ray)
	And color ← world.ReflectedColor(computations)
	Then color = Color(0.19032, 0.2379, 0.14274)

Scenario: shade_hit() with a reflective material
	Given world ← default_world()
	And plane ← Plane() with:
		| material.reflective | 0.5                   |
		| transform           | translation(0, -1, 0) |
	And plane is added to world
	And ray ← Ray(Point(0, 0, -3), Vector(0, -√2/2, √2/2))
	And intersection ← Intersection(√2, plane)
	When computations ← intersection.PrepareComputations(ray)
	And color ← world.ShadeHit(computations, 5)
	Then color = Color(0.87677, 0.92436, 0.82918)

Scenario: color_at() with mutually reflective surfaces
	Given world ← default_world()
	And light ← PointLight(Point(0, 0, 0), Color(1, 1, 1))
	And lowerPlane ← Plane() with:
		| material.reflective | 1                     |
		| transform           | translation(0, -1, 0) |
	And lowerPlane is added to world
	And upperPlane ← Plane() with:
		| material.reflective | 1                    |
		| transform           | translation(0, 1, 0) |
	And upperPlane is added to world
	And ray ← Ray(Point(0, 0, 0), Vector(0, 1, 0))
	Then world.ColorAt(ray) should terminate successfully

Scenario: The reflected color at the maximum recursive depth
	Given world ← default_world()
	And plane ← Plane() with:
		| material.reflective | 0.5                   |
		| transform           | translation(0, -1, 0) |
	And plane is added to world
	And ray ← Ray(Point(0, 0, -3), Vector(0, -√2/2, √2/2))
	And intersection ← Intersection(√2, plane)
	When computations ← intersection.PrepareComputations(ray)
	And color ← world.ReflectedColor(computations, 0)
	Then color = Color(0, 0, 0)

Scenario: The refracted color with an opaque surface
	Given world ← default_world()
	And sphere1 ← the first shape in world
	And ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	And intersections ← Add(4, sphere1)
	And intersections ← Add(6, sphere1)
	When computations ← intersections[0].PrepareComputations(ray, intersections)
	And color ← world.RefractedColor(computations, 5)
	Then color = Color(0, 0, 0)

Scenario: The refracted color at the maximum recursive depth
	Given world ← default_world()
	And sphere1 ← the first shape in world
	And sphere1 has:
		| material.transparency    | 1.0 |
		| material.RefractiveIndex | 1.5 |
	And ray ← Ray(Point(0, 0, -5), Vector(0, 0, 1))
	And intersections ← Add(4, sphere1)
	And intersections ← Add(6, sphere1)
	When computations ← intersections[0].PrepareComputations(ray, intersections)
	And color ← world.RefractedColor(computations, 0)
	Then color = Color(0, 0, 0)

Scenario: The refracted color under total internal reflection
	Given world ← default_world()
	And sphere1 ← the first shape in world
	And sphere1 has:
		| material.transparency    | 1.0 |
		| material.RefractiveIndex | 1.5 |
	And ray ← Ray(Point(0, 0, √2/2), Vector(0, 1, 0))
	And intersections ← Add(-√2/2, sphere1)
	And intersections ← Add(√2/2, sphere1)
	# NOTE: this time you're inside the sphere, so you need
	# to look at the second intersection, xs[1], not xs[0]
	When computations ← intersections[1].PrepareComputations(ray, intersections)
	And color ← world.RefractedColor(computations, 5)
	Then color = Color(0, 0, 0)

Scenario: The refracted color with a refracted ray
	Given world ← default_world()
	And sphere1 ← the first shape in world
	And sphere1 has:
		| material.pattern | TestPatter() |
		| material.Ambient | 1.0          |
	And sphere2 ← the second shape in world
	And sphere2 has:
		| material.Transparency    | 1.0 |
		| material.RefractiveIndex | 1.5 |
	And ray ← Ray(Point(0, 0, 0.1), Vector(0, 1, 0))
	And intersections ← Add(-0.9899, sphere1)
	And intersections ← Add(-0.4899, sphere2)
	And intersections ← Add(0.4899, sphere2)
	And intersections ← Add(0.9899, sphere1)
	When computations ← intersections[2].PrepareComputations(ray, intersections)
	And color ← world.RefractedColor(computations, 5)
	Then color = Color(0, 0.99888, 0.04725)

Scenario: shade_hit() with a transparent material
	Given world ← default_world()
	And floor ← Plane() with:
		| transform                | translation(0, -1, 0) |
		| material.Transparency    | 0.5                   |
		| material.RefractiveIndex | 1.5                   |
	And floor is added to world
	And sphere ← Sphere() with:
		| material.color   | (1, 0, 0)                  |
		| material.Ambient | 0.5                        |
		| transform        | translation(0, -3.5, -0.5) |
	And sphere is added to world
	And ray ← Ray(Point(0, 0, -3), Vector(0, -√2/2, √2/2))
	And intersections ← Add(√2, floor)
	When computations ← intersections[0].PrepareComputations(ray, intersections)
	And color ← world.ShadeHit(computations, 5)
	Then color = Color(0.93642, 0.68642, 0.68642)

Scenario: shade_hit() with a reflective, transparent material
	Given world ← default_world()
	And ray ← Ray(Point(0, 0, -3), Vector(0, -√2/2, √2/2))
	And floor ← Plane() with:
		| transform                | translation(0, -1, 0) |
		| material.reflective      | 0.5                   |
		| material.Transparency    | 0.5                   |
		| material.RefractiveIndex | 1.5                   |
	And floor is added to world
	And sphere ← Sphere() with:
		| material.color   | (1, 0, 0)                  |
		| material.Ambient | 0.5                        |
		| transform        | translation(0, -3.5, -0.5) |
	And sphere is added to world
	And intersections ← Add(√2, floor)
	When computations ← intersections[0].PrepareComputations(ray, intersections)
	And color ← world.ShadeHit(computations, 5)
	Then color = Color(0.93391, 0.69643, 0.69243)

Scenario Outline: is_shadow tests for occlusion between two points
	Given world ← default_world()
	And light_position ← Point(-10, -10, -10)
	And point ← <point>
	Then is_shadowed(w, light_position, point) is <result>

	Examples:
		| point                | result |
		| Point(-10, -10, 10)  | false  |
		| Point(10, 10, 10)    | true   |
		| Point(-20, -20, -20) | false  |
		| Point(-5, -5, -5)    | false  |