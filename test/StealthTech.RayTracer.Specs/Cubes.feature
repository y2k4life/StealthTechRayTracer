Feature: Cubes

Scenario Outline: A ray intersects a cube
	Given cube ← Cube()
	And ray ← Ray(<origin>, <direction>)
	When intersections ← cube.LocalIntersect(ray)
	Then intersections.Count = 2
	And intersections[0].Time = <t1>
	And intersections[1].Time = <t2>

	Examples:
		| index  | origin            | direction        | t1 | t2 |
		| +x     | Point(5, 0.5, 0)  | Vector(-1, 0, 0) | 4  | 6  |
		| -x     | Point(-5, 0.5, 0) | Vector(1, 0, 0)  | 4  | 6  |
		| +y     | Point(0.5, 5, 0)  | Vector(0, -1, 0) | 4  | 6  |
		| -y     | Point(0.5, -5, 0) | Vector(0, 1, 0)  | 4  | 6  |
		| +z     | Point(0.5, 0, 5)  | Vector(0, 0, -1) | 4  | 6  |
		| -z     | Point(0.5, 0, -5) | Vector(0, 0, 1)  | 4  | 6  |
		| inside | Point(0, 0.5, 0)  | Vector(0, 0, 1)  | -1 | 1  |

Scenario Outline: A ray misses a cube
	Given cube ← Cube()
	And ray ← Ray(<origin>, <direction>)
	When intersections ← cube.LocalIntersect(ray)
	Then intersections.Count = 0

	Examples:
		| origin          | direction                      |
		| Point(-2, 0, 0) | Vector(0.2673, 0.5345, 0.8018) |
		| Point(0, -2, 0) | Vector(0.8018, 0.2673, 0.5345) |
		| Point(0, 0, -2) | Vector(0.5345, 0.8018, 0.2673) |
		| Point(2, 0, 2)  | Vector(0, 0, -1)               |
		| Point(0, 2, 2)  | Vector(0, -1, 0)               |
		| Point(2, 2, 0)  | Vector(-1, 0, 0)               |

Scenario Outline: The normal on the surface of a cube
	Given cube ← Cube()
	And point ← <point>
	When normalVector ← cube.LocalNormalAt(point)
	Then normalVector = <normal>

	Examples:
		| point                | normal           |
		| Point(1, 0.5, -0.8)  | Vector(1, 0, 0)  |
		| Point(-1, -0.2, 0.9) | Vector(-1, 0, 0) |
		| Point(-0.4, 1, -0.1) | Vector(0, 1, 0)  |
		| Point(0.3, -1, -0.7) | Vector(0, -1, 0) |
		| Point(-0.6, 0.3, 1)  | Vector(0, 0, 1)  |
		| Point(0.4, 0.4, -1)  | Vector(0, 0, -1) |
		| Point(1, 1, 1)       | Vector(1, 0, 0)  |
		| Point(-1, -1, -1)    | Vector(-1, 0, 0) |