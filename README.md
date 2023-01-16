# Sudoku Solver by Yuval Tzeamach
My project contains a C sharp sudoku solver, that written in (.NET 6.0).

This project is based on the algorithm of Algorithm X, invented by Donald Knuth, and the 
implementation technique I used, called Dancing Links, also known as DLX, 
using doubly-linked circular lists to represent the matrix of the problem.

## The Algorithm:
This algorithm is proven to be one of the best sudoku solver techniques, esspacially on bigger 
matrixes than 9x9 sudokus.

Algorithm X is a recursive and backtracking algorithm that finds all solutions 
to the exact cover problem.

The exact cover problem is represented in this algorithm by a matrix of zeros and ones.

### See an example:

![image](https://user-images.githubusercontent.com/117098093/212727355-173c2f7c-1231-4b8f-9fa7-1d508143d73d.png)

As the user can see, every zero represents an invalid value for the location and constraint 
they represent, and every one represents a valid and possible value.

In the next step, the algorithm represents the matrix of the sudoku, by using doubly-linked 
circular lists, and each node in the lists contains the following fiedls:
- Pointer to node above it
- Pointer to node below it
- Pointer to node left to it
- Pointer to node right to it
- Pointer to list column node to which it belongs

Each row of the matrix is a circular linked list, linked to each other with left
and right pointers, and each column of the matrix will also be circular linked list linked to 
each above with up and down pointer. Each column list includes a special node called “ColumnNode”. 
This node is just like simple node but have few extra fields:
- Number of nodes
- Value

### See an example:

![image](https://user-images.githubusercontent.com/117098093/212703954-09041585-577b-45fe-abb3-c40cf573f168.png)


In the next and the final step, the algorithm will solve the sudoku in the way of the exact cover 
problem, which means, the algorithm will remove and restore, until it finds the right combination-
the solution of the sudoku. 


## How To Use The Program
When the user runs this project, it will need to answer a couple of questions, before he inputs
the string he would like to run.

### See an example:
![image](https://user-images.githubusercontent.com/117098093/212714501-1b605db9-6b63-46ab-bd0b-18a79d0620d8.png)

**Note:**
it required from the user to insert both height and width of one box of the sudoku,
beacuse the program can also solve sudokus that their boxes are rectangles, and not only squares.

**For example:**

1. In this example, the height is equal to 2, and the width is equal to 3.

![image](https://user-images.githubusercontent.com/117098093/212716896-daef0f17-5ac7-4c36-ae4f-7587e15cb9a8.png)

2. In this example, both of the height and the width are equal to 3.

![image](https://user-images.githubusercontent.com/117098093/212717752-fc6049a3-fead-416b-9ae8-4e44a0388dbd.png)
