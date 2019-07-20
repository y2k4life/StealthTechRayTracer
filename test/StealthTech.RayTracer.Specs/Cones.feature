Feature: Cones

Scenario Outline: Intersecting a cone with a ray
	Given cone ← Cone()
	And direction ← <direction>.Normalize()
	And ray ← Ray(<origin>, direction)
	When intersections ← cone.LocalIntersect(ray)
	Then intersections.Count = 2
	And intersections[0].Time = <t0>
	And intersections[1].Time = <t1>

	Examples:
		| origin          | direction           | t0      | t1       |
		| Point(0, 0, -5) | Vector(0, 0, 1)     | 5       | 5        |
		| Point(0, 0, -5) | Vector(1, 1, 1)     | 8.66025 | 8.66025  |
		| Point(1, 1, -5) | Vector(-0.5, -1, 1) | 4.55006 | 49.44994 |

Scenario: Intersecting a cone with a ray parallel to one of its halves
	Given cone ← Cone()
	And direction ← Vector(0, 1, 1).Normalize()
	And ray ← Ray(Point(0, 0, -1), direction)
	When intersections ← cone.LocalIntersect(ray)
	Then intersections.Count = 1
	And intersections[0].Time = 0.35355

Scenario Outline: Intersecting a cone's end caps
	Given cone ← Cone()
	And cone.Minimum ← -0.5
	And cone.Maximum ← 0.5
	And cone.IsClosed ← true
	And direction ← <direction>.Normalize()
	And ray ← Ray(<origin>, direction)
	When intersections ← cone.LocalIntersect(ray)
	Then intersections.Count = <count>

	Examples:
		| origin             | direction       | count |
		| Point(0, 0, -5)    | Vector(0, 1, 0) | 0     |
		| Point(0, 0, -0.25) | Vector(0, 1, 1) | 2     |
		| Point(0, 0, -0.25) | Vector(0, 1, 0) | 4     |

Scenario Outline: Computing the normal vector on a capped cone
	Given cone ← Cone()
	When normalVector ← cone.LocalNormalAt(<point>)
	Then normalVector = <normal>

	Examples:
		| point            | normal            |
		| Point(0, 0, 0)   | Vector(0, 0, 0)   |
		| Point(1, 1, 1)   | Vector(1, -√2, 1) |
		| Point(-1, -1, 0) | Vector(-1, 1, 0)  |

Scenario Outline: Computing the normal vector on a cone
	Given cone ← Cone()
	And cone.Minimum ← 1
	And cone.Maximum ← 2
	And cone.IsClosed ← true
	When normalVector ← cone.LocalNormalAt(<point>)
	Then normalVector = <normal>

	Examples:
		| point          | normal           |
		| Point(0, 1, 0) | Vector(0, -1, 0) |
		| Point(0, 2, 0) | Vector(0, 1, 0)  |
		| Point(0.5, 2, 0) | Vector(0, 1, 0)  |