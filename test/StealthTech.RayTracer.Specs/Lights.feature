Feature: Lights

Scenario: A point light has a position and intensity
	Given intensity ← color(1, 1, 1)
	And position ← Point(0, 0, 0)
	When light ← point_light(position, intensity)
	Then light.position = position
	And light.intensity = intensity

Scenario Outline: Point lights evaluate the light intensity at a given point
	Given world ← default_world()
	And light ← world.Light
	And point ← <point>
	When intensityAt ← light.IntensityAt(point, world)
	Then intensityAt = <result>

	Examples:
		| point                | result |
		| Point(0, 1.0001, 0)  | 1.0    |
		| Point(-1.0001, 0, 0) | 1.0    |
		| Point(0, 0, -1.0001) | 1.0    |
		| Point(0, 0, 1.0001)  | 0.0    |
		| Point(1.0001, 0, 0)  | 0.0    |
		| Point(0, -1.0001, 0) | 0.0    |
		| Point(0, 0, 0)       | 0.0    |

Scenario: Creating an area light
	Given corner ← Point(0, 0, 0)
	And vector1 ← Vector(2, 0, 0)
	And vector2 ← Vector(0, 0, 1)
	When areaLight ← AreaLight(corner, vector1, 4, vector2, 2, Color(1, 1, 1))
	Then areaLight.Corner = corner
	And areaLight.UVector = Vector(0.5, 0, 0)
	And areaLight.USteps = 4
	And areaLight.VVector = vector(0, 0, 0.5)
	And areaLight.VSteps = 2
	And areaLight.Samples = 8
	And areaLight.Position = point(1, 0, 0.5)

Scenario Outline: Finding a single point on an area light
	Given corner ← Point(0, 0, 0)
	And vector1 ← Vector(2, 0, 0)
	And vector2 ← Vector(0, 0, 1)
	And areaLight ← AreaLight(corner, vector1, 4, vector2, 2, Color(1, 1, 1))
	When point ← areaLight.PointOnLight(<u>, <v>)
	Then point = <result>

	Examples:
		| u | v | result               |
		| 0 | 0 | Point(0.25, 0, 0.25) |
		| 1 | 0 | Point(0.75, 0, 0.25) |
		| 0 | 1 | Point(0.25, 0, 0.75) |
		| 2 | 0 | Point(1.25, 0, 0.25) |
		| 3 | 1 | Point(1.75, 0, 0.75) |

Scenario Outline: The area light intensity function
	Given world ← default_world()
	And corner ← Point(-0.5, -0.5, -5)
	And vector1 ← Vector(1, 0, 0)
	And vector2 ← Vector(0, 1, 0)
	And light ← AreaLight(corner, vector1, 2, vector2, 2, Color(1, 1, 1))
	And point ← <point>
	When intensityAt ← light.IntensityAt(point, world)
	Then intensityAt = <result>

	Examples:
		| point                | result |
		| Point(0, 0, 2)       | 0.0    |
		| Point(1, -1, 2)      | 0.25   |
		| Point(1.5, 0, 2)     | 0.5    |
		| Point(1.25, 1.25, 3) | 0.75   |
		| Point(0, 0, -2)      | 1.0    |

Scenario Outline: Finding a single point on a jittered area light
	Given corner ← Point(0, 0, 0)
	And vector1 ← Vector(2, 0, 0)
	And vector2 ← Vector(0, 0, 1)
	And areaLight ← AreaLight(corner, vector1, 4, vector2, 2, Color(1, 1, 1))
	And areaLight.JitterBy ← Sequence(0.3, 0.7)
	When point ← areaLight.PointOnLight(<u>, <v>)
	Then point = <result>

	Examples:
		| u | v | result               |
		| 0 | 0 | Point(0.15, 0, 0.35) |
		| 1 | 0 | Point(0.65, 0, 0.35) |
		| 0 | 1 | Point(0.15, 0, 0.85) |
		| 2 | 0 | Point(1.15, 0, 0.35) |
		| 3 | 1 | Point(1.65, 0, 0.85) |

Scenario Outline: The area light with jittered samples
	Given world ← default_world()
	And corner ← Point(-0.5, -0.5, -5)
	And vector1 ← Vector(1, 0, 0)
	And vector2 ← Vector(0, 1, 0)
	And areaLight ← AreaLight(corner, vector1, 2, vector2, 2, Color(1, 1, 1))
	And areaLight.JitterBy ← Sequence(0.7, 0.3, 0.9, 0.1, 0.5)
	And point ← <point>
	When intensityAt ← areaLight.IntensityAt(point, world)
	Then intensityAt = <result>

	Examples:
		| point                | result |
		| Point(0, 0, 2)       | 0.0    |
		| Point(1, -1, 2)      | 0.5    |
		| Point(1.5, 0, 2)     | 0.75   |
		| Point(1.25, 1.25, 3) | 0.75   |
		| Point(0, 0, -2)      | 1.0    |