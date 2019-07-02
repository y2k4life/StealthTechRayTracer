Feature: Point

Scenario: point() creates tuples with w=1
	Given point ← Point(4, -4, 3)
	Then point = tuple(4, -4, 3, 1)

Scenario: Subtracting two points
	Given point1 ← Point(3, 2, 1)
	And point2 ← Point(5, 6, 7)
	Then point1 - point2 = Vector(-2, -4, -6)

Scenario: Subtracting a vector from a point
	Given point ← Point(3, 2, 1)
	And vector ← Vector(5, 6, 7)
	Then point - vector = Point(-2, -4, -6)