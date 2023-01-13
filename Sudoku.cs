using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject2
{
    internal class Sudoku
    {
        public int[,] mat;
        public int height;
        public int width;
        public int max;

        //constructor of the Sudoku class
        public Sudoku(int height, int width, string fill)
        {
            this.height = height;
            this.width = width;
            int index = 0;
            this.max = height * width;

            //creating a matrix that has 
            mat = new int[max, max];

            //filling the matrix with what the input was
            for (int i = 0; i < (height * width); i++)
            {
                for (int j = 0; j < (height * width); j++)
                {
                    mat[i, j] = (int)(fill[index] - '0');
                    index++;
                }
            }
        }

        //the function is printing the Sudoku
        public void printSudoku()
        {
            Console.Write("\n");
            //amount of '-' that getting into one row 
            for (int i = 0; i < (width * 3 + 2) * height; i++)
            {
                Console.Write("-");
            }
            for (int i = 0; i < max; i++)
            {
                Console.Write("\n");
                Console.Write("|");
                for (int j = 0; j < max; j++)
                {
                    if (mat[i, j] < 10)
                    {
                        Console.Write(" " + (mat[i, j]) + " ");
                    }
                    else
                    {
                        Console.Write(" " + (mat[i, j]));
                    }
                    if ((j % width) == (width - 1))
                    {
                        Console.Write(" |");
                    }
                }
                Console.Write("\n");
                if ((i % height) == (height - 1))
                {
                    for (int k = 0; k < (width * 3 + 2) * height; k++)
                    {
                        Console.Write("-");
                    }
                }
            }
            Console.Write("\n");
        }

        //convert the sudoku result to string
        public string convertSudokuToString()
        {
            string output = "";

            for (int i = 0; i < (height * width); i++)
            {
                for (int j = 0; j < (height * width); j++)
                {
                    char ch = (char)mat[i, j];
                    ch += '0';
                    output += ch;
                }
            }
            return output;
        }

        //checking if the sudoku can be solved- if yes, return true, else, false
        public bool solve(int row, int col)
        {
            int heightWidth = (height * width);

            //cheking if we got to the end of the sudoku, if yes, return true
            if (row == heightWidth - 1 && col == heightWidth)
            {
                return true;
            }

            //if we got to the end of the colmun, we are going to the next row
            if (col == heightWidth)
            {
                row++;
                col = 0;
            }

            //if the cell is no 0- go to the next cell
            if (mat[row, col] != 0)
            {
                return solve(row, col + 1);
            }

            //going through all the options and checking their validation
            for (int option = 1; option <= heightWidth; option++)
            {
                if (validation(row, col, option))
                {
                    mat[row, col] = option;

                    //if it can solve the sudoku, return true
                    if (solve(row, col + 1))
                    {
                        return true;
                    }
                }
                mat[row, col] = 0;
            }
            return false;
        }

        //checking the validation of a specific integer in a specific cell in the sudoku
        public bool validation(int row, int col, int num)
        {
            for (int i = 0; i < max; i++)
            {
                //checking in the row, if there are cells like num, if yes, return false
                if (mat[row, i] == num)
                {
                    return false;
                }
            }
            for (int i = 0; i < max; i++)
            {
                //checking in the colmun, if there are cells like num, if yes, return false
                if (mat[i, col] == num)
                {
                    return false;
                }
            }

            //checking in an one square of the sudoku, if there are cells like num, if yes, return false
            int startRow = row - row % height;
            int startCol = col - col % width;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (mat[(i + startRow), (j + startCol)] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        }
    }
}
