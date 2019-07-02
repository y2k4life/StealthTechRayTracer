Feature: Camera

Scenario: Constructing a camera
	Given horizontalSize ← 160
	And verticalSize ← 120
	And fieldOfView ← π/2
	When camera ← Camera(horizontalSize, verticalSize, fieldOfView)
	Then camera.HorizontalSize = 160
	And camera.VerticalSize = 120
	And camera.FieldOfView = π/2
	And camera.Transform = identityMatrix

Scenario: The pixel size for a horizontal canvas
	Given camera ← Camera(200, 125, π/2)
	Then camera.PixelSize = 0.01

Scenario: The pixel size for a vertical canvas
	Given camera ← Camera(125, 200, π/2)
	Then camera.PixelSize = 0.01

Scenario: Constructing a ray through the center of the canvas
	Given camera ← Camera(201, 101, π/2)
	When ray ← camera.RayForPixel(100, 50)
	Then ray.Origin = Point(0, 0, 0)
	And ray.Direction = Vector(0, 0, -1)

Scenario: Constructing a ray through a corner of the canvas
	Given camera ← Camera(201, 101, π/2)
	When ray ← camera.RayForPixel(0, 0)
	Then ray.Origin = Point(0, 0, 0)
	And ray.Direction = Vector(0.66519, 0.33259, -0.66851)

Scenario: Constructing a ray when the camera is transformed
	Given camera ← Camera(201, 101, π/2)
	When camera.Transform ← translation(0, -2, 5).rotation_y(π/4)
	And ray ← camera.RayForPixel(100, 50)
	Then ray.Origin = Point(0, 2, -5)
	And ray.Direction = Vector(0.707106, 0, -0.707106)

Scenario: Rendering a world with a camera
	Given world ← default_world()
	And camera ← Camera(11, 11, π/2)
	And from ← Point(0, 0, -5)
	And to ← Point(0, 0, 0)
	And up ← Vector(0, 1, 0)
	And camera.Transform ← ViewTransform(from, to, up)
	When image ← render(c, w)
	Then pixel_at(image, 5, 5) = Color(0.38066, 0.47583, 0.2855)