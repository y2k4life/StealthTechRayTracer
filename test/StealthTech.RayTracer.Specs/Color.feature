Feature: Color

Scenario: Colors are (red, green, blue) tuples
	Given c <- Color(-0.5, 0.4, 1.7)
	Then c.Red = -0.5
	And c.Green = 0.4
	And c.Blue = 1.7

Scenario: Adding colors
	Given c1 <- Color(0.9, 0.6, 0.75)
	And c2 <- Color(0.7, 0.1, 0.25)
	Then c1 + c2 = Color(1.6, 0.7, 1.0)

Scenario: Subtracting colors
	Given c1 <- Color(0.9, 0.6, 0.75)
	And c2 <- Color(0.7, 0.1, 0.25)
	Then c1 - c2 = Color(0.2, 0.5, 0.5)

Scenario: Multiplying a color by a scalar
	Given c <- Color(0.2, 0.3, 0.4)
	Then c * 2 = Color(0.4, 0.6, 0.8)

Scenario: Multiplying colors
	Given c1 <- Color(1, 0.2, 0.4)
	And c2 <- Color(0.9, 1, 0.1)
	Then c1 * c2 = Color(0.9, 0.2, 0.04)