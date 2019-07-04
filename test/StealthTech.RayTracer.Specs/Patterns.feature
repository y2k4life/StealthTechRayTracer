Feature: Patterns

Background:
	Given black ← Color(0, 0, 0)
	And white ← Color(1, 1, 1)

Scenario: Creating a stripe pattern
	Given stripePattern ← StripePattern(white, black)
	Then pattern.ColorA = white
	And pattern.ColorB = black

Scenario: A stripe pattern is constant in y
	Given pattern ← StripePattern(white, black)
	Then pattern.PatternAt(Point(0, 0, 0)) = white
	And pattern.PatternAt(Point(0, 1, 0)) = white
	And pattern.PatternAt(Point(0, 2, 0)) = white

Scenario: A stripe pattern is constant in z
	Given pattern ← StripePattern(white, black)
	Then pattern.PatternAt(Point(0, 0, 0)) = white
	And pattern.PatternAt(Point(0, 0, 1)) = white
	And pattern.PatternAt(Point(0, 0, 2)) = white

Scenario: A stripe pattern alternates in x
	Given pattern ← StripePattern(white, black)
	Then pattern.PatternAt(Point(0, 0, 0)) = white
	And pattern.PatternAt(Point(0.9, 0, 0)) = white
	And pattern.PatternAt(Point(1, 0, 0)) = black
	And pattern.PatternAt(Point(-0.1, 0, 0)) = black
	And pattern.PatternAt(Point(-1, 0, 0)) = black
	And pattern.PatternAt(Point(-1.1, 0, 0)) = white

Scenario: Stripes with an object transformation
	Given sphere ← Sphere()
	And sphere.Transform ← scaling(2, 2, 2)
	And pattern ← TestPattern()
	When color ← pattern.PatternAtShape(sphere, Point(2, 3, 4))
	Then color = Color(1, 1.5, 2)

Scenario: Stripes with a pattern transformation
	Given sphere ← Sphere()
	And pattern ← StripePattern(white, black)
	And pattern.Transform ← scaling(2, 2, 2)
	When color ← pattern.PatternAtShape(sphere, Point(1.5, 0, 0))
	Then color = white

Scenario: Stripes with both an object and a pattern transformation
	Given sphere ← Sphere()
	And sphere.Transform ← scaling(2, 2, 2)
	And pattern ← StripePattern(white, black)
	And pattern.Transform ← translation(0.5, 0, 0)
	When color ← pattern.PatternAtShape(sphere, Point(2.5, 0, 0))
	Then color = white

Scenario: The default pattern transformation
	Given pattern ← TestPattern()
	Then pattern.Transform = identityMatrix

Scenario: Assigning a transformation
	Given pattern ← TestPattern()
	When pattern.Transform ← translation(1, 2, 3)
	Then pattern.Transform = translation(1, 2, 3)

Scenario: A gradient linearly interpolates between colors
	Given pattern ← GradientPattern(white, black)
	Then pattern.PatternAt(Point(0, 0, 0)) = white
	And pattern.PatternAt(Point(0.25, 0, 0)) = color(0.75, 0.75, 0.75)
	And pattern.PatternAt(Point(0.5, 0, 0)) = color(0.5, 0.5, 0.5)
	And pattern.PatternAt(Point(0.75, 0, 0)) = color(0.25, 0.25, 0.25)

Scenario: A ring should extend in both x and z
	Given pattern ← RingPattern(white, black)
	Then pattern.PatternAt(Point(0, 0, 0)) = white
	And pattern.PatternAt(Point(1, 0, 0)) = black
	And pattern.PatternAt(Point(0, 0, 1)) = black
	# 0.708 = just slightly more than √2/2
	And pattern.PatternAt(Point(0.708, 0, 0.708)) = black

Scenario: Checkers should repeat in x
  Given pattern ← CheckersPattern(white, black)
  Then pattern.PatternAt(Point(0, 0, 0)) = white
    And pattern.PatternAt(Point(0.99, 0, 0)) = white
    And pattern.PatternAt(Point(1.01, 0, 0)) = black

Scenario: Checkers should repeat in y
  Given pattern ← CheckersPattern(white, black)
  Then pattern.PatternAt(Point(0, 0, 0)) = white
    And pattern.PatternAt(Point(0, 0.99, 0)) = white
    And pattern.PatternAt(Point(0, 1.01, 0)) = black

Scenario: Checkers should repeat in z
  Given pattern ← CheckersPattern(white, black)
  Then pattern.PatternAt(Point(0, 0, 0)) = white
    And pattern.PatternAt(Point(0, 0, 0.99)) = white
    And pattern.PatternAt(Point(0, 0, 1.01)) = black