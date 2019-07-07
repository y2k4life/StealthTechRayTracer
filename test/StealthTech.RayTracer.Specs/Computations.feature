Feature: Computations

Scenario: The default computations
	Given computations ← Computations()
	Then computations.EyeVector = Vector(0, 0, 0)
	And computations.Position = Point(0, 0, 0)
	And computations.NormalVector = Vector(0, 0, 0)