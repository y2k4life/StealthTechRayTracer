﻿Feature: world

Scenario: Creating a world
	Given w ← world()
	Then w contains no objects
	And w has no light source

Scenario: The default world
	Given light ← point_light(point(-10, 10, -10), color(1, 1, 1))
	And s1 ← sphere() with:
		| material.color    | (0.8, 1.0, 0.6) |
		| material.diffuse  | 0.7             |
		| material.specular | 0.2             |
	And s2 ← sphere() with:
		| transform | scaling(0.5, 0.5, 0.5) |
	When w ← default_world()
	Then w.light = light
	And w contains s1
	And w contains s2

Scenario: Intersect a world with a ray
	Given w ← default_world()
	And r ← ray(point(0, 0, -5), vector(0, 0, 1))
	When xs ← intersect_world(w, r)
	Then xs.count = 4
	And xs[0].Time = 4
	And xs[1].Time = 4.5
	And xs[2].Time = 5.5
	And xs[3].Time = 6

Scenario: Shading an intersection
	Given w ← default_world()
	And r ← ray(point(0, 0, -5), vector(0, 0, 1))
	And s ← the first object in w
	And i1 ← intersection(4, s)
	When comps ← prepare_computations(i, r)
	And c ← shade_hit(w, comps)
	Then c = color(0.38066, 0.47583, 0.2855)

Scenario: Shading an intersection from the inside
	Given w ← default_world()
	And w.light ← point_light(point(0, 0.25, 0), color(1, 1, 1))
	And r ← ray(point(0, 0, 0), vector(0, 0, 1))
	And s ← the second object in w
	And i1 ← intersection(0.5, s)
	When comps ← prepare_computations(i, r)
	And c ← shade_hit(w, comps)
	Then c = color(0.90498, 0.90498, 0.90498)

Scenario: The color when a ray misses
	Given w ← default_world()
	And r ← ray(point(0, 0, -5), vector(0, 1, 0))
	When c ← color_at(w, r)
	Then c = color(0, 0, 0)

Scenario: The color when a ray hits
	Given w ← default_world()
	And r ← ray(point(0, 0, -5), vector(0, 0, 1))
	When c ← color_at(w, r)
	Then c = color(0.38066, 0.47583, 0.2855)

Scenario: The color with an intersection behind the ray
	Given w ← default_world()
	And outer ← the first object in w
	And outer.material.ambient ← 1
	And inner ← the second object in w
	And inner.material.ambient ← 1
	And r ← ray(point(0, 0, 0.75), vector(0, 0, -1))
	When c ← color_at(w, r)
	Then c = inner.material.color

Scenario: There is no shadow when nothing is collinear with point and light
	Given w ← default_world()
	And p ← point(0, 10, 0)
	Then is_shadowed(w, p) is false

Scenario: The shadow when an object is between the point and the light
	Given w ← default_world()
	And p ← point(10, -10, 10)
	Then is_shadowed(w, p) is true

Scenario: There is no shadow when an object is behind the light
	Given w ← default_world()
	And p ← point(-20, 20, -20)
	Then is_shadowed(w, p) is false

Scenario: There is no shadow when an object is behind the point
	Given w ← default_world()
	And p ← point(-2, 2, -2)
	Then is_shadowed(w, p) is false

Scenario: shade_hit() is given an intersection in shadow
	Given w ← world()
	And w.light ← point_light(point(0, 0, -10), color(1, 1, 1))
	And s ← sphere()
	And s is added to w
	And s2 ← sphere() with:
		| transform | translation(0, 0, 10) |
	And s2 is added to w
	And r ← ray(point(0, 0, 5), vector(0, 0, 1))
	And i ← intersection(4, s2)
	When comps ← prepare_computations(i, r)
	And c ← shade_hit(w, comps)
	Then c = color(0.1, 0.1, 0.1)