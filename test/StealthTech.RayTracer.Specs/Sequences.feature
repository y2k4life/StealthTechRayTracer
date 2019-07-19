Feature: Sequences

Scenario: A number generator returns a cyclic sequence of numbers
	Given generator ← Sequence(0.1, 0.5, 1.0)
	Then generator.Next() = 0.1
	And generator.Next() = 0.5
	And generator.Next() = 1.0
	And generator.Next() = 0.1