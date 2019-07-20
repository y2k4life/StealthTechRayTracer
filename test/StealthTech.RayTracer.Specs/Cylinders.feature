Feature: Cylinders

Scenario Outline: A ray misses a cylinder
	Given cylinder ← cylinder()
	And direction ← <direction>.Normalize()
	And ray ← Ray(<origin>, direction)
	When intersections ← cylinder.LocalIntersect(ray)
	Then intersections.Count = 0

	Examples:
		| origin          | direction       |
		| Point(1, 0, 0)  | Vector(0, 1, 0) |
		| Point(0, 0, 0)  | Vector(0, 1, 0) |
		| Point(0, 0, -5) | Vector(1, 1, 1) |

Scenario Outline: A ray strikes a cylinder
	Given cylinder ← cylinder()
	And direction ← <direction>.Normalize()
	And ray ← Ray(<origin>, direction)
	When intersections ← cylinder.LocalIntersect(ray)
	Then intersections.Count = 2
	And intersections[0].Time = <t0>
	And intersections[1].Time = <t1>

	Examples:
		| origin            | direction         | t0      | t1      |
		| Point(1, 0, -5)   | Vector(0, 0, 1)   | 5       | 5       |
		| Point(0, 0, -5)   | Vector(0, 0, 1)   | 4       | 6       |
		| Point(0.5, 0, -5) | Vector(0.1, 1, 1) | 6.80798 | 7.08872 |

Scenario Outline: Normal vector on a cylinder
	Given cylinder ← cylinder()
	When normalVector ← cylinder.LocalNormalAt(<point>)
	Then normalVector = <normal>

	Examples:
		| point           | normal           |
		| Point(1, 0, 0)  | Vector(1, 0, 0)  |
		| Point(0, 5, -1) | Vector(0, 0, -1) |
		| Point(0, -2, 1) | Vector(0, 0, 1)  |
		| Point(-1, 1, 0) | Vector(-1, 0, 0) |

Scenario: The default minimum and maximum for a cylinder
	Given cylinder ← cylinder()
	Then cylinder.Minimum = -infinity
	And cylinder.Maximum = infinity

Scenario Outline: Intersecting a constrained cylinder
	Given cylinder ← cylinder()
	And cylinder.Minimum ← 1
	And cylinder.Maximum ← 2
	And direction ← <direction>.Normalize()
	And ray ← Ray(<point>, direction)
	When intersections ← cylinder.LocalIntersect(ray)
	Then intersections.Count = <count>

	Examples:
		| point             | direction         | count |
		| Point(0, 1.5, 0)  | Vector(0.1, 1, 0) | 0     |
		| Point(0, 3, -5)   | Vector(0, 0, 1)   | 0     |
		| Point(0, 0, -5)   | Vector(0, 0, 1)   | 0     |
		| Point(0, 2, -5)   | Vector(0, 0, 1)   | 0     |
		| Point(0, 1, -5)   | Vector(0, 0, 1)   | 0     |
		| Point(0, 1.5, -2) | Vector(0, 0, 1)   | 2     |

Scenario: The default closed value for a cylinder
	Given cylinder ← cylinder()
	Then cylinder.IsClosed = false

Scenario Outline: Intersecting the caps of a closed cylinder
	Given cylinder ← cylinder()
	And cylinder.Minimum ← 1
	And cylinder.Maximum ← 2
	And cylinder.IsClosed ← true
	And direction ← <direction>.Normalize()
	And ray ← Ray(<point>, direction)
	When intersections ← cylinder.LocalIntersect(ray)
	Then intersections.Count = <count>

	Examples:
		| point            | direction        | count |
		| Point(0, 3, 0)   | Vector(0, -1, 0) | 2     |
		| Point(0, 3, -2)  | Vector(0, -1, 2) | 2     |
		| Point(0, 4, -2)  | Vector(0, -1, 1) | 2     |
		| Point(0, 0, -2)  | Vector(0, 1, 2)  | 2     |
		| Point(0, -1, -2) | Vector(0, 1, 1)  | 2     |

Scenario Outline: The normal vector on a cylinder's end caps
	Given cylinder ← cylinder()
	And cylinder.Minimum ← 1
	And cylinder.Maximum ← 2
	And cylinder.IsClosed ← true
	When normalVector ← cylinder.LocalNormalAt(<point>)
	Then normalVector = <normal>

	Examples:
		| point            | normal           |
		| Point(0, 1, 0)   | Vector(0, -1, 0) |
		| Point(0.5, 1, 0) | Vector(0, -1, 0) |
		| Point(0, 1, 0.5) | Vector(0, -1, 0) |
		| Point(0, 2, 0)   | Vector(0, 1, 0)  |
		| Point(0.5, 2, 0) | Vector(0, 1, 0)  |
		| Point(0, 2, 0.5) | Vector(0, 1, 0)  |