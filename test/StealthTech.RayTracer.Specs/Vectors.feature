Feature: Vectors

Scenario: Vector() creates tuples with w=0
	Given vector ← Vector(4, -4, 3)
	Then vector = Tuple(4, -4, 3, 0)

Scenario: Subtracting two vectors
	Given vector1 ← Vector(3, 2, 1)
	And vector2 ← Vector(5, 6, 7)
	Then vector1 - vector2 = Vector(-2, -4, -6)

Scenario: Subtracting a vector from the zero vector
	Given zeroVector ← Vector(0, 0, 0)
	And vector ← Vector(1, -2, 3)
	Then zeroVector - vector = Vector(-1, 2, -3)

Scenario: Computing the magnitude of Vector(1, 0, 0)
	Given vector ← Vector(1, 0, 0)
	Then magnitude(vector) = 1

Scenario: Computing the magnitude of Vector(0, 1, 0)
	Given vector ← Vector(0, 1, 0)
	Then magnitude(vector) = 1

Scenario: Computing the magnitude of Vector(0, 0, 1)
	Given vector ← Vector(0, 0, 1)
	Then magnitude(vector) = 1

Scenario: Computing the magnitude of Vector(1, 2, 3)
	Given vector ← Vector(1, 2, 3)
	Then magnitude(vector) = 3.74165738677394

Scenario: Computing the magnitude of Vector(-1, -2, -3)
	Given vector ← Vector(-1, -2, -3)
	Then magnitude(vector) = 3.74165738677394

Scenario: Normalizing Vector(4, 0, 0) gives (1, 0, 0)
	Given vector ← Vector(4, 0, 0)
	Then normalize(vector) = Vector(1, 0, 0)

Scenario: Normalizing Vector(1, 2, 3) gives (0.26726, 0.53452, 0.80178)
	Given vector ← Vector(1, 2, 3)
	Then normalize(vector) = approximately Vector(0.26726, 0.53452, 0.80178)

Scenario: The magnitude of a normalized vector
	Given vector ← Vector(1, 2, 3)
	When normalizedVector ← normalize(v)
	Then magnitude(normalizedVector) = 1

Scenario: The dot product of two vectors
	Given vector1 ← Vector(1, 2, 3)
	And vector2 ← Vector(2, 3, 4)
	Then dot(vector1, vector2) = 20

Scenario: The cross product of two vectors
	Given vector1 ← Vector(1, 2, 3)
	And vector2 ← Vector(2, 3, 4)
	Then cross(vector1, vector2) = Vector(-1, 2, -1)
	And cross(vector2, vector1) = Vector(1 -2, 1)

Scenario: Reflecting a vector approaching at 45°
	Given vector ← Vector(1, -1, 0)
	And normalVector ← Vector(0, 1, 0)
	When reflect ← reflect(v, n)
	Then reflect = Vector(1, 1, 0)

Scenario: Reflecting a vector off a slanted surface
	Given vector ← Vector(0, -1, 0)
	And normalVector ← Vector(0.707106, 0.707106, 0)
	When reflect ← reflect(v, n)
	Then reflect = Vector(1, 0, 0)