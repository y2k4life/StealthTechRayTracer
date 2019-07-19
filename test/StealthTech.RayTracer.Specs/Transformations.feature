Feature: Transformations

Scenario: Multiplying by a translation matrix
	Given transform ← translation(5, -3, 2)
	And point ← Point(-3, 4, 5)
	Then transform * point = Point(2, 1, 7)

Scenario: Multiplying by the inverse of a translation matrix
	Given transform ← translation(5, -3, 2)
	And inverseTransform ← inverse(transform)
	And point ← Point(-3, 4, 5)
	Then inverseTransform * p = Point(-8, 7, 3)

Scenario: Translation does not affect vectors
	Given transform ← translation(5, -3, 2)
	And vector ← Vector(-3, 4, 5)
	Then transform * v = v

Scenario: A scaling matrix applied to a point
	Given transform ← scaling(2, 3, 4)
	And point ← Point(-4, 6, 8)
	Then transform * point = Point(-8, 18, 32)

Scenario: A scaling matrix applied to a vector
	Given transform ← scaling(2, 3, 4)
	And vector ← Vector(-4, 6, 8)
	Then transform * vector = Vector(-8, 18, 32)

Scenario: Multiplying by the inverse of a scaling matrix
	Given transform ← scaling(2, 3, 4)
	And inverseTransform ← inverse(transform)
	And vector ← Vector(-4, 6, 8)
	Then inverseTransform * vector = Vector(-2, 2, 2)

Scenario: Rotating a point around the x axis
	Given point ← Point(0, 1, 0)
	And halfQuarter ← rotation_x(π / 4)
	And fullQuarter ← rotation_x(π / 2)
	Then halfQuarter * point = Point(0, √2/2, √2/2)
	And fullQuarter * point = Point(0, 0, 1)

Scenario: The inverse of an x-rotation rotates in the opposite direction
	Given point ← Point(0, 1, 0)
	And halfQuarter ← rotation_x(π / 4)
	And inverseTransform ← inverse(half_quarter)
	Then inverseTransform * p = Point(0, √2/2, -√2/2)

Scenario: Rotating a point around the y axis
	Given point ← Point(0, 0, 1)
	And half_quarter ← rotation_y(π / 4)
	And fullQuarter ← rotation_y(π / 2)
	Then halfQuarter * point = Point(√2/2, 0, √2/2)
	And fullQuarter * point = Point(1, 0, 0)

Scenario: Rotating a point around the z axis
	Given point ← Point(0, 1, 0)
	And halfQuarter ← rotation_z(π / 4)
	And full_quarter ← rotation_z(π / 2)
	Then halfQuarter * point = Point(-√2/2, √2/2, 0)
	And fullQuarter * point = Point(-1, 0, 0)

Scenario: A shearing transformation moves x in proportion to y
	Given transform ← shearing(1, 0, 0, 0, 0, 0)
	And point ← Point(2, 3, 4)
	Then transform * point = Point(5, 3, 4)

Scenario: A shearing transformation moves y in proportion to x
	Given transform ← shearing(0, 0, 1, 0, 0, 0)
	And point ← Point(2, 3, 4)
	Then transform * point = Point(2, 5, 4)

Scenario: A shearing transformation moves y in proportion to z
	Given transform ← shearing(0, 0, 0, 1, 0, 0)
	And point ← Point(2, 3, 4)
	Then transform * point = Point(2, 7, 4)

Scenario: A shearing transformation moves z in proportion to x
	Given transform ← shearing(0, 0, 0, 0, 1, 0)
	And point ← Point(2, 3, 4)
	Then transform * point = Point(2, 3, 6)

Scenario: A shearing transformation moves z in proportion to y
	Given transform ← shearing(0, 0, 0, 0, 0, 1)
	And point ← Point(2, 3, 4)
	Then transform * point = Point(2, 3, 7)

Scenario: Individual transformations are applied in sequence
	Given point ← Point(1, 0, 1)
	And transformA ← rotation_x(π / 2)
	And transformB ← scaling(5, 5, 5)
	And transformC ← translation(10, 5, 7)
	# apply rotation first
	When point2 ← transformA * point
	Then point2 = Point(1, -1, 0)
	# then apply scaling
	When point3 ← transformB * point2
	Then point3 = Point(5, -5, 0)
	# then apply translation
	When point4 ← transformC * point3
	Then point4 = Point(15, 0, 7)

Scenario: Chained transformations must be applied in reverse order
	Given point ← Point(1, 0, 1)
	And transformA ← rotation_x(π / 2)
	And transformB ← scaling(5, 5, 5)
	And transformC ← translation(10, 5, 7)
	When transformT ← transformC * transformB * transformA
	Then transformT * point = Point(15, 0, 7)

Scenario: Fluent chained transformations
	Given point ← Point(1, 0, 1)
	When transformT ← rotation_x(π / 2).scaling(5, 5, 5).translation(10, 5, 7)
	Then transformT * point = Point(15, 0, 7)

Scenario: The transformation matrix for the default orientation
	Given from ← Point(0, 0, 0)
	And to ← Point(0, 0, -1)
	And up ← Vector(0, 1, 0)
	When transform ← ViewTransform(from, to, up)
	Then transform = identity_matrix

Scenario: A view transformation matrix looking in positive z direction
	Given from ← Point(0, 0, 0)
	And to ← Point(0, 0, 1)
	And up ← Vector(0, 1, 0)
	When transform ← ViewTransform(from, to, up)
	Then transform = scaling(-1, 1, -1)

Scenario: The view transformation moves the world
	Given from ← Point(0, 0, 8)
	And to ← Point(0, 0, 0)
	And up ← Vector(0, 1, 0)
	When transform ← ViewTransform(from, to, up)
	Then transform = translation(0, 0, -8)

#Scenario: An arbitrary view transformation
#	Given from ← Point(1, 3, 2)
#	And to ← Point(4, -2, 8)
#	And up ← Vector(1, 1, 0)
#	When transform ← ViewTransform(from, to, up)
#	Then t is the following matrix:
#		| -0.50709 | 0.50709 | 0.67612  | -2.36643 |
#		| 0.76772  | 0.60609 | 0.12122  | -2.82843 |
#		| -0.35857 | 0.59761 | -0.71714 | 0.00000  |
#		| 0.00000  | 0.00000 | 0.00000  | 1.00000  |