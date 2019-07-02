Feature: Canvas

Scenario: Creating a canvas
	Given canvas ← Canvas(10, 20)
	Then canvas.Width = 10
	And canvas.Height = 20
	And every pixel of canvas is Color(0, 0, 0)

Scenario: Writing pixels to a canvas
	Given canvas ← Canvas(10, 20)
	And red ← Color(1, 0, 0)
	When canvas[2,3] ← red
	Then canvas[2, 3] = red

Scenario: Constructing the PPM header
	Given canvas ← Canvas(5, 3)
	When ppm ← canvas.PPMContent()
	Then lines 1-3 of ppm are
		"""
		P3
		5 3
		255
		"""

Scenario: Constructing the PPm pixel data
	Given canvas ← Canvas(5, 3)
	And color1 ← Color(1,5, 0, 0)
	And color2 ← Color(0, 0.5, 0)
	And color3 ← Color(-0.5, 0, 1)
	When canvas[0, 0] ← color1
	And canvas[2, 1] ← color2
	And canvas[4, 2] ← color3
	And ppm ← canvas.PPMContent()
	Then lines 4-6 of ppm are
		"""
		255 0 0 0 0 0 0 0 0 0 0 0 0 0 0
		0 0 0 0 0 0 0 128 0 0 0 0 0 0 0
		0 0 0 0 0 0 0 0 0 0 0 0 0 0 255
		"""

Scenario: Splitting long lines in PPM files
	Given canvas ← Canvas(10, 2)
	When every pixel of canvas is set to Color(1, 0.8, 0.6)
	And ppm ← canvas.PPMContent()
	Then lines 4-7 of ppm are
		"""
		255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
		153 255 204 153 255 204 153 255 204 153 255 204 153
		255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204
		153 255 204 153 255 204 153 255 204 153 255 204 153
		"""

Scenario: PPM files are terminated by a newline character
	Given canvas ← Canvas(5, 3)
	When ppm ← canvas.PPMContent()
	Then ppm ends with a newline character