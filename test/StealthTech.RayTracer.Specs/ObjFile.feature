Feature: ObjFile

Scenario: Ignoring unrecognized lines
	Given objReader ← objReader()
	And file ← a file containing:
		"""
		There was a young lady named Bright
		who traveled much faster than light.
		She set out one day
		in a relative way,
		and came back the previous night.
		"""
	When objFile ← objReader.Parse(file)
	Then objFile.IgnoredLineCount should equal 5 lines

Scenario: Vertex records
	Given objReader ← objReader()
	And file ← a file containing:
		"""
		v -1 1 0
		v -1.0000 0.5000 0.0000
		v 1 0 0
		v 1 1 0
		"""
	When objFile ← objReader.Parse(file)
	Then objFile.Mesh.Vertices[1] = Point(-1, 1, 0)
	And objFile.Mesh.Vertices[2] = Point(-1, 0.5, 0)
	And objFile.Mesh.Vertices[3] = Point(1, 0, 0)
	And objFile.Mesh.Vertices[4] = Point(1, 1, 0)

Scenario: Parsing triangle faces
	Given objReader ← objReader()
	And file ← a file containing:
		"""
		v -1 1 0
		v -1 0 0
		v 1 0 0
		v 1 1 0

		f 1 2 3
		f 1 3 4
		"""
	When objFile ← objReader.Parse(file)
	And triangle1 ← first child of objFile.Triangles
	And triangle2 ← second child of objFile.Triangles
	Then triangle1.Point1 = objFile.Mesh.Vertices[1]
	And triangle1.Point2 = objFile.Mesh.Vertices[2]
	And triangle1.Point3 = objFile.Mesh.Vertices[3]
	And triangle2.Point1 = objFile.Mesh.Vertices[1]
	And triangle2.Point2 = objFile.Mesh.Vertices[3]
	And triangle2.Point3 = objFile.Mesh.Vertices[4]

Scenario: Triangulating polygons
	Given objReader ← objReader()
	And file ← a file containing:
		"""
		v -1 1 0
		v -1 0 0
		v 1 0 0
		v 1 1 0
		v 0 2 0

		f 1 2 3 4 5
		"""
	When objFile ← objReader.Parse(file)
	And triangle1 ← first child of objFile.Triangles
	And triangle2 ← second child of objFile.Triangles
	And triangle3 ← third child of objFile.Triangles
	Then triangle1.Point1 = objFile.Mesh.Vertices[1]
	And triangle1.Point2 = objFile.Mesh.Vertices[2]
	And triangle1.Point3 = objFile.Mesh.Vertices[3]
	And triangle2.Point1 = objFile.Mesh.Vertices[1]
	And triangle2.Point2 = objFile.Mesh.Vertices[3]
	And triangle2.Point3 = objFile.Mesh.Vertices[4]
	And triangle3.Point1 = objFile.Mesh.Vertices[1]
	And triangle3.Point2 = objFile.Mesh.Vertices[4]
	And triangle3.Point3 = objFile.Mesh.Vertices[5]

Scenario: Triangles in groups
	Given objReader ← objReader()
	And fileName ← "triangles.obj"
	When objFile ← objReader.ParseFile(file)
	And group1 ← "FirstGroup" from parser
	And group2 ← "SecondGroup" from parser
	And triangle1 ← first child of group1
	And triangle2 ← first child of group2
	Then triangle1.Point1 = objFile.Mesh.Vertices[1]
	And triangle1.Point2 = objFile.Mesh.Vertices[2]
	And triangle1.Point3 = objFile.Mesh.Vertices[3]
	And triangle2.Point1 = objFile.Mesh.Vertices[1]
	And triangle2.Point2 = objFile.Mesh.Vertices[3]
	And triangle2.Point3 = objFile.Mesh.Vertices[4]

Scenario: Vertex normal records
	Given objReader ← objReader()
	Given file ← a file containing:
		"""
		vn 0 0 1
		vn 0.707 0 -0.707
		vn 1 2 3
		"""
	When objFile ← objReader.Parse(file)
	Then objFile.Mesh.Normals[1] = Vector(0, 0, 1)
	And objFile.Mesh.Normals[2] = Vector(0.707, 0, -0.707)
	And objFile.Mesh.Normals[3] = Vector(1, 2, 3)