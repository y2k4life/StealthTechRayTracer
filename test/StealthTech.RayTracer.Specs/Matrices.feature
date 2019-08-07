Feature: Matrices

Scenario: Matrix equality with identical matrices
	Given the following matrix A:
		| 1 | 2 | 3 | 4 |
		| 5 | 6 | 7 | 8 |
		| 9 | 8 | 7 | 6 |
		| 5 | 4 | 3 | 2 |
	And the following matrix B:
		| 1 | 2 | 3 | 4 |
		| 5 | 6 | 7 | 8 |
		| 9 | 8 | 7 | 6 |
		| 5 | 4 | 3 | 2 |
	Then A = B

Scenario: Matrix equality with different matrices
	Given the following matrix A:
		| 1 | 2 | 3 | 4 |
		| 5 | 6 | 7 | 8 |
		| 9 | 8 | 7 | 6 |
		| 5 | 4 | 3 | 2 |
	And the following matrix B:
		| 1 | 2 | 3 | 4 |
		| 5 | 6 | 7 | 8 |
		| 9 | 8 | 7 | 6 |
		| 5 | 4 | 4 | 2 |
	Then A != B

Scenario: Multiplying two matrices
	Given the following matrix A:
		| 1 | 2 | 3 | 4 |
		| 5 | 6 | 7 | 8 |
		| 9 | 8 | 7 | 6 |
		| 5 | 4 | 3 | 2 |
	And the following matrix B:
		| -2 | 1 | 2 | 3  |
		| 3  | 2 | 1 | -1 |
		| 4  | 3 | 6 | 5  |
		| 1  | 2 | 7 | 8  |
	Then A * B is the following matrix:
		| 20 | 22 | 50  | 48  |
		| 44 | 54 | 114 | 108 |
		| 40 | 58 | 110 | 102 |
		| 16 | 26 | 46  | 42  |

Scenario: A matrix multiplied by a point
	Given the following matrix A:
		| 1 | 2 | 3 | 4 |
		| 2 | 4 | 4 | 2 |
		| 8 | 6 | 4 | 1 |
		| 0 | 0 | 0 | 1 |
	And point ← Point(1, 2, 3)
	Then A * b = Point(18, 24, 33)

Scenario: Multiplying a matrix by the identity matrix
	Given the following matrix A:
		| 0 | 1 | 2  | 4  |
		| 1 | 2 | 4  | 8  |
		| 2 | 4 | 8  | 16 |
		| 4 | 8 | 16 | 32 |
	Then A * identity_matrix = A

Scenario: Multiplying the identity matrix by a point
	Given point ← Point(1, 2, 3)
	And the following matrix A:
		| 1 | 0 | 0 | 0 |
		| 0 | 1 | 0 | 0 |
		| 0 | 0 | 1 | 0 |
		| 0 | 0 | 0 | 1 |
	Then identity_matrix * point = point

Scenario: Transposing a matrix
	Given the following matrix A:
		| 0 | 9 | 3 | 0 |
		| 9 | 8 | 0 | 8 |
		| 1 | 8 | 5 | 3 |
		| 0 | 0 | 5 | 8 |
	Then transpose(A) is the following matrix:
		| 0 | 9 | 1 | 0 |
		| 9 | 8 | 8 | 0 |
		| 3 | 0 | 5 | 5 |
		| 0 | 8 | 3 | 8 |

Scenario: Transposing the identity matrix
	Given the following matrix A:
		| 1 | 0 | 0 | 0 |
		| 0 | 1 | 0 | 0 |
		| 0 | 0 | 1 | 0 |
		| 0 | 0 | 0 | 1 |
	Then transpose(A) is the following matrix:
		| 1 | 0 | 0 | 0 |
		| 0 | 1 | 0 | 0 |
		| 0 | 0 | 1 | 0 |
		| 0 | 0 | 0 | 1 |

Scenario: Testing an invertible matrix for invertibility
	Given the following matrix A:
		| 6 | 4  | 4 | 4  |
		| 5 | 5  | 7 | 6  |
		| 4 | -9 | 3 | -7 |
		| 9 | 1  | 7 | -6 |
	Then determinant(A) = -2120
	And A is invertible

Scenario: Testing a noninvertible matrix for invertibility
	Given the following matrix A:
		| -4 | 2  | -2 | -3 |
		| 9  | 6  | 2  | 6  |
		| 0  | -5 | 1  | -5 |
		| 0  | 0  | 0  | 0  |
	Then determinant(A) = 0
	And A is not invertible

Scenario: Calculating the inverse of another matrix
	Given the following matrix A:
		| 8  | -5 | 9  | 2  |
		| 7  | 5  | 6  | 1  |
		| -6 | 0  | 9  | 6  |
		| -3 | 0  | -9 | -4 |
	Then inverse(A) is approximately equal to matrix:
		| -0.15385 | -0.15385 | -0.28205 | -0.53846 |
		| -0.07692 | 0.12308  | 0.02564  | 0.03077  |
		| 0.35897  | 0.35897  | 0.43590  | 0.92308  |
		| -0.69231 | -0.69231 | -0.76923 | -1.92308 |

Scenario: Calculating the inverse of a third matrix
	Given the following matrix A:
		| 9  | 3  | 0  | 9  |
		| -5 | -2 | -6 | -3 |
		| -4 | 9  | 6  | 4  |
		| -7 | 6  | 6  | 2  |
	Then inverse(A) is approximately equal to matrix:
		| -0.04074 | -0.07778 | 0.14444  | -0.22222 |
		| -0.07778 | 0.03333  | 0.36667  | -0.33333 |
		| -0.02901 | -0.14630 | -0.10926 | 0.12963  |
		| 0.17778  | 0.06667  | -0.26667 | 0.33333  |

Scenario: Multiplying a product by its inverse
	Given the following matrix A:
		| 3  | -9 | 7  | 3  |
		| 3  | -8 | 2  | -9 |
		| -4 | 4  | 4  | 1  |
		| -6 | 5  | -1 | 1  |
	And the following matrix B:
		| 8 | 2  | 2 | 2 |
		| 3 | -1 | 7 | 0 |
		| 7 | 0  | 5 | 4 |
		| 6 | -2 | 0 | 5 |
	And C ← A * B
	Then C * inverse(B) approximately equal to A
