Feature: Matrices

Scenario: A 2x2 matrix ought to be representable
	Given the following 2x2 matrix M:
		| col1 | col2 |
		| -3   | 5    |
		| 1    | -2   |
	Then M[0,0] = -3
	And M[0,1] = 5
	And M[1,0] = 1
	And M[1,1] = -2

Scenario: A 3x3 matrix ought to be representable
	Given the following 3x3 matrix M:
		| col1 | col2 | col3 |
		| -3   | 5    | 0    |
		| 1    | -2   | -7   |
		| 0    | 1    | 1    |
	Then M[1,1] = -2
	And M[2,2] = 1

Scenario: Matrix equality with identical matrices
	Given the following matrix A:
		| col1 | col2 | col3 | col4 |
		| 1    | 2    | 3    | 4    |
		| 5    | 6    | 7    | 8    |
		| 9    | 8    | 7    | 6    |
		| 5    | 4    | 3    | 2    |
	And the following matrix B:
		| col1 | col2 | col3 | col4 |
		| 1    | 2    | 3    | 4    |
		| 5    | 6    | 7    | 8    |
		| 9    | 8    | 7    | 6    |
		| 5    | 4    | 3    | 2    |
	Then A = B

Scenario: Matrix equality with different matrices
	Given the following matrix A:
		| col1 | col2 | col3 | col4 |
		| 1    | 2    | 3    | 4    |
		| 5    | 6    | 7    | 8    |
		| 9    | 8    | 7    | 6    |
		| 5    | 4    | 3    | 2    |
	And the following matrix B:
		| col1 | col2 | col3 | col4 |
		| 1    | 2    | 3    | 4    |
		| 5    | 6    | 7    | 8    |
		| 9    | 8    | 7    | 6    |
		| 5    | 4    | 4    | 2    |
	Then A != B

Scenario: Multiplying two small matrices
	Given the following matrix A:
		| col1 | col2 |
		| 1    | 2    |
		| 3    | 4    |
	And the following matrix B:
		| col1 | col2 |
		| 2    | 0    |
		| 1    | 2    |
	Then A * B is the following matrix:
		| col1 | col2 |
		| 4    | 4    |
		| 10   | 8    |

Scenario: Multiplying two matrices
	Given the following matrix A:
		| col1 | col2 | col3 | col4 |
		| 1    | 2    | 3    | 4    |
		| 5    | 6    | 7    | 8    |
		| 9    | 8    | 7    | 6    |
		| 5    | 4    | 3    | 2    |
	And the following matrix B:
		| col1 | col2 | col3 | col4 |
		| -2   | 1    | 2    | 3    |
		| 3    | 2    | 1    | -1   |
		| 4    | 3    | 6    | 5    |
		| 1    | 2    | 7    | 8    |
	Then A * B is the following matrix:
		| col1 | col2 | col3 | col4 |
		| 20   | 22   | 50   | 48   |
		| 44   | 54   | 114  | 108  |
		| 40   | 58   | 110  | 102  |
		| 16   | 26   | 46   | 42   |

Scenario: A matrix multiplied by a tuple
	Given the following matrix A:
		| col1 | col2 | col3 | col4 |
		| 1    | 2    | 3    | 4    |
		| 2    | 4    | 4    | 2    |
		| 8    | 6    | 4    | 1    |
		| 0    | 0    | 0    | 1    |
	And b <- tuple(1, 2, 3, 1)
	Then A * b = tuple(18, 24, 33, 1)
	And b * A = tuple(18, 24, 33, 1)

Scenario: Multiplying two matrices find E23
	Given the following matrix A:
		| col1 | col2 | col3 |
		| 1    | 0    | 0    |
		| -3   | 1    | 0    |
		| 0    | 0    | 1    |
	And the following matrix B:
		| col1 | col2 | col3 |
		| 1    | 2    | 1    |
		| 3    | 8    | 1    |
		| 0    | 4    | 1    |
	Then A * B is the following matrix:
		| col1 | col2 | col3 |
		| 1    | 2    | 1    |
		| 0    | 2    | -2   |
		| 0    | 4    | 1    |

Scenario: Multiplying two matrices find E32
	Given the following matrix A:
		| c1 | c2 | c3 |
		| 1  | 0  | 0  |
		| 0  | 1  | 0  |
		| 0  | -2 | 1  |
	And the following matrix B:
		| c1 | c2 | c3 |
		| 1  | 2  | 1  |
		| 0  | 2  | -2 |
		| 0  | 4  | 1  |
	Then A * B is the following matrix:
		| c1 | c2 | c3 |
		| 1  | 2  | 1  |
		| 0  | 2  | -2 |
		| 0  | 0  | 5  |

Scenario: Multiplying column by row
	Given the following matrix A:
		| c1 |
		| 2  |
		| 3  |
		| 4  |
	And the following matrix B:
		| c1 | c2 |
		| 1  | 6  |
	Then A * B is the following matrix:
		| c1 | c2 |
		| 2  | 12 |
		| 3  | 18 |
		| 4  | 24 |

Scenario: Multiplying irregular shape
	Given the following matrix A:
		| c1 | c2 |
		| 2  | 7  |
		| 3  | 8  |
		| 4  | 9  |
	And the following matrix B:
		| c1 | c2 |
		| 1  | 6  |
		| 0  | 0  |
	Then A * B is the following matrix:
		| c1 | c2 |
		| 2  | 12 |
		| 3  | 18 |
		| 4  | 24 |