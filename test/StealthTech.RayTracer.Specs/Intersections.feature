﻿Feature: Intersections

Scenario: An intersection encapsulates t and object
	Given s ← sphere()
	When i ← intersection(3.5, s)
	Then i.Time = 3.5
	And i.Item = s

Scenario: Aggregating intersections
	Given s ← sphere()
	And i1 ← intersection(1, s)
	And i2 ← intersection(2, s)
	When xs ← intersections(i1, i2)
	Then xs.count = 2
	And xs[0].Time = 1
	And xs[1].Time = 2

Scenario: The hit, when all intersections have positive t
	Given s ← sphere()
	And i1 ← intersection(1, s)
	And i2 ← intersection(2, s)
	And xs ← intersections(i1, i2)
	When i ← hit(xs)
	Then i = i1

Scenario: The hit, when some intersections have negative t
	Given s ← sphere()
	And i1 ← intersection(-1, s)
	And i2 ← intersection(1, s)
	And xs ← intersections(i1, i2)
	When i ← hit(xs)
	Then i = i2

Scenario: The hit, when all intersections have negative t
	Given s ← sphere()
	And i1 ← intersection(-2, s)
	And i2 ← intersection(-1, s)
	And xs ← intersections(i1, i2)
	When i ← hit(xs)
	Then i is nothing

Scenario: The hit is always the lowest nonnegative intersection
	Given s ← sphere()
	And i1 ← intersection(5, s)
	And i2 ← intersection(7, s)
	And i3 ← intersection(-3, s)
	And i4 ← intersection(2, s)
	And xs ← intersections(i1, i2, i3, i4)
	When i ← hit(xs)
	Then i = i4