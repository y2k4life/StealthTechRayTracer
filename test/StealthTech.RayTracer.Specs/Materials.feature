Feature: Materials

Background:
	Given material ← Material()
	And computations ← Computations()
	And computations.Shape = Sphere()

Scenario: The default material
	Given material ← Material()
	Then material.Color = Color(1, 1, 1)
	And material.Ambient = 0.1
	And material.Diffuse = 0.9
	And material.Specular = 0.9
	And material.Shininess = 200.0

Scenario: Lighting with the eye between the light and the surface
	Given computations.EyeVector ← Vector(0, 0, -1)
	And computations.NormalVector ← Vector(0, 0, -1)
	And light ← PointLight(Point(0, 0, -10), Color(1, 1, 1))
	When result ← lighting(m, light, position, eyeVector, normalVector)
	Then result = Color(1.9, 1.9, 1.9)

Scenario: Lighting with the eye between light and surface, eye offset 45°
	Given computations.EyeVector ← Vector(0, √2/2, -√2/2)
	And computations.NormalVector ← Vector(0, 0, -1)
	And light ← PointLight(Point(0, 0, -10), Color(1, 1, 1))
	When result ← lighting(m, light, position, eyeVector, normalVector)
	Then result = Color(1.0, 1.0, 1.0)

Scenario: Lighting with eye opposite surface, light offset 45°
	Given computations.EyeVector ← Vector(0, 0, -1)
	And computations.NormalVector ← Vector(0, 0, -1)
	And light ← PointLight(Point(0, 10, -10), Color(1, 1, 1))
	When result ← lighting(m, light, position, eyeVector, normalVector)
	Then result = Color(0.7364, 0.7364, 0.7364)

Scenario: Lighting with eye in the path of the reflection vector
	Given computations.EyeVector ← Vector(0, -√2/2, -√2/2)
	And computations.NormalVector ← Vector(0, 0, -1)
	And light ← PointLight(Point(0, 10, -10), Color(1, 1, 1))
	When result ← lighting(m, light, position, eyeVector, normalVector)
	Then result = Color(1.6364, 1.6364, 1.6364)

Scenario: Lighting with the light behind the surface
	Given computations.EyeVector ← Vector(0, 0, -1)
	And computations.NormalVector ← Vector(0, 0, -1)
	And light ← PointLight(Point(0, 0, 10), Color(1, 1, 1))
	When result ← lighting(m, light, position, eyeVector, normalVector)
	Then result = Color(0.1, 0.1, 0.1)

Scenario: Lighting with the surface in shadow
	Given computations.EyeVector ← Vector(0, 0, -1)
	And computations.NormalVector ← Vector(0, 0, -1)
	And light ← PointLight(Point(0, 0, -10), Color(1, 1, 1))
	And inShadow ← true
	When result ← lighting(m, light, position, eyeVector, normalVector, inShadow)
	Then result = Color(0.1, 0.1, 0.1)

Scenario: Lighting with a pattern applied
	Given material.Pattern ← StripePattern(color(1, 1, 1), color(0, 0, 0))
	And material.Ambient ← 1
	And material.Diffuse ← 0
	And material.Specular ← 0
	And computations.EyeVector ← Vector(0, 0, -1)
	And computations.NormalVector ← Vector(0, 0, -1)
	And light ← PointLight(Point(0, 0, -10), Color(1, 1, 1))
	When color1 ← lighting(m, light, Point(0.9, 0, 0), eyeVector, normalVector, false)
	And color2 ← lighting(m, light, Point(1.1, 0, 0), eyeVector, normalVector, false)
	Then color1 = Color(1, 1, 1)
	And color2 = Color(0, 0, 0)

Scenario: Reflectivity for the default material
	Given material ← Material()
	Then material.Reflective = 0.0

Scenario: Transparency and Refractive Index for the default material
	Given material ← Material()
	Then material.Transparency = 0.0
	And material.RefractiveIndex = 1.0