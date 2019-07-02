Feature: Materials

Background:
	Given material ← Material()
	And position ← Point(0, 0, 0)

Scenario: The default material
	Given material ← Material()
	Then material.Color = Color(1, 1, 1)
	And material.Ambient = 0.1
	And material.Diffuse = 0.9
	And material.Specular = 0.9
	And material.Shininess = 200.0

Scenario: Lighting with the eye between the light and the surface
	Given eyeVector ← Vector(0, 0, -1)
	And normalVector ← Vector(0, 0, -1)
	And light ← PointLight(Point(0, 0, -10), Color(1, 1, 1))
	When result ← lighting(m, light, position, eyeVector, normalVector)
	Then result = Color(1.9, 1.9, 1.9)

Scenario: Lighting with the eye between light and surface, eye offset 45°
	Given eyeVector ← Vector(0, √2/2, -√2/2)
	And normalVector ← Vector(0, 0, -1)
	And light ← PointLight(Point(0, 0, -10), Color(1, 1, 1))
	When result ← lighting(m, light, position, eyeVector, normalVector)
	Then result = Color(1.0, 1.0, 1.0)

Scenario: Lighting with eye opposite surface, light offset 45°
	Given eyeVector ← Vector(0, 0, -1)
	And normalVector ← Vector(0, 0, -1)
	And light ← PointLight(Point(0, 10, -10), Color(1, 1, 1))
	When result ← lighting(m, light, position, eyeVector, normalVector)
	Then result = Color(0.7364, 0.7364, 0.7364)

Scenario: Lighting with eye in the path of the reflection vector
	Given eyeVector ← Vector(0, -√2/2, -√2/2)
	And normalVector ← Vector(0, 0, -1)
	And light ← PointLight(Point(0, 10, -10), Color(1, 1, 1))
	When result ← lighting(m, light, position, eyeVector, normalVector)
	Then result = Color(1.6364, 1.6364, 1.6364)

Scenario: Lighting with the light behind the surface
	Given eyeVector ← Vector(0, 0, -1)
	And normalVector ← Vector(0, 0, -1)
	And light ← PointLight(Point(0, 0, 10), Color(1, 1, 1))
	When result ← lighting(m, light, position, eyeVector, normalVector)
	Then result = Color(0.1, 0.1, 0.1)

Scenario: Lighting with the surface in shadow
	Given eyeVector ← Vector(0, 0, -1)
	And normalVector ← Vector(0, 0, -1)
	And light ← PointLight(Point(0, 0, -10), Color(1, 1, 1))
	And inShadow ← true
	When result ← lighting(m, light, position, eyeVector, normalVector, inShadow)
	Then result = Color(0.1, 0.1, 0.1)