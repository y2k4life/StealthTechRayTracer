Feature: Tuples

Scenario: A tuple with w=1.0 is a point
	Given a ← tuple(4.3, -4.2, 3.1, 1.0)
	Then a.X = 4.3
	And a.Y = -4.2
	And a.Z = 3.1
	And a.W = 1.0
	And a is a point
	And a is not a vector

Scenario: A tuple with w=0 is a vector
	Given a ← tuple(4.3, -4.2, 3.1, 0.0)
	Then a.X = 4.3
	And a.Y = -4.2
	And a.Z = 3.1
	And a.W = 0.0
	And a is not a point
	And a is a vector

Scenario: Adding two tuples
	Given a1 ← tuple(3, -2, 5, 1)
	And a2 ← tuple(-2, 3, 1, 0)
	Then a1 + a2 = tuple(1, 1, 6, 1)

Scenario: Negating a tuple
	Given a ← tuple(1, -2, 3, -4)
	Then -a = tuple(-1, 2, -3, 4)

Scenario: Multiplying a tuple by a scalar
	Given a ← tuple(1, -2, 3, -4)
	Then a * 3.5 = tuple(3.5, -7, 10.5, -14)
	And 3.5 * a = tuple(3.5, -7, 10.5, -14)

Scenario: Multiplying a tuple by a fraction
	Given a ← tuple(1, -2, 3, -4)
	Then a * 0.5 = tuple(0.5, -1, 1.5, -2)

Scenario: Dividing a tuple by a scalar
	Given a ← tuple(1, -2, 3, -4)
	Then a / 2 = tuple(0.5, -1, 1.5, -2)
