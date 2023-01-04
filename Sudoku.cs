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
        protected char[,] mat;
        protected int height;
        protected int width;
        protected char max;

        //constructor of the Sudoku class
        public Sudoku(int height, int width, string fill)
        {
            this.height = height;
            this.width = width;
            max = (char)(height * width);
            max += '0';
            int index = 0;

            //creating a matrix that has 
            mat = new char[height * width, height * width];

            //filling the matrix with what the input was
            for (int i = 0; i < (height * width); i++)
            {
                for (int j = 0; j < (height * width); j++)
                {
                    mat[i, j] = fill[index];
                    index++;
                }
            }
        }

        //the function is printing the Sudoku
        public void printSudoku()
        {
            Console.Write("\n");
            for (int i = 0; i < this.height * this.width; i++)
            {
                Console.Write("----");
            }
            for (int i = 0; i < this.height * this.width; i++)
            {
                Console.Write("\n");
                Console.Write("|");
                for (int j = 0; j < this.height * this.width; j++)
                {
                    if (mat[i, j] > '9')
                    {
                        int ch = (int)(mat[i, j] - '0');
                        Console.Write(" " + ch + " |");
                    }
                    else
                    {
                        Console.Write(" " + mat[i, j] + " |");
                    }
                }

                Console.Write("\n");
                if((i % width) == 1)
                {
                    for (int k = 0; k < this.height * this.width; k++)
                    {
                        Console.Write("----");
                    }
                }
            }
        }

        //the function gets the height and the width of a square in the sudoku
        //the function scan the exact number of digits the sudoku should get, unless it gets
        //an invalid char- every char thats not between '0' and the
        //max char (height * width). if so, it throws InvalidExpressionException, else, return the input
        public static string getTheInputFromConsole(int height, int width)
        {
            string input = "";

            //convert from int to char what is the biggest number that the sudoku can get
            char max = (char)(height * width);
            max += '0';
            do
            {
                char c = Console.ReadKey().KeyChar;
                if (c < '0' || c > max)
                {
                    throw new InvalidExpressionException("the char is not valid");
                }

                //insert the char into the string
                input += c;

            } //doing the while the number of cells in the Sudoku, unless it raises the InvalidExpressionException
            while (input.Length < ((height * width) * (height * width)));

            //if the last char is not enter, it throws InvalidExpressionException
            if (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                throw new InvalidExpressionException("the string is longer than what it supposed to be");
            }

            return input;
        }

        //the function gets the height and the width of a square in the sudoku
        //the function gets the input of the sudoku from a file
        //it checks if the file is exists, and if so read the chars inside
        //it also checks if the the amount of chars it got is bigger, smaller or what it expected
        //then, it checks the validation of the chars
        //if is invalid, it throws InvalidExpressionException, else, return the input
        public static string getTheInputFromFile(int height, int width)
        {
            string input = "";
            //string txt = @"C:\\Users\\yuval\\source\\repos\\FinalProject2\\SudokuSolver\\TextFile.txt";
            string txt = @"C:\\Users\\yuval\\source\\repos\\SudokuSolverr\\TextFile.txt";
            int sizeSudoku = (height * width) * (height * width);
            char[] arr = new char[sizeSudoku];

            //convert from int to char what is the biggest number that the sudoku can get
            char max = (char)(height * width);
            max += '0';
            if (File.Exists(txt))
            {
                using (StreamReader file = new StreamReader(txt))
                {
                    int count = file.ReadBlock(arr, 0, sizeSudoku);
                    //if the amount of the chars is bigger, throws EndOfStreamException
                    if (file.EndOfStream == false)
                    {
                        throw new EndOfStreamException("The number of chars that have been scanned is bigger");
                    }
                    //if the amount of the chars is smaller, throws EndOfStreamException
                    if (count != sizeSudoku)
                    {
                        throw new EndOfStreamException("The number of chars that have been scanned is smaller");
                    }
                    input = new string(arr);
                }
            }
            //if it didn't fount the file, throws FileNotFoundException
            else
            {
                throw new FileNotFoundException("There is no file with the name 'TextFile.txt'");
            }
            //check validation of the input
            for (int i = 0; i < sizeSudoku; i++)
            {
                if (input[i] < '0' || input[i] > max)
                {
                    throw new InvalidExpressionException("the char is not valid");
                }
            }
            return input;
        }

        //convert the sudoku result to string
        public string convertSudokuToString()
        {
            string output = "";

            for (int i = 0; i < (height * width); i++)
            {
                for (int j = 0; j < (height * width); j++)
                {
                    output += mat[i, j];
                }
            }
            return output;
        }

        //checking if the sudoku can be solved- if yes, return true, else, false
        public bool solve()
        {
            int heightWidth = (height * width);
            char max = (char)heightWidth;
            max += '0';
            for (int i = 0; i < heightWidth; i++)
            {
                for (int j = 0; j < heightWidth; j++)
                {
                    //checking if the char in the matrix is 0- if yes, tring to solve the missing cell, else, skip
                    if (mat[i, j] == '0')
                    {
                        //going through all the options and checking their validation
                        for (char c = '1'; c <= max; c++)
                        {
                            if (validation(i, j, c))
                            {
                                mat[i, j] = c;

                                //if it can solve the sudoku it, return false
                                if (solve())
                                {
                                    return true;
                                }
                                else
                                    mat[i, j] = '0';
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        //checking the validation of a specific char in a specific place in the sudoku
        public bool validation(int row, int col, char c)
        {
            int maxInt = (int)(max - '0');
            for (int i = 0; i < maxInt; i++)
            {
                //checking in the row if there are no chars like c and if it is not 0
                if (mat[i, col] != '0' && mat[i, col] == c)
                {
                    return false;
                }
                //checking in the colmun if there are no chars like c and if it is not 0
                if (mat[row, i] != '0' && mat[row, i] == c)
                {
                    return false;
                }
            }

            //checking a one square of the sudoku
            int startRow = row - row % height;
            int startCol = col - col % width;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (mat[(i + startRow), (j + startCol)] == c)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
